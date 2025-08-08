# Laboratório 4 - Criar, avaliar e implementar um agente baseado em RAG com o Azure AI Foundry SDK

**Tempo estimado: 120 minutos**

## Objetivo

O objetivo deste laboratório é criar, avaliar e implementar um agente
baseado em Retrieval-Augmented Generation (RAG) usando o SDK do Azure AI
Foundry. O laboratório orienta você na configuração do projeto e do
ambiente de desenvolvimento, na implementação de modelos de AI (por
exemplo, GPT-4 e text-embedding-ada-002), na integração do Azure AI
Search para recuperação de documentos e na criação de um aplicativo de
chat personalizado para recuperação de conhecimento (RAG). O foco é
fundamentar as respostas do modelo de AI com dados relevantes do
produto, desenvolver uma interface de chat personalizada e avaliar o
desempenho das respostas geradas.

## Solução

A solução envolve a configuração de um projeto no Azure AI Foundry, a
implementação de modelos de AI (GPT-4 e text-embedding-ada-002) e a
integração do Azure AI Search para armazenar e recuperar dados
personalizados do produto. Inclui a criação de scripts Python para gerar
embeddings vetoriais, criar índices de pesquisa e consultá-los em busca
de informações relevantes sobre o produto. Uma interface de chat baseada
em RAG é desenvolvida para fornecer respostas fundamentadas,
aproveitando os resultados da pesquisa, e o desempenho do aplicativo de
chat é avaliado usando conjuntos de dados e métricas predefinidos para
aprimorar sua eficácia.

## Exercício 0: Entenda a VM e as credenciais

Neste exercício, identificaremos e entenderemos as credenciais que
usaremos ao longo do laboratório.

**Importante:** Siga cada etapa deste exercício para conhecer os termos
genéricos e as credenciais que serão usadas para a execução do
laboratório.

1.  **Instructions** contém o guia do laboratório com as instruções a
    serem seguidas durante todo o laboratório.

2.  **Resources** contém as credenciais que serão necessárias para
    executar o laboratório.

    - **URL** – URL para o portal do Azure

    - **Subscription** – Este é o **ID** da **assinatura** atribuída a
      você

    - **Username** – O **ID de usuário** com o qual você precisa fazer
      **login** nos **serviços do Azure**.

    - **Password** – **Senha** para o **login do Azure**.

Vamos chamar esse nome de usuário e senha como **Azure login
credentials**. Usaremos essas credenciais sempre que mencionarmos
**Azure login credentials**.

- **Resource Group** – O **grupo de recurso** atribuído a você.

\[!Alerta\] **Importante**: Certifique-se de criar todos os seus
recursos neste grupo de recursos

![A screenshot of a computer Description automatically
generated](./media/image1.png)

3.  A aba **Help** contém informações de suporte. O valor do **ID** aqui
    é o **Lab instance ID** que será usado durante a execução do
    laboratório.

![A screenshot of a computer Description automatically
generated](./media/image2.png)

## Exercício 1: Criar um recurso e projeto do Azure AI Hub

Neste exercício, criaremos o hub no portal do Azure, depois um projeto
no Azure AI Foundry, implementaremos o modelo e criaremos o agente
necessário para a execução.

### Tarefa 1: Criar um Projeto

1.  Em um navegador, abra +++\*\*<https://portal.azure.com/**+++> e faça
    login usando seu **login** **credentials** e selecione **Azure AI
    Foundry** na página **Home**.

    - User name – <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password – <+++@lab.CloudPortalCredential>(User1).Password+++

![image](./media/image3.png)

2.  Selecione **Use with AI Foundry** -\> **AI Hubs**. Selecione **+
    Create** -\> **Hub**.

![image](./media/image4.png)

3.  Insira os detalhes abaixo, aceite os outros padrões e selecione
    **Review + create**.

    - Subscription - Selecione sua **assigned subscription**

    - Resource group - Selecione o grupo de recursos atribuído
      (**ResourceGroup1**)

    - Region - Selecione
      @lab.CloudResourceGroup(ResourceGroup1).Location

    - Name - <+++hub@lab.LabInstance.Id>+++

![image](./media/image5.png)

![image](./media/image6.png)

4.  Após a validação, selecione **Create**.

![image](./media/image7.png)

5.  Quando a implementação estiver concluída, clique em **Go to
    resource**.

![image](./media/image8.png)

6.  Selecione **Launch Azure AI Foundry** na página de recursos do hub.

![image](./media/image9.png)

7.  No recurso do hub que foi aberto, role para baixo e selecione **+
    New project**.

![image](./media/image10.png)

![image](./media/image11.png)

8.  Digite o nome como <+++RAGproj@lab.LabInstance.Id>+++ e selecione
    **Create**.

![image](./media/image12.png)

9.  **Close** o pop-up **Explore and experiment**.

![image](./media/image13.png)

10. Você será direcionado para a página do projeto criado.

![image](./media/image14.png)

11. Role a página para baixo e copie o valor **Project connection
    string** para um bloco de notas.

![image](./media/image15.png)

12. Role para baixo no painel esquerdo e selecione **Management
    center**.

![image](./media/image16.png)

13. Selecione **Connected resources** no recurso Hub e clique em **+ New
    connection** para criar uma conexão com o recurso Azure AI Foundry.

![image](./media/image17.png)

14. Selecione **Azure AI Foundry** nos ativos externos disponíveis.

![image](./media/image18.png)

15. Selecione **Add connection** para adicionar a conexão.

![image](./media/image19.png)

![image](./media/image20.png)

16. Após a conexão, clique em **Close**. Se o botão **Close** não
    estiver visível, reduza o **zoom size** do navegador e selecione
    **Close**.

![image](./media/image21.png)

17. Selecione **Go to project** no painel esquerdo.

![image](./media/image22.png)

18. Na página do projeto, copie os valores da **API Key** e do **Azure
    OpenAI endpoint** e salve-os em um bloco de notas.

![image](./media/image23.png)

19. Agora, temos os recursos do Azure prontos.

### Tarefa 2: Implementar modelos

Você precisa de dois modelos para criar um aplicativo de chat baseado em
RAG: um modelo de chat do Azure OpenAI (gpt-4o-mini) e um modelo de
integração do Azure OpenAI (text-embedding-ada-002). Implemente esses
modelos no seu projeto do Azure AI Foundry, seguindo este conjunto de
etapas para cada modelo.

Essas etapas implementam um modelo em um endpoint em tempo real do
catálogo de modelos do portal AI Foundry

1.  No painel de navegação esquerdo, selecione **Model catalog**.

![](./media/image24.png)

2.  Selecione o modelo +++**gpt-4o-mini**+++ na lista de modelos. Você
    pode usar a barra de pesquisa para encontrá-lo.

![A screenshot of a computer Description automatically
generated](./media/image25.png)

3.  Na página de detalhes do modelo, selecione **Deploy**.

![A screenshot of a computer Description automatically
generated](./media/image26.png)

4.  Mantenha o **Deployment name** padrão. Selecione **Deploy**. Ou, se
    o modelo não estiver disponível na sua região, uma região diferente
    será selecionada para você e conectada ao seu projeto. Nesse caso,
    selecione **Create resource and deploy**.

![A screenshot of a computer Description automatically
generated](./media/image27.png)

![](./media/image28.png)

5.  Após implementar o **gpt-4o-mini**, implemente o modelo
    +++**text-embedding-ada-002**+++. Selecione o **Deployment Type**
    como **Standard**.

![A screenshot of a computer Description automatically
generated](./media/image29.png)

### Tarefa 3: Criar um serviço do Azure AI Search

O objetivo desta aplicação é basear as respostas do modelo em seus dados
personalizados. O índice de pesquisa é usado para recuperar documentos
relevantes com base na pergunta do usuário.

Você precisa de um serviço do Azure AI Search e de uma conexão para
criar um índice de pesquisa.

