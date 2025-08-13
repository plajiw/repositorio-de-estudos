# Visão Geral

A Ivy é um chatbot baseado em WhatsApp projetado para interagir com usuários, fornecendo informações sobre boletos, notas fiscais e outros serviços financeiros. Ela se integra a sistemas externos, como o SAP Business One (SAP B1) e uma API de Boletos, e utiliza o banco de dados RavenDB para armazenar informações. O coração da aplicação é uma máquina de estados, que gerencia o fluxo de conversação de forma estruturada, permitindo que o chatbot responda de maneira contextual e guiada.

O fluxo lógico da Ivy pode ser resumido assim:

1. **Inicialização**: Configuração dos serviços e componentes necessários.
2. **Recebimento de Mensagem**: Via WhatsApp, através de um webhook.
3. **Processamento**: Identificação do estado atual da conversa e execução da lógica correspondente.
4. **Resposta**: Envio de mensagens ou documentos ao usuário.
5. **Persistência**: Salvamento do histórico no RavenDB.

---

## 1. Inicialização da Aplicação

### Onde a Aplicação Começa?

A Ivy não "começa" diretamente no dicionário da máquina de estados, mas sim na **inicialização dos serviços e da infraestrutura**. No documento, isso está descrito na seção # INICIALIZAÇÃO DA IVI PARA DESENVOLVIMENTO:

- **RavenDB**: Banco de dados NoSQL documental que armazena contas, históricos de conversas e outros dados. É inicializado primeiro porque a aplicação depende dele para persistência.
- **Projeto Invent Admin (localhost:7105)**: Uma interface administrativa, provavelmente para gerenciar configurações ou monitorar a aplicação.
- **Projeto Ivy (localhost:7281)**: O núcleo do chatbot, onde a lógica de interação reside. É exposto via um túnel de desenvolvimento (ex.: ngrok) para integração com o WhatsApp.
- **SAP B1 e AddOns**: Integração com o SAP Business One e serviços como Tax NF-e/NFS-e para acessar dados de notas fiscais e boletos.

### O Que é Instanciado?

Durante a inicialização, o sistema utiliza um **container de injeção de dependência** (provavelmente o do ASP.NET Core) para criar instâncias de serviços, repositórios e classes de processo. Exemplos:

- **ServicoDaConta**: Gerencia contas (criação, atualização, busca).
- **ServicoDeMensagem**: Envia mensagens e documentos via WhatsApp.
- **ProcessosFactory**: Instancia processos com base no estado atual.
- **ManipuladorDoStatusDoProcesso**: Controla a máquina de estados.

### Importância Dessa Etapa

Sem essa inicialização, a aplicação não teria acesso aos dados (RavenDB), às APIs externas (SAP, BankPlus) ou ao WhatsApp. É como ligar o motor de um carro antes de dirigir.

------

## 2. Máquina de Estados: O Coração do Fluxo Lógico

### O Que é a Máquina de Estados?

A máquina de estados é um modelo que define **estados** (ex.: Autenticacao, SelecionarParceiro, Finalizado) e **transições** entre eles com base em **comandos** (ex.: Iniciar, Finalizar). No código, isso é implementado no MaquinaDeEstados:

- Dicionário de Transições

  : Um 

  Dictionary<EstadoDeTransicao, Estado>

   mapeia o estado atual e o comando para o próximo estado. Exemplo:

  - { Status.Finalizado, Comando.Iniciar } → Estado.ObterEstadoDeAutenticacao()
  - Isso significa que, se a conversa está finalizada e o usuário inicia uma interação, ela vai para o estado de autenticação.

### Valores Controlados e Recebidos

- **EstadoDeTransicao**: Combinação de Status (estado atual) e Comando (ação do usuário ou sistema).
- **Estado**: Define o próximo estado e o tipo de processo associado (ex.: EstadoDeAutenticacao).
- **ManipuladorDoStatusDoProcesso**: Classe que usa o dicionário para gerenciar o estado atual e determinar o próximo passo.

### Importância

A máquina de estados é crucial porque:

- **Controla o fluxo**: Garante que a conversa siga uma lógica pré-definida.
- **Mantém o contexto**: Permite que o chatbot "lembre" onde o usuário está no processo.
- **Modularidade**: Cada estado tem sua própria lógica, facilitando manutenção e suporte.

### Para Onde Segue?

Quando uma mensagem chega, o sistema consulta o estado atual (inicialmente Finalizado) e o comando (ex.: Iniciar) para decidir o próximo estado (ex.: Autenticacao). Isso é gerenciado pelo ManipuladorDoStatusDoProcesso.

------

## 3. Recebimento de Mensagens via Webhook

### Como as Mensagens Chegam?

A interação começa quando o usuário envia uma mensagem ao número do WhatsApp vinculado à Ivy. Isso é capturado pelo **WebhookController**:

