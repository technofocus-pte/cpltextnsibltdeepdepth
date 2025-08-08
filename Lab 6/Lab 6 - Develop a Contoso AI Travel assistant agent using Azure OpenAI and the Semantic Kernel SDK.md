# Laboratório 6 - Desenvolver um agente assistente de viagens Contoso AI usando o Azure OpenAI e o SDK Semantic Kernel

**Tempo estimado: 40 minutos**

## Objetivo

Neste laboratório, os participantes criarão um agente de viagens com
tecnologia de AI para a Contoso usando o Azure OpenAI e o Semantic
Kernel SDK. O objetivo é demonstrar como utilizar tecnologias de AI para
criar um agente conversacional capaz de entender as consultas dos
usuários, fornecer recomendações de viagens e executar tarefas como
reservar voos, hotéis e gerenciar itinerários. Ao final do laboratório,
os participantes terão experiência prática na integração de modelos de
AI com aplicações reais, utilizando o Semantic Kernel SDK para aprimorar
as capacidades do agente de viagens e testando o desempenho do agente em
um ambiente simulado.

## Área de foco da solução

O laboratório se concentra na construção de um agente de viagens com
tecnologia de AI usando o Azure OpenAI e o Semantic Kernel SDK. Ele
habilita o natural language processing (NLP) para lidar com consultas do
usuário relacionadas ao planejamento de viagens, como reservas de voos,
acomodações e fornecimento de recomendações de viagem.

O laboratório enfatiza a criação de uma interface de AI conversacional
que interage com os usuários, respondendo a perguntas e auxiliando em
tarefas relacionadas a viagens. Utilizando o Semantic Kernel SDK, ele
orquestra tarefas como gerenciamento de itinerários e integra APIs para
dados de viagens em tempo real.

A solução visa aprimorar a experiência do usuário, oferecendo
assistência em viagens personalizada e ágil. Ela automatiza tarefas
comuns de viagem para otimizar fluxos de trabalho e agilizar os
processos de planejamento de viagens.

## Exercício 1: Entenda a VM e as credenciais

Neste exercício, identificaremos e entenderemos as credenciais que
usaremos durante o laboratório.

1.  **Instructions** contém o guia do laboratório com as instruções a
    serem seguidas durante todo o laboratório.

2.  **Resources** contém as credenciais que serão necessárias para
    executar o laboratório.

    - **URL** – URL para o portal do Azure

    - **Subscription** – Este é o **ID** da **assinatura** atribuída a
      você

    - **Username** – O **user id** com o qual você precisa fazer
      **login** no **Azure services**.

    - **Password** – **Password** para o **Azure login**.

Vamos chamar esse nome de usuário e senha **Azure login credentials**.
Usaremos essas credenciais sempre que mencionarmos **Azure login
credentials**.

- **Resource Group** – O **Resource group** atribuído a você.

\[!Alerta\] **Importante**: Certifique-se de criar todos os seus
recursos neste grupo de recursos

![A screenshot of a computer Description automatically
generated](./media/image1.png)

3.  **Help** contém informações de suporte. O valor do **ID** aqui é o
    **Lab instance ID** que será usado durante a execução do
    laboratório.

![A screenshot of a computer Description automatically
generated](./media/image2.png)

## Exercício 2: Criar implementação de recurso e modelo do Azure OpenAI

1.  Faça login em +++\*\* usando as credenciais de login do Azure,

    - Username - <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image3.png)

2.  Pesquise por +++**Azure OpenAI**+++ na barra de pesquisa e
    selecione-o.

![A screenshot of a computer Description automatically
generated](./media/image4.png)

3.  Selecione **+ Create**.

![A screenshot of a computer Description automatically
generated](./media/image5.png)

