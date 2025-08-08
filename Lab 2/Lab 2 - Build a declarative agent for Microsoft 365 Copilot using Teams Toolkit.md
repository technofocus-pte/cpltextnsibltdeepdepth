# Laboratório 2: Criar um agente declarativo para o Microsoft 365 Copilot usando o Teams Toolkit

**Tempo estimado: 30 minutos**

## Objetivo

O objetivo deste laboratório é capacitar os participantes a criar um
agente declarativo para o Microsoft 365 Copilot usando o Teams Toolkit.
Ao concluir o laboratório, os participantes criarão um jogo de
geolocalização que proporcionará uma pausa divertida e educativa do
trabalho. O laboratório se concentra em compreender a estrutura dos
agentes declarativos, configurá-los com instruções e integrá-los ao
ecossistema do Microsoft 365 para interações personalizadas do Copilot.

## Solução

Os participantes instalarão o Teams Toolkit no Visual Studio Code e
configurarão seu ambiente de desenvolvimento. Usando um modelo, eles
criarão um scaffold de um agente declarativo chamado Geo Locator Game.
Eles personalizarão as instruções do agente e atualizarão seus arquivos
de configuração, como instruction.txt e manifest.json . O laboratório
também orienta os participantes a aprimorar o agente com identificadores
exclusivos, ícones personalizados e funcionalidades de teste. O
resultado é um aplicativo Copilot totalmente funcional e envolvente,
desenvolvido para fornecer dicas sobre cidades e integrar-se
perfeitamente ao Microsoft 365.

## Exercício 1: Configure seu ambiente de desenvolvimento para o Microsoft 365 Copilot

### Tarefa 1: Instalar o Teams Toolkit

Estes laboratórios são baseados no Teams Toolkit versão 5.0. Siga os
passos mostrados na captura de tela abaixo.

1.  Abra o Visual Studio Code e feche o **Appliances.csv** que já está
    aberto.

2.  Na mensagem Modo restrito pretendido, selecione **Manage**.

![](./media/image1.png)

3.  Selecione **Trust** na caixa de diálogo **You are in Restricted
    mode**.

![](./media/image2.png)

4.  Clique no botão da barra de ferramentas Extensões.

![](./media/image3.png)

5.  Pesquise por +++**Teams**+++, localize o Teams **Toolkit** e clique
    em **Install.**

![](./media/image4.png)

6.  Quando a instalação estiver concluída, o ícone do **Teams Toolkit**
    aparecerá na barra de navegação à esquerda.![](./media/image5.png)

## Exercício 2: Primeiro agente declarativo

Neste laboratório, você criará um agente declarativo simples usando o
Teams Toolkit para o Visual Studio Code. Seu agente foi projetado para
oferecer uma pausa divertida e educativa no trabalho, ajudando você a
explorar cidades ao redor do mundo. Ele apresenta pistas abstratas para
que você adivinhe a cidade; quanto mais pistas você usar, menos pontos
receberá. Ao final, sua pontuação final será revelada.

Neste exercício você aprenderá:

- O que é um agente declarativo para o Microsoft 365 Copilot

- Criar um agente declarativo usando o modelo do Teams Toolkit

- Personalizar o agente para criar o jogo de geolocalização usando
  instruções

- Aprender a executar e testar seu aplicativo

- Para o exercício bônus, você precisará de um site do SharePoint Teams.

**Introdução**

Os agentes declarativos utilizam a mesma infraestrutura e plataforma
escaláveis do Microsoft 365 Copilot, adaptados especificamente para
atender às suas necessidades específicas. Eles funcionam como
especialistas em uma área ou necessidade comercial específica,
permitindo que você use a mesma interface de um chat padrão do Microsoft
365 Copilot, garantindo que se concentrem exclusivamente na tarefa
específica em questão.

Bem-vindo à criação do seu próprio agente declarativo! Vamos mergulhar
de cabeça e fazer seu Copilot fazer mágica!

