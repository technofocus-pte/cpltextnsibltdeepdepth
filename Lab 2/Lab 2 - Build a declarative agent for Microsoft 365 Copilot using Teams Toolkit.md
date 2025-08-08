# Laboratorio 2: Construya un declarative agent para Microsoft 365 Copilot usando Teams Toolkit

**Duración estimada: 30 minutos**

## Objetivo

El objetivo de este laboratorio es empoderar a los participantes a
construir un agente declarativo para Microsoft 365 Copilot mediante
Teams Toolkit. Al completar este laboratorio, los participantes crearán
un juego de geolocalización que proporciona un descanso divertido y
educativo del trabajo. El laboratorio se centra en comprender la
estructura de los agentes declarativos, configurarlos con instrucciones
e integrarlos en el ecosistema de Microsoft 365 para interacciones de
Copilot personalizadas.

## Solución

Los participantes instalarán Teams Toolkit en Visual Studio Code y
configurarán su entorno de desarrollo. Usando una plantilla, andamiarán
un agente declarativo llamado Geo Locator Game. Personalizarán las
instrucciones del agente y actualizarán sus archivos de configuración,
como instruction.txt y manifest.json. El laboratorio también guía a los
participantes en la mejora del agente con identificadores únicos, iconos
personalizados y funcionalidad de prueba. El resultado es una aplicación
Copilot totalmente funcional y atractiva diseñada para ofrecer pistas
sobre las ciudades mientras se integra a la perfección con Microsoft
365.

## Ejercicio 1: Configure su entorno de desarrollo para Microsoft 365 Copilot

### Tarea 1: Instale Teams Toolkit

Estos laboratorios se basan en la versión 5.0 de Teams Toolkit. Siga los
pasos que se muestran en la captura de pantalla a continuación.

1.  Abra Visual Studio Code y cierre **Appliances.csv** que ya está
    abierto.

2.  En el mensaje Restricted Mode is intended, seleccione **Manage**.

![](./media/image1.png)

3.  Seleccione **Trust** en el diálogo You are in Restricted mode.

![](./media/image2.png)

4.  Haga clic en el botón Extensions toolbar.

![](./media/image3.png)

5.  Busque +++**Teams**+++ y localice el Teams **Toolkit** y haga clic
    en **Install.**

![](./media/image4.png)

6.  Una vez completada la instalación, aparecerá el icono de **Teams
    Toolkit** en la barra de navegación izquierda.  
    ![](./media/image5.png)

## Ejercicio 2: Primer declarative agent

En este laboratorio, creará un agente declarativo simple mediante Teams
Toolkit para Visual Studio Code. Su agente está diseñado para brindarle
un descanso divertido y educativo del trabajo ayudándole a explorar
ciudades de todo el mundo. Presenta pistas abstractas para que adivine
una ciudad, con menos puntos otorgados cuantas más pistas use. Al final,
se revelará su puntuación final.

En este ejercicio aprenderá:

- Para qué sirve un agente declarativo en Microsoft 365 Copilot

- La creación de un agente declarativo mediante la plantilla del kit de
  herramientas de Teams

- Personalice el agente para crear el juego de localización geográfica
  siguiendo instrucciones

- Obtenga información sobre cómo ejecutar y probar su app

- Como ejercicio adicional, necesita un sitio de SharePoint teams

**Introducción**

Los declarative agents aprovechan la misma infraestructura y plataforma
esalable de Microsoft 365 Copilot, personalizadas en concreto para
enfocarse en un área específica de sus necesidades. Sirven como expertos
del tema en áreas o necesidades empresariales específicas, permitiéndole
a usar el mismo interfaz como un Microsoft 365 Copilot chat estándar
mientras se enfocan exclusivamente en la tarea actual.

¡Bienvenid@s a construir su propio agente declarativo! ¡Comenzamos y
convertimos el trabajo de su Copilot en magia!

En este laboratorio, empezará con crear un agente declarativo mediante
Teams Toolkit con una plantilla predeterminada de la herramienta. Esto
le ayuda a iniciar. A continaución, modificará su agente para centrarse
en un juego de geolocalización.

