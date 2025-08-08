# Laboratorio 3: Construya un Contoso Agent personalizado para chatear con sus datos usando el Teams AI Library y Teams Toolkit

**Duración estimada: 45 minutos**

## Objetivo

El objetivo de este laboratorio es habilitar a los participantes a
construir un Contoso Agent personalizado aprovechando el Teams AI
Library y Teams Toolkit. Los participantes configurarán el Azure OpenAI
API para integrar las capacidades de GPT, configurar y gestionar datos
mediante Azure OpenAI y Azure Blob Storage, e implementar un modelo de
chat personalizado para las interacciones impulsadas por la IA. Al final
del laboratorio, habrán creado y configurado un agente personalizado con
tecnología de IA de Teams mediante Visual Studio Code y el Teams
Toolkit, adquiriendo experiencia práctica en la implementación y
administración de aplicaciones habilitadas para IA.

## Área de enfoque de la solución

Esta guía de laboratorio se centra en permitir que los participantes
aprovechen la API de Azure OpenAI para crear interacciones de chat
inteligentes y contextuales. Los participantes configurarán modelos
basados en GPT y se integrarán con servicios de Azure como Blob Storage
y Azure AI Search para una gestión de datos eficiente.

El laboratorio proporciona experiencia práctica en la implementación y
personalización de modelos de chat con prompts y configuraciones
personalizadas para satisfacer las necesidades empresariales. Además,
los participantes crearán un agente de IA personalizado utilizando la
biblioteca de IA de Teams y el Teams Toolkit, integrándolo sin problemas
en los workflows de la organización.

## Ejericicio 1: Configure el Azure OpenAI API y permisos de roles

### Tarea 1: Cree un Azure OpenAI API key para usar el GPT del OpenAI

1.  Abra un navegador, navegue a la siguiente URL
    +++<https://oai.azure.com/portal+++> e inicie sesión usando,

    - Username - <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image1.png)

2.  En la página de inicio de **Azure AI Foundry** haga clic en **Create
    new Azure OpenAI resource**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image2.png)

3.  Se abrirá la ventana Create Azure OpenAI, y si se le pide, inicie
    sesión de nuevo. Ingrese los siguientes detalles en los campos
    correspondientes y haga clic en **Next**.

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image3.png)

4.  En la pestaña **Network** y la pestaña **Tags**, acepte los valores
    predetrminados y haga clic en **Next**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image4.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image5.png)

5.  En la pestaña **Review + submit** haga clic en **Create.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image6.png)

6.  Después de la implementación exitosa, la ventana se navega a la
    página CognitiveServiceOpenAI automáticamente. Haga clic en **Go to
    resource** para ir a la página Resource Group.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image7.png)

7.  Seleccione el recurso Azure OpenAI creado. En la página AzureOpenAI
    resource, desde el panel izquierdo, seleccione **Keys and
    Endpoint** en **Resource Management** y copie y **guarde** los
    valores de **Key** y **Endpoint** a un notepad para más tarde.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

### Tarea 2: Asigne el rol de Cognitive contributor.

1.  Seleccione el **ResourceGroup1** para ir a la página de Resource
    Group overview.

2.  Seleccione **Access control (IAM)** desde el panel izquierdo de la
    página Resource group. Y seleccione **+** **Add** y haga clic
    en **Add role assignment**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

3.  Busque y seleccione +++**cognitive service contributor+++**, haga
    clic en **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

4.  Haga clic en **Select members** para asignar miembros.
    Busque <+++@lab.CloudPortalCredential>(User1).Username+++ y haga
    clic en **Select**. Haga clic en **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

5.  En la pestaña assignment type, seleccione assignment type
    como **Active**, duration como **Permanent**, y haga clic
    en **Review +Assign** y de nuevo en **Review + Assign**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

6.  Recibirá un mensaje de éxito una vez que la asignación de roles se
    haya realizado correctamente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image15.png)

## Ejercicio 2: Configure sus datos en Azure OpenAI

### Tarea 1: Implemente el chat en AI Foundry

1.  Seleccione el menú con tres barras horizontales en la esquina
    superior izquierda y haga clic en **All resources**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

2.  Seleccione el Azure OpenAI
    service [**ContosoAgent@lab.LabInstance.Id**](mailto:ContosoAgent@lab.LabInstance.Id) que
    creó anteriormente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

3.  Seleccione **Go to Azure AI Foundry portal**.

4.  Seleccione **Model Catalog** desde el panel izquierdo.

![image](./media/image18.png)

5.  En la página **Select a chat completion model**, busque
    +++gpt-4o+++, selecciónelo y haga clic en **Confirm.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