Neste laboratório, você começará criando um agente declarativo usando o
Teams Toolkit com um modelo padrão fornecido pela ferramenta. Isso serve
para ajudá-lo a dar os primeiros passos. Em seguida, você modificará seu
agente para que seja focado em um jogo de geolocalização.

O objetivo da sua AI é proporcionar uma pausa divertida no trabalho
enquanto ajuda você a aprender sobre diferentes cidades ao redor do
mundo. Oferecendo pistas abstratas para que você identifique uma cidade.
Quanto mais pistas precisar, menos pontos você ganhará. Ao final do
jogo, sua pontuação final será revelada.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image6.png)

Você também dará ao seu agente alguns arquivos para consultar — um
diário secreto 🕵🏽 e um mapa 🗺️ — para oferecer mais desafios ao jogador.

Então, vamos começar

**Anatomia de um agente declarativo**

À medida que desenvolvemos cada vez mais extensões para o Copilot, você
verá que, no final, o que será construído é um conjunto de alguns
arquivos em um arquivo .zip, que chamaremos de *app package*, o qual
você irá instalar e usar. Por isso, é importante ter uma compreensão
básica do que compõe esse pacote. O pacote de aplicativo de um agente
declarativo é semelhante a um aplicativo do Teams (caso você já tenha
criado um), com alguns elementos adicionais. Consulte a tabela para ver
todos os elementos principais. Você também verá que o processo de
implementação do aplicativo é muito semelhante ao de implementação de um
aplicativo do Teams.

[TABLE]

**Observação:** você pode adicionar dados de referência do SharePoint,
OneDrive, pesquisa na Web etc. e adicionar recursos de extensão a um
agente declarativo, como plugins e conectores. Você aprenderá como
adicionar um plugin nos próximos laboratórios deste caminho.

**Capacidades de um agente declarativo**

Você pode aprimorar o foco do agente no contexto e nos dados não apenas
adicionando instruções, mas também especificando a base de conhecimento
que ele deve acessar. Essas funcionalidades são chamadas de capacidades
e há três tipos de capacidades compatíveis.

- **Microsoft Graph Connectors** - Transfere conexões dos conectores do
  Graph para o agente, permitindo que ele acesse e utilize o
  conhecimento desses conectores.

- **OneDrive and SharePoint** - Fornece URLs de arquivos e sites ao
  agente, para que ele tenha acesso a esses conteúdos.

- **Web search** - Habilite ou desabilite o conteúdo da Web como parte
  da base de conhecimento do agente.

![](./media/image7.png)

**One Drive and SharePoint**

As URLs devem ser o caminho completo para os itens do SharePoint (site,
biblioteca de documentos, pasta ou arquivo). Você pode usar a opção
"Copiar link direto" no SharePoint para obter o caminho completo dos
arquivos e pastas. Para isso, clique com o botão direito do mouse no
arquivo ou pasta e selecione Detalhes. Navegue até "Caminho" e clique no
ícone de cópia. Sem especificar as URLs, todo o conteúdo do OneDrive e
do SharePoint disponível para o usuário conectado será usado pelo
agente.

**Microsoft Graph Connector**

Sem especificar as conexões, todo o corpus de conteúdo dos Conectores de
Gráfico disponível para o usuário conectado será usado pelo agente.

**Web search**

No momento, você não pode passar por sites ou domínios específicos, e
isso funciona apenas como uma forma de ativar e desativar o uso da web.

## Exercício 3: Gerar a estrutura de um agente declarativo a partir de um modelo

Você pode usar qualquer editor para criar um agente declarativo se
conhecer a estrutura dos arquivos no pacote do aplicativo mencionado
acima. Mas as coisas ficam mais fáceis se você usar uma ferramenta como
o Teams Toolkit, que não apenas cria esses arquivos para você, mas
também ajuda a implementar e publicar seu aplicativo. Portanto, para
manter as coisas o mais simples possível, você usará o Teams Toolkit.

### Tarefa 1: Usar o Teams Toolkit para criar um aplicativo de agente declarativo

1.  Acesse a extensão Teams Toolkit no seu editor do Visual Studio Code
    e selecione **Create a New App.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

