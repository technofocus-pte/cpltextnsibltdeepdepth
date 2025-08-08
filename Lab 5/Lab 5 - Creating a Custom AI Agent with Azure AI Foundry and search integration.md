# Laboratorio 5 – Cree un AI Agent personalizado con Azure AI Foundry y la integración de búsqueda

**Duración estimada: 45 minutos**

## Objetivo

El objetivo de este laboratorio es guiar a los participantes en la
creación de un agente con tecnología de IA mediante los servicios de IA
de Azure y la integración de búsqueda. La generación aumentada de
recuperación (RAG) es una técnica utilizada para crear aplicaciones que
integran datos de fuentes de datos personalizadas en una solicitud para
un modelo de IA generativa. RAG es un patrón comúnmente utilizado para
desarrollar aplicaciones de IA generativa, aplicaciones basadas en chat
que usan un modelo de lenguaje para interpretar entradas y generar
respuestas apropiadas. Los participantes aprenderán a usar el portal de
Azure AI Foundry para integrar datos personalizados en un generative AI
prompt flow.

## Solución

Este laboratorio se centra en la integración de los servicios de IA de
Azure con funcionalidades de búsqueda avanzada para crear una solución
sólida e inteligente. Hace hincapié en la configuración de un agente
impulsado por IA, lo que permite la recuperación de datos sin problemas
y proporciona respuestas contextuales. Al aprovechar la IA y la
integración de búsqueda, la solución tiene como objetivo optimizar los
flujos de trabajo, mejorar la toma de decisiones y mejorar la
participación del usuario a través de interacciones intuitivas y
eficientes.

## Tarea 1: Cree en Azure AI Search resource

1.  En un navegador web, abra el archivo Azure
    portal en +++[https://portal.azure.com+++](https://portal.azure.com+++/) e **inicie
    sesión** usando

- Username - <+++@lab.CloudPortalCredential>(User1).Username+++

- Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer Description automatically
generated](./media/image1.png)

2.  En el home page, seleccione **+ Create a resource.**

![A screenshot of a computer Description automatically
generated](./media/image2.png)

3.   Desde la búsqueda, busque y seleccione +++**Azure AI Search**+++.

![A screenshot of a computer Description automatically
generated](./media/image3.png)

4.  Seleccione el drop down junto a **Create** y seleccione **Azure AI
    Search**.

![A screenshot of a computer Description automatically
generated](./media/image4.png)

5.  En la página Create a search service, ingrese los detalles a
    continuación y haga clic en **Review + create**.

    - **Subscription**: Seleccione su suscripción de Azure en el menú
      desplegable.

    - **Resource group**: Seleccione el grupo de recursos asignado a la
      suscripción (ResourceGroup1)

    - **Service name**: <+++aisearch@lab.LabInstance.Id>+++

    - **Location**: Seleccione
      @lab.CloudResourceGroup(ResourceGroup1).Location

    - **Pricing tier**: Standard

![A screenshot of a computer Description automatically
generated](./media/image5.png)

6.  Revise la configuración y haga clic en **Create**.

![A screenshot of a search service Description automatically
generated](./media/image6.png)

7.  Espere a que se complete la implementación de recursos de Azure AI
    Search.

![A screenshot of a computer Description automatically
generated](./media/image7.png)

## Tarea 2: Cree un recurso y proyecto de Azure AI Hub

1.  Seleccione **Azure AI Foundry** desde la página principal de Azure
    portal.

![image](./media/image8.png)

2.  Seleccione **Use with AI Foundry** -\> **AI Hubs**. Seleccione **+
    Create** -\> **Hub**

![image](./media/image9.png)

3.  Ingrese los detalles a continuación, acepte los otros valores
    predeterminados y seleccione **Review + create**.

    - Subscription - Seleccione la **suscripción asignada**

    - Resource group - Seleccione el grupo de recursos asignado
      (**ResourceGroup1**)

    - Region - Seleccione
      @lab.CloudResourceGroup(ResourceGroup1).Location

    - Name -
      +++[**hub@lab.LabInstance.Id**](mailto:hub@lab.LabInstance.Id)+++

