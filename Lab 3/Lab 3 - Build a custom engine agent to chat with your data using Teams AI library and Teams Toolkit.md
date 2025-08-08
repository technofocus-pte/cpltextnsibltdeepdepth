# Laboratório 3: Crie um Agente Personalizado da Contoso para Conversar com Seus Dados Usando a Teams AI Library e o Teams Toolkit

**Tempo estimado: 45 minutos**

## Objetivo

O objetivo deste laboratório é capacitar os participantes a criar um
Agente Contoso personalizado utilizando a Teams AI Library e o Teams
Toolkit. Os participantes configurarão a API do Azure OpenAI para
integrar recursos do GPT, configurarão e gerenciarão dados usando o
Azure OpenAI e o Azure Blob Storage e implementarão um modelo de chat
personalizado, adaptado para interações orientadas por AI. Ao final do
laboratório, eles terão criado e configurado um agente personalizado com
AI do Teams usando o Visual Studio Code e o Teams Toolkit, adquirindo
experiência prática na implementação e no gerenciamento de aplicativos
habilitados para AI.

## Área de Foco da Solução

Este guia de laboratório se concentra em capacitar os participantes a
utilizar a API OpenAI do Azure para criar interações de chat
inteligentes e contextualizadas. Os participantes configurarão modelos
baseados em GPT e os integrarão a serviços do Azure, como o Blob Storage
e o Azure AI Search, para um gerenciamento de dados eficiente.

O laboratório oferece experiência prática na implementação e
personalização de modelos de chat com prompts e configurações
personalizados para atender às necessidades do negócio. Além disso, os
participantes criarão um agente de AI personalizado usando a Biblioteca
de AI do Teams e o Teams Toolkit, integrando-o perfeitamente aos fluxos
de trabalho organizacionais.

## Exercício 1: Configurando a API do Azure OpenAI e permissões de função

### Tarefa 1: Criando uma chave de API do Azure OpenAI para usar o GPT do OpenAI

1.  Abra um navegador, navegue até o seguinte URL +++
    <https://oai.azure.com/portal+++> e faça login usando,

    - Username - <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image1.png)

2.  Na página inicial do **Azure AI Foundry**, clique em **Create new
    Azure OpenAI resource**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image2.png)

3.  A janela **Create Azure OpenAI** será aberta. Se solicitado, faça
    login novamente. Insira as informações abaixo nos campos apropriados
    e clique em **Next**.

[TABLE]

4.  ![A screenshot of a computer AI-generated content may be
    incorrect.](./media/image3.png)

5.  Na aba **Network** e na aba **Tags**, aceite os padrões e clique em
    **Next**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image4.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image5.png)

6.  Na aba **Review + submit,** clique em **Create.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image6.png)

7.  Após a implementação bem-sucedida, a janela navegará automaticamente
    para a página CognitiveServiceOpenAI. Clique em **Go to resource**
    para navegar até a página do Grupo de Recursos.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image7.png)

8.  Selecione o recurso do Azure OpenAI criado. Na página de recursos do
    AzureOpenAI, no painel esquerdo, selecione **Keys and Endpoint** em
    **Resource Management** e copie e **save** os valores de **Key** e
    **Endpoint** em um bloco de notas para referência futura.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

### Tarefa 2: Atribuir função de colaborador cognitivo.

1.  Selecione **ResourceGroup1** para ir para a página de visão geral do
    Grupo de Recursos.

2.  Selecione **Access control (IAM)** no painel esquerdo da página
    Grupo de recursos. Em seguida, selecione **+** **Add** e clique em
    **Add role assignment**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

3.  Pesquise e selecione +++ **cognitive service contributor +++** e
    clique em **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

4.  Clique em **Select members** para atribuir membros. Pesquise por
    <+++@lab.CloudPortalCredential>(User1).Username+++ e clique em
    **Select**. Clique em **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

5.  Na aba **Assignment type**, selecione o tipo de tarefa como
    **Active**, a duração como **Permanent** e clique em **Review
    +Assign** e novamente em **Review + Assign**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

6.  Você receberá uma mensagem de sucesso quando a atribuição da função
    for bem-sucedida.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image15.png)

## Exercício 2: Configure seus dados no Azure OpenAI

### Tarefa 1: Implementar chat no AI Foundary

1.  Selecione o menu de hambúrguer no canto superior esquerdo e clique
    em **All resources**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

2.  Selecione o serviço Azure OpenAI
    [**ContosoAgent@lab.LabInstance.Id**](mailto:ContosoAgent@lab.LabInstance.Id)
    que você criou anteriormente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

3.  Selecione **Go to Azure AI Foundry portal**.

4.  Selecione **Model Catalog** no painel esquerdo.

![image](./media/image18.png)

5.  Na página **Select a chat completion model**, procure por
    +++gpt-4o+++, selecione-o e clique em **Confirm.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

