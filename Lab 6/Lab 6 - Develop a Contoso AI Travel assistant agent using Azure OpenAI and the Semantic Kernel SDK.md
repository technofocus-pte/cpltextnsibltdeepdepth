# Laboratorio 6 - Desarrollo de un agente asistente de viajes con inteligencia artificial de Contoso mediante Azure OpenAI y el Semantic Kernel SDK

**Duración estimada: 40 minutos**

## Objetivo

En este laboratorio, los participantes crearán un agente de viajes con
tecnología de IA para Contoso mediante Azure OpenAI y el Semantic kernel
SDK. El objetivo es demostrar cómo aprovechar las tecnologías de IA para
crear un agente conversacional capaz de comprender las consultas de los
usuarios, proporcionar recomendaciones de viaje y realizar tareas como
reservar vuelos, hoteles y administrar itinerarios. Al final del
laboratorio, los participantes tendrán experiencia práctica en la
integración de modelos de IA con aplicaciones del mundo real, utilizando
el Semantic kernel SDK para mejorar las capacidades del agente de viajes
y probando el rendimiento del agente en un entorno simulado.

## Área de enfoque de la solución

El laboratorio se centra en la creación de una agencia de viajes con
tecnología de IA mediante Azure OpenAI y el Semantic kernel SDK. Permite
el procesamiento del lenguaje natural (NLP) para gestionar las consultas
de los usuarios relacionadas con la planificación de viajes, como la
reserva de vuelos, alojamientos y el suministro de recomendaciones de
viaje.

El laboratorio hace hincapié en la creación de una interfaz de IA
conversacional que interactúe con los usuarios, responda preguntas y
ayude con las tareas relacionadas con los viajes. Con el Semantic kernel
SDK, organiza tareas como la gestión de itinerarios e integra API para
datos de viajes en tiempo real.

La solución tiene como objetivo mejorar la experiencia del usuario al
proporcionar asistencia de viaje personalizada y receptiva. Automatiza
las tareas de viaje comunes para optimizar los workflows y agilizar los
procesos de planificación de viajes.

## Ejercicio 1: Descripción de la máquina virtual y las credenciales

En este ejercicio, identificaremos y comprenderemos las credenciales que
utilizaremos en todo el laboratorio.

1.  La pestaña **Instructions** tiene la guía de laboratorio con las
    instrucciones que se deben seguir durante todo el laboratorio.

2.  La pestaña **Resources** tiene las credenciales que se necesitarán
    para ejecutar el laboratorio.

    - **URL** – URL al Azure portal

    - **Subscription** – Este es el **ID** de la **suscripción**
      asignada a usted

    - **Username** – El **ID de usuario** con el que debe **iniciar
      sesión** en el **Azure services**.

    - **Password** – **Contraseña** para el **Azure login**.

Llamemos a este nombre de usuario y contraseña como **Azure login
credentials**. Usaremos estas credenciales dondequiera que
mencionemos **Azure login credentials**.

- **Resource Group** – El **grupo de recursos** que se le ha asignado.

\[!Alerta\] **Importante**: Asegúrese de crear todos los recursos en
este grupo de recursos

![A screenshot of a computer Description automatically
generated](./media/image1.png)

3.  La pestaña **Help** tiene kla información de Support. El
    valor **ID** aquí es **Lab instance ID** que se utilizará durante la
    ejecución del laboratorio.

![A screenshot of a computer Description automatically
generated](./media/image2.png)

## Ejecicio 2: Cree un Azure OpenAI resource e implementación de modelos

1.  Inicie sesión en +++\*\* con las Azure login credentials,

    - Username - <+++@lab.CloudPortalCredential>(User1).Username+++

    - Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image3.png)

2.  Busque +++**Azure OpenAI**+++ en la barra de búsqueda y
    selecciónelo.

![A screenshot of a computer Description automatically
generated](./media/image4.png)

3.  Seleccione **+ Create**.

![A screenshot of a computer Description automatically
generated](./media/image5.png)