El objetivo de su IA es proporcionar un descanso divertido mientras le
ayuda a aprender más sobre diferentes ciudades del mundo. Ofrece pistas
abstractas para que pueda identificar la ciudad. Cuántas más pistas
necesita, menos puntos obtendrá. Por fin, revelará su puntuación final.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image6.png)

También dará unos archivos a su agente para que pueda referir a un
diario secreto 🕵🏽 y un mapa 🗺️ para dar más retos al jugador.

Así que empezamos

**La anatomía de un Declarative agent**

Verá a medida que desarrollamos más y más extensiones para Copilot, que
al final lo que construirá es una colección de algunos archivos en un
archivo zip al que nos referiremos como un paquete de aplicación que
luego instalará y usará. Por lo tanto, es importante que tenga una
comprensión básica de en qué consiste el paquete de la aplicación. El
paquete de la aplicación de un agente declarativo es como una aplicación
de Teams si ha creado una antes con elementos adicionales. Consulte la
tabla para ver todos los elementos principales. También verá que el
proceso de implementación de la aplicación es muy similar a la
implementación de una aplicación de Teams.

[TABLE]

**Ojo:** puede agregar datos de referencia desde SharePoint, OneDrive,
Web search etc. y agregar capacidades de extensiones a un declarative
agent como plugins y conectores. Aprenderá cómo agregar un plugin en los
próximos laboratorios en esta ruta de aprendizaje.

**Capacidades de un Declarative agent**

Puede mejorar el enfoque del agente en el contexto y los datos, no solo
al agregar instrucciones sino también al especificar la base de
conocimientos a la que que debe acceder. Se llaman capacidades y hay
tres tipos de capacidades admitidas.

- **Microsoft Graph Connectors** - Pase las conexiones de los conectores
  Graph al agente, lo que permite que el agente acceda y utilice el
  conocimiento del conector.

- **OneDrive y SharePoint** - Proporciona direcciones URL de archivos y
  sitios al agente, para que obtenga acceso a esos contenidos.

- **Web search** - Habilita o deshabilita el contenido web como parte de
  la base de conocimientos del agente.

![](./media/image7.png)

**OneDrive y SharePoint**

Las direcciones URL deben ser la ruta de acceso completa a los elementos
de SharePoint (sitio, biblioteca de documentos, carpeta o archivo).
Puede usar la opción "Copy direct link" en SharePoint para obtener la
ruta completa o los archivos y carpetas. Para ello, haga clic con el
botón derecho del ratón en el archivo o carpeta y seleccione Details.
Vaya a Path y haga clic en el icono de copiar. Si no especifica las
direcciones URL, el agente usará todo el corpus de contenido de OneDrive
y SharePoint disponible para el usuario que ha iniciado sesión.

**Microsoft Graph Connector**

Si no se especifican las conexiones, el agente utilizará todo el corpus
de contenido de Graph Connectors disponible para el usuario que ha
iniciado sesión.

**Web search**

Por el momento, no puede pasar sitios web o dominios específicos, y esto
actúa solo como un interruptor de encendido y apagado para usar la web.

## Ejercicio 3: Scaffolding de un agente declarativo a partir de una plantilla

Puede usar cualquier editor para crear un agente declarativo si conoce
la estructura de los archivos en el paquete de la aplicación mencionado
anteriormente. Pero las cosas son más fáciles si usa una herramienta
como Teams Toolkit no solo para crear estos archivos automáticamente,
sino también para ayudarlo a implementar y publicar su aplicación. Por
lo tanto, para mantener las cosas lo más simples posible, utilizará
Teams Toolkit.

### Tarea 1: Use el Teams Toolkit Para crear una aplicación de agente declarativo

1.  Vaya a la extensión Teams Toolkit en su editor de Visual Studio Code
    y seleccione **Create a New App.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

2.  Se abre un panel donde se debe seleccionar **Agent** desde la lista
    de tipos de proyectos.

![](./media/image9.png)

3.  A continuación, se le pedirá elegir la característica de la app de
    Copilot Agent Choose **declarative agent** y presione **Enter**.

![](./media/image10.png)

