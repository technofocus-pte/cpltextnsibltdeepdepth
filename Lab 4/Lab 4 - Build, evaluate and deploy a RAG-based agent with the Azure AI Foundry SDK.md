# Laboratorio 4 – Construya, evalúe e implemente un agente basado en RAG con Azure AI Foundry SDK

**Duración estimada: 120 minutos**

## Objetivo

El objetivo de este laboratorio es crear, evaluar e implementar un
agente basado en la generación aumentada de recuperación (RAG) mediante
el SDK de Azure AI Foundry. El laboratorio le guía a través de la
configuración del proyecto y el entorno de desarrollo, la implementación
de modelos de IA (por ejemplo, GPT-4 y text-embedding-ada-002), la
integración de Azure AI Search para la recuperación de documentos y la
creación de una aplicación de chat de recuperación de conocimientos
(RAG) personalizada. La atención se centra en fundamentar las respuestas
del modelo de IA con datos de productos relevantes, desarrollar una
interfaz de chat personalizada y evaluar el rendimiento de las
respuestas generadas.

## Solución

La solución implica la configuración de un proyecto en Azure AI Foundry,
la implementación de modelos de IA (GPT-4 y text-embedding-ada-002) y la
integración de Azure AI Search para almacenar y recuperar datos de
productos personalizados. Incluye la creación de scripts de Python para
generar incrustaciones vectoriales, crear índices de búsqueda y
consultarlos para obtener información relevante del producto. Se
desarrolla una interfaz de chat basada en RAG para proporcionar
respuestas fundamentadas aprovechando los resultados de la búsqueda, y
el rendimiento de la aplicación de chat se evalúa utilizando conjuntos
de datos y métricas predefinidos para mejorar su eficacia.

## Ejercicio 0: Descripción de la máquina virtual y las credenciales

En este ejercicio, identificaremos y comprenderemos las credenciales que
utilizaremos en todo el laboratorio.

**Importante:** Realice cada paso de este ejercicio para conocer los
términos genéricos y las credenciales que se usarán para la ejecución
del laboratorio.

1.  La pestaña **Instructions** Sostenga la guía de laboratorio con las
    instrucciones que se deben seguir durante todo el laboratorio.

2.  La pestaña **Resources** tiene las credenciales que se necesitarán
    para ejecutar el laboratorio.

    - **URL** – Dirección URL de Azure Portal

    - **Subscription** – Este es el **ID** de la **suscripción**
      asignada a usted

    - **Username** – El **ID de usuario** con el que debe **iniciar
      sesión** en el archivo **Azure services**.

    - **Password** – **Contraseña** para el inicio de **sesión de
      Azure**.

Llamemos a este nombre de usuario y contraseña como **Azure login
credentials**. Usaremos estas credenciales dondequiera que
mencionemos **Azure login credentials**.

- **Resource Group** – el **Resource group** que se le asignó.

\[!Alerta\] **Importante**: Asegúrese de crear todos sus recursos bajo
este Resource group

![A screenshot of a computer Description automatically
generated](./media/image1.png)

3.  La pestaña **Help** contiene la información de soporte. El valor de
    **ID** aquí es el **Lab instance ID** que se utilizará durante la
    ejecución del laboratorio.

![A screenshot of a computer Description automatically
generated](./media/image2.png)

## Ejercicio 1: Cree un recurso y proyecto Azure AI Hub

En este ejercicio, crearemos el centro en Azure Portal y, a
continuación, un proyecto en Azure AI Foundry, implementaremos el modelo
y crearemos el agente necesario para la ejecución.

### Tarea 1: Cree un Proyecto

1.  Desde un navegador, abra +++\*\*<https://portal.azure.com/**+++>, e
    inicie sesión con su **login** **credentials** y seleccione **Azure
    AI Foundry** desde la página **Home**.

    - User name – <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password – <+++@lab.CloudPortalCredential>(User1).Password+++

![image](./media/image3.png)

2.  Seleccione **Use with AI Foundry** -\> **AI Hubs**. Seleccione **+
    Create** -\> **Hub**.

![image](./media/image4.png)

