# Estrutura das regras

Dentro da aplicação da Ivi, tudo começa na clase estática MaquinaDeEstados.cs. Onde é degfinido um livro de regras único e comportatilhado por toda a aplicação. Por ser estático ele é criado na memória assim que a aplicação é iniciada, antes de qualquer interação com o usuário.

A propriedade "Maquina" é um dicionário que mapeia todas as possibilidades de fluxo.

#### O que é um Dicionário?

Em c#, um dicionário ou Dictionay é uma coleção que armazena pares de chave-valor, onde cada chave é única e está associada a um valor. Por padrão é uma classe genérica que é implementado por Dictionary<TKey, TValue>. Suas vantagens é a busca eficiente utilizando tabelas hash para localizar as chaves e flexibilidade, pois as chaves e os valores podem ser de qualquer tipo.



Na aplicação o Dicionário Maquina, opera da seguinte forma: Possui como chave o EstadoDeTransicao e como valor Estado

É como um índice de um livro



Para que o dicionário funcione, ele precisa de uma chave única para cada regra. É aqui que entra a classe EstadoDeTransicao.

O único propósito desta classe é servir como a "chave" do nosso dicionário. Ela combina duas informações para criar um contexto único.

```c#
public EstadoDeTransicao(Status currentState, Comando command)
{
    StatusDoFluxo = currentState;
    Comando = command;
}
```

O seu construtor recebe Status currentState e Comando command, onde o status indica o estado atual da conversa e o comman o evento que acabou de acontecer



**Exemplo Prático):**

 `new EstadoDeTransicao(Status.Finalizado, Comando.Iniciar)`.

Isso cria uma chave que significa: "Quando a conversa está no estado `Finalizado` E o comando `Iniciar` acontece...

O valor do dicionário Estado.cs

Depois de encontrar a chave correta no dicionário, precisamos saber o que fazer. Essa resposta é o objeto Estado. Ele representa o destino da transição. Como a classe estado tem duas propriedades principais:

```c#
public Status Status { get; set; }
public Type? Executor { get; set; }
```

onde status define o novo estado da conversa e Executor define qual classe de serviço (arquivo .cs) será responsável por executar a lógica daquele novo estado.



**Exemplo Prático:** O valor para a chave `(Status.Finalizado, Comando.Iniciar)` é `Estado.ObterEstadoDeAutenticacao()`.



Este método, que está na classe `Estado.cs`, simplesmente retorna um novo objeto `Estado` com as instruções:

```c#
return new Estado() 
{ 
    Status = Status.Autenticacao, Executor = typeof(EstadoDeAutenticacao) 
};
```

e assim por diante para **todas as dezenas de regras** que você tem na sua máquina de estados. Após a última regra ser adicionada, o dicionário está completo e carregado na memória. A "fase de montagem" terminou.

A partir deste ponto, a aplicação fica em estado de espera. Ela não faz mais nada até que a primeira notificação de mensagem chegue no `WebhookController`. Só então ela começará a **consultar** o dicionário que acabou de construir para dar início à comunicação real com o usuário.