4.  Complete los detalles a continuación en la pestaña **Basics** y
    seleccione **Next**.

    - Subscription – Seleccione la **suscripción asignada**

    - Resource group – Seleccione el **grupo de recursos** que se le ha
      asignado

    - Region – @lab.CloudResourceGroup(ResourceGroup1).Location

    - Name –
      +++[**AOAI@lab.LabInstance.Id**](mailto:AOAI@lab.LabInstance.Id)+++

    - Pricing tier – **Standard**

![A screenshot of a computer Description automatically
generated](./media/image6.png)

5.  Acepte los valores predeterminados en las
    páginas **Network** y **Tags** y haga clic en **Create** en la
    página **Review + submit**.

![A screenshot of a computer Description automatically
generated](./media/image7.png)

6.  Una vez creado, haga clic en **Go to resource** y seleccione el
    **Azure OpenAI** que ha creado ahora.

![A screenshot of a computer Description automatically
generated](./media/image8.png)

7.  Seleccione **Keys and Endpoint** en **Resource Management**. Copie
    los valores **Key 1** y **Endpoint** a un notepad para uso futuro en
    este laboratorio.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

8.  Desde la página Azure OpenAI resource **Overview**, seleccione **Go
    to Azure AI Foundry portal**.

![A screenshot of a computer Description automatically
generated](./media/image10.png)

9.  En el panel izquierdo, seleccione **Deployments**.

![A screenshot of a computer Description automatically
generated](./media/image11.png)

10. Seleccione **+ Deploy model** -\> **Deploy base model**

![A screenshot of a computer Description automatically
generated](./media/image12.png)

11. Busque y seleccione +++**gpt-35-turbo**+++. Haga clic
    en **Confirm**.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image13.png)

12. Acepte los valores predeterminados y seleccione **Deploy**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

## Ejericicio 3: configure el AI Travel Agent Project con Azure OpenAI Services

En este ejercicio, instalará la carpeta del proyecto en Visual Studio
Code y la configurará para que se integre con Azure OpenAI Services.
Siguiendo los pasos, aprenderá a configurar un entorno de desarrollo
local, modificar los archivos del proyecto y preparar la aplicación para
su ejecución con los detalles de implementación de Azure OpenAI.

1.  Busque +++**Command Prompt**+++ desde la búsqueda Windows Search y
    abra **Command prompt**.

![A screenshot of a computer Description automatically
generated](./media/image15.png)

2.  Ejecute los siguientes comandos uno por uno.

+++dotnet nuget list source+++

+++dotnet nuget add source <https://api.nuget.org/v3/index.json> --name
nuget.org+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

3.  Abra **Visual Studio Code** que está anclado a Windows Taskbar.
    Seleccione **File** -\> **Open folder**.

![A screenshot of a computer Description automatically
generated](./media/image17.png)

4.  Navegue a **C:\LabFiles** y seleccione **AITravelAgent** y haga clic
    en **Select Folder**. La carpeta se abrirá en VS Code.

![A screenshot of a computer Description automatically
generated](./media/image18.png)

5.  Seleccione **Yes, I trust the authors** en el Do you want to trust
    the authors of the files in this folder?

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image19.png)

6.  En el panel Explorer, navegue a la
    carpeta **AITravelAgent/Starter**. Haga clic en la carpeta y
    seleccione **Open in Integrated Terminal**.

![A screenshot of a computer Description automatically
generated](./media/image20.png)

7.  En el panel Explorer, expanda Starter, y debería ver las carpetas
    Plugins, Prompts y el archivo Program.cs.

![A screenshot of a computer Description automatically
generated](./media/image21.png)

8.  Abra el archivo Starter/Program.cs y actualice las siguientes
    variables con el nombre de implementación, la clave de API y el
    endpoint de Azure OpenAI Services. Después de realizar los cambios,
    presione Ctrl + S para guardar el archivo:

> string yourDeploymentName = +++**gpt-35-turbo**+++
>
> string yourEndpoint = The Azure OpenAI resource Endpoint value we
> saved earlier
>
> string yourKey = The Key1 of the AOAI resource that we saved earlier

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image22.png)