3.  Ingrese los detalles a continuación, acepte los otros valores
    predeterminados y seleccione **Review + create**.

    - Subscription – Seleccione su **assigned subscription**

    - Resource group – Seleccione su Resource group asignado
      (**ResourceGroup1**)

    - Region - Seleccione
      @lab.CloudResourceGroup(ResourceGroup1).Location

    - Name - <+++hub@lab.LabInstance.Id>+++

![image](./media/image5.png)

![image](./media/image6.png)

4.  Una vez superada la validación, seleccione **Create**.

![image](./media/image7.png)

5.  Una vez que se complete la implementación, haga clic en **Go to
    resource**.

![image](./media/image8.png)

6.  Seleccione **Launch Azure AI Foundry** desde la página de hub
    resource.

![image](./media/image9.png)

7.  Desde el hub resource iniciado, baje y seleccione **+ New project**.

![image](./media/image10.png)

![image](./media/image11.png)

8.  Ingrese el nombre como <+++RAGproj@lab.LabInstance.Id>+++ y
    seleccione **Create**.

![image](./media/image12.png)

9.  **Cierre** el popup de Explore and experiment.

![image](./media/image13.png)

10. Llegará en la página de proyecto creado.

![image](./media/image14.png)

11. Baje en la página y copie el valor de **Project connection
    string** a un notepad.

![image](./media/image15.png)

12. Baje en el panel izquierdo y seleccione **Management center**.

![image](./media/image16.png)

13. Seleccione **Connected resources** en Hub resource y haga clic
    en **+ New connection** para crear una conexión con el Azure AI
    Foundry resource.

![image](./media/image17.png)

14. Seleccione **Azure AI Foundry** desde los external assets
    disponibles.

![image](./media/image18.png)

15. Seleccione **Add connection** para agregar una conexión.

![image](./media/image19.png)

![image](./media/image20.png)

16. Una vez conectado, haga clic en **Close**. Si no se ve el
    botón **Close**, reduzca el tamaño de **zoom** del navegador y
    seleccione **Close**.

![image](./media/image21.png)

17. Seleccione **Go to project** desde el panel izquierdo.

![image](./media/image22.png)

18. Desde la página project, copie los valores del **API Key** y
    el **Azure OpenAI endpoint** y guárdelos en un notepad.

![image](./media/image23.png)

19. Ahora, tenemos listos los Azure resources.

### Tarea 2: Implemente los modelos

Necesita dos modelos para crear una aplicación de chat basada en RAG: un
modelo de chat de Azure OpenAI (gpt-4o-mini) y un modelo de inserción de
Azure OpenAI (text-embedding-ada-002). Implemente estos modelos en el
proyecto de Azure AI Foundry mediante este conjunto de pasos para cada
modelo.

Estos pasos implementan un modelo en un punto de conexión en tiempo real
desde el model catalog del portal de AI Foundry

1.  Desde el panel izquierdo, seleccione **Model catalog**.

![](./media/image24.png)

2.  Seleccione el modelo +++**gpt-4o-mini**+++ desde la lista de
    modelos. Puede usar la barra de búsqueda para encontrarlo.

![A screenshot of a computer Description automatically
generated](./media/image25.png)

3.  En la página de model details, seleccione **Deploy**.

![A screenshot of a computer Description automatically
generated](./media/image26.png)

4.  Deje el **Deployment name** predeterminado. Seleccione **Deploy**. O
    bien, si el modelo no está disponible en su región, se selecciona
    una región diferente y se conecta a su proyecto. En este caso,
    seleccione **Create resource and deploy**.

![A screenshot of a computer Description automatically
generated](./media/image27.png)

![](./media/image28.png)

5.  Después de implementar el **gpt-4o-mini**, implemente el
    modelo +++**text-embedding-ada-002**+++. Seleccione el **Deployment
    Type** como **Standard**.

![A screenshot of a computer Description automatically
generated](./media/image29.png)

### Tarea 3: Cree un Azure AI Search service

El objetivo de esta aplicación es basar las respuestas del modelo en los
datos personalizados. El search index se utiliza para recuperar
documentos relevantes en función de la pregunta del usuario.

Necesita un servicio de Azure AI Search y una conexión para crear un
search index.