2.  Um painel será aberto, onde você precisará selecionar **Agent** na
    lista de tipos de projeto.

![](./media/image9.png)

3.  Em seguida, você será solicitado a escolher o recurso de aplicativo
    do Copilot Agent. Escolha **declarative agent** e pressione
    **Enter**.

![](./media/image10.png)

4.  Em seguida, será solicitado que você escolha entre criar um agente
    declarativo básico ou um com um plugin de API. Selecione a opção
    **No Plugin**.

![](./media/image11.png)

5.  Em seguida, selecione a opção **Default folder** para especificar
    onde a pasta do projeto deve ser criada.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

6.  Em seguida, dê um nome ao aplicativo +++ **Geo Locator Game**+++ e
    selecione Enter.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

O projeto será criado em poucos segundos na pasta que você mencionou e
será aberto em uma nova janela de projeto do Visual Studio Code. Esta é
a sua pasta de trabalho.

7.  Clique em **Yes, I trust the authors** se solicitado.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

> ![](./media/image15.png)

Parabéns! Você configurou com sucesso o agente declarativo base! Agora,
examine os arquivos contidos nele para poder personalizá-lo e criar o
aplicativo de jogo de geolocalização.

### Tarefa 2: Configurar contas no Teams Toolkit

1.  Agora, selecione o ícone do Teams Toolkit no painel esquerdo. Em
    "Accounts", clique em "Sign in to Microsoft 365" e faça login com
    suas **User1 credentials.** Clique em **Sign in** no pop-up do
    Visual Studio Code.

- Username - <+++@lab.CloudPortalCredential>(User1).Username+++

- Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![](./media/image16.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

3.  Selecione **Allow access** na caixa de diálogo Alerta de segurança.

![](./media/image18.png)

4.  Após o login, um navegador será aberto com a mensagem: "You are
    signed in now and close this page". Por favor, faça isso.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

5.  Verifique se o verificador **Custom App Upload Enabled** tem uma
    marca de seleção verde.

6.  Verifique se o verificador **Copilot Access Enabled** tem uma marca
    de seleção verde.

![](./media/image20.png)

### Tarefa 3: Entendendo os arquivos no aplicativo

Veja como fica o projeto base:

[TABLE]

1.  O arquivo de interesse do nosso laboratório é principalmente o
    **appPackage/instruction.txt**, que contém as diretivas principais
    necessárias para o seu agente. É um arquivo de texto simples e você
    pode escrever instruções em linguagem natural nele.

![](./media/image21.png)

2.  Outro arquivo importante é **appPackage/ declarativeAgent.json**,
    onde há um esquema a ser seguido para estender o Microsoft 365
    Copilot com o novo agente declarativo. Vejamos quais propriedades o
    esquema deste arquivo possui.

- O $schema é a referência do esquema

- A version é a versão do esquema

- A name key representa o nome do agente declarativo.

- A description fornece uma descrição.

- As instructions são o caminho para o arquivo **instructions.txt**, que
  contém as diretivas que determinarão o comportamento operacional. Você
  também pode inserir suas instruções em texto simples como um valor
  aqui. Mas, para este laboratório, usaremos o arquivo
  **instructions.txt**.

![](./media/image22.png)

3.  Outro arquivo importante é o **appPackage/manifest.json**, que
    contém metadados cruciais, incluindo o nome do pacote, o nome do
    desenvolvedor e referências aos agentes copilot utilizados pelo
    aplicativo. A seção a seguir do arquivo manifest.json ilustra esses
    detalhes:

> "copilotAgents": {
>
> "declarativeAgents": \[
>
> {
>
> "id": "declarativeAgent",
>
> "file": "declarativeAgent.json"
>
> }
>
> \]
>
> },
>
> ![](./media/image23.png)

4.  Você também pode atualizar os arquivos do logotipo color.png e
    outline.png para que correspondam à marca do seu aplicativo. No
    laboratório de hoje, você alterará o ícone **color.png** para
    destacar o agente.

## Exercício 4: Atualizar instruções e ícones

### Tarefa 1: Atualizar ícones e manifestos

1.  Primeiro, vamos substituir o logotipo. Substituiremos a imagem
    **color.png** no projeto por uma nova. Copie a imagem **color.png**
    localizada em **C:\LabFiles** e substitua a imagem de mesmo nome na
    pasta **appPackage** do seu projeto raiz (o caminho deve ser
    **C:\Users\Student\TeamsApps\Geo Locator Game\appPackage**).

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![](./media/image26.png)

2.  Em seguida, acesse o arquivo **appPackage/manifest.json** no seu
    projeto raiz e encontre o nó **copilotAgents**. Atualize o valor do
    ID da primeira entrada do array declarativeAgents de
    declarativeAgent para +++ dcGeolocator +++ para tornar esse ID
    único.

> "copilotAgents": {
>
> "declarativeAgents": \[
>
> {
>
> "id": "dcGeolocator",
>
> "file": "declarativeAgent.json"
>
> }
>
> \]
>
> },
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image27.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

3.  Em seguida, vá até o arquivo **appPackage /instruction.txt** e copie
    e cole as instruções abaixo para substituir o conteúdo existente do
    arquivo.

> System Role: You are the game host for a geo-location guessing game.
> Your goal is to provide the player with clues about a specific city
> and guide them through the game until they guess the correct answer.
> You will progressively offer more detailed clues if the player guesses
> incorrectly. You will also reference PDF files in special rounds to
> create a clever and immersive game experience.
>
> Game play Instructions:
>
> Game Introduction Prompt
>
> Use the following prompt to welcome the player and explain the rules:
>
> Welcome to the Geo Location Game! I’ll give you clues about a city,
> and your task is to guess the name of the city. After each wrong
> guess, I’ll give you a more detailed clue. The fewer clues you use,
> the more points you score! Let’s get started. Here’s your first clue:
>
> Clue Progression Prompts
>
> Start with vague clues and become progressively specific if the player
> guesses incorrectly. Use the following structure:
>
> Clue 1: Provide a general geographical clue about the city (e.g.,
> continent, climate, latitude/longitude).
>
> Clue 2: Offer a hint about the city’s landmarks or natural features
> (e.g., a famous monument, a river).
>
> Clue 3: Give a historical or cultural clue about the city (e.g.,
> famous events, cultural significance).
>
> Clue 4: Offer a specific clue related to the city’s cuisine, local
> people, or industry.
>
> Response Handling
>
> After the player’s guess, respond accordingly:
>
> If the player guesses correctly, say:
>
> That’s correct! You’ve guessed the city in \[number of clues\] clues
> and earned \[score\] points. Would you like to play another round?
>
> If the guess is wrong, say:
>
> Nice try! \[followed by more clues\]
>
> PDF-Based Scenario
>
> For special rounds, use a PDF file to provide clues from a historical
> document, traveler's diary, or ancient map:
>
> This round is different! I’ve got a secret document to help us. I’ll
> read clues from this \[historical map/traveler’s diary\] and guide you
> to guess the city. Here’s the first clue:
>
> Reference the specific PDF to extract details:
>
> Traveler's Diary PDF,Historical Map PDF.
>
> Use emojis where necessary to have friendly tone.
>
> Scorekeeping System
>
> Track how many clues the player uses and calculate points:
>
> 1 clue: 10 points
>
> 2 clues: 8 points
>
> 3 clues: 5 points
>
> 4 clues: 3 points
>
> End of Game Prompt
>
> After the player guesses the city or exhausts all clues, prompt:
>
> Would you like to play another round, try a special challenge?

![](./media/image29.png)

4.  Observe esta linha em **appPackage/declarativeAgent.json**:

> "instructions": "$\[file('instruction.txt')\]",
>
> Isso traz suas instruções do arquivo **instruction.txt**. Se quiser
> modularizar seus arquivos de empacotamento, você pode usar essa
> técnica em qualquer um dos arquivos JSON na pasta **appPackage**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

### Tarefa 2: Adicionar iniciadores de conversa

Você pode melhorar o envolvimento do usuário com o agente declarativo
adicionando iniciadores de conversa a ele.

Alguns dos benefícios de ter iniciadores de conversa são:

- **Engajamento**: Eles ajudam a iniciar a interação, fazendo com que os
  usuários se sintam mais confortáveis e incentivando a participação.

- **Definição de contexto**: Os iniciadores definem o tom e o tópico da
  conversa, orientando os usuários sobre como prosseguir.

- **Eficiência**: Ao iniciar com um foco claro, os iniciantes reduzem a
  ambiguidade, permitindo que a conversa progrida suavemente.

- **Retenção do usuário**: Iniciadores bem projetados mantêm os usuários
  interessados, incentivando interações repetidas com a AI.

1.  Abra o arquivo **declarativeAgent.json** e logo após o nó de
    instruções, adicione uma vírgula, pressione Enter e cole o código
    abaixo.

> "conversation_starters": \[
>
> {
>
> "title": "Getting Started",
>
> "text":"I am ready to play the Geo Location Game! Give me a city to
> guess, and start with the first clue."
>
> },
>
> {
>
> "title": "Ready for a Challenge",
>
> "text": "Let us try something different. Can we play a round using the
> travelers diary?"
>
> },
>
> {
>
> "title": "Feeling More Adventurous",
>
> "text": "I am in the mood for a challenge! Can we play the game using
> the historical map? I want to see if I can figure out the city from
> those ancient clues."
>
> }
>
> \]
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image31.png)