1.  Efetue login no portal do Azure em
    +++[https://portal.azure.com+++](https://portal.azure.com+++/)
    usando as credenciais de login do Azure.

2.  Na barra de pesquisa da página inicial, procure por +++**AI
    search**+++ e selecione-o.

![A screenshot of a computer Description automatically
generated](./media/image30.png)

3.  Clique no ícone **+ Create** e preencha os seguintes detalhes.

![](./media/image31.png)

4.  Insira os detalhes abaixo e selecione **Review + create**.

    - Subscription – Selecione sua assinatura atribuída

    - Resource Group – Selecione o grupo de recursos atribuído a você

    - Service name – Insira **<+++aisearch@lab.LabInstance.Id>+++**

    - Region - Selecione
      @lab.CloudResourceGroup(ResourceGroup1).Location

    - Pricing tier – Selecione **Standard**

![A screenshot of a computer Description automatically
generated](./media/image32.png)

5.  Revise os detalhes e selecione **Create**.

![A screenshot of a computer Description automatically
generated](./media/image33.png)

6.  Aguarde até que a implementação seja bem-sucedida, como na captura
    de tela abaixo, antes de prosseguir para a próxima etapa.

![A screenshot of a computer Description automatically
generated](./media/image34.png)

### Tarefa 4: Conectar o Azure AI Search ao seu projeto

No portal do Azure AI Foundry, verifique se há um recurso conectado ao
Azure AI Search.

1.  No seu projeto no Azure AI Foundry, selecione **Management center**
    no painel esquerdo.

![A screenshot of a computer Description automatically
generated](./media/image35.png)

2.  Na seção **Connected resources**, selecione **New connection** e, em
    seguida, selecione **Azure AI Search**.

![](./media/image36.png)

![](./media/image37.png)

3.  Selecione **API key** em **Authentication** e selecione **Add
    connection**.

![A screenshot of a search engine Description automatically
generated](./media/image38.png)

![A screenshot of a search engine Description automatically
generated](./media/image39.png)

4.  Na página **Connected resources**, agora você pode ver a conexão do
    recurso adicionado.

![](./media/image40.png)

### Tarefa 5: Instalar a CLI do Azure e fazer login

Instale o Azure CLI e entre no seu ambiente de desenvolvimento local
para poder usar suas credenciais de usuário para chamar o serviço Azure
OpenAI.

1.  Pesquise por +++**PowerShell**+++ na barra de pesquisa do Windows e
    abra-o no modo **Administrator**. Aceite a solicitação para
    continuar a inicialização.

![A screenshot of a computer Description automatically
generated](./media/image41.png)

2.  Abra o Windows PowerShell, cole o comando abaixo e execute-o.

> $ progressPreference = ' silenciosamenteContinuar '$progressPreference
> = 'silentlyContinue'
>
> Write-Host "Installing WinGet PowerShell module from PSGallery..."
>
> Install-PackageProvider -Name NuGet -Force | Out-Null
>
> Install-Module -Name Microsoft.WinGet.Client -Force -Repository
> PSGallery | Out-Null
>
> Write-Host "Using Repair-WinGetPackageManager cmdlet to bootstrap
> WinGet..."
>
> Repair-WinGetPackageManager
>
> Write-Host "Done."

3.  Instale o Azure CLI do seu terminal usando o seguinte comando:

> +++winget install -e --id Microsoft.AzureCLI+++

Selecione **Y** e depois **Enter** quando solicitado a aceitar.

![A screenshot of a computer Description automatically
generated](./media/image42.png)

![](./media/image43.png)

![](./media/image44.png)

4.  Depois de instalar o Azure CLI, entre usando o comando az login e
    entre usando o navegador:

> +++ login az +++

Selecione **Work or school account** e clique em **Continue**.

![A screenshot of a computer screen Description automatically
generated](./media/image45.png)

5.  Efetue login com suas **Azure login credentials**.

![A computer screen shot of a program Description automatically
generated](./media/image46.png)

6.  Digite **1** para **Select a subscription** e clique em **Enter**.

![A screenshot of a computer Description automatically
generated](./media/image47.png)

### Tarefa 6: Criar um novo ambiente Python

Primeiro, você precisa criar um novo ambiente Python para instalar o
pacote necessário para este tutorial. NÃO instale pacotes na sua
instalação global do Python. Você deve sempre usar um ambiente virtual
ou conda ao instalar pacotes Python, caso contrário, poderá interromper
a instalação global do Python.

\[!Alerta\] **Importante:** Se os comandos abaixo não puderem ser
colados, tente colá-los em um bloco de notas e depois copiá-los e
colá-los no PowerShell. Ou copie e cole diretamente no PowerShell. O
botão T às vezes não funciona no PowerShell.

**Crie um ambiente virtual**

1.  No seu Power Shell, navegue até **C:\Users\Admin** executando os
    comandos abaixo.

cd\\

cd Users\Admin

2.  Crie uma pasta com o nome do seu projeto,
    [**RAGproj@lab.LabInstance.Id**](mailto:RAGproj@lab.LabInstance.Id),
    digitando o seguinte comando no seu PowerShell.

> mkdir RAGproj@lab.LabInstance.Id

![A computer screen with white and green text Description automatically
generated](./media/image48.png)

3.  No seu terminal digite o seguinte comando para navegar até o novo
    local da pasta

> cd RAGproj@lab.LabInstance.Id

![A blue screen with white text Description automatically
generated](./media/image49.png)

4.  Crie um ambiente virtual usando os seguintes comandos

> py -3 -m venv .venv
>
> .venv\scripts\activate

![A computer screen shot of a code Description automatically
generated](./media/image50.png)

Ativar o ambiente Python significa que quando você executa python ou pip
na linha de comando, você usa o interpretador Python contido na pasta.
venv do seu aplicativo.

5.  Abra o **VS Code**. Selecione **File -\> Open Folder** e selecione a
    pasta **RAGproject** que criamos nos passos anteriores (em
    **C:\Usuários\Admin**).

Observação: Clique em **Yes**, confio na pasta e no conteúdo e prossiga
se solicitado.

![A screenshot of a computer Description automatically
generated](./media/image51.png)

![A screenshot of a computer Description automatically
generated](./media/image52.png)

![A screenshot of a computer Description automatically
generated](./media/image53.png)

6.  Selecione **Yes, I trust the authors** quando for exibida a mensagem
    **Do** **you trust the authors of the files in this folder?**

### Tarefa 7: Instalar pacotes

Instale azure-ai-projects(preview) e azure-ai-inference (preview),
juntamente com outros pacotes necessários.

1.  Crie um arquivo chamado +++**requirements.txt**+++ na sua pasta
    **Project** e adicione os seguintes pacotes ao arquivo:

> azure-ai-projects==1.0.0b10
>
> azure-ai-inference\[prompts\]
>
> azure-identity
>
> azure-search-documents
>
> pandas
>
> python-dotenv
>
> opentelemetry-api
>
> marshmallow==3.23.2

![](./media/image54.png)

![](./media/image55.png)

2.  Na barra de navegação superior, clique em **File** e **Save All**.

3.  Clique com o botão direito do mouse em requirements.txt e selecione
    **Open in Integrated Terminal**.

![](./media/image56.png)

![A screenshot of a computer Description automatically
generated](./media/image57.png)

4.  Execute o seguinte comando para entrar no ambiente virtual

> +++py -3 -m venv .venv+++
>
> +++.venv\scripts\activate+++

![A screenshot of a computer Description automatically
generated](./media/image58.png)

5.  Execute o comando +++az login+++ e faça login com suas credenciais
    de login do Azure. Selecione **1** para selecionar a assinatura.

**Observação:** Minimize o VS Code para visualizar o prompt de login,
caso não esteja visível automaticamente.

![A screenshot of a computer Description automatically
generated](./media/image59.png)

![A screenshot of a computer Description automatically
generated](./media/image60.png)

6.  Para instalar os pacotes necessários, execute o seguinte código.

+++pip install -r requirements.txt+++

![A screenshot of a computer Description automatically
generated](./media/image61.png)

![A screenshot of a computer Description automatically
generated](./media/image62.png)

**Observação:** Se você receber um aviso sobre uma nova versão do pip,
execute os comandos abaixo para atualizar o pip

+++pip install -r requirements.txt+++

+++python.exe -m pip install --upgrade pip+++

![A screenshot of a computer program Description automatically
generated](./media/image63.png)

### Tarefa 8: Criar script auxiliar

1.  Crie uma nova pasta chamada **src**. Execute o seguinte comando no
    terminal.

+++mkdir src+++

![A screenshot of a computer Description automatically
generated](./media/image64.png)

2.  Crie um novo arquivo na pasta **src** e nomeie-o +++**config.py**+++

![A screenshot of a computer Description automatically
generated](./media/image65.png)

3.  Adicione o seguinte código ao **config.py** e salve-o.

> \# ruff: noqa: ANN201, ANN001
>
> import os
>
> import sys
>
> import pathlib
>
> import logging
>
> from azure.identity import DefaultAzureCredential
>
> from azure.ai.projects import AIProjectClient
>
> from azure.ai.inference.tracing import AIInferenceInstrumentor
>
> \# load environment variables from the .env file
>
> from dotenv import load_dotenv
>
> load_dotenv()
>
> \# Set "./assets" as the path where assets are stored, resolving the
> absolute path:
>
> ASSET_PATH = pathlib.Path(\_\_file\_\_).parent.resolve() / "assets"
>
> \# Configure an root app logger that prints info level logs to stdout
>
> logger = logging.getLogger("app")
>
> logger.setLevel(logging.INFO)
>
> logger.addHandler(logging.StreamHandler(stream=sys.stdout))
>
> \# Returns a module-specific logger, inheriting from the root app
> logger
>
> def get_logger(module_name):
>
> return logging.getLogger(f"app.{module_name}")
>
> \# Enable instrumentation and logging of telemetry to the project
>
> def enable_telemetry(log_to_project: bool = False):
>
> AIInferenceInstrumentor().instrument()
>
> \# enable logging message contents
>
> os.environ\["AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED"\] =
> "true"
>
> if log_to_project:
>
> from azure.monitor.opentelemetry import configure_azure_monitor
>
> project = AIProjectClient.from_connection_string(
>
> conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
> credential=DefaultAzureCredential()
>
> )
>
> tracing_link =
> f"https://ai.azure.com/tracing?wsid=/subscriptions/{project.scope\['subscription_id'\]}/resourceGroups/{project.scope\['resource_group_name'\]}/providers/Microsoft.MachineLearningServices/workspaces/{project.scope\['project_name'\]}"
>
> application_insights_connection_string =
> project.telemetry.get_connection_string()
>
> if not application_insights_connection_string:
>
> logger.warning(
>
> "No application insights configured, telemetry will not be logged to
> project. Add application insights at:"
>
> )
>
> logger.warning(tracing_link)
>
> return
>
> configure_azure_monitor(connection_string=application_insights_connection_string)
>
> logger.info("Enabled telemetry logging to project, view traces at:")
>
> logger.info(tracing_link)

![A screenshot of a computer Description automatically
generated](./media/image66.png)

**Observação:** Este arquivo de script config.py recém-criado será usado
no próximo exercício.

### Tarefa 9: Configurar variáveis de ambiente

A string de conexão do seu projeto é necessária para chamar o serviço
Azure OpenAI a partir do seu código. Neste início rápido , você salva
esse valor em um arquivo .env, que contém variáveis de ambiente que seu
aplicativo pode ler.

1.  Crie um novo arquivo **+++.env+++** no diretório **src** e cole o
    seguinte código:

Substitua **\< your-connection-string \>** pelo valor da string de
conexão do projeto salvo no bloco de notas na tarefa 1.

> AIPROJECT_CONNECTION_STRING="\<your-connection-string\>"
>
> AISEARCH_INDEX_NAME="example-index"
>
> EMBEDDINGS_MODEL="text-embedding-ada-002"
>
> INTENT_MAPPING_MODEL="gpt-4o-mini"
>
> CHAT_MODEL="gpt-4o-mini"
>
> EVALUATION_MODEL="gpt-4o-mini"

![](./media/image67.png)

**Observação**: Sua sequência de conexão pode ser encontrada na página
inicial do projeto Azure AI Foundry em **Overview**.

## Exercício 2: Crie um aplicativo personalizado de recuperação de conhecimento (RAG) com o SDK do Azure AI Foundry

### Tarefa 1: Crie dados de exemplo para seu aplicativo de chat

O objetivo deste aplicativo baseado em RAG é basear as respostas do
modelo em seus dados personalizados. Você usa um índice de Azure AI
Search que armazena dados vetorizados do modelo de integração. O índice
de pesquisa é usado para recuperar documentos relevantes com base na
pergunta do usuário.

1.  Na configuração do VS Code aberta, crie uma pasta chamada
    +++**assets**+++ na pasta **src**.

![A screenshot of a computer Description automatically
generated](./media/image68.png)

2.  Copie o arquivo **products.csv** de **C:\LabFiles** e cole-o na
    pasta **C:\Users\Admin\< Your Project Name\>\src\assets**.

Observação: Isso precisa ser feito no Explorador de Arquivos e então
será refletido no VS Code.

![A screenshot of a computer Description automatically
generated](./media/image69.png)

3.  Navegue até **File** na barra de navegação superior e clique em
    **Save All.**

![A screenshot of a computer Description automatically
generated](./media/image70.png)

### Tarefa 2: Criar um índice de pesquisa

O índice de pesquisa é usado para armazenar dados vetorizados do modelo
de integração. O índice de pesquisa é usado para recuperar documentos
relevantes com base na pergunta do usuário.

1.  No código VS, crie um arquivo chamado
    +++**create_search_index.py**+++ na sua pasta **src**.

![A screenshot of a computer Description automatically
generated](./media/image71.png)

2.  Abra o arquivo criado, **create_search_index.py** e adicione o
    seguinte código para importar as bibliotecas necessárias, criar um
    cliente de projeto e configurar algumas definições:

> import os
>
> from azure.ai.projects import AIProjectClient
>
> from azure.ai.projects.models import ConnectionType
>
> from azure.identity import DefaultAzureCredential
>
> from azure.core.credentials import AzureKeyCredential
>
> from azure.search.documents import SearchClient
>
> from azure.search.documents.indexes import SearchIndexClient
>
> from config import get_logger
>
> \# initialize logging object
>
> logger = get_logger(\_\_name\_\_)
>
> \# create a project client using environment variables loaded from the
> .env file
>
> project = AIProjectClient.from_connection_string(
>
> conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
> credential=DefaultAzureCredential()
>
> )
>
> \# create a vector embeddings client that will be used to generate
> vector embeddings
>
> embeddings = project.inference.get_embeddings_client()
>
> \# use the project client to get the default search connection
>
> search_connection = project.connections.get_default(
>
> connection_type=ConnectionType.AZURE_AI_SEARCH,
> include_credentials=True
>
> )
>
> \# Create a search index client using the search connection
>
> \# This client will be used to create and delete search indexes
>
> index_client = SearchIndexClient(
>
> endpoint=search_connection.endpoint_url,
> credential=AzureKeyCredential(key=search_connection.key)
>
> )

![A screenshot of a computer Description automatically
generated](./media/image72.png)

3.  Agora adicione a função no final do **create_search_index.py** para
    definir um índice de pesquisa:

Mantenha o cursor no final do arquivo, selecione **Enter** duas vezes e
cole o código abaixo.

> import pandas as pd
>
> from azure.search.documents.indexes.models import (
>
> SemanticSearch,
>
> SearchField,
>
> SimpleField,
>
> SearchableField,
>
> SearchFieldDataType,
>
> SemanticConfiguration,
>
> SemanticPrioritizedFields,
>
> SemanticField,
>
> VectorSearch,
>
> HnswAlgorithmConfiguration,
>
> VectorSearchAlgorithmKind,
>
> HnswParameters,
>
> VectorSearchAlgorithmMetric,
>
> ExhaustiveKnnAlgorithmConfiguration,
>
> ExhaustiveKnnParameters,
>
> VectorSearchProfile,
>
> SearchIndex,
>
> )
>
> def create_index_definition(index_name: str, model: str) -\>
> SearchIndex:
>
> dimensions = 1536 \# text-embedding-ada-002
>
> if model == "text-embedding-3-large":
>
> dimensions = 3072
>
> \# The fields we want to index. The "embedding" field is a vector
> field that will
>
> \# be used for vector search.
>
> fields = \[
>
> SimpleField(name="id", type=SearchFieldDataType.String, key=True),
>
> SearchableField(name="content", type=SearchFieldDataType.String),
>
> SimpleField(name="filepath", type=SearchFieldDataType.String),
>
> SearchableField(name="title", type=SearchFieldDataType.String),
>
> SimpleField(name="url", type=SearchFieldDataType.String),
>
> SearchField(
>
> name="contentVector",
>
> type=SearchFieldDataType.Collection(SearchFieldDataType.Single),
>
> searchable=True,
>
> \# Size of the vector created by the text-embedding-ada-002 model.
>
> vector_search_dimensions=dimensions,
>
> vector_search_profile_name="myHnswProfile",
>
> ),
>
> \]
>
> \# The "content" field should be prioritized for semantic ranking.
>
> semantic_config = SemanticConfiguration(
>
> name="default",
>
> prioritized_fields=SemanticPrioritizedFields(
>
> title_field=SemanticField(field_name="title"),
>
> keywords_fields=\[\],
>
> content_fields=\[SemanticField(field_name="content")\],
>
> ),
>
> )
>
> \# For vector search, we want to use the HNSW (Hierarchical Navigable
> Small World)
>
> \# algorithm (a type of approximate nearest neighbor search algorithm)
> with cosine
>
> \# distance.
>
> vector_search = VectorSearch(
>
> algorithms=\[
>
> HnswAlgorithmConfiguration(
>
> name="myHnsw",
>
> kind=VectorSearchAlgorithmKind.HNSW,
>
> parameters=HnswParameters(
>
> m=4,
>
> ef_construction=1000,
>
> ef_search=1000,
>
> metric=VectorSearchAlgorithmMetric.COSINE,
>
> ),
>
> ),
>
> ExhaustiveKnnAlgorithmConfiguration(
>
> name="myExhaustiveKnn",
>
> kind=VectorSearchAlgorithmKind.EXHAUSTIVE_KNN,
>
> parameters=ExhaustiveKnnParameters(metric=VectorSearchAlgorithmMetric.COSINE),
>
> ),
>
> \],
>
> profiles=\[
>
> VectorSearchProfile(
>
> name="myHnswProfile",
>
> algorithm_configuration_name="myHnsw",
>
> ),
>
> VectorSearchProfile(
>
> name="myExhaustiveKnnProfile",
>
> algorithm_configuration_name="myExhaustiveKnn",
>
> ),
>
> \],
>
> )
>
> \# Create the semantic settings with the configuration
>
> semantic_search = SemanticSearch(configurations=\[semantic_config\])
>
> \# Create the search index definition
>
> return SearchIndex(
>
> name=index_name,
>
> fields=fields,
>
> semantic_search=semantic_search,
>
> vector_search=vector_search,
>
> )