4.  Preencha os detalhes abaixo na aba **Basics**  e selecione **Next**.

    - Subscription – Selecione sua **subscription** atribuída

    - Resource group – Selecione o **Resource group** atribuído a você

    - Region – @lab.CloudResourceGroup(ResourceGroup1).Location

    - Name –
      +++[**AOAI@lab.LabInstance.Id**](mailto:AOAI@lab.LabInstance.Id)+++

    - Pricing tier – **Standard**

![A screenshot of a computer Description automatically
generated](./media/image6.png)

5.  Aceite os padrões nas páginas **Network** e **Tags** e clique em
    **Create** na página **Review + submit**.

![A screenshot of a computer Description automatically
generated](./media/image7.png)

6.  Depois de criado, clique em **Go to resource** e selecione o **Azure
    OpenAI** que você criou agora.

![A screenshot of a computer Description automatically
generated](./media/image8.png)

7.  Selecione **Keys and Endpoint** em **Resource Management**. Copie os
    valores da **Key 1** e do **Endpoint** para um bloco de notas para
    uso futuro neste laboratório.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

8.  Na página **Overview** do recurso Azure OpenAI, selecione **Go to
    Azure AI Foundry portal**.

![A screenshot of a computer Description automatically
generated](./media/image10.png)

9.  No painel esquerdo, selecione **Deployments**.

![A screenshot of a computer Description automatically
generated](./media/image11.png)

10. Selecione **+ Deploy model** -\> **Deploy base model**

![A screenshot of a computer Description automatically
generated](./media/image12.png)

11. Procure e selecione +++**gpt-35-turbo**+++. Clique em **Confirm**.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image13.png)

12. Aceite os padrões e selecione **Deploy**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

## Exercício 3: Configurando o Projeto do Agente de Viagens de AI com serviços Azure OpenAI

Neste exercício, você configurará a pasta do seu projeto no Visual
Studio Code e a configurará para integração com os Serviços OpenAI do
Azure. Seguindo as etapas, você aprenderá a configurar um ambiente de
desenvolvimento local, modificar arquivos de projeto e preparar o
aplicativo para execução usando os detalhes de implementação do Azure
OpenAI.

1.  Pesquise por +++**Command Prompt**+++ na barra de Pesquisa do
    Windows e abra o **Command prompt**.

![A screenshot of a computer Description automatically
generated](./media/image15.png)

2.  Execute os comandos abaixo um por um.

+++dotnet nuget list source+++

+++dotnet nuget add source https://api.nuget.org/v3/index.json --name
nuget.org+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

3.  Abra o **Visual Studio Code** que está fixado na Barra de Tarefas do
    Windows. Selecione **File** -\> **Open folder**.

![A screenshot of a computer Description automatically
generated](./media/image17.png)

4.  Navegue até **C:\LabFiles**, selecione a pasta **AITravelAgent** e
    clique em **Select Folder**. A pasta será aberta no VS Code.

![A screenshot of a computer Description automatically
generated](./media/image18.png)

5.  Selecione **Yes, I trust the authors** em **Do you want to trust the
    authors of the files in this folder?**

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image19.png)

6.  No painel do Explorer, navegue até a pasta
    **AITravelAgent/Starter.** Clique com o botão direito do mouse na
    pasta e selecione **Open in Integrated Terminal**.

![A screenshot of a computer Description automatically
generated](./media/image20.png)

7.  No painel Explorer, expanda a pasta **Starter** e você deverá ver a
    pasta **Plugins**, a pasta **Prompts** e o arquivo **Program.cs**.

![A screenshot of a computer Description automatically
generated](./media/image21.png)

8.  Abra o arquivo **Starter/Program.cs** e atualize as seguintes
    variáveis com o nome da implementação, a chave de API e o endpoint
    do Azure OpenAI Services. Após fazer as alterações, pressione Ctrl +
    S para salvar o arquivo:

> string yourDeploymentName = +++**gpt-35-turbo**+++
>
> string yourEndpoint = O valor do Endpoint do recurso Azure OpenAI que
> salvamos anteriormente
>
> string yourKey = A Key1 do recurso AOAI que salvamos anteriormente

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image22.png)