Agora que todas as alterações foram feitas no agente, é hora de
testá-lo.

2.  Vá em **Files** na barra superior e clique em **Save All.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

### Tarefa 3: Teste o aplicativo

1.  Para testar o aplicativo, acesse a extensão Teams Toolkit no Visual
    Studio Code. Isso abrirá o painel esquerdo. Em "**LIFECYCLE**",
    selecione "**Provision**". Você pode ver o valor do Teams Toolkit
    aqui, pois ele simplifica muito a publicação.

![](./media/image33.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

2.  Se solicitado, faça login com suas credenciais.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image35.png)

3.  Nesta etapa, o Teams toolkit empacotará todos os arquivos dentro da
    pasta appPackage como um arquivo zip e instalará o agente
    declarativo no seu próprio catálogo de aplicativos .

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

4.  Quando você receber uma mensagem informando que **5/5 actions in
    provision stage executed succedssfully**, o processo estará
    concluído.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image37.png)

5.  Acesse
    +++[https://teams.microsoft.com/v2/+++ ](https://teams.microsoft.com/v2/+++ %20)
    de um navegador e faça login no seu locatário, se solicitado. O novo
    aplicativo será fixado automaticamente acima dos seus chats. Basta
    abrir o Teams, selecione "chats" e você verá o **Copilot**.
    Selecione-o.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

\[!Alerta\] Se você receber uma mensagem informando que o Copilot não
está disponível nesta região no momento, use este link
+++<https://m365.cloud.microsoft/chat/+++> e siga as mesmas etapas para
testar o aplicativo.

5.  Após o carregamento do aplicativo Copilot, localize o +++Geo Locator
    Game+++ no painel à direita, conforme mostrado.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

Se você não conseguir encontrá-lo, a lista pode ser longa e você pode
encontrar seu agente expandindo a lista selecionando "see more".

6.  Após iniciar, você estará nesta janela de chat com o agente. Você
    verá os iniciadores de conversa, conforme marcado abaixo:

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

7.  Selecione um dos iniciadores de conversa e ele preencherá sua caixa
    de mensagem com o prompt inicial, aguardando apenas você pressionar
    "Enter". Ele ainda é apenas o seu assistente e aguardará que você
    tome uma ação.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

8.  Tente responder à pergunta e explorar o jogo que você desenvolveu.

## Resumo

Neste laboratório, aprendemos a criar um agente declarativo usando o
Teams Toolkit e testar a funcionalidade do agente.