![image](./media/image10.png)

![image](./media/image11.png)

4.  Una vez que pase la validación, seleccione **Create**.

![image](./media/image12.png)

5.  Una vez que se complete la implementación, haga clic en **Go to
    resource**.

![image](./media/image13.png)

6.  Seleccione **Launch Azure AI Foundry** desde la página hub resource.

![image](./media/image14.png)

7.  Desde el hub resource lanzado, baje y seleccione **+ New project**

![image](./media/image15.png)

![image](./media/image16.png)

8.  Introduzca el nombre como
    +++[**ragpfproject@lab.LabInstance.Id**](mailto:ragpfproject@lab.LabInstance.Id)+++
    y seleccione **Create**.

![image](./media/image17.png)

9.  **Cierre** el popup Explore and experiment.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image18.png)

10. Llega en la página del proyecto creado.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

## Tarea 3: Implemente los modelos

Necesita dos modelos para implementar su solución:

- Un embedding model para vectorizar datos de texto para una indexación
  y procesamiento eficientes.

- Un modelo que puede generar respuestas en lenguaje natural a preguntas
  basadas en sus datos.

1.  Seleccione **Models + endpoints** en **My assets** desde el panel
    izquierdo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

2.  En la página **Manage deployments of your models and
    services,** haga clic en **+Deploy model** y sleccione **Deploy base
    model.**

![A screenshot of a computer Description automatically
generated](./media/image21.png)

3.  En la página **Select a model**, busque y
    seleccione +++**text-embedding-ada-002**+++ y haga clic
    en **Confirm.**

![A screenshot of a computer Description automatically
generated](./media/image22.png)

4.  En el panel **Deploy model text-embedding-ada-002**, Acepte el valor
    rellenado previamente para el **Deployment
    name** seleccione **Deployment type** como **standard**. Haga clic
    en **Customize** y escriba los siguientes detalles en el Asistente
    para implementar modelo.

![A screenshot of a computer Description automatically
generated](./media/image23.png)

- **Model version**: Seleccione la versión predeterminada

- **AI resource**: Seleccione el recurso creado anteriormente (es decir,
  el recurso que se enumera en el menú desplegable)

- **Tokens per Minute Rate Limit (thousands)**: 5K

- **Content filter**: DefaultV2

- **Enable dynamic quota**: Disabled

![A screenshot of a computer Description automatically
generated](./media/image24.png)

![A screenshot of a computer Description automatically
generated](./media/image25.png)

![A screenshot of a computer Description automatically
generated](./media/image26.png)

5.  Repita los pasos anteriores para implementar un modelo
    **+++gpt-4o+++** con el nombre de implementación gpt-4o.

![A screenshot of a computer Description automatically
generated](./media/image27.png)

6.  Ahora tenemos las dos implementaciones listas.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

\[!Ojo\] **Ojo:** Reducir los Tokens Per Minute (TPM) Ayuda a evitar el
uso excesivo de la cuota disponible en la suscripción que está
utilizando. 5.000 TPM es suficiente para los datos utilizados en este
ejercicio.

## Tarea 4: Añada datos a su proyecto

Los datos de su copilot consisten en un conjunto de folletos de viaje en
formato PDF de la agencia de viajes ficticia *Margie’s Travel*.
Agreguémoslos al proyecto.

1.  Seleccione **Data + indexes** en **My assets** desde el panel
    izquierdo. Seleccione **+ New data**.

![A screenshot of a computer Description automatically
generated](./media/image29.png)

2.  En el **Add your data** wizard, seleccione **Upload
    files/folders** desde el drop down.

![A screenshot of a computer Description automatically
generated](./media/image30.png)

3.  Seleccione **Upload folder** y seleccione la
    carpeta **brochures** desde **C:\LabFiles** y haga clic
    en **Upload**.

![A screenshot of a computer Description automatically
generated](./media/image31.png)