4.  A continuación, Se le pedirá que elija si desea crear un agente
    declarativo básico o uno con un API plugin. Elija la opción **No
    Plugin**.

![](./media/image11.png)

5.  A continuación, seleccione la opción **Default folder** para
    especificar dónde se debe crear la carpeta del proyecto.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

6.  A continuación, dé un nombre a la aplicación +++**Geo Locator
    Game**+++ y seleccione Enter.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

El proyecto se creará en unos segundos en la carpeta que mencionó y se
abrirá en una nueva ventana de proyecto de Visual Studio Code. Esta es
su carpeta de trabajo.

7.  Haga clic en **Yes, I trust the authors,** si se le pide.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

> ![](./media/image15.png)

¡Bien hecho! ¡Ha configurado con éxito el agente declarativo base!
Ahora, proceda a examinar los archivos que contiene para poder
personalizarlos para crear la aplicación de juego de localización
geográfica.

### Tarea 2: Configure las cuentas en Teams Toolkit

1.  Ahora seleccione el icono Teams Toolkit desde el panel izquierdo. En
    "Accounts" haga clic en "Sign in to Microsoft 365" e inicie sesión
    con sus **User1 credentials**. Haga clic en Sign in en el popup de
    Visual Studio Code.

- Username - <+++@lab.CloudPortalCredential>(User1).Username+++

- Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![](./media/image16.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

3.  Seleccione **Allow access** en el diálogo Security Alert.

![](./media/image18.png)

4.  Una vez dentro, se abre un navegador con el mensaje, "You are signed
    in now and close this page". Por favor, hágalo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

5.  Verifique que el **Custom App Upload Enabled** checker tiene una
    marca de verificación verde.

6.  Verifique que el **Copilot Access Enabled** checker tiene una marca
    de verificación verde.

![](./media/image20.png)

### Tarea 3: Comprenda los archivos en la app

Así es como se ve el proyecto base:

[TABLE]

1.  El archivo de interés para nuestro laboratorio es principalmente el
    **archivo appPackage/instruction.txt,** que son las directivas
    básicas necesarias para su agente. Es un archivo de texto sin
    formato y puede escribir instrucciones en lenguaje natural en él.

![](./media/image21.png)

2.  Otro archivo importante es **appPackage/declarativeAgent.json**
    donde hay un esquema que se debe seguir para ampliar Microsoft 365
    Copilot con el nuevo agente declarativo. Veamos qué propiedades
    tiene el esquema de este archivo.

- El $schema es la referencia del esquema

- La version es la versión del esquema

- El name key representa el nombre del agente declarativo.

- La description proporciona una descripción.

- Las instructions La ruta al archivo **instructions.txt** que contiene
  directivas que determinarán el comportamiento operativo. También puede
  poner sus instrucciones como texto sin formato como un valor aquí.
  Pero para este laboratorio usaremos el archivo **instructions.txt**.

![](./media/image22.png)

3.  Otro archivo importante es el archivo **appPackage/manifest.json**,
    que contiene metadatos cruciales, como el nombre del paquete, el
    nombre del desarrollador y las referencias a los agentes copilot
    utilizados por la aplicación. En la siguiente sección del archivo
    manifest.json se ilustran estos detalles:

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

4.  También puede actualizar los archivos del logotipo color.png y
    outline.png para que coincidan con la marca de su aplicación. En el
    laboratorio de hoy, cambiará **color.png** icono para que el agente
    se destaque.

## Ejercicio 4: Actualice las instrucciones e iconos

### Tarea 1: Actualice los iconos y manifests

1.  Primero, reemplazaremos el logotipo. Reemplazaremos la imagen
    **color.png** en el proyecto por una nueva. Copie la imagen
    **color.png** ubicada en **C:\LabFiles** y reemplace la imagen del
    mismo nombre en la carpeta **appPackage** en su proyecto raíz (la
    ruta debe ser **C:\Users\Student\TeamsApps\Geo Locator
    Game\appPackage**).

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

![](./media/image26.png)

2.  A continuación, vaya al archivo **appPackage/manifest.json** en su
    proyecto raíz y busque el nodo **copilotAgents**. Actualice el valor
    id de la primera entrada de la matriz declarativeAgents de
    declarativeAgent a +++dcGeolocator+++ para hacer que este ID sea
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

3.  A continuación, vaya al archivo **appPackage/instruction txt** y
    copie y pegue las instrucciones a continuación para sobrescribir el
    contenido existente del archivo.

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

4.  Note esta línea en **appPackage/declarativeAgent.json**:

> "instructions": "$\[file('instruction.txt')\]",
>
> Esto trae sus instrucciones del archivo **instruction.txt**. Si desea
> modularizar los archivos de empaquetado, puede usar esta técnica en
> cualquiera de los archivos JSON de la carpeta **appPackage**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image30.png)