## Ejercicio 4:Cree y pruebe el Currency Converter Plugin con Semantic Kernel

En este ejercicio, creará un plugin de conversión de divisas utilizando
Semantic Kernel. Escribirá y probará una función que convierte una
cantidad de una moneda a otra utilizando tipos de cambio predefinidos.
Este ejercicio te ayudará a entender cómo crear e invocar plugins
personalizados, utilizar decoradores para la funcionalidad y las
descripciones, e integrar plugins en una aplicación más grande.

1.  Cree un nuevo archivo llamado +++CurrencyConverter.cs+++ en la
    carpeta **Stater/Plugins/ConvertCurrency**

![A screenshot of a computer Description automatically
generated](./media/image23.png)

2.  En el archivo CurrencyConverter.cs, agregue el siguiente código para
    crear una función de plugin

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

En este código, se usa el decorador KernelFunction para declarar la
función nativa. También se usa el decorador Description para agregar una
descripción de lo que hace la función. Puede usar Currency.Currencies
para obtener un diccionario de monedas y sus tipos de cambio. A
continuación, agregue algo de lógica para convertir una cantidad
determinada de una moneda a otra.

3.  Modify your ConvertAmount function. Replace the existing code with
    the below code.

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

En este código, se usa el diccionario Currency.Currencies para obtener
el objeto Currency para las monedas de destino y base. A continuación,
utilice el objeto Currency para convertir el importe de la divisa base a
la divisa de destino. Por último, devuelva una cadena con la cantidad
convertida. A continuación, probemos su plugin.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image25.png)

\[!Ojo\] **Ojo:** Al usar el Semantic kernel SDK en sus propios
proyectos, no necesita codificar datos en archivos si tiene acceso a las
API RESTful. En su lugar, puede usar el plugin Plugins.Core.HttpClient
para recuperar datos de las API.

4.  En el archivo Starter/Program.cs, importe e invoque la nueva función
    del plugin con el siguiente código. (Elimine el código a
    continuación: var kernel = builder.Build(); y reemplácelo con el
    código que se proporciona a continuación. )

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

En este código, se usa el método ImportPluginFromType para importar el
complemento. A continuación, use el método InvokeAsync para invocar la
función de complemento. El método InvokeAsync toma el nombre del
complemento, el nombre de la función y un diccionario de parámetros. Por
último, imprimes el resultado en la consola. A continuación, ejecute el
código para asegurarse de que funciona.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

5.  Vaya a **File** en la barra superior y seleccione **Save all.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

6.  En el terminal, ingrese +++**dotnet run**+++. Debería ver el
    siguiente resultado:

**Output:** $52000 VND is approximately $2.13 in US Dollars (USD)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

Ahora que su plugin funciona correctamente, creemos un prompt de
lenguaje natural que pueda detectar qué monedas y cantidad desea
convertir el usuario.

## Ejercicio 5: Configure un Target Currency Prompt para Semantic Processing

En este ejercicio, configurará un sistema de prompt para identificar las
monedas de destino, las monedas base y los importes a partir de la
entrada del usuario. Al crear y configurar archivos de configuración y
prompts, definirá cómo la IA interpreta y procesa los prompts de
lenguaje natural para conversiones de moneda.

1.  Desde Visual Studio Code, ubique la carpeta **Starter/Prompts**.
    Vaya a esta carpeta para prepararse para los siguientes pasos.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image29.png)

2.  Dentro de la carpeta **Starter/Prompts**, Cree una nueva carpeta
    llamada +++**GetTargetCurrencies**+++. Esta carpeta contendrá todos
    los archivos relacionados con este ejercicio.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

3.  Dentro de la **carpeta GetTargetCurrencies**, cree un nuevo archivo
    denominado +++**config.json**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

4.  Abra el archivo config.json recién creado en Visual Studio Code.
    Copie y pegue el siguiente código en el archivo.

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

Guarde el archivo pulsando **Ctrl + S**. Esta configuración define cómo
el sistema de IA debe interpretar y procesar la entrada del usuario.