![A screenshot of a computer Description automatically
generated](./media/image32.png)

4.  Espere a que se cargue la carpeta y observe que contiene varios
    archivos .pdf. Seleccione **Next** una vez que se hayan cargado
    todos los archivos.

![A screenshot of a computer Description automatically
generated](./media/image33.png)

5.  En la página siguiente de name and finish, introduzca el nombre de
    los datos como
    +++[**data@lab.LabInstance.Id**](mailto:data@lab.LabInstance.Id)+++
    y haga clic en **Create.**

![A screenshot of a computer Description automatically
generated](./media/image34.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

## Tarea 5: Cree un índice para los datos

Ahora que ha agregado una fuente de datos a su proyecto, puede usarla
para crear un índice en su Azure AI Search resource.

1.  Desde la página **Data + indexes**, seleccione **Indexes**.

![A screenshot of a computer Description automatically
generated](./media/image36.png)

2.  En la pestaña **Indexes**, seleccione **+ New index** para agregar
    un nuevo index.

![A screenshot of a computer Description automatically
generated](./media/image37.png)

3.  Ingrese los detalles a continuación y haga clic en **Next**.

    - **Data source** - Seleccione **Data in Azure AI Foundry**

Seleccione la fuente de datos enumerada y luego haga clic en **Next**.

![A screenshot of a computer Description automatically
generated](./media/image38.png)

4.  Ingrese los detalles a continuación en Create a vector index – Index
    configuration y haga clic en **Next.**

    - **Select Azure AI Search service**: Seleccione **AzureAISearch**

    - Vector index - +++**brochures-index**+++

    - **Virtual machine**: Seleccione **Auto select**

![A screenshot of a computer Description automatically
generated](./media/image39.png)

5.  En Create a vector index – Search settings,

**Vector settings** - Seleccione **Add vector search to this search
resource**

Acepte los demás valores predeterminados y seleccione **Next.**

![A screenshot of a search box Description automatically
generated](./media/image40.png)

6.  En la página **Review and finish**, revise los detalles y
    seleccione **Create vector index**.

![A screenshot of a computer Description automatically
generated](./media/image41.png)

7.  Espere a que se complete el proceso de indexación, que puede tardar
    varios minutos. La operación de creación de índices consta de los
    siguientes trabajos:

    - Descifre, fragmente e incruste los tokens de texto en los datos de
      sus folletos.

    - Cree el índice de Azure AI Search.

    - Registrar el activo de índice.

![A screenshot of a computer error Description automatically
generated](./media/image42.png)

![A screenshot of a computer program Description automatically
generated](./media/image43.png)

## Tarea 6: Pruebe el index

Antes de usar el índice en un Prompt flow basado en RAG, verifiquemos
que se puede usar para afectar a las respuestas generativas de IA.

1.  Seleccione **Playgrounds** en el panel izquierdo y seleccione **Chat
    Playground.**

![A screenshot of a chat Description automatically
generated](./media/image44.png)

2.  Haga clic en **Show setup** si no está visible de forma
    predeterminada.

![A screenshot of a computer Description automatically
generated](./media/image45.png)

3.  Asegúrese de que la implementación **del modelo gpt-4o** esté
    seleccionada. Luego, en el panel principal de la sesión de chat,
    envíe el prompt +++**Where can I stay in New York?**+++

![A screenshot of a computer program Description automatically
generated](./media/image46.png)

![A screenshot of a chat Description automatically
generated](./media/image47.png)

4.  Revise la respuesta, que debe ser una respuesta genérica del modelo
    sin ningún dato del índice.

5.  En el panel Configuración, expanda el **Add your data**, seleccione
    el **brochures-index** project index y seleccione el **hybrid
    (vector + keyword)** search type.

![A screenshot of a computer Description automatically
generated](./media/image48.png)

\[!Ojo\] **Ojo:** Algunos usuarios encuentran que los índices recién
creados no están disponibles de inmediato. Actualizar el navegador suele
ayudar, pero si sigues experimentando el problema de que no puede
encontrar el índice, es posible que tengas que esperar hasta que se
reconozca el índice.

6.  Esta adición de la fuente de datos inicia una nueva sesión. Una vez
    hecho esto, vuelva a enviar el prompt +++**Where can I stay in New
    York?**+++

![A screenshot of a chat Description automatically
generated](./media/image49.png)

7.  Revise la respuesta y observe que ahora la respuesta se basa en los
    datos del índice.

![A screenshot of a chat Description automatically
generated](./media/image50.png)

## Tarea 7: Use el index en un prompt flow

El índice vectorial se ha guardado en el proyecto de Azure AI Foundry,
lo que le permite usarlo fácilmente en un prompt flow.

1.  Seleccione **Prompt flow** en **Build and customize** desde el panel
    de navegación izquierdo y, a continuación, haga clic en **Create**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image51.png)