6.  No painel **Deploy model gpt-4o**, expanda a aba **Customize**,
    insira os seguintes detalhes e clique em **Deploy.**

    - **Deployment type**: Standard

    - **Deployment name**: gpt-4o

    - **Token per Minute Rate**: 5K (Role para ajustar o limite. Se não
      funcionar, clique sobre ele e use Shift + seta para a
      direita/esquerda para ajustar o limite)

    - **Content Filter**: defaultv2

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image21.png)

7.  Você pode verificar a implementação em **Shared resources** à
    **Deployments**

\![A screenshot of a computer AI-generated content may be

incorrect.\](./media/image25.png)

### Tarefa 2: Criando uma conta de armazenamento

1.  No portal do Azure, +++ <https://portal.azure.com/+++> Página
    inicial, pesquise e selecione +++Storage accounts+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image22.png)

2.  Clique em **+ Create,** insira os seguintes detalhes e clique em
    **Review + create.**

    - Subscription - Selecione sua assinatura

    - Resource group – Selecione o grupo de recursos atribuído

    - Storage account name - <+++contosostorage@lab.LabInstance.Id>+++

    - Region – Selecione
      @lab.CloudResourceGroup(ResourceGroup1).Location

    - Primary service – Azure Blob storage ou Azure Data Lake Storage
      Gen 2

    - Performance – Standard

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

3.  Clique em **Create** e aguarde a conclusão da implementação e, em
    seguida, clique em **Go to resource**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

4.  Na conta de armazenamento recém-criada, navegue até
    **Containers** em Armazenamento de dados e clique em **+ Container**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

5.  Digite o nome do contêiner como +++**source**+++ e clique em
    **create.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

6.  Clique no contêiner **source** e abra-o.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

7.  Para adicionar dados ao contêiner de origem, clique em
    **Upload** --\_ **Browse for files** e, em C:\Labfiles, selecione
    **TF-AzureOpenAI.pdf.** Depois de selecionar o arquivo, clique no
    botão **upload**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

### Tarefa 3: Criar Azure AI search

1.  No portal do Azure +++<https://portal.azure.com/+++> Página inicial,
    pesquise e selecione +++**AI search**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

2.  Clique em **+ Create** para criar um novo recurso do Azure AI
    Search.

Insira os seguintes detalhes e clique em **Review + create** e depois
selecione **Create**.

- Subscription: selecione sua assinatura

- Resource Group: selecione o grupo de recursos atribuído a você

- Service name: <+++contoso-ai-search-@lab.LabInstance.Id>+++

- Location: @lab.CloudResourceGroup(ResourceGroup1).Location

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

![A screenshot of a search service AI-generated content may be
incorrect.](./media/image35.png)

![A screenshot of a search engine AI-generated content may be
incorrect.](./media/image36.png)

3.  Na visão geral do search-service-contoso-ai-search-01, clique em
    **Go to resource**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

4.  Na visão geral <contoso-ai-search-@lab.LabInstance.Id>, salve o
    endpoint de **URL** para uso futuro. Em seguida, na barra de
    navegação à esquerda, selecione **keys**  em **Settings** e salve o
    **primary** e o **secondary** **key** para uso futuro.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

### Tarefa 4: Adicionar dados ao chat no Azure AI Foundry

1.  Na página **Azure AI Foundry**, selecione **Chat** -\> **Add your
    data -\> Add a data source**.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image40.png)

2.  No menu suspenso, selecione **Azure Blob Storage (preview)**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  Na página **Add data**, insira os seguintes detalhes e clique em
    **Next.**

    - Select data source – Azure Blob Storage(preview)

    - Subscription - Selecione sua assinatura

    - Select Azure Blob storage resource – Selecione
      [**contosostorage@lab.LabInstance.Id**](mailto:contosostorage@lab.LabInstance.Id)

    - Select storage container – Selecione **source**

    - Select Azure AI Search resource – Selecione
      [**contoso-ai-search-@lab.LabInstance.Id**](mailto:contoso-ai-search-@lab.LabInstance.Id)

    - Index Name - Digite <+++contosoindex@lab.LabInstance.Id>+++

    - Indexer schedule - Once

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image42.png)

4.  Na página **Data management**, selecione o tipo de pesquisa como
    **keyword** e clique em **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image43.png)

5.  Na página **Data connection**, selecione **API key** e clique em
    **Next.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image44.png)

6.  Na página **Review and finish**, clique em **Save and close.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image45.png)

7.  A ingestão levará algum tempo. Uma vez concluída, os detalhes dos
    dados serão exibidos no painel. Após a conclusão do processo de
    ingestão de dados, você poderá começar a criar seu agente de
    mecanismo personalizado usando o Teams AI library e o Teams Toolkit.

\[!Nota\] **Nota:** Os arquivos devem estar nos formatos .txt, .md,
.html, .pdf, .docx ou .pptx com limite de tamanho de 16 MB.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image46.png)

## Exercício 3: Criar e configurar seu agente personalizado

### Tarefa 1: Adicionando uma extensão do Teams AI Library

