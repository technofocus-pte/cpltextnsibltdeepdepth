# Laboratório 7 - Criar uma Solução com Múltiplos Agentes usando Azure AI Agent Service com Semantic Kernel

Podemos criar agentes de AI voltados para empresas por meio do Azure AI
Agent Service.

**Introdução**

A seguir, apresentamos um cenário de escrita de blog. Este cenário
envolve dois agentes de AI: um para assistência à escrita e o outro para
armazenamento e gerenciamento de conteúdo. Esses agentes podem ser
orquestrados perfeitamente usando o AutoGen ou o Semantic Kernel. Neste
laboratório, estamos usando a Orquestração do Semantic Kernel.

![A diagram of a diagram of a business AI-generated content may be
incorrect.](./media/image1.png)

## Objetivo:

Usando o SDK do Azure AI Foundry, os desenvolvedores podem criar
rapidamente agentes com base no Azure AI Agent Service usando Python ou
C#. As empresas terão diferentes Agentes de AI com base em seus
negócios, então como esses Agentes de AI devem ser combinados no fluxo
de trabalho? Precisamos usar o AutoGen ou o Semantic Kernel para
orquestrar os Agentes de AI. Neste laboratório, usaremos o Semantic
Kernel para desenvolver uma solução multiagente usando o Azure AI Agent
Service.

## Exercício 1: Criar um recurso e projeto do Azure AI Hub

Neste exercício, criaremos o hub no portal do Azure, depois um projeto
no Azure AI Foundry, implementaremos o modelo e criaremos o agente
necessário para a execução.

1.  Em um navegador, abra +++\*\*<https://portal.azure.com/**+++> e faça
    login usando seu **login** **credentials** e selecione **Azure AI
    Foundry** na página **Home**.

    - User name – <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password – <+++@lab.CloudPortalCredential>(User1).Password+++

![image](./media/image2.png)

2.  Selecione **Use with AI Foundry** -\> **AI Hubs**. Selecione **+
    Create** -\> **Hub**.

![image](./media/image3.png)

3.  Insira os detalhes abaixo, aceite os outros padrões e selecione
    **Review + create**.

    - Subscription - Selecione sua **assigned subscription**

    - Resource group - Selecione o grupo de recursos atribuído
      (**ResourceGroup1**)

    - Region - Selecione
      @lab.CloudResourceGroup(ResourceGroup1).Location

    - Name - <+++hub@lab.LabInstance.Id>+++

![image](./media/image4.png)

![image](./media/image5.png)

4.  Após a validação, selecione **Create**.

![image](./media/image6.png)

5.  Quando a implementação estiver concluída, clique em **Go to
    resource**.

![image](./media/image7.png)

6.  Selecione **Launch Azure AI Foundry** na página de recursos do hub.

![image](./media/image8.png)

7.  No recurso do hub iniciado, role para baixo e selecione **+ New
    project**.

![image](./media/image9.png)

![image](./media/image10.png)

8.  Digite o nome como <+++multiagent@lab.LabInstance.Id>+++ e selecione
    **Create**.

![image](./media/image11.png)

9.  **Feche** o pop-up **Explore and experiment**.

![image](./media/image12.png)

10. Você será direcionado para a página do projeto criado.

![image](./media/image13.png)

11. Role a página para baixo e copie o valor da **Project connection
    string** para um bloco de notas.

![image](./media/image14.png)

12. Role para baixo no painel esquerdo e selecione **Management
    center**.

![image](./media/image15.png)

13. Selecione **Connected resources** no recurso Hub e clique em **+ New
    connection** para criar uma conexão com o recurso Azure AI Foundry.

![image](./media/image16.png)

14. Selecione **Azure AI Foundry** nos ativos externos disponíveis.

![image](./media/image17.png)

15. Selecione **Add connection** para adicionar a conexão.

![image](./media/image18.png)

![image](./media/image19.png)

16. Após a conexão, clique em **Close**. Se o botão **Close** não
    estiver visível, reduza o **zoom size** do navegador e selecione
    **Close**.