## Exercício 4: Criando e testando um plugin conversor de moedas com kernel semântico

Neste exercício, você criará um plugin conversor de moedas usando o
Semantic Kernel. Você escreverá e testará uma função que converte um
valor de uma moeda para outra usando taxas de câmbio predefinidas. Este
exercício ajudará você a entender como criar e invocar plugins
personalizados, utilizar decoradores para funcionalidades e descrições e
integrar plugins em uma aplicação maior.

1.  Crie um novo arquivo chamado +++CurrencyConverter.cs+++ na pasta
    **Stater/Plugins/ConvertCurrency**

![A screenshot of a computer Description automatically
generated](./media/image23.png)

2.  No arquivo CurrencyConverter.cs, adicione o seguinte código para
    criar uma função de plugin

> using Microsoft.SemanticKernel;
>
> using System.ComponentModel;
>
> using AITravelAgent;
>
> class CurrencyConverter
>
> {
>
> \[KernelFunction,
>
> Description("Convert an amount from one currency to another")\]
>
> public static string ConvertAmount(
>
> {
>
> var currencyDictionary = Currency.Currencies;
>
> }
>
> }

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

Neste código, você usa o decorador KernelFunction para declarar sua
função nativa. Você também usa o decorador Description para adicionar
uma descrição do que a função faz. Você pode usar Currency.Currencies
para obter um dicionário de moedas e suas taxas de câmbio. Em seguida,
adicione alguma lógica para converter um determinado valor de uma moeda
para outra.

3.  Modifique sua função ConvertAmount. Substitua o código existente
    pelo código abaixo.

> using Microsoft.SemanticKernel;
>
> using System.ComponentModel;
>
> using AITravelAgent;
>
> class CurrencyConverter
>
> {
>
> \[KernelFunction, Description(@"Converts an amount from one currency
> to another
>
> and returns a friendly message with the results")\]
>
> public static string ConvertAmount(
>
> \[Description("The starting currency code")\] string baseCurrencyCode,
>
> \[Description("The target currency code")\] string targetCurrencyCode,
>
> \[Description("The amount to convert")\] string amount)
>
> {
>
> var currencyDictionary = Currency.Currencies;
>
> Currency targetCurrency = currencyDictionary\[targetCurrencyCode\];
>
> Currency baseCurrency = currencyDictionary\[baseCurrencyCode\];
>
> if (targetCurrency == null)
>
> {
>
> return targetCurrencyCode + " was not found";
>
> }
>
> else if (baseCurrency == null)
>
> {
>
> return baseCurrencyCode + " was not found";
>
> }
>
> else
>
> {
>
> double amountInUSD = Double.Parse(amount) \* baseCurrency.USDPerUnit;
>
> double result = amountInUSD \* targetCurrency.UnitsPerUSD;
>
> return $"${amount} {baseCurrencyCode} is approximately
> {result.ToString("C")} in {targetCurrency.Name}s
> ({targetCurrencyCode})";
>
> }
>
> }
>
> }

Neste código, você usa o método ImportPluginFromType para importar seu
plugin. Em seguida, utiliza o método InvokeAsync para invocar a função
do plugin. O método InvokeAsync recebe o nome do plugin, o nome da
função e um dicionário de parâmetros. Por fim, você imprime o resultado
no console. Agora, execute o código para verificar se está funcionando.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image25.png)

\[!Observação\] **Observação:** Ao usar o Semantic Kernel SDK em seus
próprios projetos, não é necessário codificar dados diretamente em
arquivos se você tiver acesso a APIs RESTful. Em vez disso, você pode
usar o plugin Plugins.Core.HttpClient para recuperar dados das APIs.

4.  No arquivo Starter/Program.cs, importe e acione sua nova função de
    plugin com o código a seguir. (Exclua o código abaixo var kernel =
    builder.Build(); e substitua-o pelo código fornecido abaixo.)

> kernel.ImportPluginFromType\<CurrencyConverter\>();
>
> kernel.ImportPluginFromType\<ConversationSummaryPlugin\>();
>
> var prompts = kernel.ImportPluginFromPromptDirectory("Prompts");
>
> var result = await kernel.InvokeAsync("CurrencyConverter",
>
> "ConvertAmount",
>
> new() {
>
> {"targetCurrencyCode", "USD"},
>
> {"amount", "52000"},
>
> {"baseCurrencyCode", "VND"}
>
> }
>
> );
>
> Console.WriteLine(result);

Neste código, você usa o método ImportPluginFromType para importar seu
plugin. Em seguida, você usa o método InvokeAsync para invocar a função
do plugin. O método InvokeAsync recebe o nome do plugin, o nome da
função e um dicionário de parâmetros. Por fim, você imprime o resultado
no console. Em seguida, execute o código para verificar se está
funcionando.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

5.  Vá em **File** na barra superior e selecione **Save all.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

6.  No terminal, digite +++**dotnet run**+++. Você deverá ver a seguinte
    saída:

**Saída:** ₫52.000 VND é aproximadamente US$2,13 em dólares americanos
(USD)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

Agora que seu plugin está funcionando corretamente, vamos criar um
prompt de linguagem natural que possa detectar quais moedas e valores o
usuário deseja converter.

## Exercício 5: Configurando um prompt de moeda de destino para processamento semântico

Neste exercício, você configurará um sistema de prompt para identificar
moedas de destino, moedas base e valores a partir da entrada do usuário.
Ao criar e configurar arquivos de configuração e prompt, você definirá
como a AI interpreta e processa solicitações em linguagem natural para
conversões de moeda.

1.  No Visual Studio Code, localize a pasta **Starter/Prompts**. Navegue
    até ela para se preparar para as próximas etapas.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

2.  Dentro da pasta **Starter/Prompts**, crie uma nova pasta chamada
    +++**GetTargetCurrencies**+++. Esta pasta conterá todos os arquivos
    relacionados a este exercício.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

3.  Dentro da pasta **GetTargetCurrencies**, crie um novo arquivo
    chamado +++**config.json**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

4.  Abra o arquivo **config.json** recém-criado no Visual Studio Code.
    Copie e cole o código a seguir no arquivo.

> {
>
> "schema": 1,
>
> "type": "completion",
>
> "description": "Identify the target currency, base currency, and
> amount to convert",
>
> "execution_settings": {
>
> "default": {
>
> "max_tokens": 800,
>
> "temperature": 0
>
> }
>
> },
>
> "input_variables": \[
>
> {
>
> "name": "input",
>
> "description": "Text describing some currency amount to convert",
>
> "required": true
>
> }
>
> \]
>
> }

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

Salve o arquivo pressionando **Ctrl + S.** Esta configuração define como
o sistema de AI deve interpretar e processar a entrada do usuário.

5.  Na pasta **Prompts**, crie outro arquivo novo chamado
    +++**skprompt.txt**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  Abra o arquivo **skprompt.txt** no seu editor de texto e cole o
    seguinte conteúdo:

7.  \<message role="system"\>Identify the target currency, base
    currency, and

8.  amount from the user's input in the format
    target|base|amount\</message\>

> Por exemplo:
>
> \<message role="user"\>How much in GBP is 750.000 VND?\</message\>
>
> \<message role="assistant"\>GBP|VND|750000\</message\>
>
> \<message role="user"\>How much is 60 USD in New Zealand
> Dollars?\</message\>
>
> \<message role="assistant"\>NZD|USD|60\</message\>
>
> \<message role="user"\>How many Korean Won is 33,000 yen?\</message\>
>
> \<message role="assistant"\>KRW|JPY|33000\</message\>
>
> \<message role="user"\>{{$input}}\</message\>
>
> \<message role="assistant"\>target|base|amount\</message\>

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

Salve o arquivo pressionando **Ctrl + S.** Este script define a lógica
do prompt para processar solicitações de conversão de moeda.

## Exercício 6: Configurando um Sistema de Prompt para Recomendações de Atividades de Viagem

Neste exercício, você configurará e personalizará um sistema de prompts
para sugerir atividades e pontos de interesse com base no destino de
viagem de um usuário. Editando os arquivos de configuração e prompts,
você definirá o comportamento, o tom e os requisitos de entrada do
sistema para gerar recomendações de viagem personalizadas e criativas.

1.  No Visual Studio Code, navegue até a pasta
    **Starter/Prompts/SuggestActivities**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

2.  Localize o arquivo **config.json** dentro da pasta SuggestActivities
    e abra-o.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

3.  Substitua o código existente no arquivo **config.json** pelo
    seguinte:

> {
>
> "schema": 1,
>
> "type": "completion",
>
> "description": "Suggest activities and points of interest at a given
> destination",
>
> "execution_settings": {
>
> "default": {
>
> "max_tokens": 4000,
>
> "temperature": 0.5
>
> }
>
> },
>
> "input_variables": \[
>
> {
>
> "name": "history",
>
> "description": "Some background information about the user",
>
> "required": false
>
> },
>
> {
>
> "name": "destination",
>
> "description": "The destination a user wants to visit",
>
> "required": true
>
> }
>
> \]
>
> }

![A screenshot of a computer code AI-generated content may be
incorrect.](./media/image37.png)

Salve o arquivo após fazer as alterações pressionando **Ctrl + S.** Este
arquivo configura o sistema para processar entradas do usuário e gerar
sugestões de atividades.

4.  Permaneça na pasta SuggestActivities e localize o arquivo
    **skprompt.txt**. Abra este arquivo no editor.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

5.  Substitua o conteúdo existente de **skprompt.txt** pelo seguinte
    texto:

> You are an experienced travel agent.
>
> You are helpful, creative, and very friendly.
>
> Consider the traveler's background: {{$history}}
>
> The traveler would like some activity recommendations for their trip
> to {{$destination}}.
>
> Please suggest a list of things to do, see, and points of interest.

![A screenshot of a computer code AI-generated content may be
incorrect.](./media/image39.png)

Salve o arquivo pressionando **Ctrl + S.** Este script define o
comportamento e o tom do sistema ao gerar recomendações de atividades.

## Exercício 7: Configurando o Programa Principal para o Fluxo de Trabalho de AI

Neste exercício, você irá configurar o arquivo principal Program.cs para
integrar com os serviços do Azure OpenAI e o Microsoft Semantic Kernel.
Ao personalizar o código, você habilitará funcionalidades como conversão
de moeda, sugestões de atividades e recomendações de viagem. Essa
configuração estabelece um fluxo de trabalho robusto com AI para
interação com o usuário e reconhecimento de intenção, utilizando plugins
e lógica baseada em prompts.

1.  No seu projeto no Visual Studio Code, navegue até o arquivo
    **Starter/Program.cs** e abra-o para edição.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

2.  Substitua todo o conteúdo do arquivo **Program.cs** pelo código a
    seguir e **pressione ctrl + S** para salvar o código.

\[!Nota\] **Nota:** Após substituir o código, substitua os espaços
reservados de endpoint e Key pelos seus valores.

using System.Text;

using Microsoft.SemanticKernel;

using Microsoft.SemanticKernel.ChatCompletion;

using Microsoft.SemanticKernel.Connectors.OpenAI;

using Microsoft.SemanticKernel.Plugins.Core;

\#pragma warning disable SKEXP0050

\#pragma warning disable SKEXP0060

string yourDeploymentName = "gpt-35-turbo";

string yourEndpoint = "EndPoint";

string yourApiKey = "API Key";

var builder = Kernel.CreateBuilder();

builder.Services.AddAzureOpenAIChatCompletion(

yourDeploymentName,

yourEndpoint,

yourApiKey,

"gpt-35-turbo");

var kernel = builder.Build();

kernel.ImportPluginFromType\<CurrencyConverter\>();

kernel.ImportPluginFromType\<ConversationSummaryPlugin\>();

var prompts = kernel.ImportPluginFromPromptDirectory("Prompts");

// Note: ChatHistory isn't working correctly as of SemanticKernel v
1.4.0

StringBuilder chatHistory = new();

OpenAIPromptExecutionSettings settings = new()

{

ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions

};

string input;

do {

Console.WriteLine("What would you like to do?");

input = Console.ReadLine()!;

var intent = await kernel.InvokeAsync\<string\>(

prompts\["GetIntent"\],

new() {{ "input", input }}

);

switch (intent) {

case "ConvertCurrency":

var currencyText = await kernel.InvokeAsync\<string\>(

prompts\["GetTargetCurrencies"\],

new() {{ "input", input }}

);

var currencyInfo = currencyText!.Split("|");

var result = await kernel.InvokeAsync("CurrencyConverter",

"ConvertAmount",

new() {

{"targetCurrencyCode", currencyInfo\[0\]},

{"baseCurrencyCode", currencyInfo\[1\]},

{"amount", currencyInfo\[2\]},

}

);

Console.WriteLine(result);

break;

case "SuggestDestinations":

chatHistory.AppendLine("User:" + input);

var recommendations = await kernel.InvokePromptAsync(input!);

Console.WriteLine(recommendations);

break;

case "SuggestActivities":

var chatSummary = await kernel.InvokeAsync(

"ConversationSummaryPlugin",

"SummarizeConversation",

new() {{ "input", chatHistory.ToString() }});

var activities = await kernel.InvokePromptAsync(

input!,

new () {

{"input", input},

{"history", chatSummary},

{"ToolCallBehavior", ToolCallBehavior.AutoInvokeKernelFunctions}

});

chatHistory.AppendLine("User:" + input);

chatHistory.AppendLine("Assistant:" + activities.ToString());

Console.WriteLine(activities);

break;

case "HelpfulPhrases":

case "Translate":

var autoInvokeResult = await kernel.InvokePromptAsync(input,
new(settings));

Console.WriteLine(autoInvokeResult);

break;

default:

Console.WriteLine("Sure, I can help with that.");

var otherIntentResult = await kernel.InvokePromptAsync(input);

Console.WriteLine(otherIntentResult);

break;

}

}

while (!string.IsNullOrWhiteSpace(input));

O programa começa importando namespaces essenciais, como System.Text
para manipulação de texto e Microsoft.SemanticKernel para fluxos de
trabalho conversacionais com tecnologia de AI. Ele integra os serviços
do Microsoft Azure OpenAI por meio do namespace
Microsoft.SemanticKernel.Connectors.OpenAI, permitindo a comunicação com
o modelo GPT (gpt-35-turbo). A configuração envolve a definição de
variáveis como yourDeploymentName, yourEndpoint e yourApiKey para
autenticação e conexão com o endpoint do Azure OpenAI.

O Kernel Semântico é inicializado usando um padrão de criador. Plugins
para funcionalidades adicionais, como CurrencyConverter e
ConversationSummaryPlugin, são importados. Além disso, prompts
armazenados em um diretório (Prompts) são carregados dinamicamente para
facilitar o reconhecimento de intenções e a execução de tarefas.

O loop principal do programa interage com o usuário solicitando
informações e determinando a intenção usando o prompt GetIntent. Com
base na intenção, o programa se ramifica em diferentes funcionalidades:

1.  **Conversão de Moeda**: Se a intenção for converter moeda, o
    programa extrai os detalhes (moeda de destino, moeda base e valor)
    usando o prompt GetTargetCurrencies. Em seguida, ele chama o método
    ConvertAmount do plugin CurrencyConverter e exibe o resultado.

2.  **Sugestões de destino**: Se a intenção for sugerir destinos, o
    programa usa o método InvokePromptAsync do Semantic Kernel para
    fornecer recomendações com base na entrada do usuário.

3.  **Sugestões de Atividades:** Esta funcionalidade utiliza o resumo de
    conversas por meio do ConversationSummaryPlugin para fornecer
    sugestões de atividades contextualmente relevantes. O histórico de
    conversas é mantido usando um objeto StringBuilder para um fluxo
    contínuo de diálogos.

4.  **Frases úteis e tradução**: Para intenções como " HelpfulPhrases "
    ou " Translate ", o kernel invoca automaticamente funções relevantes
    com base na entrada e nas configurações.

Outras intenções do usuário são tratadas genericamente invocando o
sistema de prompt, garantindo flexibilidade nas respostas. O ciclo de
interação continua até que o usuário não forneça nenhuma entrada (uma
string vazia).

## Exercício 8: Testando o aplicativo

Neste exercício, você testará a funcionalidade da sua aplicação
executando consultas para conversão de moeda, sugestões de destinos e
recomendações de atividades. Isso garantirá que seu sistema com a AI
esteja funcionando conforme o esperado e fornecendo respostas precisas e
sensíveis ao contexto.

**Etapas para testar**

1.  **Execute o aplicativo**

    - Clique com o botão direito do mouse na pasta Starter e selecione
      **Open in Integrated Terminal**.

    - No terminal, digite o seguinte comando para executar o aplicativo:

+++dotnet run+++

2.  **Teste de conversão de moeda**

    - Quando solicitado **What would you like to do?** insira uma
      consulta de conversão de moeda conforme abaixo  
      +++**How much is 60 USD in New Zealand dollars?**+++

    - Produção esperada:  
      **$60 USD is approximately $97.88 in New Zealand Dollars (NZD)**

3.  **Sugestões de Destino de Teste**

    - Insira uma consulta para sugestões de destino, fornecendo contexto
      como abaixo,

> **+++I'm planning an anniversary trip with my spouse, but they are
> currently using a wheelchair and accessibility is a must. What are
> some destinations that would be romantic for us?+++**

- **Expected Output:** Uma lista de destinos românticos acessíveis,
  como:

  1.  Santorini, Grécia: Pôr do sol romântico e caminhos acessíveis para
      cadeiras de rodas em certas áreas.

  2.  Veneza, Itália: Passeios de gôndola com opções de embarque
      acessíveis.

  3.  Maui, Havaí: Vistas deslumbrantes e resorts acessíveis.

4.  **Sugestões de atividades de teste**

    - Insira uma consulta para recomendações de atividades em um destino
      específico. Por exemplo:  
      **+++What are some things to do in Barcelona?+++**

    - Resultado esperado: Recomendações adaptadas ao destino, como:

      1.  Visite a Sagrada Família: Uma obra-prima de Gaudí com
          instalações acessíveis.

      2.  Explore o Parque Güell: Designs de mosaicos exclusivos com
          rotas acessíveis a cadeiras de rodas.

      3.  Explore o Museu Picasso: Um local de arte acessível para
          cadeiras de rodas.

## Exercício 7: Limpar os recursos

1.  No portal do Azure
    (+++[https://portal.azure.com+++](https://portal.azure.com+++/)),
    selecione o Grupo de recursos atribuído a você.

2.  Selecione os recursos abaixo e clique em **Delete**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  Digite +++delete+++ na caixa de texto de confirmação de exclusão e
    clique em **Delete**.

4.  Selecione **Delete** na caixa de diálogo de confirmação de exclusão.

5.  Procure uma notificação de confirmação de exclusão de recurso.

## Resumo

Neste laboratório, aprendemos a criar um agente usando o Semantic Kernel
e o serviço Azure OpenAI.