1.  Abra o **Visual Studio Code** no seu PC. Selecione **Trust** para
    remover o modo restrito no Visual Studio Code.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

2.  Na página inicial do VS, no painel de navegação esquerdo, clique no
    ícone **Extensions**, procure por +++ **Teams AI Library**+++ e
    clique em **Install.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image48.png)

3.  Após a conclusão da instalação, selecione o ícone
    ![](./media/image49.png) do Teams AI Library na barra de atividades
    do Visual Studio Code e selecione **Create a New App**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image50.png)

4.  Selecione **Custom Engine Agent**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image51.png)

5.  Selecione **Basic AI Chatbot**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image52.png)

6.  Selecione **JavaScript** como linguagem de programação.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image53.png)

7.  Selecione **Azure OpenAI**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

8.  Insira os valores do portal do Azure, aqueles que copiamos e
    salvamos no bloco de notas.

    - **Azure OpenAI key**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

- **Azure OpenAI endpoint**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image56.png)

- **Deployment name** - +++gpt-4o+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image57.png)

9.  Crie uma nova pasta para conter os dados relacionados às equipes e
    navegue até esse local clicando em **Browse**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image58.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

10. Digite +++**TeamsContosoAgent**+++ como nome do seu agente de
    mecanismo personalizado e selecione **Enter**. O agente de mecanismo
    personalizado será criado em poucos segundos.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

11. Selecione **Yes, I author**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image61.png)

**Examine a estrutura do código-fonte**

Dê uma olhada no que há dentro deste agente de mecanismo personalizado
\> Modelo básico de chatbot de AI.

[TABLE]

### Tarefa 2: Configurar seu agente personalizado

Vamos personalizar o prompt para seu agente de mecanismo personalizado.

1.  Acesse src/prompts/chat/skprompt.txt e substitua o código existente
    pelo código abaixo. Após a atualização, pressione **ctrl+s** para
    salvar o arquivo.

> The following is a conversation with an AI assistant, who is an expert
> on answering questions over the given context.
>
> Responses should be in a short journalistic style with no more than 80
> words.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

2.  Acesse o arquivo **config.json** em prompts/chat. Substitua o código
    existente pelo código a seguir e substitua os valores **endpoint**,
    **index_name** e **key** pelos detalhes do recurso do **Azure AI
    Search**. Após a atualização, pressione **Ctrl+S** para salvar o
    arquivo.

> {
>
> "schema": 1.1,
>
> "description": "A bot that can chat with users",
>
> "type": "completion",
>
> "completion": {
>
> "completion_type": "chat",
>
> "include_history": true,
>
> "include_input": true,
>
> "max_input_tokens": 2800,
>
> "max_tokens": 1000,
>
> "temperature": 0.9,
>
> "top_p": 1.0,
>
> "presence_penalty": 0.6,
>
> "frequency_penalty": 0.0
>
> },
>
> "data_sources": \[
>
> {
>
> "type": "azure_search",
>
> "parameters": {
>
> "endpoint": "AZURE-AI-SEARCH-ENDPOINT",
>
> "index_name": "YOUR-INDEX_NAME",
>
> "authentication": {
>
> "type": "api_key",
>
> "key": "AZURE-AI-SEARCH-KEY"
>
> }
>
> }
>
> }
>
> \]
>
> }

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image63.png)

3.  Vá para o arquivo src/app/app.js e adicione a seguinte variável
    dentro do OpenAIModel – após a entrada azureEndpoint.

+++azureApiVersion: '2024-02-15-preview',+++

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image64.png)

4.  Abra o Powershell como administrador, execute o seguinte comando e
    digite A.

5.  Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image65.png)

6.  De volta ao **Visual Studio Code**, no painel esquerdo, selecione
    **Run and Debug (Ctrl+Shift+D)**. Selecione **Debug in Test Tool**
    para iniciar a depuração.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image66.png)

7.  Selecione **Allow access** se receber um Alerta de Segurança do
    Windows.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image67.png)

8.  O agente de mecanismo personalizado é executado na Ferramenta de
    teste de aplicativo do Teams, que é aberta no seu navegador.

![A black screen with white text AI-generated content may be
incorrect.](./media/image68.png)

9.  O navegador abrirá uma nova aba, a Ferramenta de teste do aplicativo
    Teams, e consultas poderão ser executadas no aplicativo.

![A screenshot of a computer Description automatically
generated](./media/image69.png)

## Conclusão

Ao concluir este laboratório, os participantes adquiriram experiência
prática na criação e implementação de um chatbot personalizado baseado
em AI usando o Teams AI library e o Teams Toolkit. Isso incluiu a
configuração de recursos do Azure OpenAI, a integração de armazenamento
de dados e recursos de pesquisa de AI, e a personalização do chatbot
para interações sensíveis ao contexto. Por meio deste exercício, os
participantes aprenderam a configurar agentes inteligentes adaptados às
necessidades do negócio e a integrá-los aos fluxos de trabalho
organizacionais, aproveitando com eficácia os recursos modernos de AI do
Microsoft Teams.

 