![image](./media/image20.png)

17. Selecione **Go to project** no painel esquerdo.

![image](./media/image21.png)

18. Na página do projeto, copie os valores da **API Key** e do **Azure
    OpenAI endpoint** e salve-os em um bloco de notas.

![image](./media/image22.png)

19. Selecione **Agents** em **Build and customize** no painel esquerdo.
    Na página **Azure AI Agent Service**, selecione o **Azure OpenAI
    Service** que foi criado e clique em **Let’s go**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

20. Selecione **gpt-4o-mini** e clique em **Confirm**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

21. Aceite o nome da implementação como +++**gpt-4o-mini**+++, selecione
    o tipo de implementação como **Standard**. Aceite os outros padrões
    e clique em **Deploy** para implementar o modelo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

22. Agora, temos os recursos do Azure prontos.

## Exercício 2: Orquestração Multiagente

Neste exercício, configuraremos o Visual Studio Code e instalaremos os
pré-requisitos necessários para a execução.

1.  Na sua VM, abra o **Visual Studio Code**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

2.  Selecione **File** -\> **Open Folder** e selecione a pasta
    **MultiAgent** em **C:\LabFiles** e clique em **Select Folder**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

3.  Selecione **Yes, I trust the authors** no pop-up.

![A screenshot of a computer error AI-generated content may be
incorrect.](./media/image30.png)

4.  Clique com o botão direito do mouse no notebook e selecione **Open
    in Integrated Terminal**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

5.  Execute os comandos abaixo um após o outro para adicionar o **nuget
    source**.

+++dotnet nuget list source+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

> +++dotnet nuget add
> source <https://api.nuget.org/v3/index.json> --name nuget.org+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  Execute o comando abaixo para instalar o dotnet interacrive.

+++dotnet tool install --global Microsoft.dotnet-interactive --version
1.0.556801+++

![](./media/image34.png)

7.  Execute +++pip install jupyter+++ para instalar o Jupyter.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image35.png)

8.  Execute o próximo comando no jupyter interactive.

+++dotnet interactive jupyter install+++

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image36.png)

9.  **Close** o **Terminal**. Selecione **Extensions** no painel
    esquerdo do **Visual Studio Code**. Pesquise e selecione
    +++**Jupyter**+++ e clique em **Install** para instalar a extensão
    Jupyter.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

10. **Close** o Visual Studio Code e **abra-o** novamente.

11. Abra o notebook **AzureAIMultiAgentWithSK.ipynb**. Após aberto,
    clique em **Select Kernel**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

12. Selecione **Jupyter Kernel**.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image39.png)

13. Selecione **.NET (C#) dotnet** no próximo conjunto de opções.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image40.png)

14. Selecione **Allow access** no **Security Alert**.

![A screenshot of a computer security alert AI-generated content may be
incorrect.](./media/image41.png)

15. Execute a primeira célula para **instalar** todos os **packages**.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image42.png)

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image43.png)

16. Execute a próxima célula para importar os namespaces.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image44.png)

17. Na próxima célula, verifique se o valor da variável **deployment** é
    o mesmo da **model deployment** que você criou. Substitua,

    - Endpoint – **Azure OpenAI Endpoint**

    - Key – A **API Key**

Ambos os valores acima foram salvos anteriormente em um bloco de notas
depois que o projeto foi criado no Azure AI Foundry.

Após substituir os valores, **execute** a célula.

Isso define esses valores para variáveis correspondentes a serem usadas
posteriormente.

![A black screen with numbers AI-generated content may be
incorrect.](./media/image45.png)

18. A próxima célula cria uma nova instância **KernelBuilder,** adiciona
    o **Azure OpenAI Chat Completion** com as variáveis da etapa
    anterior como entrada e, ao chamar **Build** (), criando uma
    instância do Kernel.

**Execute-o** para criar a instância do Kernel.

![A screen shot of a computer code AI-generated content may be
incorrect.](./media/image46.png)

