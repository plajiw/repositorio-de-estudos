# Introdução à Programação Orientada a Objetos (POO)

---

## O que é um Paradigma de Programação?

Um **paradigma de programação** é um modelo conceitual que define a abordagem para estruturar, projetar e implementar soluções computacionais. Ele estabelece os princípios fundamentais que guiam a construção de programas, influenciando como os problemas são decompostos e resolvidos. Conforme Sebesta (2010), um paradigma é “um conjunto de conceitos fundamentais que governam a construção de linguagens e programas”. Cada paradigma oferece uma perspectiva única para modelar sistemas, e os principais incluem:

- **Imperativo**: Baseado em comandos sequenciais que alteram o estado do programa, com foco em "como" realizar uma tarefa (ex.: C, Pascal).
- **Funcional**: Centrado em funções matemáticas puras, com ênfase em imutabilidade e ausência de efeitos colaterais (ex.: Haskell, Scala).
- **Lógico**: Focado em regras lógicas e inferências, onde o programa descreve "o que" deve ser resolvido (ex.: Prolog).
- **Orientado a Objetos (POO)**: Organiza o código em torno de **objetos**, que encapsulam dados (atributos) e comportamentos (métodos), promovendo uma modelagem próxima do mundo real (ex.: C#, Java, Python, C++).

A **Programação Orientada a Objetos (POO)**, foco deste texto, é amplamente adotada devido à sua capacidade de modelar sistemas complexos de forma modular, reutilizável e intuitiva. Ela é suportada por diversas linguagens modernas e é aplicável a domínios variados, desde desenvolvimento web até sistemas embarcados.

---

## O que é Programação Orientada a Objetos (POO)?

A **Programação Orientada a Objetos (POO)** é um paradigma que estrutura o software em torno de **objetos**, entidades que combinam **atributos** (dados que representam o estado) e **métodos** (funções que definem comportamentos). Os objetos são instâncias de **classes**, que funcionam como moldes ou especificações que descrevem as propriedades e funcionalidades de um conjunto de objetos. A POO é fundamentada em quatro pilares principais:

- **Abstração**: Simplifica a modelagem ao focar nos aspectos relevantes de uma entidade, ignorando detalhes desnecessários.
- **Encapsulamento**: Protege os dados internos de um objeto, controlando o acesso por meio de métodos.
- **Herança**: Permite que classes derivem de outras, reutilizando e estendendo funcionalidades.
- **Polimorfismo**: Habilita que objetos de diferentes classes sejam tratados de forma uniforme, com comportamentos específicos.



### Benefícios da POO

A POO oferece vantagens significativas, amplamente reconhecidas em sistemas de software modernos:

- **Modularidade**: Divide o sistema em unidades independentes (classes), facilitando desenvolvimento, teste e manutenção.
- **Reutilização**: Classes podem ser reutilizadas em diferentes contextos ou projetos, reduzindo redundância.
- **Manutenibilidade**: Alterações em uma classe têm impacto localizado, minimizando erros em outras partes do sistema.
- **Escalabilidade**: A POO suporta sistemas complexos, permitindo a adição de novas classes sem afetar as existentes.
- **Modelagem Intuitiva**: Representa entidades do mundo real (ex.: carros, alunos) de forma natural, alinhada à percepção humana.

**Exemplo Contextual**: Em um sistema de gerenciamento de uma biblioteca, a POO permite criar uma classe `Livro` com atributos como `Titulo` e `Autor` e métodos como `Emprestar` ou `Devolver`. Cada livro específico (ex.: "Dom Quixote") é um objeto criado a partir dessa classe.

---

## Conceitos Fundamentais: Classes e Objetos

### O que é uma Classe?

Uma **classe** é uma construção abstrata que define a estrutura e o comportamento de um conjunto de objetos. Ela atua como um **molde** ou **blueprint**, especificando:

- **Atributos** (ou campos): Variáveis que armazenam os dados de um objeto, representando seu estado (ex.: `Modelo`, `Cor` em uma classe `Carro`).
- **Métodos**: Funções que definem as operações ou comportamentos que os objetos podem executar (ex.: `Acelerar`, `ExibirInformacoes`).

Em termos formais, uma classe é uma **abstração de tipo**, que encapsula as propriedades e comportamentos comuns a um grupo de entidades. Ela é análoga a um conceito matemático de conjunto, onde os objetos são os elementos desse conjunto.

**Exemplo em C#**:

```csharp
public class Carro {
    // Atributos (campos)
    public string Modelo;
    public string Cor;
    public int Ano;

    // Método
    public void ExibirInformacoes() {
        Console.WriteLine($"Carro: {Modelo}, Cor: {Cor}, Ano: {Ano}");
    }
}
```

**Analogia**: Uma classe é como um formulário em branco, como uma ficha de cadastro de aluno, que define campos a serem preenchidos (nome, matrícula) e ações associadas (emitir certificado). Cada ficha preenchida é um objeto.



### O que é um Objeto?

Um **objeto** é uma instância concreta de uma classe, criada durante a execução do programa. Ele possui valores específicos para os atributos definidos pela classe e pode invocar os métodos associados. Em termos técnicos, um objeto é uma alocação de memória que materializa o modelo descrito pela classe, com dados próprios e comportamento funcional.

**Exemplo em C#**:

```csharp
Carro meuCarro = new Carro(); // Criação do objeto
meuCarro.Modelo = "Fusca";
meuCarro.Cor = "Vermelho";
meuCarro.Ano = 1970;
meuCarro.ExibirInformacoes(); // Saída: Carro: Fusca, Cor: Vermelho, Ano: 1970
```

**Analogia**: Se a classe `Carro` é a planta de uma casa, o objeto `meuCarro` é uma casa específica construída a partir dessa planta, com características próprias (ex.: paredes vermelhas, dois quartos).



### Diferença entre Classe e Objeto

| **Conceito** | **Definição**                                              | **Exemplo**                         |
| ------------ | ---------------------------------------------------------- | ----------------------------------- |
| **Classe**   | Modelo abstrato que define atributos e métodos.            | Planta de uma casa.                 |
| **Objeto**   | Instância concreta com valores específicos para atributos. | Casa construída com base na planta. |

**Representação Matemática**:

- Classe: Um conjunto abstrato de objetos possíveis:

$$
Classe = \{Obj_1, Obj_2, Obj_3, \dots, Obj_N\}
$$

- Objeto: Um elemento específico do conjunto:

$$
Obj \in Classe
$$



### Unicidade e Identidade dos Objetos

Cada objeto é **único**, mesmo que dois objetos de uma mesma classe tenham valores idênticos para seus atributos. Essa unicidade é chamada de **identidade do objeto** e resulta do fato de que cada objeto é alocado em um endereço de memória distinto no **heap**. Em linguagens como C#, Java e Python, as variáveis associadas a objetos armazenam **referências** (ou ponteiros) para esses endereços, não os dados diretamente.

**Exemplo em C#**:

```csharp
Carro carro1 = new Carro();
carro1.Modelo = "Fusca";
carro1.Cor = "Azul";

Carro carro2 = new Carro();
carro2.Modelo = "Fusca";
carro2.Cor = "Azul";

Console.WriteLine(carro1 == carro2); // False, pois as referências são diferentes
Console.WriteLine(Object.ReferenceEquals(carro1, carro2)); // False, confirma diferentes endereços
```

**Explicação Técnica**:

- O operador `==` em C# compara as referências dos objetos, não seus valores. Para comparar os valores dos atributos, seria necessário implementar um método como `Equals` ou comparar os atributos individualmente.
- Em Java, o comportamento é idêntico com `==` para referências.

**Analogia**: Dois carros idênticos (mesmo modelo e cor) ainda são veículos distintos, com números de chassi diferentes. Da mesma forma, objetos com os mesmos valores de atributos têm identidades únicas na memória.



### Como os Objetos São Armazenados na Memória?

Em linguagens orientadas a objetos como C#, Java e Python, a criação de um objeto com o operador `new` (ou equivalente) aloca espaço no **heap**, uma área de memória dinâmica gerenciada pelo runtime da linguagem. A variável associada ao objeto armazena uma **referência** (um ponteiro) para o endereço no heap onde os dados do objeto estão localizados.

- **Atributos de instância**: Cada objeto possui sua própria cópia dos atributos, armazenada no heap. Por exemplo, `Modelo` e `Cor` de um objeto `Carro` são exclusivos daquele objeto.
- **Atributos de classe (static)**: Declarados com a palavra-chave `static` em C# (ou equivalente em outras linguagens), são compartilhados entre todas as instâncias da classe e armazenados em uma área única da memória.

**Exemplo em C#**:

```csharp
public class Carro {
    public string Modelo; // Atributo de instância
    public static int TotalCarros; // Atributo de classe (compartilhado)
}

Carro carro1 = new Carro();
carro1.Modelo = "Fusca";
Carro.TotalCarros++; // Incrementa o contador compartilhado

Carro carro2 = new Carro();
carro2.Modelo = "Civic";
Carro.TotalCarros++; // Incrementa o mesmo contador

Console.WriteLine(Carro.TotalCarros); // Saída: 2
```

**Diagrama de Memória**:

```
Variável: carro1 ----> [Referência: 0x1234]
Heap: [0x1234] -> Objeto Carro { Modelo: "Fusca" }

Variável: carro2 ----> [Referência: 0x5678]
Heap: [0x5678] -> Objeto Carro { Modelo: "Civic" }

Memória Estática: TotalCarros = 2
```

**Nota Técnica**: Em C#, o **Garbage Collector** gerencia a liberação de memória no heap, enquanto em C++ o programador deve liberar explicitamente objetos alocados com `new` usando `delete`.

---

## Abstração: Modelando o Essencial

### O que é Abstração?

A **abstração** é um dos pilares fundamentais da POO, que consiste em modelar entidades do mundo real (ou conceitos abstratos) focando apenas nos aspectos relevantes para o contexto do sistema, ignorando detalhes irrelevantes. Ela permite simplificar a complexidade, criando representações que capturam o essencial sem sobrecarregar o design com informações desnecessárias.

**Definição Formal**: Abstração é o processo de identificar as características e comportamentos essenciais de uma entidade, definindo-os em uma classe de forma que os detalhes de implementação sejam ocultados do usuário final.

**Exemplo**: Em um sistema de gerenciamento de frota, a classe `Veiculo` pode abstrair um veículo com atributos como `Placa` e `Capacidade` e métodos como `Abastecer`. Detalhes como o tipo de combustível ou o design do motor podem ser omitidos, a menos que sejam necessários.

**Benefícios da Abstração**:

- **Simplificação**: Reduz a complexidade ao focar no que é relevante.
- **Reutilização**: Classes abstratas podem ser usadas em diferentes contextos.
- **Manutenibilidade**: Permite modificar a implementação interna sem afetar os usuários da classe.
- **Clareza**: Facilita a comunicação entre desenvolvedores e stakeholders, pois o modelo reflete o problema de forma intuitiva.



### Abstração na Prática

Na POO, a abstração é implementada por meio de **classes** que definem apenas os atributos e métodos necessários para o sistema. Em linguagens como C#, isso pode ser reforçado com **encapsulamento** (usando modificadores como `private`) e, em alguns casos, com **classes abstratas** ou **interfaces**.

**Exemplo em C#**:

```csharp
public class Aluno {
    private string _nome; // Encapsulamento reforça a abstração
    private int _matricula;

    public Aluno(string nome, int matricula) {
        _nome = nome;
        _matricula = matricula;
    }

    public void ExibirDados() {
        Console.WriteLine($"Aluno: {_nome}, Matrícula: {_matricula}");
    }
}

Aluno aluno = new Aluno("Maria", 12345);
aluno.ExibirDados(); // Saída: Aluno: Maria, Matrícula: 12345
```

**Analogia**: A abstração é como um controle remoto de TV. O usuário interage com botões simples (ex.: ligar, mudar canal), sem precisar entender os circuitos internos da TV. A classe `Aluno` é um "controle remoto" que expõe apenas o necessário (nome, matrícula, exibir dados).



### Conexão com Classes e Objetos

A abstração é o princípio que guia a criação de classes, definindo quais atributos e métodos são relevantes para representar uma entidade. Quando instanciamos objetos a partir de uma classe, concretizamos essa abstração, atribuindo valores específicos aos atributos e utilizando os métodos. A abstração, portanto, é o fundamento para projetar classes que sejam claras, focadas e reutilizáveis, preparando o terreno para a inicialização de objetos com construtores.

---

## Construtores: Inicializando Objetos

### O que é um Construtor?

Um **construtor** é um método especial de uma classe, chamado automaticamente quando um objeto é criado com o operador `new`. Ele tem o mesmo nome da classe e é responsável por inicializar os atributos do objeto, garantindo que ele comece em um estado válido e consistente. Construtores são cruciais para implementar a abstração, pois asseguram que os objetos respeitem o modelo definido pela classe desde o momento de sua criação.

**Características Principais**:

- **Nome**: Igual ao da classe (ex.: `Carro` para a classe `Carro`).
- **Sem tipo de retorno**: Não retorna valores, nem mesmo `void`.
- **Execução**: Invocado automaticamente pelo operador `new`.
- **Modificadores de acesso**: Geralmente `public`, mas pode ser `private`, `protected` ou `internal` (em C#), dependendo do design.
- **Objetivo**: Inicializar atributos, configurar o estado inicial ou executar lógica necessária (ex.: abrir conexões, validar dados).

**Exemplo em C#**:

```csharp
public class Carro {
    public string Modelo;
    public int Ano;
    public bool Ligado;

    // Construtor
    public Carro() {
        Modelo = "Desconhecido";
        Ano = 2023;
        Ligado = false;
    }
}

Carro meuCarro = new Carro();
Console.WriteLine($"Modelo: {meuCarro.Modelo}, Ano: {meuCarro.Ano}, Ligado: {meuCarro.Ligado}");
// Saída: Modelo: Desconhecido, Ano: 2023, Ligado: False
```



### Criando um Construtor

Um construtor é definido como um método dentro da classe, sem especificar um tipo de retorno. Ele pode ser simples (sem parâmetros) ou parametrizado. Aqui, focamos em construtores sem parâmetros, que inicializam atributos com valores padrão.

**Sintaxe em C#**:

```csharp
[modificador] NomeDaClasse() {
    // Código de inicialização
}
```

**Exemplo em C#**:

```csharp
public class Aluno {
    private string _nome;
    private int _matricula;
    private DateTime _dataCadastro;

    public Aluno() {
        _nome = "Sem Nome";
        _matricula = 0;
        _dataCadastro = DateTime.Now; // Inicializa com a data atual
    }

    public void ExibirDados() {
        Console.WriteLine($"Aluno: {_nome}, Matrícula: {_matricula}, Cadastrado em: {_dataCadastro}");
    }
}

Aluno aluno = new Aluno();
aluno.ExibirDados(); // Saída: Aluno: Sem Nome, Matrícula: 0, Cadastrado em: [data atual]
```

**Detalhes Técnicos**:

- O construtor pode realizar inicializações complexas, como configurar conexões com bancos de dados ou validar estados.
- Em C#, atributos privados (ex.: `_nome`) são frequentemente usados com construtores para reforçar o encapsulamento, embora aqui mantenhamos a simplicidade.
- Podemos inicializar o construtor de modo rápido usando `ctor` dentro da classe.



### Construtor Padrão (Sem Parâmetros)

Se uma classe não define nenhum construtor, o compilador de C# (e linguagens como Java) fornece automaticamente um **construtor padrão** sem parâmetros. Esse construtor inicializa os atributos com os valores padrão de seus tipos:

- **Tipos de referência** (ex.: `string`, classes): `null`.
- **Tipos numéricos** (ex.: `int`, `double`): `0` ou `0.0`.
- **Booleanos** (ex.: `bool`): `false`.
- **Estruturas** (ex.: `DateTime`): Valores padrão específicos do tipo.

**Exemplo em C#**:

```csharp
public class Carro {
    public string Modelo; // null
    public int Ano;      // 0
    public bool Ligado;  // false
}

Carro meuCarro = new Carro();
Console.WriteLine($"Modelo: {meuCarro.Modelo}, Ano: {meuCarro.Ano}, Ligado: {meuCarro.Ligado}");
// Saída: Modelo: null, Ano: 0, Ligado: False
```

**Nota Crítica**: Se você definir qualquer construtor na classe, o construtor padrão implícito não será fornecido. Nesse caso, você deve explicitamente criar um construtor sem parâmetros, se desejar mantê-lo.



### Conexão com Abstração

Os construtores desempenham um papel crucial na implementação da **abstração**, pois garantem que os objetos sejam criados em um estado que respeite o modelo abstrato definido pela classe. Por exemplo, se a classe `Carro` abstrai um veículo com atributos `Modelo` e `Ano`, o construtor pode assegurar que esses atributos sejam inicializados com valores válidos (ex.: `Ano` maior que 1900), evitando estados inconsistentes. Assim, os construtores reforçam a abstração ao controlar a inicialização dos objetos.

**Exemplo em C#**:

```csharp
public class Carro {
    private string _modelo;
    private int _ano;

    public Carro() {
        _modelo = "Modelo Padrão";
        _ano = 2023;
        if (_ano < 1900) throw new ArgumentException("Ano inválido"); // Validação
    }

    public string Modelo => _modelo;
    public int Ano => _ano;
}
```

Aqui, o construtor valida o estado inicial, garantindo que o objeto respeite a abstração de um carro válido.

---

## Modificadores de Acesso (Especificadores de Acesso)

### O que são Modificadores de Acesso?

**Modificadores de acesso** (ou especificadores de acesso) são palavras-chave usadas em linguagens orientadas a objetos para controlar a **visibilidade** e o **acesso** aos membros de uma classe, como atributos (campos), métodos, construtores e até mesmo a própria classe. Eles definem quem pode acessar ou modificar esses membros, promovendo segurança, organização e modularidade no código. Em C#, os principais modificadores de acesso são:

- **public**: O membro é acessível de qualquer lugar, dentro ou fora da classe, sem restrições.
- **private**: O membro só pode ser acessado dentro da própria classe. É o modificador mais restritivo.
- **protected**: O membro é acessível dentro da classe e em classes derivadas (subclasses) via herança.
- **internal**: O membro é acessível apenas dentro do mesmo *assembly* (projeto ou biblioteca).
- **protected internal**: Combina protected e internal, permitindo acesso em classes derivadas ou no mesmo *assembly*.
- **private protected**: Restringe o acesso à classe e a subclasses no mesmo *assembly*.

**Propósito**: Modificadores de acesso são a base para implementar a ocultação de dados, um aspecto essencial do encapsulamento, pois controlam como os dados e comportamentos de uma classe são expostos ou protegidos.

**Exemplo em C#**:

```c#
public class Carro {
    public string Modelo; // Acessível de qualquer lugar
    private int _velocidadeAtual; // Acessível apenas dentro da classe

    public void Acelerar() {
        _velocidadeAtual += 10;
        Console.WriteLine($"Velocidade atual: {_velocidadeAtual} km/h");
    }
}

Carro meuCarro = new Carro();
meuCarro.Modelo = "Fusca"; // OK, Modelo é public
meuCarro.Acelerar(); // OK, Acelerar é public

// meuCarro._velocidadeAtual = 50; // ERRO: _velocidadeAtual é private
```

**Explicação**:

- Modelo é public, permitindo acesso e modificação de qualquer código.
- _velocidadeAtual é private, garantindo que apenas métodos da classe (como Acelerar) possam alterá-lo, protegendo o estado interno do objeto.

**Analogia**: Pense em uma casa. A porta da frente (public) pode ser acessada por qualquer pessoa, mas o cofre dentro da casa (private) só pode ser aberto pelos moradores. Modificadores de acesso definem quem tem a "chave" para cada parte da classe.



### Papel na POO

Modificadores de acesso são universais em POO, pois permitem que os desenvolvedores controlem a **interface pública** de uma classe (o que é visível externamente) e protejam a **implementação interna** (detalhes que devem permanecer ocultos). Isso é crucial para a **ocultação de dados**, que veremos a seguir, e para garantir que os objetos mantenham estados consistentes.

---

## Encapsulamento

### O que é Encapsulamento?

**Encapsulamento** é um dos pilares fundamentais da POO que consiste em **agrupar dados (atributos) e métodos (comportamentos)** relacionados em uma única unidade, a classe, enquanto se controla o acesso a esses dados por meio de modificadores de acesso e métodos públicos. O encapsulamento protege o estado interno de um objeto, garantindo que ele só possa ser alterado de maneira controlada, respeitando as regras definidas pela classe.

**Definição Formal**: Encapsulamento é o processo de agrupar dados e operações relacionadas em uma classe, restringindo o acesso direto aos dados internos e expondo apenas uma interface pública para interação.

**Características**:

- **Agrupamento**: Os atributos (ex.: Modelo, Velocidade) e métodos (ex.: Acelerar, Frear) que operam sobre esses dados estão na mesma classe.
- **Controle de acesso**: Usa modificadores como private para proteger os dados e métodos públicos (ou propriedades) para acesso controlado.
- **Manutenção do estado**: Garante que o objeto permaneça em um estado válido, aplicando validações nas operações.

**Exemplo em C#**:

```c#
public class Aluno {
    private string _nome; // Atributo privado
    private int _matricula;

    // Construtor para inicializar os dados
    public Aluno(string nome, int matricula) {
        _nome = nome;
        _matricula = matricula > 0 ? matricula : throw new ArgumentException("Matrícula deve ser positiva");
    }

    // Propriedade para acesso controlado
    public string Nome {
        get { return _nome; }
        set { _nome = string.IsNullOrEmpty(value) ? "Sem Nome" : value; }
    }

    public int Matricula {
        get { return _matricula; } // Somente leitura
    }

    public void ExibirDados() {
        Console.WriteLine($"Aluno: {_nome}, Matrícula: {_matricula}");
    }
}

Aluno aluno = new Aluno("João", 12345);
aluno.Nome = "Maria"; // OK, via propriedade
aluno.ExibirDados(); // Saída: Aluno: Maria, Matrícula: 12345

// aluno._nome = "Ana"; // ERRO: _nome é private
```

**Em Outras Linguagens**:

- **Java**: Usa métodos getNome() e setNome(String nome) para acesso controlado, em vez de propriedades como em C#.
- **Python**: Usa convenções como _nome para indicar atributos protegidos ou @property para criar getters/setters.
- **C++**: Similar ao C#, com atributos privados e métodos públicos, mas sem propriedades automáticas (usa métodos getters/setters).

**Analogia**: Encapsulamento é como uma máquina de café. Os grãos e a água (dados) estão dentro da máquina (classe), protegidos. O usuário interage apenas com botões (métodos públicos), sem acesso direto aos componentes internos.



### Encapsulamento na Prática

O encapsulamento é implementado por meio de:

- **Atributos privados**: Usando private para proteger os dados.
- **Métodos ou propriedades públicas**: Para permitir acesso controlado, com validações quando necessário.
- **Métodos internos**: Para realizar operações que manipulam os dados de forma consistente.

**Exemplo em C#**:

```c#
public class ContaBancaria {
    private decimal _saldo;
    private string _titular;

    public ContaBancaria(string titular, decimal saldoInicial) {
        _titular = titular;
        _saldo = saldoInicial >= 0 ? saldoInicial : throw new ArgumentException("Saldo inicial não pode ser negativo");
    }

    public decimal Saldo {
        get { return _saldo; } // Somente leitura
    }

    public void Depositar(decimal valor) {
        if (valor <= 0) throw new ArgumentException("Valor de depósito deve ser positivo");
        _saldo += valor;
    }

    public bool Sacar(decimal valor) {
        if (valor <= 0) throw new ArgumentException("Valor de saque deve ser positivo");
        if (valor > _saldo) return false; // Saque não permitido
        _saldo -= valor;
        return true;
    }

    public string ExibirSaldo() {
        return $"Titular: {_titular}, Saldo: {_saldo:C}";
    }
}

ContaBancaria conta = new ContaBancaria("Ana", 1000);
conta.Depositar(500);
Console.WriteLine(conta.ExibirSaldo()); // Saída: Titular: Ana, Saldo: R$ 1.500,00
conta.Sacar(200);
Console.WriteLine(conta.ExibirSaldo()); // Saída: Titular: Ana, Saldo: R$ 1.300,00

// conta._saldo = -100; // ERRO: _saldo é private
```

**Explicação**:

- `_saldo` e `_titular` são privados, protegendo o estado da conta.
- Métodos como `Depositar` e `Sacar` controlam as alterações no `_saldo`, aplicando validações.
- A propriedade `Saldo` permite leitura, mas não escrita direta, reforçando a segurança.



### Papel na POO

O encapsulamento é essencial em POO porque:

- **Protege a integridade**: Evita que dados sejam modificados de forma inconsistente.
- **Facilita manutenção**: Alterações na implementação interna (ex.: mudar a lógica de `Sacar`) não afetam o código externo.
- **Promove modularidade**: A classe é uma unidade autônoma, com uma interface clara para interação.

---

## Ocultação de Dados

### O que é Ocultação de Dados?

**Ocultação de dados** (ou *data hiding*) é a prática de restringir o acesso direto aos atributos de uma classe, tornando-os privados (ou, em alguns casos, protegidos) e permitindo que sejam manipulados apenas por métodos ou propriedades públicas. É um aspecto específico do encapsulamento, focado em proteger os dados internos de modificações indevidas ou acesso não autorizado.

**Definição Formal**: Ocultação de dados é o uso de modificadores de acesso (como private) para impedir que os atributos de uma classe sejam acessados diretamente, expondo apenas métodos ou propriedades que controlam esse acesso.

**Exemplo em C#**:

```c#
public class Carro {
    private int _velocidadeAtual; // Ocultação de dados
    private readonly string _chassi; // Atributo imutável

    public Carro(string chassi) {
        _chassi = chassi;
        _velocidadeAtual = 0;
    }

    public int Velocidade {
        get { return _velocidadeAtual; }
    }

    public string Chassi {
        get { return _chassi; } // Somente leitura
    }

    public void Acelerar(int incremento) {
        if (incremento < 0) throw new ArgumentException("Incremento deve ser positivo");
        _velocidadeAtual += incremento;
    }
}

Carro carro = new Carro("ABC123");
carro.Acelerar(20);
Console.WriteLine($"Velocidade: {carro.Velocidade} km/h"); // Saída: Velocidade: 20 km/h

// carro._velocidadeAtual = 100; // ERRO: _velocidadeAtual é private
```



### Benefícios da Ocultação de Dados

A ocultação de dados oferece vantagens cruciais:

- **Segurança**: Impede modificações acidentais ou maliciosas nos dados (ex.: definir um saldo negativo em uma conta).
- **Integridade do estado**: Garante que os atributos sejam alterados apenas de forma válida, com validações nos métodos.
- **Flexibilidade de implementação**: Permite mudar a estrutura interna da classe (ex.: trocar um int por um double) sem afetar o código externo.
- **Abstração reforçada**: Esconde detalhes de implementação, expondo apenas uma interface simples e clara.

**Exemplo em C#**:

```c#
public class ContaBancaria {
    private decimal _saldo;

    public ContaBancaria(decimal saldoInicial) {
        _saldo = saldoInicial >= 0 ? saldoInicial : throw new ArgumentException("Saldo inválido");
    }

    public decimal Saldo => _saldo;

    public void Depositar(decimal valor) {
        if (valor <= 0) throw new ArgumentException("Valor inválido");
        _saldo += valor;
    }
}
```

Aqui, _saldo é privado, garantindo que não seja definido como negativo diretamente. O método Depositar valida o valor, mantendo a integridade do estado.

## Relação entre Encapsulamento e Ocultação de Dados

### Diferença e Complementaridade

Embora **encapsulamento** e **ocultação de dados** sejam conceitos relacionados, eles não são idênticos:

- **Encapsulamento**: É o conceito mais amplo, envolvendo o agrupamento de dados e métodos em uma classe, com controle de acesso para proteger o estado. Ele define a estrutura da classe como uma unidade coesa.
- **Ocultação de dados**: É uma prática específica dentro do encapsulamento, focada em tornar os atributos privados e acessar/modificar esses dados apenas por métodos ou propriedades públicas.

**Relação**:

- A ocultação de dados é uma **consequência natural** do encapsulamento. Sem encapsulamento (ou seja, sem agrupar dados e métodos em uma classe), os dados precisariam ser públicos para serem manipulados por métodos externos, comprometendo a proteção.
- O encapsulamento habilita a ocultação de dados ao permitir que os métodos que operam nos dados sejam definidos dentro da classe, controlando o acesso.

**Exemplo em C#**:

```c#
public class Relogio {
    private int _horas; // Ocultação de dados
    private int _minutos;

    public void AjustarHora(int horas, int minutos) { // Método público (encapsulamento)
        if (horas < 0 || horas > 23 || minutos < 0 || minutos > 59)
            throw new ArgumentException("Hora ou minutos inválidos");
        _horas = horas;
        _minutos = minutos;
    }

    public string ObterHora() {
        return $"{_horas:D2}:{_minutos:D2}";
    }
}

Relogio relogio = new Relogio();
relogio.AjustarHora(14, 30);
Console.WriteLine(relogio.ObterHora()); // Saída: 14:30

// relogio._horas = 25; // ERRO: _horas é private
```

**Análise**:

- **Encapsulamento**: A classe `Relogio` agrupa `_horas`, `_minutos` e os métodos `AjustarHora` e `ObterHora`, formando uma unidade coesa.
- **Ocultação de dados**: `_horas` e `_minutos` são privados, garantindo que só possam ser alterados via `AjustarHora`, que inclui validações.

**Cenário sem Encapsulamento**: Se os métodos `AjustarHora` e `ObterHora` fossem definidos fora da classe `Relogio`, os atributos `_horas` e `_minutos` precisariam ser públicos para serem acessados, comprometendo a ocultação de dados. Isso mostra como o encapsulamento é um pré-requisito para a ocultação de dados eficaz.



### Por que a Ocultação de Dados Depende do Encapsulamento?

Se os dados e os métodos que operam sobre eles não estiverem agrupados na mesma classe (encapsulamento), os dados precisariam ser expostos publicamente para que métodos externos pudessem acessá-los. Isso violaria a ocultação de dados, pois qualquer código poderia modificar os atributos diretamente, sem validações. Por exemplo:

```c#
// Sem encapsulamento
public class DadosRelogio {
    public int Horas; // Público, sem proteção
    public int Minutos;
}

public class OperadorRelogio {
    public void AjustarHora(DadosRelogio relogio, int horas, int minutos) {
        relogio.Horas = horas; // Acesso direto, sem validação
        relogio.Minutos = minutos;
    }
}

DadosRelogio relogio = new DadosRelogio();
relogio.Horas = 25; // Hora inválida, sem proteção
```



## Benefícios Combinados de Encapsulamento e Ocultação de Dados

Ao combinar encapsulamento e ocultação de dados, obtemos um design robusto:

- **Segurança**: Atributos privados protegem o estado interno contra modificações indevidas.
- **Validação**: Métodos ou propriedades públicas aplicam regras de negócio (ex.: impedir saldos negativos ou horas inválidas).
- **Flexibilidade**: A implementação interna pode mudar sem afetar o código externo, desde que a interface pública permaneça consistente.
- **Modularidade**: A classe é uma unidade independente, facilitando reutilização e manutenção.
- **Abstração reforçada**: O usuário interage com uma interface simples, sem se preocupar com detalhes internos.



```C#
public class Funcionario {
    private string _nome;
    private decimal _salario;
    private readonly string _id; // Imutável após inicialização

    public Funcionario(string id, string nome, decimal salario) {
        _id = id;
        _nome = string.IsNullOrEmpty(nome) ? "Sem Nome" : nome;
        _salario = salario >= 0 ? salario : throw new ArgumentException("Salário inválido");
    }

    public string Nome {
        get => _nome;
        set => _nome = string.IsNullOrEmpty(value) ? "Sem Nome" : value;
    }

    public decimal Salario {
        get => _salario;
    }

    public string Id => _id; // Somente leitura

    public void AumentarSalario(decimal percentual) {
        if (percentual <= 0) throw new ArgumentException("Percentual deve ser positivo");
        _salario += _salario * (percentual / 100);
    }

    public string ExibirInformacoes() {
        return $"Funcionário: {_nome}, ID: {_id}, Salário: {_salario:C}";
    }
}

Funcionario func = new Funcionario("E123", "Carlos", 5000);
func.AumentarSalario(10);
Console.WriteLine(func.ExibirInformacoes()); // Saída: Funcionário: Carlos, ID: E123, Salário: R$ 5.500,00
func.Nome = "Ana";
Console.WriteLine(func.ExibirInformacoes()); // Saída: Funcionário: Ana, ID: E123, Salário: R$ 5.500,00

// func._salario = -100; // ERRO: _salario é private
```

**Análise**:

- **Encapsulamento**: _nome, _salario e _id estão agrupados com métodos como AumentarSalario e ExibirInformacoes.
- **Ocultação de dados**: Atributos são privados, acessíveis apenas via propriedades ou métodos com validações.
- **Benefícios**: O salário não pode ser definido como negativo, e o ID é imutável após a criação, garantindo integridade.

---

## Sobrecarga de Métodos

Sobrecarga de métodos (ou *method overloading*) é uma característica da Programação Orientada a Objetos (POO) que permite a definição de múltiplos métodos com o mesmo nome dentro da mesma classe, desde que possuam assinaturas diferentes. A assinatura de um método é composta pelo nome do método e pela lista de parâmetros (incluindo o número, tipo e ordem dos parâmetros). O compilador diferencia os métodos sobrecarregados com base nessas assinaturas, permitindo que o mesmo nome de método seja reutilizado para realizar operações relacionadas, mas com diferentes combinações de argumentos.

Em C#, a assinatura de um método é composta pelo seu nome e pela lista ordenada de tipos e número de parâmetros formais”. O tipo de retorno não faz parte da assinatura para fins de sobrecarga.



### Assinatura de Método

A assinatura de um método em linguagens como C#, Java e C++ é definida pelos seguintes elementos:

- **Nome do método**: O identificador do método.
- **Número de parâmetros**: Quantidade de argumentos que o método aceita.
- **Tipos dos parâmetros**: O tipo de dado de cada parâmetro.
- **Ordem dos parâmetros**: A sequência em que os parâmetros são declarados.
- **Modificadores de parâmetro**: Modificadores como  `ref`, `out` e  `in`.

Elementos que **NÃO** fazem parte da assinatura:

- **Tipo de retorno**: Em C#, o tipo de retorno não é considerado na diferenciação de métodos sobrecarregados.
- **Modificadores de acesso** (e.g., `public`, `private`): Não influenciam a assinatura.
- **Nomes dos parâmetros**: Apenas os tipos e a ordem importam, não os nomes.

Exemplo em C#:

```c#
public class Calculadora {
    // Método 1: Soma de dois inteiros
    public int Somar(int a, int b) {
        return a + b;
    }

    // Método 2: Soma de três inteiros
    public int Somar(int a, int b, int c) {
        return a + b + c;
    }

    // Método 3: Soma de dois doubles
    public double Somar(double a, double b) {
        return a + b;
    }
}
```

**Análise**:

- Os três métodos têm o mesmo nome (`Somar`), mas assinaturas diferentes:
  - Somar(`int`, `int`): Dois parâmetros inteiros.
  - Somar(`int`, `int`, `int`): Três parâmetros inteiros.
  - Somar(`double`, `double`): Dois parâmetros do tipo `double`.
- O compilador escolhe o método correto com base nos argumentos fornecidos na chamada.

Exemplo em C#:

```c#
Calculadora calc = new Calculadora();
Console.WriteLine(calc.Somar(2, 3));        // Saída: 5 (chama Somar(int, int))
Console.WriteLine(calc.Somar(2, 3, 4));     // Saída: 9 (chama Somar(int, int, int))
Console.WriteLine(calc.Somar(2.5, 3.7));    // Saída: 6.2 (chama Somar(double, double))
```



### Regras para Sobrecarga de Métodos

* **Nome igual**: Todos os métodos sobrecarregados devem compartilhar o mesmo nome.

* **Assinatura única**: Cada método deve ter uma lista de parâmetros distinta (número, tipo ou ordem).

* **Resolução em tempo de compilação**: O compilador determina qual método chamar com base nos argumentos fornecidos, um processo chamado *resolução estática*.

* **Independência do tipo de retorno**: Em C#, o tipo de retorno não pode ser usado para diferenciar métodos. Por exemplo, o seguinte código gera um erro de compilação:

```c#
public class Exemplo {
    public int Metodo(int x) { return x; }
    public double Metodo(int x) { return x; } // ERRO: Assinaturas idênticas
}
```

* **Modificadores de acesso irrelevantes**: Métodos sobrecarregados podem ter diferentes modificadores de acesso (`public`, `private`, etc.), mas isso não afeta a resolução da sobrecarga.



### Limitações e Cuidados

* **Ambiguidade**: Se os argumentos fornecidos não permitem ao compilador distinguir claramente qual método chamar, ocorre um erro de compilação. Exemplo:

```c#
public class Exemplo {
    public void Processar(int x, double y) { }
    public void Processar(double x, int y) { }
}
Exemplo ex = new Exemplo();
ex.Processar(1, 2); // ERRO: Chamada ambígua
```

Nesse caso, o compilador não sabe qual método escolher, pois os argumentos podem ser convertidos implicitamente para ambos os tipos.

* **Complexidade**: Sobrecarga excessiva pode dificultar a manutenção e a compreensão do código, especialmente se muitos métodos sobrecarregados tiverem lógica semelhante.

* **Boas práticas**: Use nomes claros e mantenha a lógica dos métodos sobrecarregados consistente com o propósito do nome do método. Evite sobrecargas que possam causar confusão.

### Referências

[Métodos - C# | Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/methods)

---

## Sobrecarga de Construtores

Sobrecarga de construtores é uma aplicação específica da sobrecarga de métodos, onde uma classe define múltiplos construtores com **diferentes listas de parâmetros**. Cada construtor permite inicializar objetos de maneiras diferentes, oferecendo flexibilidade na criação de instâncias com base nos dados disponíveis ou no contexto.

**Definição Formal**: Um construtor é um método especial que inicializa objetos de uma classe. A sobrecarga de construtores permite que a classe forneça várias formas de criar objetos, distinguindo-as pela assinatura (número, tipo e ordem dos parâmetros). Como descrito por Deitel & Deitel (2017), a sobrecarga de construtores facilita a inicialização de objetos com diferentes combinações de valores iniciais, mantendo a consistência do estado do objeto.



### Características da Sobrecarga de Construtores

- **Nome do construtor**: Igual ao nome da classe.
- **Sem tipo de retorno**: Construtores não retornam valores, nem mesmo void.
- **Diferenciação por parâmetros**: Os construtores são distinguidos pelo número, tipo ou ordem dos parâmetros.
- **Resolução estática**: Assim como na sobrecarga de métodos, o compilador seleciona o construtor apropriado com base nos argumentos fornecidos na chamada com o operador new.



Exemplo em C#:

```c#
public class Carro {
    private string _modelo;
    private int _ano;
    private bool _ligado;

    // Construtor padrão (sem parâmetros)
    public Carro() {
        _modelo = "Desconhecido";
        _ano = 2023;
        _ligado = false;
    }

    // Construtor com modelo
    public Carro(string modelo) {
        _modelo = modelo;
        _ano = 2023;
        _ligado = false;
    }

    // Construtor com modelo e ano
    public Carro(string modelo, int ano) {
        _modelo = modelo;
        _ano = ano >= 1900 ? ano : throw new ArgumentException("Ano inválido");
        _ligado = false;
    }

    // Construtor completo
    public Carro(string modelo, int ano, bool ligado) {
        _modelo = modelo;
        _ano = ano >= 1900 ? ano : throw new ArgumentException("Ano inválido");
        _ligado = ligado;
    }

    public void ExibirInformacoes() {
        Console.WriteLine($"Carro: {_modelo}, Ano: {_ano}, Ligado: {_ligado}");
    }
}
```

Uso Prático:

```c#
Carro carro1 = new Carro();                     // Usa o construtor padrão
carro1.ExibirInformacoes();                     // Saída: Carro: Desconhecido, Ano: 2023, Ligado: False

Carro carro2 = new Carro("Fusca");              // Usa o construtor com modelo
carro2.ExibirInformacoes();                     // Saída: Carro: Fusca, Ano: 2023, Ligado: False

Carro carro3 = new Carro("Civic", 2020);        // Usa o construtor com modelo e ano
carro3.ExibirInformacoes();                     // Saída: Carro: Civic, Ano: 2020, Ligado: False

Carro carro4 = new Carro("Mustang", 2022, true); // Usa o construtor completo
carro4.ExibirInformacoes();                     // Saída: Carro: Mustang, Ano: 2022, Ligado: True
```

### Regras para Sobrecarga de Construtores

1. **Assinatura única**: Cada construtor deve ter uma lista de parâmetros distinta (número, tipo ou ordem).
2. **Validações**: Construtores devem garantir que o objeto seja inicializado em um estado válido, aplicando validações quando necessário.
3. **Uso do `this` para vincular construtores**: Em C#, a palavra-chave `this` pode ser usada para chamar outro construtor da mesma classe, evitando duplicação de código. Exemplo:

```c#
public class Carro {
    private string _modelo;
    private int _ano;

    public Carro() : this("Desconhecido", 2023) { } // Chama o construtor com parâmetros

    public Carro(string modelo, int ano) {
        _modelo = modelo;
        _ano = ano >= 1900 ? ano : throw new ArgumentException("Ano inválido");
    }
}
```

4. Aqui, o construtor padrão delega a inicialização para o construtor parametrizado, usando `: this()`.

5. **Construtor padrão implícito**: Se nenhum construtor for definido, o compilador fornece um construtor padrão sem parâmetros. Porém, se qualquer construtor for definido explicitamente, o construtor padrão implícito não é gerado.



Exemplo em C#:

```c#
public class Pessoa
{
    public string Nome { get; }
    public int Idade { get; }

    // Construtor sem parâmetros (valores padrão)
    public Pessoa()
    {
        Nome = "Sem Nome";
        Idade = 0;
    }

    // Construtor com nome
    public Pessoa(string nome)
    {
        Nome = nome;
        Idade = 0;
    }

    // Construtor com nome e idade
    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}

// Uso:
var p1 = new Pessoa();
var p2 = new Pessoa("Maria");
var p3 = new Pessoa("João", 25);
```

### Uso do `this` para Encadeamento de Construtores

Em C#, é possível reduzir duplicação de código usando **chaining** de construtores com o `this`, chamando outro construtor da mesma classe:

```c#
public class Pessoa
{
    public string Nome { get; }
    public int Idade { get; }

    public Pessoa() : this("Sem Nome", 0) { }

    public Pessoa(string nome) : this(nome, 0) { }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}
```

Neste exemplo:

- O construtor sem parâmetros chama o construtor com `(string, int)`.
- O construtor com apenas `string` também chama o `(string, int)`.
- Isso centraliza a lógica de inicialização no construtor mais completo.



#### Benefícios da Sobrecarga de Construtores

- **Flexibilidade na inicialização**: Permite criar objetos com diferentes combinações de dados iniciais.
- **Reutilização de código**: Usando this para vincular construtores, evita-se duplicação de lógica de inicialização.
- **Clareza**: Oferece opções claras para instanciar objetos, dependendo do contexto.
- **Robustez**: Permite validações específicas para cada combinação de parâmetros, garantindo estados consistentes.

#### Limitações e Cuidados

- **Ambiguidade**: Assim como na sobrecarga de métodos, construtores com assinaturas ambíguas (e.g., parâmetros que podem ser implicitamente convertidos) causam erros de compilação.
- **Manutenção**: Muitos construtores podem dificultar a manutenção, especialmente se a lógica de inicialização for complexa.
- Boas práticas:
  - Mantenha a lógica dos construtores simples e focada na inicialização.
  - Use `this` para evitar duplicação de código.
  - Aplique validações para garantir que o objeto seja criado em um estado válido.

#### Relação com a Palavra-chave this

Embora o tópico principal não foque na palavra-chave this, vale mencionar que ela desempenha um papel importante na sobrecarga de construtores. Em C#, this pode ser usado para:

- **Chamar outro construtor**: Como mostrado no exemplo acima, this permite que um construtor delegue a inicialização para outro construtor da mesma classe.
- **Referenciar a instância atual**: Fora do contexto de construtores, this refere-se ao objeto atual, útil para diferenciar atributos de parâmetros com nomes iguais. Exemplo:

```c#
public class Carro {
    private string _modelo;

    public Carro(string modelo) {
        this._modelo = modelo; // this diferencia o atributo do parâmetro
    }
}
```



### Referências

[Constructors - C# | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors)

---











































## Diferença de Declaração e Expressão

Expressions bodies 

O C# é uma linguagem que evoluiu significativamente ao longo dos anos, e acho que é melhor conhecer todos os seus

novos recursos interessantes.

Muitas das novas adições ao C# têm o objetivo de tornar o código mais curto.

Um desses recursos é chamado de métodos com corpo de expressão.

Isso parece muito sério, mas na prática é simples.

Se o seu método contiver apenas uma única instrução ou expressão, você poderá escrevê-lo com uma sintaxe

especial que o torna uma linha.

Mas, primeiro, o que é uma declaração

e o que é uma expressão?

Bem, expressão é algo que é avaliado como um valor.

Por exemplo, 1+2 ou uma chamada a um método que retorna uma cadeia de caracteres.

Por outro lado, uma instrução é um trecho de código que faz algo, mas não é avaliado em um valor.

Por exemplo, pode ser uma chamada para o Console. WriteLine ou uma instrução "if".

Esses dois métodos

contêm uma única expressão cada.

Portanto, podemos transformá-los em métodos com corpo de expressão.

Em vez disso, descartaremos os colchetes e a palavra-chave "return" e usaremos seta.

## Palavra `this`

refere à instância atual da classe.

## Reandonly e Const

Tornar todos os campos de um objeto readonly torna o objeto inteiro imutável.

Imutabilidade significa que, depois que um objeto é criado, ele nunca será modificado.

[5 Benefits of Immutable Objects Worth Considering for Your Next Project | HackerNoon](https://hackernoon.com/5-benefits-of-immutable-objects-worth-considering-for-your-next-project-f98e7e85b6ac)

O modificador const pode ser aplicado a variáveis e campos.

Essas variáveis e campos devem ser atribuídos na declaração e nunca podem ser modificados posteriormente.

Além disso, eles devem receber um valor constante de tempo de compilação, ou seja, um valor que possa ser avaliado durante

a compilação antes de o aplicativo ser executado.