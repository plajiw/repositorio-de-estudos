### **Gerenciamento de Conexões de Banco de Dados em Serviços de Fundo .NET**

------

### Resumo

Serviços de fundo (Background Services) são um componente essencial em aplicações modernas, responsáveis por executar tarefas de longa duração. No entanto, sua natureza de longa vida (`Singleton`) cria um desafio arquitetural comum ao interagir com serviços de banco de dados, que geralmente têm um tempo de vida curto (`Scoped`). Este artigo explora os conceitos de tempo de vida de serviço no .NET, a forma correta de gerenciar conexões com bancos de dados como o RavenDB, e apresenta o padrão arquitetural definitivo usando `IServiceScopeFactory` para resolver o conflito de dependências de forma segura e escalável.



### 1. Introdução: O Desafio dos Serviços de Fundo



No ecossistema .NET, a classe `BackgroundService` é a ferramenta padrão para criar serviços que rodam em segundo plano, como processamento de filas, tarefas agendadas (jobs) ou monitoramento contínuo. Por design, um `BackgroundService` é registrado no contêiner de injeção de dependência como um **Singleton**: uma única instância é criada quando a aplicação inicia e persiste até que ela seja encerrada. O desafio surge quando este serviço Singleton precisa executar uma operação que envolve um banco de dados, cujas conexões são, por boas práticas, gerenciadas em escopos de curta duração.



### 2. Conceitos Fundamentais: Tempos de Vida de Serviço no .NET



Para entender a solução, primeiro precisamos dominar os três tempos de vida de serviço (lifetimes) no sistema de injeção de dependência do .NET:

- **Singleton:** Uma única instância do serviço é criada e compartilhada por toda a aplicação durante todo o seu ciclo de vida. Ideal para serviços sem estado, configurações ou objetos pesados que são caros para criar, como o `IDocumentStore` do RavenDB.
- **Scoped:** Uma nova instância é criada para cada "escopo". Em uma aplicação web, um escopo é tipicamente uma requisição HTTP. Fora desse contexto, um escopo precisa ser criado manualmente. É o tempo de vida ideal para serviços que representam uma unidade de trabalho, como um `DbContext` do Entity Framework ou uma `IAsyncDocumentSession` do RavenDB.
- **Transient:** Uma nova instância é criada toda vez que o serviço é solicitado. Ideal para serviços leves e sem estado.

**A Regra de Ouro:** Um serviço com tempo de vida longo **não pode** depender diretamente de um serviço com tempo de vida mais curto. Tentar injetar um serviço `Scoped` no construtor de um `Singleton` resultará em uma exceção (`InvalidOperationException`) na inicialização da aplicação. O .NET faz isso para prevenir um erro grave chamado "dependência cativa" (captive dependency), onde o serviço `Scoped` ficaria "preso" no `Singleton` para sempre, nunca sendo descartado e causando vazamentos de recursos.



### 3. O Padrão de Conexão com RavenDB



A arquitetura do RavenDB exemplifica perfeitamente essa separação de responsabilidades:

- **`IDocumentStore` (O Singleton):** É o "portal" para o seu banco de dados. Um objeto pesado, thread-safe, que gerencia o pool de conexões e o cache. Sua inicialização (`store.Initialize()`) é uma operação custosa que deve ocorrer **apenas uma vez** no início da aplicação.
- **`IAsyncDocumentSession` (O Scoped):** É a "unidade de trabalho". Um objeto leve, de curta duração, usado para realizar um conjunto de operações (consultas, salvamentos). **Não é thread-safe** e uma nova sessão deve ser aberta para cada transação de negócio.



### 4. A Solução Arquitetural: `IServiceScopeFactory`



Se um `Singleton` não pode receber um `Scoped` diretamente, como ele pode usar os serviços de que precisa? A resposta é a `IServiceScopeFactory`.