19. Execute a próxima célula para instalar os pacotes necessários do
    **Azure** e a próxima célula para importar as referências.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image47.png)

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image48.png)

20. A classe na próxima célula define uma **política de pipeline HTTP
    personalizada para solicitações do SDK** do Azure e adiciona um
    cabeçalho HTTP personalizado (x-ms-enable-preview: true) a cada
    solicitação de saída. **Execute-o**.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image49.png)

## Exercício 3: Salvar Agente de Blog

1.  A próxima célula define a classe **SavePlugin** que implementa um
    método para **salvar conteúdo de blog** usando o **Azure AI Projects
    e o Semantic Kernel**.

    - Recebe o **blog content** como entrada.

    - Interage com **Azure AI Projects** para criar um agente de AI.

    - Gera e executa código Python para **salvar** o **conteúdo** como
      um arquivo **Markdown** (.md).

    - **Baixa** e **armazena** o arquivo gerado localmente.

    - **Retorna** uma mensagem **de confirmação** ("Salvo").

Para executar esta célula, substitua **Your Connection String** pela
**Project Connection String** que você salvou anteriormente em um bloco
de notas. Ela pode ser acessada na página de visão geral do projeto no
portal do Azure AI Foundry.

Clique em **Execute** após substituir a string de conexão.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image50.png)

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image51.png)

2.  A próxima célula inicializa **constantes** com valores específicos
    salvos.  
    **Execute** essa célula. Essas constantes serão usadas nas próximas
    células.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image52.png)

3.  A próxima célula cria um **ChatCompletionAgent** chamado
    **save_blog_agent**. Execute-o para criar o agente.

![A computer screen shot of a computer program AI-generated content may
be incorrect.](./media/image53.png)

## Exercício 4: Agente escritor

1.  Execute a próxima célula no notebook que declara constantes com
    valores específicos do Writer.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image54.png)

2.  A próxima célula cria um **ChatCompletionAgent** chamado
    write-blog_content, que será responsável por escrever uma postagem
    de blog usando os modelos de chat do Microsoft Semantic Kernel e do
    Azure OpenAI. Execute-o para criar o agente.

![A computer screen shot of a black screen AI-generated content may be
incorrect.](./media/image55.png)

3.  O código na próxima célula torna **SavePlugin** disponível como uma
    função dentro de **save_blog_agent**. Cria um **Kernel Plugin** a
    partir do **SavePlugin.** **Adiciona** o plugin ao **Agent's
    Kernel**. A AI aciona a função **SavePlugin.Save** quando detecta
    uma solicitação relacionada ao salvamento.

Execute-o para criar o plugin do kernel.

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image56.png)

4.  A próxima célula contém o código para a classe
    **ApprovalTerminationStrategy**

5.  Esta **estratégia de encerramento personalizada** é usada para
    determinar **quando um agente de AI deve parar de executar**.
    **Execute**.

![A computer screen with text on it AI-generated content may be
incorrect.](./media/image57.png)

6.  A próxima célula contém o código **AgentGroupChat. Isso cria um
    sistema de bate-papo multiagente** onde dois agentes de AI
    (**write_blog_agent** e **save_blog_agent**) colaboram. Usa
    **ApprovalTerminationStrategy** para determinar quando o chat deve
    parar.

Somente **save_blog_agent** pode aprovar o encerramento.

**Execute-o** para configurar o chat multiagente.

![A computer screen shot of a program AI-generated content may be
incorrect.](./media/image58.png)

7.  A próxima célula contém instruções para o agente. **Adiciona uma
    mensagem do usuário ao sistema de chat multiagente**, instruindo a
    AI a **pesquisar informações no GraphRAG, escrever um blog e
    salvá-lo** .

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image59.png)

8.  **Execute** a próxima célula. Isso **itera sobre as respostas
    geradas pela AI** no chat multiagente **à medida que são
    transmitidas**.

Na execução, ele escreve um blog e o salva.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image60.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image61.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

## Resumo

Implementamos um sistema multiagente usando o Azure AI Agent Service com
Semantic Kernel.