2.  Seleccione **Clone** en **Multi-Round Q&A on Your Data**.

![A screenshot of a computer Description automatically
generated](./media/image52.png)

3.  Asigne el nombre de la carpeta como +++**brochure-flow**+++ y haga
    clic en **Clone**.

![A screenshot of a computer Description automatically
generated](./media/image53.png)

\[!Ojo\] **Ojo:** Si se enfrenta a un error de permisos, vuelva a
intentarlo con un nuevo nombre después de 2 minutos y el flujo se
clonará.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

4.  Cuando se abra la página del prompt flow designer, revise
    **brochure-flow**. Su gráfico debe parecerse a la siguiente imagen:

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

![A screenshot a a prompt flow graph](./media/image56.png)

El Prompt flow de ejemplo que está utilizando implementa la lógica de
prompt para una aplicación de chat en la que el usuario puede enviar
iterativamente una entrada de texto a la interfaz de chat. El historial
conversacional se conserva y se incluye en el contexto de cada
iteración. El Prompt flow organiza una secuencia de *herramientas* para:

- Anexar el historial a la entrada del chat para definir un prompt en
  forma de una forma contextualizada de una pregunta.

- Recuperar el contexto utilizando el índice y un tipo de consulta de su
  elección en función de la pregunta.

- Generar un contexto de prompt mediante el uso de los datos recuperados
  del índice para aumentar la pregunta.

- Cree variantes de prompts agregando un mensaje del sistema y
  estructurando el historial de chat.

- Envíe el prompt a un modelo de lenguaje para generar una respuesta de
  lenguaje natural.

5.  Use el **Start compute session** para iniciar el proceso en tiempo
    de ejecución del flujo.

Espere a que se inicie el tiempo de ejecución. Esto proporciona un
contexto de proceso para el Prompt flow. Mientras espera, en la
**pestaña Flow**, revise las secciones de las herramientas del flujo.

![A screenshot of a computer screen Description automatically
generated](./media/image57.png)

6.  En la sección **Inputs**, asegúrese de que las entradas incluyan:

    - **chat_history**

    - **chat_input**

El historial de chat predeterminado de este ejemplo incluye algunas
conversaciones sobre la IA.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image58.png)

7.  En la sección **Outputs**, asegúrese de que la salida incluya:

    - **chat_output** with value ${chat_with_context.output}

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

8.  En la sección **modify_query_with_history**, Seleccione los
    siguientes ajustes (dejar a los demás como están):

    - **Connection**: Seleccione el **Azure OpenAI resource** para el AI
      hubque aparece en la lista

    - **Api**: Seleccione **chat**

    - **deployment_name**: Seleccione **gpt-4o**

    - **response_format**: Seleccione **{“type”:”text”}**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

9.  Una vez iniciada la sesión de proceso, en la sección **de
    búsqueda**, establezca los siguientes valores de parámetro:

    - **mlindex_content**: *Seleccione el campo vacío para abrir el
      panel Generate*

      - **index_type**: Seleccione **Registered Index**

 

- **mlindex_asset_id**: Seleccione **brochures-index:1**