![A screenshot of a computer Description automatically
generated](./media/image73.png)

4.  Agora adicione a função em create_search_index.py para criar a
    função para adicionar um arquivo csv ao índice.

Mantenha o cursor no final do arquivo, selecione **Enter** duas vezes e
cole o código abaixo.

> \# define a function for indexing a csv file, that adds each row as a
> document
>
> \# and generates vector embeddings for the specified content_column
>
> def create_docs_from_csv(path: str, content_column: str, model: str)
> -\> list\[dict\[str, any\]\]:
>
> products = pd.read_csv(path)
>
> items = \[\]
>
> for product in products.to_dict("records"):
>
> content = product\[content_column\]
>
> id = str(product\["id"\])
>
> title = product\["name"\]
>
> url = f"/products/{title.lower().replace(' ', '-')}"
>
> emb = embeddings.embed(input=content, model=model)
>
> rec = {
>
> "id": id,
>
> "content": content,
>
> "filepath": f"{title.lower().replace(' ', '-')}",
>
> "title": title,
>
> "url": url,
>
> "contentVector": emb.data\[0\].embedding,
>
> }
>
> items.append(rec)
>
> return items
>
> def create_index_from_csv(index_name, csv_file):
>
> \# If a search index already exists, delete it:
>
> try:
>
> index_definition = index_client.get_index(index_name)
>
> index_client.delete_index(index_name)
>
> logger.info(f"🗑️ Found existing index named '{index_name}', and
> deleted it")
>
> except Exception:
>
> pass
>
> \# create an empty search index
>
> index_definition = create_index_definition(index_name,
> model=os.environ\["EMBEDDINGS_MODEL"\])
>
> index_client.create_index(index_definition)
>
> \# create documents from the products.csv file, generating vector
> embeddings for the "description" column
>
> docs = create_docs_from_csv(path=csv_file,
> content_column="description", model=os.environ\["EMBEDDINGS_MODEL"\])
>
> \# Add the documents to the index using the Azure AI Search client
>
> search_client = SearchClient(
>
> endpoint=search_connection.endpoint_url,
>
> index_name=index_name,
>
> credential=AzureKeyCredential(key=search_connection.key),
>
> )
>
> search_client.upload_documents(docs)
>
> logger.info(f"➕ Uploaded {len(docs)} documents to '{index_name}'
> index")

![A screenshot of a computer Description automatically
generated](./media/image74.png)

5.  Por fim, adicione as funções abaixo no arquivo
    create_search_index.py para construir o índice e registrá-lo no
    projeto na nuvem. Após adicionar o código, vá até Arquivos na barra
    superior e clique em **Save all.**

Mantenha o cursor no final do arquivo, pressione **Enter** duas vezes.
Mova o cursor na nova linha em direção à margem esquerda e cole o
código. (Não deve haver espaço de tabulação)

\[!Alerta\] **Importante:** Certifique-se de que o **import argparse**
na segunda linha do código abaixo esteja alinhado com um espaço de
tabulação a partir da margem. Caso contrário, mantenha o cursor antes de
**import** e clique em **Tab**.

> if \_\_name\_\_ == "\_\_main\_\_":
>
> import argparse
>
> parser = argparse.ArgumentParser()
>
> parser.add_argument(
>
> "--index-name",
>
> type=str,
>
> help="index name to use when creating the AI Search index",
>
> default=os.environ\["AISEARCH_INDEX_NAME"\],
>
> )
>
> parser.add_argument(
>
> "--csv-file", type=str, help="path to data for creating search index",
> default="assets/products.csv"
>
> )
>
> args = parser.parse_args()
>
> index_name = args.index_name
>
> csv_file = args.csv_file
>
> create_index_from_csv(index_name, csv_file)

![](./media/image75.png)

6.  O arquivo agora deve ter o conteúdo abaixo.

> import os
>
> from azure.ai.projects import AIProjectClient
>
> from azure.ai.projects.models import ConnectionType
>
> from azure.identity import DefaultAzureCredential
>
> from azure.core.credentials import AzureKeyCredential
>
> from azure.search.documents import SearchClient
>
> from azure.search.documents.indexes import SearchIndexClient
>
> from config import get_logger
>
> \# initialize logging object
>
> logger = get_logger(\_\_name\_\_)
>
> \# create a project client using environment variables loaded from the
> .env file
>
> project = AIProjectClient.from_connection_string(
>
> conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
> credential=DefaultAzureCredential()
>
> )
>
> \# create a vector embeddings client that will be used to generate
> vector embeddings
>
> embeddings = project.inference.get_embeddings_client()
>
> \# use the project client to get the default search connection
>
> search_connection = project.connections.get_default(
>
> connection_type=ConnectionType.AZURE_AI_SEARCH,
> include_credentials=True
>
> )
>
> \# Create a search index client using the search connection
>
> \# This client will be used to create and delete search indexes
>
> index_client = SearchIndexClient(
>
> endpoint=search_connection.endpoint_url,
> credential=AzureKeyCredential(key=search_connection.key)
>
> )
>
> import pandas as pd
>
> from azure.search.documents.indexes.models import (
>
> SemanticSearch,
>
> SearchField,
>
> SimpleField,
>
> SearchableField,
>
> SearchFieldDataType,
>
> SemanticConfiguration,
>
> SemanticPrioritizedFields,
>
> SemanticField,
>
> VectorSearch,
>
> HnswAlgorithmConfiguration,
>
> VectorSearchAlgorithmKind,
>
> HnswParameters,
>
> VectorSearchAlgorithmMetric,
>
> ExhaustiveKnnAlgorithmConfiguration,
>
> ExhaustiveKnnParameters,
>
> VectorSearchProfile,
>
> SearchIndex,
>
> )
>
> def create_index_definition(index_name: str, model: str) -\>
> SearchIndex:
>
> dimensions = 1536 \# text-embedding-ada-002
>
> if model == "text-embedding-3-large":
>
> dimensions = 3072
>
> \# The fields we want to index. The "embedding" field is a vector
> field that will
>
> \# be used for vector search.
>
> fields = \[
>
> SimpleField(name="id", type=SearchFieldDataType.String, key=True),
>
> SearchableField(name="content", type=SearchFieldDataType.String),
>
> SimpleField(name="filepath", type=SearchFieldDataType.String),
>
> SearchableField(name="title", type=SearchFieldDataType.String),
>
> SimpleField(name="url", type=SearchFieldDataType.String),
>
> SearchField(
>
> name="contentVector",
>
> type=SearchFieldDataType.Collection(SearchFieldDataType.Single),
>
> searchable=True,
>
> \# Size of the vector created by the text-embedding-ada-002 model.
>
> vector_search_dimensions=dimensions,
>
> vector_search_profile_name="myHnswProfile",
>
> ),
>
> \]
>
> \# The "content" field should be prioritized for semantic ranking.
>
> semantic_config = SemanticConfiguration(
>
> name="default",
>
> prioritized_fields=SemanticPrioritizedFields(
>
> title_field=SemanticField(field_name="title"),
>
> keywords_fields=\[\],
>
> content_fields=\[SemanticField(field_name="content")\],
>
> ),
>
> )
>
> \# For vector search, we want to use the HNSW (Hierarchical Navigable
> Small World)
>
> \# algorithm (a type of approximate nearest neighbor search algorithm)
> with cosine
>
> \# distance.
>
> vector_search = VectorSearch(
>
> algorithms=\[
>
> HnswAlgorithmConfiguration(
>
> name="myHnsw",
>
> kind=VectorSearchAlgorithmKind.HNSW,
>
> parameters=HnswParameters(
>
> m=4,
>
> ef_construction=1000,
>
> ef_search=1000,
>
> metric=VectorSearchAlgorithmMetric.COSINE,
>
> ),
>
> ),
>
> ExhaustiveKnnAlgorithmConfiguration(
>
> name="myExhaustiveKnn",
>
> kind=VectorSearchAlgorithmKind.EXHAUSTIVE_KNN,
>
> parameters=ExhaustiveKnnParameters(metric=VectorSearchAlgorithmMetric.COSINE),
>
> ),
>
> \],
>
> profiles=\[
>
> VectorSearchProfile(
>
> name="myHnswProfile",
>
> algorithm_configuration_name="myHnsw",
>
> ),
>
> VectorSearchProfile(
>
> name="myExhaustiveKnnProfile",
>
> algorithm_configuration_name="myExhaustiveKnn",
>
> ),
>
> \],
>
> )
>
> \# Create the semantic settings with the configuration
>
> semantic_search = SemanticSearch(configurations=\[semantic_config\])
>
> \# Create the search index definition
>
> return SearchIndex(
>
> name=index_name,
>
> fields=fields,
>
> semantic_search=semantic_search,
>
> vector_search=vector_search,
>
> )
>
> \# define a function for indexing a csv file, that adds each row as a
> document
>
> \# and generates vector embeddings for the specified content_column
>
> def create_docs_from_csv(path: str, content_column: str, model: str)
> -\> list\[dict\[str, any\]\]:
>
> products = pd.read_csv(path)
>
> items = \[\]
>
> for product in products.to_dict("records"):
>
> content = product\[content_column\]
>
> id = str(product\["id"\])
>
> title = product\["name"\]
>
> url = f"/products/{title.lower().replace(' ', '-')}"
>
> emb = embeddings.embed(input=content, model=model)
>
> rec = {
>
> "id": id,
>
> "content": content,
>
> "filepath": f"{title.lower().replace(' ', '-')}",
>
> "title": title,
>
> "url": url,
>
> "contentVector": emb.data\[0\].embedding,
>
> }
>
> items.append(rec)
>
> return items
>
> def create_index_from_csv(index_name, csv_file):
>
> \# If a search index already exists, delete it:
>
> try:
>
> index_definition = index_client.get_index(index_name)
>
> index_client.delete_index(index_name)
>
> logger.info(f"🗑️ Found existing index named '{index_name}', and
> deleted it")
>
> except Exception:
>
> pass
>
> \# create an empty search index
>
> index_definition = create_index_definition(index_name,
> model=os.environ\["EMBEDDINGS_MODEL"\])
>
> index_client.create_index(index_definition)
>
> \# create documents from the products.csv file, generating vector
> embeddings for the "description" column
>
> docs = create_docs_from_csv(path=csv_file,
> content_column="description", model=os.environ\["EMBEDDINGS_MODEL"\])
>
> \# Add the documents to the index using the Azure AI Search client
>
> search_client = SearchClient(
>
> endpoint=search_connection.endpoint_url,
>
> index_name=index_name,
>
> credential=AzureKeyCredential(key=search_connection.key),
>
> )
>
> search_client.upload_documents(docs)
>
> logger.info(f"➕ Uploaded {len(docs)} documents to '{index_name}'
> index")
>
> if \_\_name\_\_ == "\_\_main\_\_":
>
> import argparse
>
> parser = argparse.ArgumentParser()
>
> parser.add_argument(
>
> "--index-name",
>
> type=str,
>
> help="index name to use when creating the AI Search index",
>
> default=os.environ\["AISEARCH_INDEX_NAME"\],
>
> )
>
> parser.add_argument(
>
> "--csv-file", type=str, help="path to data for creating search index",
> default="assets/products.csv"
>
> )
>
> args = parser.parse_args()
>
> index_name = args.index_name
>
> csv_file = args.csv_file
>
> create_index_from_csv(index_name, csv_file)

6.  Clique com o botão direito do mouse em **create_search_index.py** e
    selecione a opção **Open in integrated terminal**

![](./media/image76.png)

7.  No seu terminal, faça login na sua credencial de login do Azure e
    siga as instruções para autenticar sua conta:

+++az login+++

![](./media/image77.png)

![](./media/image78.png)

8.  Execute o código para criar seu índice localmente e registrá-lo no
    projeto de nuvem:

+++python create_search_index.py+++

![](./media/image79.png)

9.  Depois que o script for executado, você poderá visualizar o índice
    recém-criado no portal do Azure.

10. Navegue até o **Resource Group -\> Your search service
    created(aisearchLabinstanceID) -\> Search management -\> Indexes**.

![A screenshot of a computer Description automatically
generated](./media/image80.png)

11. Se você executar o script novamente com o mesmo nome de índice, ele
    criará uma nova versão do mesmo índice.

### Tarefa 3: Obter documentos do produto

Em seguida, crie um script para obter documentos do produto no índice de
pesquisa. O script consulta o índice de pesquisa em busca de documentos
que correspondam à pergunta do usuário.

**Crie um script para obter documentos do produto**

Quando o chat recebe uma solicitação, ele pesquisa seus dados para
encontrar informações relevantes. Este script usa o SDK do Azure AI para
consultar o índice de pesquisa em busca de documentos que correspondam à
pergunta do usuário. Em seguida, retorna os documentos para o aplicativo
de chat.

1.  No VS Code, crie um arquivo chamado
    +++**get_product_documents.py**+++ na pasta **src**.

![A screenshot of a computer Description automatically
generated](./media/image81.png)

2.  Copie e cole o código a seguir no arquivo. Comece com o código para
    importar as bibliotecas necessárias, criar um cliente de projeto e
    definir as configurações.

> import os
>
> from pathlib import Path
>
> from opentelemetry import trace
>
> from azure.ai.projects import AIProjectClient
>
> from azure.ai.projects.models import ConnectionType
>
> from azure.identity import DefaultAzureCredential
>
> from azure.core.credentials import AzureKeyCredential
>
> from azure.search.documents import SearchClient
>
> from config import ASSET_PATH, get_logger
>
> \# initialize logging and tracing objects
>
> logger = get_logger(\_\_name\_\_)
>
> tracer = trace.get_tracer(\_\_name\_\_)
>
> \# create a project client using environment variables loaded from the
> .env file
>
> project = AIProjectClient.from_connection_string(
>
> conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
> credential=DefaultAzureCredential()
>
> )
>
> \# create a vector embeddings client that will be used to generate
> vector embeddings
>
> chat = project.inference.get_chat_completions_client()
>
> embeddings = project.inference.get_embeddings_client()
>
> \# use the project client to get the default search connection
>
> search_connection = project.connections.get_default(
>
> connection_type=ConnectionType.AZURE_AI_SEARCH,
> include_credentials=True
>
> )
>
> \# Create a search index client using the search connection
>
> \# This client will be used to create and delete search indexes
>
> search_client = SearchClient(
>
> index_name=os.environ\["AISEARCH_INDEX_NAME"\],
>
> endpoint=search_connection.endpoint_url,
>
> credential=AzureKeyCredential(key=search_connection.key),
>
> )

3.  Adicione a função em get_product-documents.py para **get product
    documents**.

> from azure.ai.inference.prompts import PromptTemplate
>
> from azure.search.documents.models import VectorizedQuery
>
> @tracer.start_as_current_span(name="get_product_documents")
>
> def get_product_documents(messages: list, context: dict = None) -\>
> dict:
>
> if context is None:
>
> context = {}
>
> overrides = context.get("overrides", {})
>
> top = overrides.get("top", 5)
>
> \# generate a search query from the chat messages
>
> intent_prompty = PromptTemplate.from_prompty(Path(ASSET_PATH) /
> "intent_mapping.prompty")
>
> intent_mapping_response = chat.complete(
>
> model=os.environ\["INTENT_MAPPING_MODEL"\],
>
> messages=intent_prompty.create_messages(conversation=messages),
>
> \*\*intent_prompty.parameters,
>
> )
>
> search_query = intent_mapping_response.choices\[0\].message.content
>
> logger.debug(f"🧠 Intent mapping: {search_query}")
>
> \# generate a vector representation of the search query
>
> embedding = embeddings.embed(model=os.environ\["EMBEDDINGS_MODEL"\],
> input=search_query)
>
> search_vector = embedding.data\[0\].embedding
>
> \# search the index for products matching the search query
>
> vector_query = VectorizedQuery(vector=search_vector,
> k_nearest_neighbors=top, fields="contentVector")
>
> search_results = search_client.search(
>
> search_text=search_query, vector_queries=\[vector_query\],
> select=\["id", "content", "filepath", "title", "url"\]
>
> )
>
> documents = \[
>
> {
>
> "id": result\["id"\],
>
> "content": result\["content"\],
>
> "filepath": result\["filepath"\],
>
> "title": result\["title"\],
>
> "url": result\["url"\],
>
> }
>
> for result in search_results
>
> \]
>
> \# add results to the provided context
>
> if "thoughts" not in context:
>
> context\["thoughts"\] = \[\]
>
> \# add thoughts and documents to the context object so it can be
> returned to the caller
>
> context\["thoughts"\].append(
>
> {
>
> "title": "Generated search query",
>
> "description": search_query,
>
> }
>
> )
>
> if "grounding_data" not in context:
>
> context\["grounding_data"\] = \[\]
>
> context\["grounding_data"\].append(documents)
>
> logger.debug(f"📄 {len(documents)} documents retrieved: {documents}")
>
> return documents

4.  Por fim, adicione código para **testar a função** ao executar o
    script diretamente:

> if \_\_name\_\_ == "\_\_main\_\_":
>
> import logging
>
> import argparse
>
> \# set logging level to debug when running this module directly
>
> logger.setLevel(logging.DEBUG)
>
> \# load command line arguments
>
> parser = argparse.ArgumentParser()
>
> parser.add_argument(
>
> "--query",
>
> type=str,
>
> help="Query to use to search product",
>
> default="I need a new tent for 4 people, what would you recommend?",
>
> )
>
> args = parser.parse_args()
>
> query = args.query
>
> result = get_product_documents(messages=\[{"role": "user", "content":
> query}\])

![A screenshot of a computer Description automatically
generated](./media/image82.png)

5.  Clique em **File**\> **Save all**.

![](./media/image83.png)

### Tarefa 4: Criar modelo de prompt para mapeamento de intenção

O script **get_product_documents.py** usa um modelo de prompt para
converter a conversa em uma consulta de pesquisa. O modelo instrui como
extrair a intenção do usuário da conversa.

1.  Antes de executar o script, crie o modelo de prompt. Crie um arquivo
    chamado +++**intent_mapping.prompty**+++ na sua pasta de **assets**:

![](./media/image84.png)

2.  Copie o código a seguir para o arquivo intent_mapping_prompty e, na
    barra superior, vá em Arquivos e clique em **Save all.**

> ---
>
> name: Chat Prompt
>
> description: A prompty that extract users query intent based on the
> current_query and chat_history of the conversation
>
> model:
>
> api: chat
>
> configuration:
>
> azure_deployment: gpt-4o
>
> inputs:
>
> conversation:
>
> type: array
>
> ---
>
> system:
>
> \# Instructions
>
> \- You are an AI assistant reading a current user query and
> chat_history.
>
> \- Given the chat_history, and current user's query, infer the user's
> intent expressed in the current user query.
>
> \- Once you infer the intent, respond with a search query that can be
> used to retrieve relevant documents for the current user's query based
> on the intent
>
> \- Be specific in what the user is asking about, but disregard parts
> of the chat history that are not relevant to the user's intent.
>
> \- Provide responses in json format
>
> \# Examples
>
> Example 1:
>
> With a conversation like below:
>
> \- user: are the trailwalker shoes waterproof?
>
> \- assistant: Yes, the TrailWalker Hiking Shoes are waterproof. They
> are designed with a durable and waterproof construction to withstand
> various terrains and weather conditions.
>
> \- user: how much do they cost?
>
> Respond with:
>
> {
>
> "intent": "The user wants to know how much the Trailwalker Hiking
> Shoes cost.",
>
> "search_query": "price of Trailwalker Hiking Shoes"
>
> }
>
> Example 2:
>
> With a conversation like below:
>
> \- user: are the trailwalker shoes waterproof?
>
> \- assistant: Yes, the TrailWalker Hiking Shoes are waterproof. They
> are designed with a durable and waterproof construction to withstand
> various terrains and weather conditions.
>
> \- user: how much do they cost?
>
> \- assistant: The TrailWalker Hiking Shoes are priced at $110.
>
> \- user: do you have waterproof tents?
>
> \- assistant: Yes, we have waterproof tents available. Can you please
> provide more information about the type or size of tent you are
> looking for?
>
> \- user: which is your most waterproof tent?
>
> \- assistant: Our most waterproof tent is the Alpine Explorer Tent. It
> is designed with a waterproof material and has a rainfly with a
> waterproof rating of 3000mm. This tent provides reliable protection
> against rain and moisture.
>
> \- user: how much does it cost?
>
> Respond with:
>
> {
>
> "intent": "The user would like to know how much the Alpine Explorer
> Tent costs.",
>
> "search_query": "price of Alpine Explorer Tent"
>
> }
>
> user:
>
> Return the search query for the messages in the following
> conversation:
>
> {{#conversation}}
>
> \- {{role}}: {{content}}
>
> {{/conversation}}

![A screenshot of a computer Description automatically
generated](./media/image85.png)

### Tarefa 5: Testar o script de recuperação de documentos do produto

1.  Agora que você tem o script e o modelo, execute o script para testar
    quais documentos o índice de pesquisa retorna de uma consulta. Na
    janela do terminal, execute:

+++python get_product_documents.py --query "I need a new tent for 4
people, what would you recommend?"+++

![A screenshot of a computer Description automatically
generated](./media/image86.png)

### Tarefa 6: Desenvolver código de recuperação de conhecimento personalizado (RAG)

Em seguida, você cria um código personalizado para adicionar recursos de
Retrieval-Augmented Generation (RAG) a um aplicativo de chat básico.

**Crie um script de chat com recursos RAG**

1.  Na sua pasta **src**, crie um novo arquivo chamado
    +++**chat_with_products.py**+++. Este script recupera documentos do
    produto e gera uma resposta à pergunta do usuário.

![A screenshot of a computer Description automatically
generated](./media/image87.png)

2.  Adicione o código para importar as bibliotecas necessárias, criar um
    cliente de projeto e configurar as definições:

> import os
>
> from pathlib import Path
>
> from opentelemetry import trace
>
> from azure.ai.projects import AIProjectClient
>
> from azure.identity import DefaultAzureCredential
>
> from config import ASSET_PATH, get_logger, enable_telemetry
>
> from get_product_documents import get_product_documents
>
> \# initialize logging and tracing objects
>
> logger = get_logger(\_\_name\_\_)
>
> tracer = trace.get_tracer(\_\_name\_\_)
>
> \# create a project client using environment variables loaded from the
> .env file
>
> project = AIProjectClient.from_connection_string(
>
> conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
> credential=DefaultAzureCredential()
>
> )
>
> \# create a chat client we can use for testing
>
> chat = project.inference.get_chat_completions_client()

![A screenshot of a computer Description automatically
generated](./media/image88.png)

3.  Adicione o código no final de chat_with_products.py para criar a
    função de chat que usa os recursos do RAG.

> from azure.ai.inference.prompts import PromptTemplate
>
> @tracer.start_as_current_span(name="chat_with_products")
>
> def chat_with_products(messages: list, context: dict = None) -\> dict:
>
> if context is None:
>
> context = {}
>
> documents = get_product_documents(messages, context)
>
> \# do a grounded chat call using the search results
>
> grounded_chat_prompt = PromptTemplate.from_prompty(Path(ASSET_PATH) /
> "grounded_chat.prompty")
>
> system_message =
> grounded_chat_prompt.create_messages(documents=documents,
> context=context)
>
> response = chat.complete(
>
> model=os.environ\["CHAT_MODEL"\],
>
> messages=system_message + messages,
>
> \*\*grounded_chat_prompt.parameters,
>
> )
>
> logger.info(f"💬 Response: {response.choices\[0\].message}")
>
> \# Return a chat protocol compliant response
>
> return {"message": response.choices\[0\].message, "context": context}

![A screenshot of a computer Description automatically
generated](./media/image89.png)

4.  Por fim, adicione o código para executar o **chat** **function** e
    então vá para arquivos e clique em **Save all**.

> if \_\_name\_\_ == "\_\_main\_\_":
>
> import argparse
>
> \# load command line arguments
>
> parser = argparse.ArgumentParser()
>
> parser.add_argument(
>
> "--query",
>
> type=str,
>
> help="Query to use to search product",
>
> default="I need a new tent for 4 people, what would you recommend?",
>
> )
>
> parser.add_argument(
>
> "--enable-telemetry",
>
> action="store_true",
>
> help="Enable sending telemetry back to the project",
>
> )
>
> args = parser.parse_args()
>
> if args.enable_telemetry:
>
> enable_telemetry(True)
>
> \# run chat with products
>
> response = chat_with_products(messages=\[{"role": "user", "content":
> args.query}\])

![A screenshot of a computer Description automatically
generated](./media/image90.png)

### Tarefa 7: Criar um modelo de prompt de chat fundamentado

O script **chat_with_products.py** chama um modelo de prompt para gerar
uma resposta à pergunta do usuário. O modelo instrui como gerar uma
resposta com base na pergunta do usuário e nos documentos recuperados.
Crie este modelo agora.

1.  Na sua pasta de **assets**, adicione o arquivo
    +++**grounded_chat.prompty**+++

![A screenshot of a computer Description automatically
generated](./media/image91.png)

2.  Adicione o seguinte código grounded_chat.prompty.

> name: Chat with documents
>
> description: Uses a chat completions model to respond to queries
> grounded in relevant documents
>
> model:
>
> api: chat
>
> configuration:
>
> azure_deployment: gpt-4o
>
> inputs:
>
> conversation:
>
> type: array
>
> ---
>
> system:
>
> You are an AI assistant helping users with queries related to outdoor
> outdooor/camping gear and clothing.
>
> If the question is not related to outdoor/camping gear and clothing,
> just say 'Sorry, I only can answer queries related to outdoor/camping
> gear and clothing. So, how can I help?'
>
> Don't try to make up any answers.
>
> If the question is related to outdoor/camping gear and clothing but
> vague, ask for clarifying questions instead of referencing documents.
> If the question is general, for example it uses "it" or "they", ask
> the user to specify what product they are asking about.
>
> Use the following pieces of context to answer the questions about
> outdoor/camping gear and clothing as completely, correctly, and
> concisely as possible.
>
> Do not add documentation reference in the response.
>
> \# Documents
>
> {{#documents}}
>
> \## Document {{id}}: {{title}}
>
> {{content}}
>
> {{/documents}}

![A screenshot of a computer Description automatically
generated](./media/image92.png)

3.  Clique em **File\> Save all.**

![A screenshot of a computer Description automatically
generated](./media/image93.png)

### Tarefa 8: Execute o script de chat com recursos RAG

1.  Agora que você tem o script e o modelo, execute o script para testar
    seu aplicativo de chat com os recursos do RAG:

+++python chat_with_products.py --query "I need a new tent for 4 people,
what would you recommend?"+++

![A screenshot of a computer Description automatically
generated](./media/image94.png)

### Tarefa 9: Adicionar registro de telemetria

1.  No portal do Azure, selecione **Subscriptions**, selecione sua
    assinatura e, em seguida, selecione **Resource providers** em
    **Settings** no painel de navegação esquerdo.

2.  Pesquise e selecione +++**Microsoft.OperationalInsights**+++ e
    clique nos três pontos para este provedor de recursos e selecione
    **Register**.

![A screenshot of a computer Description automatically
generated](./media/image95.png)

3.  Siga o mesmo procedimento para registrar +++microsoft.insights+++

4.  Aguarde uma mensagem de sucesso no registro antes de prosseguir para
    a próxima etapa.

![A screenshot of a computer Description automatically
generated](./media/image96.png)

5.  No seu Projeto no Azure AI Foundry, selecione **Tracing** em
    **Access and improve** no painel esquerdo. Selecione **Create New**.

![A screenshot of a computer Description automatically
generated](./media/image97.png)

6.  Forneça o nome como **<+++appinsight@lab.LabInstance.Id>+++**

![A screenshot of a computer screen Description automatically
generated](./media/image98.png)

7.  Garanta que o recurso seja criado.

![A screenshot of a computer Description automatically
generated](./media/image99.png)

8.  De volta ao VS Code, para habilitar o registro de telemetria no seu
    projeto, instale azure-monitor-opentelemetry.

+++pip install azure-monitor-opentelemetry+++

![A screenshot of a computer program Description automatically
generated](./media/image100.png)

9.  Adicione o sinalizador --enable-telemetry ao usar o script
    chat_with_products.py:

+++python chat_with_products.py --query "I need a new tent for 4 people,
what would you recommend?" --enable-telemetry+++

![A screenshot of a computer Description automatically
generated](./media/image101.png)

## Exercício 3: Avaliar o aplicativo de chat personalizado com o SDK do Azure AI Foundry

### Tarefa 1: Avalie a qualidade das respostas do aplicativo de chat

Agora que você sabe que seu aplicativo de chat responde bem às suas
consultas, incluindo com o histórico de conversas, é hora de avaliá-lo
com base em alguns critérios diferentes e com mais dados.

Use um avaliador com um conjunto de dados de avaliação e a função alvo
get_chat_response(), e então analisará os resultados da avaliação.

Depois de executar uma avaliação, você pode fazer melhorias na sua
lógica, como melhorar o prompt do sistema e observar como as respostas
do aplicativo de chat mudam e melhoram.

**Criar conjunto de dados de avaliação**

Use o seguinte conjunto de dados de avaliação, que contém perguntas de
exemplo e respostas esperadas (verdade).

1.  Crie um arquivo chamado +++**chat_eval_data.jsonl**+++ na sua pasta
    de **assets**.

![](./media/image102.png)

2.  Cole este conjunto de dados no arquivo e **save** o arquivo.

{"query": "Which tent is the most waterproof?", "truth": "The Alpine
Explorer Tent has the highest rainfly waterproof rating at 3000m"}

{"query": "Which camping table holds the most weight?", "truth": "The
Adventure Dining Table has a higher weight capacity than all of the
other camping tables mentioned"}

{"query": "How much do the TrailWalker Hiking Shoes cost? ", "truth":
"The Trailewalker Hiking Shoes are priced at $110"}

{"query": "What is the proper care for trailwalker hiking shoes? ",
"truth": "After each use, remove any dirt or debris by brushing or
wiping the shoes with a damp cloth."}

{"query": "What brand is TrailMaster tent? ", "truth": "OutdoorLiving"}

{"query": "How do I carry the TrailMaster tent around? ", "truth": "
Carry bag included for convenient storage and transportation"}

{"query": "What is the floor area for Floor Area? ", "truth": "80 square
feet"}

{"query": "What is the material for TrailBlaze Hiking Pants?", "truth":
"Made of high-quality nylon fabric"}

{"query": "What color does TrailBlaze Hiking Pants come in?", "truth":
"Khaki"}

{"query": "Can the warrenty for TrailBlaze pants be transfered? ",
"truth": "The warranty is non-transferable and applies only to the
original purchaser of the TrailBlaze Hiking Pants. It is valid only when
the product is purchased from an authorized retailer."}

{"query": "How long are the TrailBlaze pants under warranty for? ",
"truth": " The TrailBlaze Hiking Pants are backed by a 1-year limited
warranty from the date of purchase."}

{"query": "What is the material for PowerBurner Camping Stove? ",
"truth": "Stainless Steel"}

{"query": "Is France in Europe?", "truth": "Sorry, I can only queries
related to outdoor/camping gear and equipment"}

![A screenshot of a computer Description automatically
generated](./media/image103.png)

### Tarefa 2: Avaliar com avaliadores do Azure AI

Agora defina um script de avaliação que irá:

- Gerar um wrapper de função de destino em torno da lógica do nosso
  aplicativo de chat.

- Carregar o conjunto de dados .jsonl de amostra.

- Executar a avaliação, que pega a função de destino e mescla o conjunto
  de dados de avaliação com as respostas do aplicativo de chat.

- Gerar um conjunto de métricas assistidas pelo GPT (relevância,
  fundamentação e coerência) para avaliar a qualidade das respostas do
  aplicativo de chat.

- Exiba os resultados localmente e registre-os no projeto na nuvem.

O script permite que você revise os resultados localmente, exibindo-os
no terminal e salvando-os em um arquivo JSON.

O script também registra os resultados da avaliação no projeto na nuvem
para que você possa comparar as execuções de avaliação na interface do
usuário.

1.  Crie um arquivo chamado +++**evaluate.py**+++ na pasta **src**.

![A screenshot of a computer Description automatically
generated](./media/image104.png)

2.  Adicione o seguinte código para importar as bibliotecas necessárias,
    criar um cliente de projeto e configurar algumas definições:

import os

import pandas as pd

from azure.ai.projects import AIProjectClient

from azure.ai.projects.models import ConnectionType

from azure.ai.evaluation import evaluate, GroundednessEvaluator

from azure.identity import DefaultAzureCredential

from chat_with_products import chat_with_products

\# load environment variables from the .env file at the root of this
repo

from dotenv import load_dotenv

load_dotenv()

\# create a project client using environment variables loaded from the
.env file

project = AIProjectClient.from_connection_string(

conn_str=os.environ\["AIPROJECT_CONNECTION_STRING"\],
credential=DefaultAzureCredential()

)

connection =
project.connections.get_default(connection_type=ConnectionType.AZURE_OPEN_AI,
include_credentials=True)

evaluator_model = {

"azure_endpoint": connection.endpoint_url,

"azure_deployment": os.environ\["EVALUATION_MODEL"\],

"api_version": "2024-06-01",

"api_key": connection.key,

}

groundedness = GroundednessEvaluator(evaluator_model)

![A screenshot of a computer Description automatically
generated](./media/image105.png)

3.  Adicione código para criar uma função wrapper que implemente a
    interface de avaliação para avaliação de consulta e resposta:

def evaluate_chat_with_products(query):

response = chat_with_products(messages=\[{"role": "user", "content":
query}\])

return {"response": response\["message"\].content, "context":
response\["context"\]\["grounding_data"\]}

![A screenshot of a computer Description automatically
generated](./media/image106.png)

4.  Por fim, adicione o código para executar a avaliação, visualize os
    resultados localmente e forneça um link para os resultados da
    avaliação no portal do AI Foundry.

> \# Evaluate must be called inside of \_\_main\_\_, not on import
>
> if \_\_name\_\_ == "\_\_main\_\_":
>
> from config import ASSET_PATH
>
> \# workaround for multiprocessing issue on linux
>
> from pprint import pprint
>
> from pathlib import Path
>
> import multiprocessing
>
> import contextlib
>
> with contextlib.suppress(RuntimeError):
>
> multiprocessing.set_start_method("spawn", force=True)
>
> \# run evaluation with a dataset and target function, log to the
> project
>
> result = evaluate(
>
> data=Path(ASSET_PATH) / "chat_eval_data.jsonl",
>
> target=evaluate_chat_with_products,
>
> evaluation_name="evaluate_chat_with_products",
>
> evaluators={
>
> "groundedness": groundedness,
>
> },
>
> evaluator_config={
>
> "default": {
>
> "query": {"${data.query}"},
>
> "response": {"${target.response}"},
>
> "context": {"${target.context}"},
>
> }
>
> },
>
> azure_ai_project=project.scope,
>
> output_path="./myevalresults.json",
>
> )
>
> tabular_result = pd.DataFrame(result.get("rows"))
>
> pprint("-----Summarized Metrics-----")
>
> pprint(result\["metrics"\])
>
> pprint("-----Tabular Result-----")
>
> pprint(tabular_result)
>
> pprint(f"View evaluation results in AI Studio:
> {result\['studio_url'\]}")

![A screenshot of a computer Description automatically
generated](./media/image107.png)

5.  Clique em **Save all** em **File** na barra de navegação superior.

### Tarefa 3: Configurar o modelo de avaliação

Como o script de avaliação chama o modelo muitas vezes, talvez você
queira aumentar o número de tokens por minuto para o modelo de
avaliação.

Inicialmente, você criou um arquivo **.env** que especifica o nome do
modelo de avaliação, gpt-4o-mini. Tente aumentar o limite de tokens por
minuto para este modelo, se tiver cota disponível. Se não tiver cota
suficiente para aumentar o valor, não se preocupe. O script foi
projetado para lidar com erros de limite.

1.  No seu projeto no portal do Azure AI Foundry, selecione **Models +
    endpoints** e selecione **gpt-4o-mini** .

![A screenshot of a computer Description automatically
generated](./media/image108.png)

2.  Selecione **gpt-4o-mini** e clique em **Edit.**

![A screenshot of a computer Description automatically
generated](./media/image109.png)

3.  Defina o valor do **Tokens per Minute Rate Limit** para o limite
    máximo permitido e selecione **Save and close**.

![A screenshot of a computer Description automatically
generated](./media/image110.png)

**Tarefa 4: Executar a avaliação**

1.  De volta ao terminal do VS Code, execute o comando abaixo para
    instalar os pacotes necessários.

+++pip install azure-ai-evaluation\[remote\]+++

2.  Execute o código abaixo para executar o script de avaliação.

+++python evaluate.py+++

A avaliação levará de 5 a 10 minutos para ser concluída.

![](./media/image111.png)

### Tarefa 5: Exibir resultados da avaliação no portal do Azure AI Foundry

1.  Após a conclusão da avaliação, siga o link para visualizar os
    resultados da avaliação na página Avaliação no portal do Azure AI
    Foundry.

![](./media/image112.png)

![](./media/image113.png)

2.  Verifique os **Evaluation results** e o **Metrics dashboard**.

![](./media/image114.png)

![](./media/image115.png)

## Exercício 4: Excluir os recursos

1.  Na página inicial do portal do Azure, selecione o grupo de recursos
    atribuído. Selecione todos os recursos no grupo de recursos e
    selecione **Delete**.

![A screenshot of a computer Description automatically
generated](./media/image116.png)

2.  Digite +++**delete**+++ e clique no botão **Delete** para confirmar
    a exclusão. Clique em **Delete** na caixa de diálogo de confirmação
    de exclusão.

![A screenshot of a computer Description automatically
generated](./media/image117.png)

3.  Confirme a exclusão de todos os recursos com uma mensagem de
    sucesso.

![A screenshot of a computer screen Description automatically
generated](./media/image118.png)

## Resumo

Neste laboratório, aprendemos a criar, avaliar e implementar um
aplicativo baseado em RAG.

 