### Tarea 2: Agregue iniciadores de conversación

Puede mejorar la participación del usuario con el agente declarativo al
agregar iniciadores de conversación.

Algunos de los beneficios de tener iniciadores de conversación son:

- **Compromiso**: Ayudan a iniciar la interacción, haciendo que los
  usuarios se sientan más cómodos y fomentando la participación.

- **Configuración de contexto**: Los iniciadores establecen el tono y el
  tema de la conversación, guiando a los usuarios sobre cómo proceder.

- **Eficacia**: Al liderar con un enfoque claro, los iniciadores reducen
  la ambigüedad, lo que permite que la conversación avance sin
  problemas.

- **Retención de usuarios**: Los iniciadores bien diseñados mantienen el
  interés de los usuarios, fomentando las interacciones repetidas con la
  IA.

1.  Abra el archivo **declarativeAgent.json** y justo después del nodo
    de instrucciones, agregue una coma, presione enter y pegue el código
    debajo.

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

Ahora que todos los cambios están realizados en el agente, es hora de
probarlo.

2.  Vaya a **Files** en la barra superior y haga clic en el botón **Save
    All.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image32.png)

### Tarea 3: Pruebe la aplicación

1.  Para probar la aplicación, vaya a la extensión del kit de
    herramientas de Teams en Visual Studio Code. Esto abrirá el panel
    izquierdo. En "**LIFECYCLE**" seleccione "**Provision**". Puede ver
    el valor de Teams Toolkit aquí, ya que simplifica la publicación.

![](./media/image33.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

2.  Si se le solicita, inicie sesión con sus credenciales.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image35.png)

3.  En este paso, Teams Toolkit empaquetará todos los archivos dentro de
    la carpeta appPackage como un archivo zip e instalará el agente
    declarativo en su propio catálogo de aplicaciones.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

4.  Una vez que ve el mensaje, **5/5 actions in provision stage executed
    succedssfully**, el proceso está completo.

![A screen shot of a computer AI-generated content may be
incorrect.](./media/image37.png)

5.  Navegue
    a +++[https://teams.microsoft.com/v2/+++ ](https://teams.microsoft.com/v2/+++%C2%A0from) desde
    un navegador e inicie sesión en su tenant si se le pide. La nueva
    aplicación se fijará automáticamente encima de tus chats. Abra
    Teams, seleccione "chats" y verá **Copilot**. Selecciónelo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

\[!Alerta\] Si recibe un mensaje que indica Copilot is currently not
available in this region, use este enlace
+++<https://m365.cloud.microsoft/chat/+++> y siga los mismos pasos para
probar la aplicación.

5.  Una vez cargada la aplicación Copilot, busque el archivo +++Geo
    Locator Game+++ desde el panel derecho como se muestra.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

Si no puede encontrarlo, esta puede ser una lista larga y puede
encontrar a su agente expandiendo la lista seleccionando "see more"

6.  Una vez iniciado, estará en esta ventana de chat enfocada con el
    agente. Y verá los iniciadores de conversación como se marca a
    continuación:

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

7.  Seleccione uno de los iniciadores de conversación y llenará su
    cuadro de mensaje de redacción con el mensaje de inicio, esperando
    que presione "Enter". Todavía es solo su asistente y esperará a que
    tome medidas.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

8.  Intenta responder la pregunta y explorar el juego que desarrollaste.

## Resumen

En este laboratorio, hemos aprendido a crear un agente declarativo
mediante el Teams Toolkit y a probar la funcionalidad del agente.