A `IServiceScopeFactory` é um serviço Singleton que funciona como uma "fábrica de escopos". Um `BackgroundService` pode injetá-la com segurança e, dentro de seu loop de execução, usá-la para criar um escopo temporário. Dentro desse escopo, ele pode resolver com segurança qualquer serviço `Scoped` de que precise.



#### 5. Exemplo Prático: Um Serviço de Relatório Diário



Vamos criar um exemplo diferente: um `BackgroundService` que roda uma vez por dia, busca todos os usuários "premium" e envia um email de relatório para cada um.

**Passo A: Registrar os Serviços (`Program.cs`)**

C#

```
// 1. Registrar o IDocumentStore do RavenDB como Singleton
builder.Services.AddSingleton<IDocumentStore>(provider =>
{
    var store = new DocumentStore { Urls = new[] { "URL_DO_SEU_BANCO" }, Database = "NOME_DO_BANCO" };
    store.Initialize();
    return store;
});

// 2. Registrar serviços de negócio como Scoped
//    IServicoSessaoRaven é um wrapper que gerencia a sessão
builder.Services.AddScoped<IServicoSessaoRaven, ServicoSessaoRaven>(); 
builder.Services.AddScoped<RepositorioDeUsuarios>();
builder.Services.AddScoped<ServicoDeEmail>();

// 3. Registrar o nosso BackgroundService
builder.Services.AddHostedService<RelatorioDiarioWorker>();
```

**Passo B: Implementar o `BackgroundService`**

C#

```
public class RelatorioDiarioWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public RelatorioDiarioWorker(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Espera até a próxima execução (ex: a cada 24 horas)
            await Task.Delay(TimeSpan.FromHours(24), stoppingToken);

            // Cria um escopo para esta execução específica
            using (var scope = _scopeFactory.CreateScope())
            {
                // Resolve os serviços Scoped de que precisamos DENTRO do escopo
                var repositorio = scope.ServiceProvider.GetRequiredService<RepositorioDeUsuarios>();
                var servicoEmail = scope.ServiceProvider.GetRequiredService<ServicoDeEmail>();

                // Agora podemos usá-los com segurança
                var usuariosPremium = await repositorio.ObterUsuariosPremiumAsync();
                foreach (var usuario in usuariosPremium)
                {
                    await servicoEmail.EnviarRelatorioAsync(usuario);
                }
            }
        }
    }
}
```



### 6. Generalizando para Outros Bancos de Dados



Este padrão não é exclusivo do RavenDB. Ele é universal para qualquer banco de dados usado com .NET Core/.NET 8:

- **Entity Framework Core:** Seu `DbContext` é tipicamente registrado como `Scoped` (`builder.Services.AddDbContext<MeuDbContext>(...)`). A abordagem com `IServiceScopeFactory` é a mesma para usá-lo em um `BackgroundService`.
- **Dapper:** A conexão (`IDbConnection`) é geralmente registrada como `Transient` ou `Scoped`. O padrão de uso dentro de um escopo criado pela factory permanece idêntico.



### 7. Conclusão



A interação entre serviços `Singleton` e `Scoped` é um pilar da arquitetura de software moderna em .NET. Embora a injeção direta seja proibida, a `IServiceScopeFactory` oferece uma solução elegante e robusta, permitindo que serviços de fundo de longa duração orquestrem unidades de trabalho de curta duração de forma segura, limpa e escalável. Compreender este padrão é essencial para construir aplicações de fundo resilientes e com bom desempenho.



### 8. Referências para Aprofundamento



1. **Injeção de Dependência no .NET (Documentação Oficial da Microsoft):**
   - https://docs.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection
2. **Serviços de Fundo no .NET (Documentação Oficial da Microsoft):**
   - https://docs.microsoft.com/pt-br/dotnet/core/extensions/workers
3. **Gerenciamento de Sessão no RavenDB (Documentação Oficial):**
   - [link suspeito removido]
4. **Livro "Dependency Injection Principles, Practices, and Patterns" por Mark Seemann e Steven van Deursen:** Um guia completo e profundo sobre o tema.