5.  En la carpeta **Prompts**, cree otro archivo nuevo llamado
    +++**skprompt.txt**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  Abra el archivo **skprompt.txt** en su editor de texto y pegue el
    siguiente contenido:

> \<message role="system"\>Identify the target currency, base currency,
> and
>
> amount from the user's input in the format
> target|base|amount\</message\>
>
> For example:
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

Guarde el archivo pulsando **Ctrl + S**. Este script define la lógica de
prompt para procesar las prompts de conversión de moneda.

## Ejercicio 6: Configure un Prompt System para recomendaciones de actividades de viaje

En este ejercicio, configurará y personalizará un prompt system para
sugerir actividades y puntos de interés en función del destino de viaje
de un usuario. Al editar los archivos de configuración y prompt,
definirá el comportamiento, el tono y los requisitos de entrada del
sistema para generar recomendaciones de viaje personalizadas y
creativas.

1.  Desde Visual Studio Code, vaya a la
    carpeta **Starter/Prompts/SuggestActivities**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

2.  Busque el archivo **config.json** dentro de la carpeta
    SuggestActivities y ábralo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

3.  Reemplace el código existente en el **archivo config.json** por lo
    siguiente:

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

Guarde el archivo después de realizar los cambios presionando **Ctrl +
S**. Este archivo configura el sistema para procesar las entradas del
usuario y generar sugerencias de actividades.

4.  Permanezca dentro de la carpeta SuggestActivities y busque el
    **archivo skprompt.txt**. Abra este archivo en el editor.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

5.  Sustitúyase el contenido existente de **skprompt.txt** por el texto
    siguiente:

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

Guarde el archivo pulsando **Ctrl + S**. Este script establece el
comportamiento y el tono del sistema al generar recomendaciones de
actividad.

## Ejercicio 7: Configure el Programa Principal para AI Workflow

En este ejercicio, configurará el archivo de main Program.cs para
integrarlo con los servicios de Azure OpenAI y el Semantic Kernel de
Microsoft. Al personalizar el código, habilitará funcionalidades como la
conversión de moneda, sugerencias de actividades y recomendaciones de
viaje. Esta configuración establece un sólido workflow impulsado por IA
para la interacción del usuario y el reconocimiento de intenciones,
aprovechando los plugins y la lógica basada en prompts.

1.  Desde el proyecto en Visual Studio Code, vaya al archivo
    **Starter/Program.cs** y ábralo para editarlo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

2.  Reemplace todo el contenido del archivo de **Program.cs** por el
    siguiente código y, a continuación, **presione ctrl + S** para
    guardar el código.

\[!Ojo\] O**jo:** Después de reemplazar el código, reemplace los
marcadores de posición del endpoint y key por sus valores.

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

El programa comienza importando espacios de nombres esenciales, como
System.Text para el manejo de texto y Microsoft.SemanticKernel para
flujos de trabajo conversacionales impulsados por IA. Integra los
servicios OpenAI de Microsoft Azure a través del espacio de nombres
Microsoft.SemanticKernel.Connectors.OpenAI, permitiendo la comunicación
con el modelo GPT (gpt-35-turbo). La configuración implica la
configuración de variables como yourDeploymentName, yourEndpoint y
yourApiKey para autenticarse y conectarse a la carpeta Azure OpenAI
endpoint.

El Semantic Kernel se inicializa mediante un patrón de compilación. Se
importan plugins para funcionalidades adicionales, como
CurrencyConverter y ConversationSummaryPlugin. Además, las solicitudes
almacenadas en un directorio (Prompts) se cargan dinámicamente para
facilitar el reconocimiento de intenciones y la ejecución de tareas.

El loop principal del programa interactúa con el usuario solicitando
entrada y determinando la intención mediante el símbolo del sistema
GetIntent. En función de la intención, el programa se ramifica en
diferentes funcionalidades:

1.  **Conversión de moneda**: Si la intención es convertir moneda, el
    programa extrae los detalles (moneda de destino, moneda base e
    importe) mediante el símbolo del sistema GetTargetCurrencies. A
    continuación, llama al método ConvertAmount del plugin
    CurrencyConverter y muestra el resultado.

2.  **Sugerencias de Destinos**: Si la intención es sugerir destinos, el
    programa usa el método InvokePromptAsync del Semantic Kernel para
    proporcionar recomendaciones basadas en la entrada del usuario.

3.  **Sugerencias de actividades**: Esta funcionalidad aprovecha el
    resumen de conversaciones a través de ConversationSummaryPlugin para
    proporcionar sugerencias de actividades contextualmente relevantes.
    El historial de conversaciones se mantiene mediante un objeto
    StringBuilder para el flujo de diálogo continuo.

4.  **Frases útiles y traducción**: Para intenciones como "Helpful
    Phrases" o "Translate", el kernel invoca automáticamente funciones
    relevantes en función de la entrada y la configuración.

Otras intenciones de usuario se manejan de forma genérica invocando el
prompt system, lo que garantiza la flexibilidad en las respuestas. El
loop de interacción continúa hasta que el usuario no proporciona ninguna
entrada (una string vacía).

## Ejercicio 8: Prueba de la aplicación

En este ejercicio, probará la funcionalidad de la aplicación mediante la
ejecución de consultas de conversión de moneda, sugerencias de destino y
recomendaciones de actividades. Esto garantizará que su sistema
impulsado por IA funcione según lo previsto y proporcione resultados
precisos y sensibles al contexto.

**Pasos para probar**

1.  **Ejecución de la aplicación**

    - Haga clic con el botón derecho en la carpeta de inicio y
      seleccione **Open in Integrated Terminal**.

    - En el terminal, introduzca el siguiente comando para ejecutar la
      aplicación:

+++dotnet run+++

2.  **Conversión de moneda de prueba**

    - Al pedir **What would you like to do?,** introduzca una consulta
      de conversión de moneda como se indica a continuación  
      +++**How much is 60 USD in New Zealand dollars?**+++

    - Resultado esperado:  
      **$60 USD is approximately $97.88 in New Zealand Dollars (NZD)**

3.  **Sugerencias de destino de prueba**

    - Escriba una consulta para sugerencias de destino, proporcionando
      contexto como el siguiente,

> **+++I'm planning an anniversary trip with my spouse, but they are
> currently using a wheelchair and accessibility is a must. What are
> some destinations that would be romantic for us?+++**

- **Resultado esperado:** A list of accessible romantic destinations,
  such as:

  1.  Santorini, Greece: Romantic sunsets and wheelchair-accessible
      paths in certain areas.

  2.  Venice, Italy: Gondola rides with accessible boarding options.

  3.  Maui, Hawaii: Stunning views and accessible resorts.

4.  **Sugerencias de actividades de prueba**

    - Introduzca una consulta de recomendaciones de actividades en un
      destino específico. Por ejemplo:  
      **+++What are some things to do in Barcelona?+++**

    - Resultado esperado: Recommendations tailored to the destination,
      such as:

      1.  Visit the Sagrada Família: A Gaudí masterpiece with accessible
          facilities.

      2.  Explore Park Güell: Unique mosaic designs with
          wheelchair-friendly routes.

      3.  Discover the Picasso Museum: A wheelchair-accessible art
          venue.

## Ejercicio 7: Elimine los recursos

1.  Desde Azure portal
    (+++[https://portal.azure.com+++](https://portal.azure.com+++/)),
    seleccione el Resource group que se le asigna.

2.  Seleccione los recursos debajo de él y haga clic en **Delete**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  Tecle +++delete+++ en el cuadro de texto de confirmar eliminación y
    haga clic en **Delete**.

4.  Seleccione **Delete** en el cuadro de diálogo delete confirmation.

5.  Busque una notificación de confirmación de recurso eliminado.

## Resumen

En este laboratorio, hemos aprendido a crear un agente utilizando
Semantic Kernel y Azure OpenAI Service.