- **Método Autenticacao (GET)**: Valida o webhook com o WhatsApp usando um token (verify_token). Retorna um "challenge" para confirmar a integração.
- **Método ReceberMensagem (POST)**: Recebe a mensagem do usuário. A assinatura (X-Hub-Signature-256) é verificada para garantir autenticidade.

### Fluxo

1. A mensagem é recebida como JSON via POST.
2. O corpo da requisição é lido (ObterBody) e enfileirado para processamento assíncrono usando um Channel.
3. O processamento é delegado ao ServicoDoWebhook.

------

## 4. Processamento da Mensagem

### Papel do ServicoDoWebhook

O ServicoDoWebhook é o "cérebro" que coordena o atendimento:

- **Preenche o Contexto**: Extrai informações como número do usuário, número da Ivy e nome do usuário do JSON recebido (DadosDeResposta).
- **Consulta o Histórico**: Busca o último estado da conversa no RavenDB via ServicoDeHistorico.
- **Verifica Inatividade**: Se a última interação foi há mais de 24 horas, finaliza a conversa e reinicia do estado Autenticacao.
- **Executa o Processo**: Usa a ProcessosFactory para instanciar o processo correspondente ao estado atual.

### Exemplo: Estado de Autenticação

No EstadoDeAutenticacao:

1. **Busca a Conta**: ServicoDaConta.ObterContaPorNumero verifica se o número da Ivy é válido.

2. **Salva o Histórico**: Registra a mensagem recebida.

3. **Verifica Status**: Se a conta está desabilitada, envia erro e finaliza.

4. **Boas-Vindas**: Envia uma mensagem inicial (ex.: "Bem-vindo à [Empresa]").

5. **Consulta Contatos**: Usa ServicoDeNotasFiscaisPelaServiceLayer ou ServicoDeContatos para buscar contatos associados ao número.

6. Define Próximo Estado

   :

   - Nenhum contato → Iniciar.
   - Um contato → SelecionarParceiro (com opção automática "1").
   - Múltiplos contatos → SelecionarParceiro (usuário escolhe).

### Critérios de Transição

As transições dependem do estado atual e do comando, que pode vir:

- Do usuário (mensagem digitada).
- Do sistema (ex.: erro ou inatividade).

------

## 5. Resposta ao Usuário

### Envio de Mensagens

O ServicoDeMensagem lida com o envio:

- **EnviarMensagem**: Envia texto simples.
- **EnviarDocumento**: Envia arquivos (ex.: PDFs de notas fiscais).
- **EnviarMensagemTemplate**: Usa templates do WhatsApp para mensagens padronizadas com anexos.

### Exemplo Prático

Se o usuário está em DetalhesDaNotaFiscal e pede o PDF (EhfetuarDownloadDoPdf), o sistema:

1. Busca o documento no SAP ou API de Boletos.
2. Faz upload para o WhatsApp via ServicoDeMensagem.
3. Envia o link ou anexo ao usuário.

------

## 6. Persistência e Tratamento de Erros

### Histórico

O ServicoDeHistorico salva cada interação no RavenDB, incluindo:

- Mensagens enviadas/recebidas.
- Requisições a APIs externas.
- Erros (ex.: ApiRequestException).

### Tratamento de Erros

- **RecursoNaoEncontradoException**: Conta ou recurso não encontrado.
- **ApiRequestException**: Falha na integração com APIs.
- Erros gerais são capturados no ServicoDoWebhook, enviando uma mensagem de erro ao usuário e salvando o histórico.

------

## Fluxo Completo: Exemplo Prático

Imagine que um usuário envia "Oi" ao chatbot:

1. **Webhook**: ReceberMensagem captura a mensagem.

2. **ServicoDoWebhook**: Preenche o ContextoDeConversa e verifica o último estado (Finalizado).

3. **Máquina de Estados**: Transição { Finalizado, Iniciar } → Autenticacao.

4. EstadoDeAutenticacao

   :

   - Busca a conta.
   - Envia "Bem-vindo à Empresa X".
   - Consulta contatos e encontra um parceiro.
   - Define próximo estado como SelecionarParceiro.

5. **Resposta**: Envia opções ou seleciona automaticamente o parceiro.

6. **Persistência**: Salva o histórico no RavenDB.

------

## Dicas para Suporte

### Pontos Críticos

- **Webhook**: Se o WhatsApp não consegue alcançar o webhook (ex.: túnel caiu), as mensagens não chegam.
- **RavenDB**: Falhas no banco interrompem a persistência e o contexto.
- **APIs Externas**: Erros no SAP ou API de Boletos podem bloquear funcionalidades.

### Como Diagnosticar?

- Verifique logs no WebhookController e ServicoDoWebhook.
- Consulte o RavenDB para históricos de erro.
- Teste transições da máquina de estados manualmente.