![A screenshot of a computer Description automatically
generated](./media/image61.png)

![A screenshot of a computer Description automatically
generated](./media/image62.png)

Volviendo en la sección Lookup ingrese los detalles a continuación

- **queries**: ${modify_query_with_history.output}

- **query_type**: Hybrid (vector + keyword)

- **top_k**: 2

![A screenshot of a computer Description automatically
generated](./media/image63.png)

10. En la sección **generate_prompt_context**, revise el script de
    Python y asegúrese de que las **entradas** de esta herramienta
    incluyan el siguiente parámetro:

    - **search_result** *(object)*: ${lookup.output}

![A screenshot of a computer Description automatically
generated](./media/image64.png)

11. En la sección **Prompt_variants**, revise el script de Python y
    asegúrese de que las **entradas de** esta herramienta incluyan los
    siguientes parámetros:

    - **contexts** *(string)*: ${generate_prompt_context.output}

    - **chat_history** *(string)*: ${inputs.chat_history}

    - **chat_input** *(string)*: ${inputs.chat_input}

![A screenshot of a chat Description automatically
generated](./media/image65.png)

12. En la sección **chat_with_context**, seleccione la siguiente
    configuración (dejando los demás tal como están):

    - **Connection**: Seleccione el **Azure OpenAI resource**

    - **Api**: Chat

    - **deployment_name**: gpt-4o

    - **response_format**: {“type”:”text”}

A continuación, asegúrese de que las **entradas de** esta herramienta
incluyan los siguientes parámetros:

- **prompt_text** *(string)*: ${Prompt_variants.output}

![A screenshot of a computer Description automatically
generated](./media/image66.png)

13. Seleccione el botón **Save** en la barra de herramientas para
    guardar los cambios que ha realizado en las herramientas de la
    prompt flow.

![A screenshot of a computer Description automatically
generated](./media/image67.png)

14. En la barra de herramientas, seleccione **Chat**. Se abre un panel
    de chat con el historial de conversaciones de muestra y la entrada
    ya rellenada en función de los valores de muestra. Puede ignorar
    estos.

![A screenshot of a computer Description automatically
generated](./media/image68.png)

15. En el panel de chat, reemplace la entrada predeterminada por la
    pregunta +++**Where can I stay in London?**+++ y envíela.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image69.png)

16. La respuesta se basa en los datos del índice.

17. Revise las salidas de cada herramienta en el flujo.

![A screenshot of a computer Description automatically
generated](./media/image70.png)

18. En el panel de chat, escriba la pregunta +++**What can I do
    there?**+++

19. Revise la respuesta, que debe basarse en los datos del índice y
    tener en **cuenta el** historial de chat (por eso “**there**” se
    entiende como “**in London**”).

![A screenshot of a chat Description automatically
generated](./media/image71.png)

20. Revise las salidas de cada herramienta en el flujo, anotando cómo
    cada herramienta en el flujo operó con sus entradas para preparar un
    mensaje contextualizado y obtener una respuesta adecuada.

## Tarea 8: Elimine los recursos:

1.  Desde Azure portal
    (+++[https://portal.azure.com+++](https://portal.azure.com+++/)),
    seleccione **ResourceGroup1**(el que se le asigne a usted).

2.  Seleccione todos los recursos debajo de él y haga clic
    en **Delete**.

![A screenshot of a computer Description automatically
generated](./media/image72.png)

3.  Ingrese +++**delete**+++ y haga clic en **Delete**  para confirmar
    la eliminación. Haga clic en **Delete** en el cuadro de diálogo de
    confirmación de eliminación.

![A screenshot of a computer Description automatically
generated](./media/image73.png)

4.  Asegúrese de que los recursos se eliminen mediante el mensaje de
    confirmación de eliminación.

![A screenshot of a computer screen Description automatically
generated](./media/image74.png)

## Resumen

En este laboratorio, hemos aprendido a crear un agente personalizado que
usa sus propios datos de **Azure AI Foundry**.