6.  En l panel **Deploy model gpt-4o**, expanda la
    pestaña **Customize** ingrese los siguientes detalles, y haga clic
    en **Deploy.**

    - **Deployment type**: Standard

    - **Deployment name**: gpt-4o

    - **Token per Minute Rate**: 5K (Desplázate para ajustar el límite.
      Si no funciona, haga clic en él y luego use la tecla de flecha
      Shift + Derecha / Izquierda para ajustar el límite)

    - **Content Filter**: defaultv2

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image21.png)

7.  Puede comprobar la implementación en **Shared
    resources** en **Deployments**

\![Una captura de pantalla de un contenido generado por IA de una
computadora puede ser incorrecto.\](./media/image25.png)

### Tarea 2: Cree una cuenta de almacenamiento

1.  Desde el Azure portal, la página de inicio
    +++<https://portal.azure.com/+++> , busque y seleccione +++Storage
    accounts+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image22.png)

2.  Haga clic en **+ Create,** ingrese los siguientes datos y haga clic
    en **Review + create.**

    - Subscription – Seleccione su subscription

    - Resource group – Seleccione su Resourcegroup asignado

    - Storage account name - <+++contosostorage@lab.LabInstance.Id>+++

    - Region – Select @lab.CloudResourceGroup(ResourceGroup1).Location

    - Primary service – Azure Blob storage o Azure Data Lake Storage Gen
      2

    - Performance – Standard

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

3.  Haga clic en **Create** y espere a que se complete la implementación
    y luego haga clic en **Go to resource**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

4.  En la cuenta de almacenamiento recién creada, vaya
    a **Containers** en Data storage y haga clic en **+ Container**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

5.  Ingrese el container name como +++**source**+++ y haga clic
    en **create.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

6.  Haga clic en el **source** container y ábralo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

7.  Para agregar datos a la carpeta source container, haga clic
    en **Upload** --\_ **Browse for files** y luego en C:\Labfiles
    seleccione **TF-AzureOpenAI.pdf** Después de seleccionar el archivo,
    haga clic en el botón **Upload**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

### Tarea 3: Cree Azure AI search

1.  Desde la página home de Azure portal
    +++<https://portal.azure.com/+++> , busque y seleccione +++**AI
    search**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

2.  Haga clic en **+ Create** para crear un nuevo Azure AI Search
    resource.

Ingrese los siguientes detalles y haga clic en **Review + create** y
seleccione **Create**.

- Subscription: seleccione su subscription

- Resource Group: Seleccione su Resource group asignado

- Service name: <+++contoso-ai-search-@lab.LabInstance.Id>+++

- Location: @lab.CloudResourceGroup(ResourceGroup1).Location

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

![A screenshot of a search service AI-generated content may be
incorrect.](./media/image35.png)

![A screenshot of a search engine AI-generated content may be
incorrect.](./media/image36.png)

3.  En el search-service-contoso-ai-search-01overview haga clic en **Go
    to resource**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

4.  En el <contoso-ai-search-@lab.LabInstance.Id> overview, guarde
    el **URL** endpoint para uso futuro. Luego, desde la barra de
    navegación izquierda, seleccione **keys** en **Settings** y
    guarde **primary** y **secondary** **key** para uso futuro.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

### Tarea 4: Agregue datos para chatear en Azure AI Foundry

1.  Desde la página **Azure AI Foundry**, seleccione **Chat** -\> **Add
    your data -\> Add a data source**.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image40.png)

2.  Desde el dropdown, seleccione **Azure Blob Storage (preview)**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  En la página **Add data**, ingrese los siguientes detalles y haga
    clic en **Next.**

    - Select data source – Azure Blob Storage(preview)

    - Subscription - Seleccione su subscription

    - Select Azure Blob storage resource –
      Select [**contosostorage@lab.LabInstance.Id**](mailto:contosostorage@lab.LabInstance.Id)

    - Select storage container – Seleccione **source**

    - Select Azure AI Search resource –
      Seleccione [**contoso-ai-search-@lab.LabInstance.Id**](mailto:contoso-ai-search-@lab.LabInstance.Id)

    - Index Name - Type <+++contosoindex@lab.LabInstance.Id>+++

    - Indexer schedule - Once

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image42.png)

4.  En la página **Data management**, seleccione search type
    como **keyword** y haga clic en **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image43.png)

5.  En la página **Data connection**, seleccione **API key** y haga clic
    en **Next.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image44.png)

6.  En la página **Review and finish**, haga clic en **Save and close.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image45.png)

7.  La ingesta llevará algún tiempo, una vez completada, los detalles de
    los datos se reflejarán en el panel. Una vez completado el proceso
    de ingesta de datos, puede empezar a crear el agente de motor
    personalizado mediante el método Teams AI library y Teams Toolkit.