1.  Inicie sesión en Azure portal en
    +++[https://portal.azure.com+++](https://portal.azure.com+++/) mediante
    las Azure login credentials.

2.  Desde la búsqueda del home page, busque +++**AI search**+++ y
    selecciónelo.

![A screenshot of a computer Description automatically
generated](./media/image30.png)

3.  Haga clic en el icono **+ Create** e ingrese los siguientes
    detalles.

![](./media/image31.png)

4.  Ingrese los detalles a continuación y seleccione **Review +
    create**.

    - Subscription – Seleccione sus suscripción asignada

    - Resource Group – Seleccione su Resource group asignado

    - Service name – Ingrese **<+++aisearch@lab.LabInstance.Id>+++**

    - Region - Select @lab.CloudResourceGroup(ResourceGroup1).Location

    - Pricing tier – Seleccione **Standard**

![A screenshot of a computer Description automatically
generated](./media/image32.png)

5.  Revise los detalles y seleccione **Create**.

![A screenshot of a computer Description automatically
generated](./media/image33.png)

6.  Espere hasta que la implementación se realice correctamente, como se
    muestra en la captura de pantalla siguiente antes de continuar con
    el siguiente paso.

![A screenshot of a computer Description automatically
generated](./media/image34.png)

### Tarea 4: Conecte el Azure AI Search a su proyecto

En el Azure AI Foundry portal, compruebe el Azure AI Search connected
resource.

1.  Desde su proyecto en Azure AI Foundry, seleccione **Management
    center** desde el panel izquierdo.

![A screenshot of a computer Description automatically
generated](./media/image35.png)

2.  En la sección **Connected resources**, seleccione **New
    connection** y luego seleccione **Azure AI Search**.

![](./media/image36.png)

![](./media/image37.png)

3.  Seleccione **API key** en **Authentication** y seleccione **Add
    connection**.

![A screenshot of a search engine Description automatically
generated](./media/image38.png)

![A screenshot of a search engine Description automatically
generated](./media/image39.png)

4.  Desde la página **Connected resources**, puede ver la resource
    connection agregada.

![](./media/image40.png)

### Tarea 5: Instale el Azure CLI e inicie sesión

Instale la CLI de Azure e inicie sesión desde el entorno de desarrollo
local, de modo que pueda usar sus credenciales de usuario para llamar al
servicio Azure OpenAI.

1.  Busque +++**PowerShell**+++ desde la barra de búsqueda de Windows y
    ábralo en el **modo Administrator**. Aceptar si se le solicita que
    el lanzamiento continúe.

![A screenshot of a computer Description automatically
generated](./media/image41.png)

2.  Abra el s Windows power shell y pegue el comando que se da a
    continuación y ejecútelo.

> $progressPreference = 'silentlyContinue'
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

3.  Instale la CLI de Azure desde el terminal mediante el siguiente
    comando:

> +++winget install -e --id Microsoft.AzureCLI+++

Seleccione **Y** y **Enter** cuando se le solicite la aceptación.

![A screenshot of a computer Description automatically
generated](./media/image42.png)

![](./media/image43.png)

![](./media/image44.png)

4.  Después de instalar la CLI de Azure, inicie sesión con el comando az
    login e inicie sesión con el explorador:

> +++az login+++

Seleccione **Work or school account** y haga clic en **Continue**.

![A screenshot of a computer screen Description automatically
generated](./media/image45.png)

5.  Inicie sesión son sus **Azure login credentials**.

![A computer screen shot of a program Description automatically
generated](./media/image46.png)

6.  Ingrese **1** para el prompt **Select a subscription** y haga clic
    en **Enter**.

![A screenshot of a computer Description automatically
generated](./media/image47.png)

### Tarea 6: Cree un nuevo entorno de Python

Primero, debe crear un nuevo entorno de Python para usar para instalar
el paquete que necesita para este tutorial. NO instale paquetes en su
instalación global de python. Siempre debe usar un entorno virtual o de
Conda al instalar paquetes de Python, de lo contrario, puede interrumpir
la instalación global de Python.

\[!Alerta\] **Importante:** Si los comandos siguientes no se pueden
pegar, intente pegarlos en un bloc de notas y, a continuación, cópielo y
péguelo en PowerShell. O copie y pegue directamente en PowerShell. El
botón T no funciona a veces en PowerShell.

**Cree un entorno virtual**

1.  Desde su Power Shell, navegue a **C:\Users\Admin** ejecutando los
    siguientes comandos.

> cd\\
>
> cd Users\Admin

2.  Cree una carpeta con el nombre de su
    proyecto, [**RAGproj@lab.LabInstance.Id**](mailto:RAGproj@lab.LabInstance.Id),
    Introduciendo el siguiente comando en el PowerShell.

> mkdir RAGproj@lab.LabInstance.Id

![A computer screen with white and green text Description automatically
generated](./media/image48.png)

3.  En su terminal, ingrese el siguiente comando para navegar a la nueva
    ubicación de la carpeta

> cd RAGproj@lab.LabInstance.Id

![A blue screen with white text Description automatically
generated](./media/image49.png)

4.  Cree un entorno virtual con los siguientes comandos

> py -3 -m venv .venv
>
> .venv\scripts\activate

![A computer screen shot of a code Description automatically
generated](./media/image50.png)

Activar el entorno de Python significa que cuando se ejecuta python o
pip desde la línea de comandos, se utiliza el intérprete de Python
contenido en la carpeta .venv de la aplicación.

5.  Abra **VS Code**. Seleccione **File -\> Open Folder** y seleccione
    la carpeta **RAGproject** que creamos en los pasos anteriores (desde
    **C:\Users\Admin**).

\[!Ojo\] **Ojo:** Haga clic en Yes, I trust the folder and content y
luego continúe si se le solicita.

![A screenshot of a computer Description automatically
generated](./media/image51.png)

![A screenshot of a computer Description automatically
generated](./media/image52.png)

![A screenshot of a computer Description automatically
generated](./media/image53.png)

6.  Seleccione **Yes, I trust the authors** cuando se le pide **Do you
    trust the authors of the files in this folder?**

### Tarea 7: Instale los paquetes

Instale azure-ai-projects (versión preliminar) y azure-ai-inference
(versión preliminar), junto con otros paquetes necesarios.

1.  Cree un archivo llamado +++**requirements.txt**+++ en su carpeta
    de **Project** y agregue los siguientes paquetes al archivo:

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

2.  En la barra de navegación superior, haga clic en **File** y **Save
    All**.

3.  Haga clic derecho en el requirements.txt y seleccione **Open in
    Integrated Terminal**.

![](./media/image56.png)

![A screenshot of a computer Description automatically
generated](./media/image57.png)

4.  Ejecute el siguiente comando para acceder al entorno virtual

> +++py -3 -m venv .venv+++
>
> +++.venv\scripts\activate+++

![A screenshot of a computer Description automatically
generated](./media/image58.png)

5.  Ejecute el comando +++az login+++ e inicie sesión con sus Azure
    login credentials. Seleccione **1** Para seleccionar la suscripción.

\[!ojo\] **Ojo:** Minimice el código de VS para ver el mensaje de inicio
de sesión si no está visible automáticamente.

![A screenshot of a computer Description automatically
generated](./media/image59.png)

![A screenshot of a computer Description automatically
generated](./media/image60.png)

6.  Para instalar los paquetes necesarios, ejecute el código siguiente.

+++pip install -r requirements.txt+++

![A screenshot of a computer Description automatically
generated](./media/image61.png)

![A screenshot of a computer Description automatically
generated](./media/image62.png)

\[!Ojo\] **Ojo:** Si recibe un aviso de una nueva versión de pip,
ejecute los siguientes comandos para actualizar pip

+++pip install -r requirements.txt+++

+++python.exe -m pip install --upgrade pip+++

![A screenshot of a computer program Description automatically
generated](./media/image63.png)

### Tarea 8: Cree el helper script

1.  CrDe esta manera, se crea una nueva carpeta llamada **src**.
    ejecutando el siguiente comando en el terminal.

+++mkdir src+++

![A screenshot of a computer Description automatically
generated](./media/image64.png)

2.  Cree un nuevo archivo en la **carpeta src** y asígnele un
    nombre +++**config.py**+++

![A screenshot of a computer Description automatically
generated](./media/image65.png)

3.  Agregue el siguiente código a **config.py** y guárdelo.

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

\[!Ojo\] **Ojo**: Este script de archivo config.py recién creado se
utilizará en el siguiente ejercicio.

### Tarea 9: Configure los variables del entorno

La connection string del proyecto es necesaria para llamar al servicio
Azure OpenAI desde el código. En este inicio rápido, guardará este valor
en un archivo .env, que es un archivo que contiene variables de entorno
que la aplicación puede leer.

1.  Cree un nuevo archivo **+++.env+++** en el **src** directory, y
    pegue el siguiente código:

Reemplace **\< your-connection-string \>** con el valor de la connection
string del proyecto guardado en el notepad en la tarea 1.

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

\[!Ojo\] **Ojo**: La connection string se puede encontrar en la página
principal del proyecto Azure AI Foundry en **Overview**.

## Ejercicio 2: Cree una aplicación de recuperación de conocimientos personalizada (RAG) con el método Azure AI Foundry SDK

### Tarea 1: Cree datos de ejemplo para su aplicación de chat

El objetivo de esta aplicación basada en RAG es basar las respuestas del
modelo en sus datos personalizados. Se usa un índice de Azure AI Search
que almacena datos vectorizados del modelo de embeddings. El search
index se utiliza para recuperar documentos relevantes en función de la
pregunta del usuario.

1.  En la configuración de VS Code que está abierta, cree una carpeta
    denominada +++**assets**+++ en la carpeta **src**.

![A screenshot of a computer Description automatically
generated](./media/image68.png)

2.  Copie el archivo **products.csv** desde **C:\LabFiles** y péguelo
    en **C:\Users\Admin\< Your Project Name\>\src\assets**.

\[!Ojo\] **Ojo:** Esto debe hacerse en el File Explorer y luego se
reflejará en el archivo VS Code.

![A screenshot of a computer Description automatically
generated](./media/image69.png)

3.  Vaya a **File** en la barra de navegación superior y haga clic
    en **Save All.**

![A screenshot of a computer Description automatically
generated](./media/image70.png)

### Tarea 2: Cree un search index

Se usa el search index para almacenar datos vectorizados del modelo de
embeddings. El search index se utiliza para recuperar documentos
relevantes en función de la pregunta del usuario.

1.  En VS code, cree un archivo llamado
    +++**create_search_index.py**+++ en su carpeta **src**.

![A screenshot of a computer Description automatically
generated](./media/image71.png)

2.  Abra el archivo creado, create_search_index.py archivo y agregue el
    siguiente código para importar las bibliotecas necesarias, crear un
    cliente de proyecto y configurar algunas opciones:

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

3.  Ahora agregue la función al final del **create_search_index.py**
    para definir un search index:

Mantenga el cursor al final del archivo, seleccione **Enter** dos veces
y luego pegue el código a continuación.

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

4.  Ahora agregue la función en create_search_index.py para crear la
    función para agregar un archivo csv al índice.

Mantenga el cursor al final del archivo, seleccione **Enter** dos veces
y luego pegue el código a continuación.

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

5.  Finalmente, agregue las siguientes funciones en
    create_search_index.py para crear el índice y registrarlo en el
    proyecto en la nube. Después de agregar el código, vaya a Files
    desde la barra superior y haga clic en **Save all.**

Mantenga el cursor al final del archivo, seleccione **Enter** dos veces.
Mueva el cursor de la nueva línea hacia el margen izquierdo y, a
continuación, pegue el código. (No debe haber espacio de tab)

\[!Alerta\] **Importante:** Asegúrese de que el argumento de importación
(argparse) en la segunda línea del código a continuación esté alineado
con un espacio de tabulación desde el margen. De lo contrario, mantenga
el cursor antes de **import** y haga clic en **Tab**.

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

6.  El archivo ahora debería tener el contenido como se muestra a
    continuación.

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

6.  Haga clic derecho en el **create_search_index.py** y
    seleccione **Open in integrated terminal**.

![](./media/image76.png)

7.  Desde el terminal, inicie sesión con sus Azure login credentials y
    siga las instrucciones para autenticar su cuenta:

+++az login+++

![](./media/image77.png)

![](./media/image78.png)

8.  Ejecute el código para compilar el índice localmente y regístrelo en
    el proyecto en la nube:

+++python create_search_index.py+++

![](./media/image79.png)

9.  Una vez que se ejecuta el script, puede ver el índice recién creado
    en desde Azure portal.

10. Navegue al **Resource Group -\> Your search service
    created(aisearchLabinstanceID) -\> Search management -\> Indexes**.

![A screenshot of a computer Description automatically
generated](./media/image80.png)

11. Si vuelve a ejecutar el script con el mismo nombre de índice, se
    crea una nueva versión del mismo índice.

### Tarea 3: Obtenga documentos de productos

A continuación, cree un script para obtener documentos de productos del
search index. El script consulta el search index de documentos que
coincidan con la pregunta de un usuario.

**Cree script para obtener documentos de productos**

Cuando el chat recibe una solicitud, busca en sus datos para encontrar
información relevante. Este script usa el Azure AI SDK para consultar el
search index de documentos que coincidan con la pregunta de un usuario.
A continuación, devuelve los documentos a la aplicación de chat.

1.  Desde VS Code, Cree un archivo llamado
    +++**get_product_documents.py**+++ en el **src**.

![A screenshot of a computer Description automatically
generated](./media/image81.png)

2.  Copie y pegue el siguiente código en el archivo. Comience con el
    código para importar las bibliotecas necesarias, crear un cliente de
    proyecto y configurar los ajustes.

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

3.  Agregue la función en get_product-documents.py para **obtener
    product documents**.

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

4.  Por fin, agregue código para **probar la función** cuando ejecute el
    script directamente:

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

5.  Haga clic en **File**\> **Save all**.

![](./media/image83.png)

### Tarea 4: Cree plantilla de prompt para intent mapping

El script **get_product_documents.py** utiliza una plantilla de
solicitud para convertir la conversación en una consulta de búsqueda. La
plantilla indica cómo extraer la intención del usuario de la
conversación.

1.  Antes de ejecutar el script, cree la plantilla de solicitud. Cree un
    archivo llamado +++**intent_mapping.prompty**+++ en la carpeta
    **assets**:

![](./media/image84.png)

2.  Copie el siguiente código en el archivo intent_mapping_prompty y
    desde la barra superior vaya a Files y haga clic en **Save all.**

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

### Tarea 5: Pruebe el product document retrieval script

1.  Ahora que tiene el script y la plantilla, ejecute el script para
    probar qué documentos devuelve el search index de una consulta.
    Desde la ventana del terminal, ejecute,

+++python get_product_documents.py --query "I need a new tent for 4
people, what would you recommend?"+++

![A screenshot of a computer Description automatically
generated](./media/image86.png)

### Tarea 6: Desrrolle el código custom knowledge retrieval (RAG)

A continuación, cree código personalizado para agregar capacidades de
generación aumentada de recuperación (RAG) a una aplicación de chat
básica.

**Cree un script de chat con capacidades RAG**

1.  En la carpeta **src**, cree un nuevo archivo
    llamado +++**chat_with_products.py**+++. Este script recupera
    documentos de productos y genera una respuesta a la pregunta de un
    usuario.

![A screenshot of a computer Description automatically
generated](./media/image87.png)

2.  Agregue el código para importar las bibliotecas necesarias, crear un
    cliente de proyecto y configurar los ajustes:

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

3.  Agregue el código al final de chat_with_products.py para crear la
    función de chat que utiliza las capacidades de RAG.

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

4.  Finalmente, agregue el código para ejecutar el
    **chat** **function** y luego vaya a Archivos y haga clic en **Save
    all**.

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

### Tarea 7: Cree un grounded chat prompt template

El **chat_with_products.py** script llama a una plantilla de prompt para
generar una respuesta a la pregunta del usuario. La plantilla indica
cómo generar una respuesta basada en la pregunta del usuario y los
documentos recuperados. Crea esta plantilla ahora.

1.  En su carpeta **assets**, agregue un
    archivo +++**grounded_chat.prompty**+++

![A screenshot of a computer Description automatically
generated](./media/image91.png)

2.  Agregue el siguiente código grounded_chat.prompty.

> ---
>
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

3.  Haga clic en **File\> Save all.**

![A screenshot of a computer Description automatically
generated](./media/image93.png)

### Tarea 8: Ejecutar el script de chat con capacidades RAG

1.  Ahora que tiene el script y la plantilla, ejecute el script para
    probar la aplicación de chat con capacidades de RAG:

+++python chat_with_products.py --query "I need a new tent for 4 people,
what would you recommend?"+++

![A screenshot of a computer Description automatically
generated](./media/image94.png)

### Tarea 9: Agregue telemetry logging

1.  Desde el Azure portal, seleccione **Subscriptions**, Seleccione su
    suscripción y, a continuación, seleccione **Resource
    providers** en **Settings** desde el panel de navegación izquierdo.

2.  Busque y seleccione +++**Microsoft.OperationalInsights**+++ y haga
    clic en los tres puntos de este proveedor de recursos y
    seleccione **Register**.

![A screenshot of a computer Description automatically
generated](./media/image95.png)

3.  Siga el mismo procedimiento para registrar +++microsoft.insights+++

4.  Espere un mensaje de éxito en el registro antes de continuar con el
    siguiente paso.

![A screenshot of a computer Description automatically
generated](./media/image96.png)

5.  Desde su Project en Azure AI Foundry,
    seleccione **Tracing** en **Access and improve** desde el panel
    izquierdo. Seleccione **Create New**.

![A screenshot of a computer Description automatically
generated](./media/image97.png)

6.  Proporcione el nombre como **<+++appinsight@lab.LabInstance.Id>+++**

![A screenshot of a computer screen Description automatically
generated](./media/image98.png)

7.  Asegúrese de que se crea el recurso.

![A screenshot of a computer Description automatically
generated](./media/image99.png)

8.  De vuelta en VS Code, para habilitar el registro de telemetría en el
    proyecto, instale azure-monitor-opentelemetry.

+++pip install azure-monitor-opentelemetry+++

![A screenshot of a computer program Description automatically
generated](./media/image100.png)

9.  Agregue la flag --enable-telemetry cuando use el script
    chat_with_products.py:

+++python chat_with_products.py --query "I need a new tent for 4 people,
what would you recommend?" --enable-telemetry+++

![A screenshot of a computer Description automatically
generated](./media/image101.png)

## Ejercicio 3: Evalúe la aplicación de chat personalizada con el Azure AI Foundry SDK

### Tarea 1: Evalúe la calidad de las respuestas de la aplicación de chat

Ahora que sabe que su aplicación de chat responde bien a sus consultas,
incluso con el historial de chat, es hora de evaluar cómo lo hace en
algunas métricas diferentes y más datos.

Utilice un evaluador con un dataset de evaluación y la función de
destino get_chat_response() y, a continuación, evalúe los resultados de
la evaluación.

Una vez que ejecute una evaluación, puede realizar mejoras en su lógica,
como mejorar el mensaje del sistema y observar cómo cambian y mejoran
las respuestas de la aplicación de chat.

**Cree evaluation dataset**

Utilice el siguiente dataset de evaluación, que contiene preguntas de
ejemplo y respuestas esperadas (truth).

1.  Cree un archivo llamado +++**chat_eval_data.jsonl**+++ en su
    carpeta **assets**.

![](./media/image102.png)

2.  Pegue este dataset en el archivo y guarde el archivo.

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

### Tarea 2: Evalúe con los Azure AI evaluators

Ahora define un script de evaluación que:

- Genera un contenedor de función de destino en torno a la lógica de
  nuestra aplicación de chat.

- Carga el dataset .jsonl de ejemplo.

- Ejecuta la evaluación, que toma la función de destino, y combina el
  dataset de evaluación con las respuestas de la aplicación de chat.

- Genera un conjunto de métricas asistidas por GPT (relevancia,
  groundedness y coherencia) para evaluar la calidad de las respuestas
  de la aplicación de chat.

- Genera los resultados localmente y registra los resultados en el
  proyecto en la nube.

El script le permite revisar los resultados localmente, mediante la
salida de los resultados en la línea de comandos, y en un archivo json.

El script también registra los resultados de la evaluación en el
proyecto en la nube para que puedas comparar las ejecuciones de
evaluación en la interfaz de usuario.

1.  Cree un archivo llamado +++**evaluate.py**+++ en la carpeta **src**.

![A screenshot of a computer Description automatically
generated](./media/image104.png)

2.  Agregue el siguiente código para importar las bibliotecas
    necesarias, crear un cliente de proyecto y configurar algunas
    opciones:

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

3.  Agregue código para crear una función wrapper que implemente la
    interfaz de evaluación para la evaluación de consultas y respuestas:

def evaluate_chat_with_products(query):

response = chat_with_products(messages=\[{"role": "user", "content":
query}\])

return {"response": response\["message"\].content, "context":
response\["context"\]\["grounding_data"\]}

![A screenshot of a computer Description automatically
generated](./media/image106.png)

4.  Por último, agregue código para ejecutar la evaluación, vea los
    resultados localmente y le proporciona un vínculo a los resultados
    de la evaluación en el portal de AI Foundry.

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

5.  Haga clic en **Save all** en **File** en la barra de navegación
    superior.

### Tarea 3: Configure el modelo de evaluación

Dado que el script de evaluación llama al modelo muchas veces, es
posible que desee aumentar el número de tokens por minuto para el modelo
de evaluación.

Inicialmente, creó un archivo **.env** que especifica el nombre del
modelo de evaluación, gpt-4o-mini. Intente aumentar el límite de tokens
por minuto para este modelo, si tiene cupo disponible. Si no tiene
suficiente cuota para aumentar el valor, no se preocupe. El script está
diseñado para controlar errores de límite.

1.  De su proyecto en Azure AI Foundry portal, seleccione **Models +
    endpoints** y seleccione **gpt-4o-mini**.

![A screenshot of a computer Description automatically
generated](./media/image108.png)

2.  Seleccione **gpt-4o-mini**, haga clic en **Edit.**

![A screenshot of a computer Description automatically
generated](./media/image109.png)

3.  Establezca el valor de **Tokens per Minute Rate Limit** hasta el
    límite máximo permitido y seleccione **Save and close**.

![A screenshot of a computer Description automatically
generated](./media/image110.png)

**Tarea 4: Ejecución de la evaluación**

1.  De vuelta en el terminal de VS Code, ejecute el siguiente comando
    para instalar los paquetes necesarios.

+++pip install azure-ai-evaluation\[remote\]+++

2.  Ejecute el siguiente código para ejecutar el script de evaluación.

+++python evaluate.py+++

La evaluación tardará entre 5 y 10 minutos en completarse.

![](./media/image111.png)

### Tarea 5: Vea los resultados de la evaluación en Azure AI Foundry portal

1.  Una vez completada la ejecución de la evaluación, siga el enlace
    para ver los resultados de la evaluación en la página Evaluation de
    la Azure AI Foundry portal.

![](./media/image112.png)

![](./media/image113.png)

2.  Compruebe los **Evaluation results** y el **Metrics dashboard**.

![](./media/image114.png)

![](./media/image115.png)

## Ejercicio 4: Elimine los recursos

1.  Desde la página Azure portal, seleccione el Resouce group asignado.
    Seleccione todos los recursos en Resource group y seleccione Delete.

![A screenshot of a computer Description automatically
generated](./media/image116.png)

2.  INgrese +++**delete**+++ y haga clic en el botón **Delete** para
    confirmar la eliminación. Haga clic en **Delete** en el cuadro de
    diálogo de confirmación de eliminación.

![A screenshot of a computer Description automatically
generated](./media/image117.png)

3.  Confirme la eliminación de todos los recursos con un mensaje de
    éxito.

![A screenshot of a computer screen Description automatically
generated](./media/image118.png)

## Resumen

En este laboratorio, hemos aprendido a construir, evaluar e implementar
una aplicación basada en RAG.

 