\[!Ojo\] **Ojo:** Los archivos deben estar en formato .txt, .md, .html,
.pdf, .docx o .pptx con un límite de tamaño de 16 MB.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image46.png)

## Ejercicio 3: Cree y configure your custom agent

### Tarea 1: Agregue un Teams Toolkit extension

1.  Abra **Visual Studio Code,** en su PC. Seleccione **Trust** para
    suprimir las restricciones en el Visual Studio Code.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

2.  En la página de inicio de VS, en el panel izquierdo haga clic en el
    icono **Extensions**, busque +++**Teams Toolkit**+++ y haga clic
    en **Install.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image48.png)

3.  Una vez completada la instalación, seleccione el icono del Teams
    Toolkit![](./media/image49.png) en el Visual Studio Code Activity
    Bar y seleccione **Create a New App**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image50.png)

4.  Seleccione **Custom Engine Agent**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image51.png)

5.  Seleccione **Basic AI Chatbot**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image52.png)

6.  Seleccione **JavaScript** como lenguaje de programación.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image53.png)

7.  Select **Azure OpenAI**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

8.  Ingrese los valores del Portal de Azure, el que hemos copiado y
    guardado en el archivo notepad.

    - **Azure OpenAI key**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

- **Azure OpenAI endpoint**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image56.png)

- **Deployment name** - +++gpt-4o+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image57.png)

9.  Cree una nueva carpeta para contener los datos relacionados con los
    equipos y navegue hasta esa ubicación haciendo clic en **Browse**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image58.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

10. Ingrese +++**TeamsContosoAgent**+++ como nombre del agente de motor
    personalizado, seleccione **Enter**. El agente de motor
    personalizado se crea en unos segundos.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

11. Seleccione Yes, I author

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image61.png)

**Haga un recorrido por el código fuente**

Echa un vistazo a lo que hay dentro de esta plantilla de chatbot de IA
básica \> agente de motor personalizado.

[TABLE]

### Tarea 2: Configure su agente personalizado

Vamos a personalizar el prompt para el agente de motor personalizado.

1.  Vaya a src/prompts/chat/skprompt.txt y reemplace el código existente
    con el código a continuación. Después de actualizar, presione
    **ctrl+s** para guardar el archivo.

> The following is a conversation with an AI assistant, who is an expert
> on answering questions over the given context.
>
> Responses should be in a short journalistic style with no more than 80
> words.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

2.  Ve al archivo **de config.json** en prompts/chat. Reemplace el
    código existente por el código siguiente y reemplace el
    **endpoint**, el **index_name** y los valores **de key** por los
    detalles del recurso de **Azure AI Search**. Después de actualizar,
    presione **ctrl+s** para guardar el archivo.

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

3.  Vaya al archivo src/app/app.js y agregue la siguiente variable
    dentro de OpenAIModel, después de la entrada azureEndpoint.

+++azureApiVersion: '2024-02-15-preview',+++

![A screen shot of a computer program AI-generated content may be
incorrect.](./media/image64.png)

4.  Abra Powershell como administrador y ejecute el siguiente comando, e
    ingrese A.

5.  Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image65.png)

6.  Volviendo en el **Visual Studio Code**, en el panel izquierdo,
    seleccione **Run and Debug (Ctrl+Shift+D)**. Seleccione **Debug in
    Test Tool** Para iniciar la depuración.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image66.png)

7.  Seleccione Allow access si recibe una alerta de Windows Security.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image67.png)

8.  El agente de motor personalizado se ejecuta dentro de la clase Teams
    App Test Tool, que se abre en su navegador.

![A black screen with white text AI-generated content may be
incorrect.](./media/image68.png)

9.  El navegador abrirá una nueva pestaña, Teams App Test Tool y las
    consultas se pueden ejecutar en la aplicación.

![A screenshot of a computer Description automatically
generated](./media/image69.png)

## Conclusión

Al completar este laboratorio, los participantes han adquirido
experiencia práctica en la creación e implementación de un chatbot
personalizado impulsado por IA utilizando la Teams AI library y el Teams
Toolkit. Esto incluyó la configuración de recursos de Azure OpenAI, la
integración del almacenamiento de datos y las capacidades de búsqueda de
IA, y la personalización del chatbot para interacciones sensibles al
contexto. A través de este ejercicio, los participantes han aprendido a
configurar agentes inteligentes adaptados a las necesidades del negocio
e integrarlos en los workflows de la organización, aprovechando
eficazmente las capacidades modernas de IA dentro de Microsoft Teams.
