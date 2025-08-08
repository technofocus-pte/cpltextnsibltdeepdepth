# Laboratorio 1 – Agilice las operaciones de soporte de IT con agente de Copilot autónomo mediante Copilot Studio

**Duración estimada: 60 minutos**

## Objetivo

El objetivo de este laboratorio es permitir a los participantes
simplificar las operaciones de soporte técnico de TI en Contoso
Solutions mediante la creación de un agente Copilot autónomo. Los
participantes aprenderán a configurar Microsoft Copilot Studio,
configurar el agente de soporte de TI, integrar Power Apps y Dataverse,
mejorar las capacidades del bot con una base de conocimientos y
automatizar la creación de tickets con Power Automate. Este laboratorio
práctico equipará a los usuarios con las habilidades para mejorar los
flujos de trabajo de TI, reducir el esfuerzo manual y mejorar la
eficiencia del soporte.

## Solución

Los participantes crearán un agente de soporte técnico de TI de Contoso
personalizado mediante Microsoft Copilot Studio, lo configurarán para
manejar problemas de TI comunes y lo integrarán con Dataverse para
almacenar datos de soporte técnico. Establecerán un entorno de
desarrollo, agregarán fuentes de conocimiento y refinarán los flujos de
conversación del bot para una mejor interacción con el usuario. Al
aprovechar Power Apps, los participantes crearán una tabla de Dataverse
para administrar los registros de soporte de TI. Con Power Automate,
automatizarán la creación de tickets y las notificaciones por correo
electrónico para problemas no resueltos. Por último, los participantes
pondrán a prueba el agente para validar su precisión en la resolución de
problemas y la automatización del flujo de trabajo, lo que garantiza que
las operaciones de soporte de TI sean fluidas.

## Ejercicio 1: Primeros pasos con Power Apps

Este ejercicio presenta a los participantes Power Apps y Dataverse. El
objetivo es iniciar sesión en Power Apps, configurar un entorno de
trabajo y crear una tabla de Dataverse importando datos de un archivo de
Excel. Los participantes aprenderán habilidades esenciales para trabajar
con aplicaciones basadas en datos.

### Tarea 1: Inicie sesión en Power Apps

1.  Abra un navegador desde el VM del laboratorio.

2.  Navegue al sitio web de power apps
    +++<https://www.microsoft.com/en-us/power-platform/products/power-apps+++> y
    haga clic en el botón **Try for Free**.

![](./media/image1.png)

3.  Ingrese el **Administrative Username** desde la sección **Office 365
    Tenant** de la pestaña **Resources** en el campo del
    email, **seleccione la casilla** y haga clic en el botón **Start
    free**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image2.png)

4.  Ingrese el **Administrative Password** y se le llevará a la página
    principal de Power Apps Home.

5.  Seleccione **Yes** en el diálogo Stay Signed in y **Got it** para el
    prompt de Save password y seleccione **No, Thanks** en el popup Sign
    in to Microsoft Edge.

\[!Note\] **Ojo:** Si se le pide el user name, password o cualquier
información para iniciar sesión, por favor proporciónela e inicie
sesión.

### Tarea 2: Configure una tabla de Dataverse

1.  Asegúrese de que el **entorno Dev One** esté seleccionado.
    Selecciónelo si aún no lo ha hecho.

![](./media/image3.png)

2.  Desde la barra izquierda seleccione **Tables.** En la sección
    superior de tables haga clic en **+ New table** y
    seleccione **Create new tables**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image4.png)

3.  Seleccione la opción **Import an Excel file or CSV** para crear una
    nueva tabla.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image5.png)

4.  Haga clic en la opción **Select form device** y seleccione el
    archivo **Support Ticket** desde la carpeta **C:\LabFiles**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image6.png)

5.  Seleccione la tabla y haga clic en **View data** para ver la tabla.

\[Atención\] **Ojo:** En este caso, la tabla se llama *Employee
Technical Support Record*. El nombre puede variar con cada ejecución.
Por favor guarde el nombre de la tabla para referenciar más tarde. El
nombre de la columna también puede variar.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image7.png)

6.  Vaya a table data, seleccione el drop down junto al
    campo **Technical Issue Description**, seleccione **Edit column**,
    Establezca el data type como **Text** 🡪 **Multiple line** 🡪 **Plain
    Text** y haga clic en **Update**. El nombre de la columna puede
    variar en cada caso.

\[!Atención\] **Ojo:** El **nombre de la columna puede ser un poco
diferente**, pero se va a pareceer a la descripción del problema ya que
está generado por Copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

7.  Expanda el menú junto al campo **Current Status**, seleccione **Edit
    column**, Establezca Choices como +++**Unresolved**+++,
    +++**Resolved**+++, +++**Processing**+++. Establezca Default choice
    como **Unresolved** y haga clic en **Update**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

8.  Desde la esquina superior derecha, haga clic en **Save and
    exit** para salir de la tabla.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

**Conclusión**

Al completar este ejercicio, los participantes aprenderán:

- Cómo acceder y navegar por Power Apps mediante las credenciales de
  office 365 admin tenant.

- Pasos para crear y configurar un Dataverse table al importar datos.

- Conocimiento práctico de configurar un entorno para admitir los
  workflows de desarrollo de aplicaciones.

## Ejercicio 2: Cree el Contoso IT Support Agent

Este ejercicio se enfoca en iniciar sesión en Microsoft Copilot Studio y
crear un agente Copilot personalizado para las operaciones de soporte de
TI en Contoso. Los participantes obtendrán una experiencia práctica de
navegar por Copilot Studio, configurar entornos y construir un agente
impulsado por la IA para agilizar los workflows de TI.

### Tarea 1: Iniciar sesión en Microsoft Copilot Studio

1.  Desde un navegador, navegue a la url
    +++[https://copilotstudio.microsoft.com+++](https://copilotstudio.microsoft.com+++/).

2.  Si dice **Setting up your copilot** como se ve aquí,
    seleccione **Environments** desde el menú superior derecho y
    seleccione **Dev One**. Por lo contrario, ignore este paso y siga
    con el paso 3.

![image](./media/image12.png)

3.  Haga clic en **Start free trial** para comenzar la prueba de Copilot
    Studio.

![](./media/image13.png)

### Tarea 2: Cree y configure el Contoso IT Support Agent

1.  Si ha completado el paso 2 de la tarea anterior, ignore este paso.
    En la sección de inicio de Copilot Studio de la parte superior
    derecha, haga clic en **Select environment** y elija **DevOne**.

![](./media/image14.png)

2.  En la pestaña welcome to copilot studio, haga clic en **Skip** para
    seguir adelante.

![](./media/image15.png)

3.  Desde la barra izquierda seleccione **Create** y seleccione **New
    agent** para empezar a crear un nuevo agente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

4.  Desde la esquina superior derecha, haga clic en **Skip to
    configure**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

5.  Ingrese **Name, Description e Instruction** del agente como se ve
    aquí y haga clic en el botón **Create**.

> **Name:** +++Contoso IT Support Agent+++
>
> **Description:** +++Create a Contoso IT Support Agent which transforms
> IT support at Contoso Solutions by providing instant troubleshooting
> for common issues, automating ticket creation for unresolved problems,
> and storing all interactions in Dataverse. This solution enhances
> response times, reduces manual workloads, and boosts employee
> productivity.+++
>
> **Instruction:** +++Create the Copilot Agent and configure it to
> handle IT support operations. Add a knowledge source containing
> solutions for common IT issues like hardware troubleshooting,
> connectivity, and software glitches. Set up a trigger to detect
> incoming emails from employees describing unresolved issues. Create an
> action to save these technical issues into a Dataverse table, ensuring
> all details are stored for tracking and reporting. Test the agent to
> validate its troubleshooting accuracy and ticket automation workflow
> before deployment.+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image18.png)

6.  En la página overview de Contoso IT Support Agent, **habilite** el
    orchestrator para el agente.

![](./media/image19.png)

7.  Oen la página overview del agente, **Desactive** la opción “**Allow
    the AI to use its own general knowledge**”.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

8.  Desde la esquina superior derecha del agente, haga clic en el
    botón **Settings**.

![](./media/image21.png)

9.  Luego, vaya a la sección **Generative AI**,
    seleccione **Generative**, establezca content moderation
    como **Medium** y haga clic en **Save** para guardar la
    configuración.

![](./media/image22.png)

**Conclusión**

Al completar el ejercicio, los participantes aprenderán:

- Cómo acceder y configurar Microsoft Copilot Studio.

- Pasos para crear y configurar un Copilot agent personalizado.

- Habilidades prácticas para habilitar las configuraciones de generative
  AI y orchestrator para el agente.

- Maneras de mejorar las operaciones de TI al automatizar la creación de
  tickets y aprovechar la IA para solucionar problemas.

## Ejercicio 3: Mejore las capacidades del Bot

Este ejercicio se centra en mejorar las capacidades del Contoso IT
Support Agent al agregar una vase de conocimiento y personalizar los bot
topics para una interacción mejorada. Los participantes refinarán las
respuestas del bot y asegurarán que ayuda a los usuarios de forma eficaz
en solucionar problemas y escalada.

### Tarea 1: Agregue bases de conocimiento

1.  En la página overview del Contoso agent, baje y haga clic en el
    botón **+ Add Knowledge**.

![](./media/image23.png)

2.  Seleccione **Upload file** para agregar el archivo del
    laboratorio **Contoso Common IT Issue.docx** desde la
    carpeta **C:\LabFiles** y haga clic en **Add** para guardar el
    archivo.

![image](./media/image24.png) ![image](./media/image25.png)

3.  De nuevo, vaya a la página agent overview, baje y haga clic en **+
    Add knowledge.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

4.  Seleccione la opción **Dataverse (preview)** como data source.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

5.  En la barra de búsqueda en la esquina superior derecha, ingrese y
    búsque +++**Employee**+++ y seleccione la tabla **Employee Technical
    Support Record**. Luego, haga clic en **Next, Next** y **Add** para
    agregar el knowledge source.

**Ojo:** El **nombre de la tabla puede variar** en su caso ya que está
generado por Copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image29.png)

\[!Alerta\] **Importante:** Desde la página Knowledge, asegúrese de que
se ha cargado el knowledge source exitosamente. Esto suele tardar unos
10 o 15 minutos en completar.

### Tarea 2: Personalice el Conversation Start Topic

1.  Desde la opción en la barra superior, haga clic
    en **Topics** -\> **System** y luego haga clic y abra
    el **Conversation Start** topic.

![image](./media/image30.png)

2.  Baje y vaya al message node. Actualice el mensaje con el nombre del
    bot así:

Hello. I’m Bot Name, a virtual assistant. +++How can I help you?+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

3.  Desde la parte superior, haga clic en **Save** para guardar el
    topic.

![](./media/image32.png)

### Tarea 3: Actualice el Fallback Topic

1.  Desde la opción en la barra superior, haga clic
    en **Topics** -\> **System** y abra el **Fallback** topic.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

2.  Baje y vaya al message node. Actualice el mensaje así:

+++I’m sorry. This information is not available in my system. You can
raise the support ticket via mail for this issue.+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

3.  Desde la parte superior derecha, haga clic en el botón **Save** para
    guardar el topic.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

**Conclusión**

Al completar este ejercicio, los participantes aprenderán:

- Cómo subir e integrar un knowledge base para mejorar la funcionalidad
  del bot.

- Pasos para personalizar los mensajes iniciales de conversación para
  una experiencia de usuario mejor.

- Técnicas para actualizar los fallback responses para mejorar la
  gestión de consultas no admitidas.

## Ejercicio 4: Pruebe el agente

Este ejercicio guua a los participantes en la prueba de Contoso IT
Support Agent para validar su funcionalidad. Los participantes verán
cómo el bot maneja los prompts con la ayuda de knowledge base y fallback
topics para asegurar interacciones y escaladas sin problemas.

1.  Desde la esquina superior derecha, haga clic en el botón **Test**.
    En la sección de test, haga clic en **Map,** póngalo en **On** y
    haga clic en **Refresh**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

2.  Ingrese el prompt +++**My printer is not working how to fix it**+++
    . Da una solución en función del knowledge source.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

3.  De nuevo, proporcione el prompt +++**Two factor Authentication (2FA)
    issue**+++ .

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

4.  El problema 2FA y su solución no están disponible en el knowledge
    source, por eso se recurre al fallback topic y devuelve un prompt
    relacionado con Raise Ticket.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

**Conclusión**

Al completar este ejercicio, los participantes aprenderán:

- Cómo validar y activar un agente IA para troubleshooting.

- La validación de las habilidades del bot para responder en función de
  su knowledge base.

- Cómo los fallback topics manejan consultas no admitidas y redirigen al
  usuario de forma eficaz.

## Ejercicio 5: Automatice la creación de Support Ticket con Power Automate

Este ejercicio demuestra cómo automatizar la creación de support ticket
mediante Power Automate e integrarlo con el Contoso IT Support Agent.
Los participantes crearán un flujo para agilizar la notificación de
problemas, almacenar datos en Dataverse y notificar los ingenieros de
soporte a través del email.

1.  Vaya a la página overview del agent, baje y haga clic en **+ Add
    action**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

2.  En la ventana choose an action, desde la parte superior izquierda,
    haga clic en **+ New Action** y seleccione **New Power Automate
    Flow** .

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  En Power automate flow, haga clic en **When an agent calls the
    flow** y seleccione **Add an Input**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image42.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image43.png)

4.  Seleccione **Text** como el data type of input y renombre el input
    como +++**Name**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image44.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image45.png)

5.  De la misma manera, cree más inputs así.

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image46.png)

6.  Debajo de **When an agent calls the flow**, haga clic en el
    signo **(+)**  y seleccione **Add an action**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

7.  En la búsqueda Add an action, ingrese +++**Add a new row**+++.
    Seleccione **Add a new row** desde la sección Microsoft Dataverse.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image48.png)

Ojo: A veces, no se crea una conexión de Dataverse automáticamente.
Puede que tenga que **iniciar sesión** de nuevo con sus credenciales de
autenticación **OAuth**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image49.png)

8.  En la sección **Table Name** busque y seleccione +++**Employee
    Technical Support Record**+++ (o el nombre de su tabla
    correspondiente).

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image50.png)

9.  Debajo de table name seleccione **Show all**, y haga clic en el
    campo particular y agregue input con la ayuda del botón dynamic
    content (relámpago) como se ve a continuación. El campo **Current
    Status** debe estar seleccionado con el dropdown **Unresolved**.

[TABLE]

> ![A blue line on a white background AI-generated content may be
> incorrect.](./media/image51.png)
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image52.png)

10. Debajo de Add a new row action haga clic en (+) y seleccione
    select **Add an action**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image53.png)

11. En la sección add an action, ingrese +++**Send an email**+++ en la
    barra de búsqueda y seleccione **send an email (V2)** desde la
    sección office 365 outlook.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

12. En la sección send an email, introduzca los siguientes detalles en
    las secciones correspondientes:

> Reemplace los place holders de **Name**, **ID**, **Details** con las
> variables mediante dynamic content
>
> **To**
>
> Enter support engineer email (**Use any email ID** - It will be to
> this id, the mail will be sent by the agent to when Support Ticket is
> raised)
>
> **Subject**
>
> New Technical Support Ticket Raised
>
> **Body**
>
> A new technical support ticket has been raised and requires your
> attention. Please find details below:
>
> Employee Name: \< Name \>
>
> Employee ID: \< ID \>
>
> Technical Issue: \< Details \>
>
> Thank you for your prompt attention to this matter.'
>
> Best Regards

![A screenshot of a email AI-generated content may be
incorrect.](./media/image56.png)

13. Desde la esquina superior izquierda, renombre el flow como
    +++**Create an Employee Support Ticket**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image57.png)

14. Desde la barra superior, haga clic en **Save draft** y luego
    en **Publish**. **Cierre** el Power automate.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image58.png)

15. Vuelva a la ventana Copilot y haga clic en el botón **Refresh**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

16. En la ventana Choose an action, seleccione el **Create an Employee
    Support Ticket** flow.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

17. Haga clic en el botón **Add action** para agregar un flow.

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image61.png)

18. Desde la página **Overview** del agente, en la sección **Action**,
    seleccione **Edit** para editar los parámetros de la acción.
    Seleccione la sección **Inputs**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

![A screenshot of a support ticket AI-generated content may be
incorrect.](./media/image63.png)

19. Ingrese la siguiente decripción en los campos correspondientes, y
    después de ingresar la descripción, haga clic en el botón **Save**.

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image64.png)
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image65.png)

**Conclusión**

Al completar este ejercicio, los participantes aprenderán:

- Cómo integrar los Power Automate flows con un agente Copilot para la
  creación de tickets.

- Pasos para recopilar y mapear los datos de forma dinámica desde las
  interacciones del usuario.

- Técnicas para automatizar las notificaciones del email para la
  escalada de tickets de soporte.

- La habilidad de configurar los workflows para una gestión de tickets
  de soporte eficaz.

## Ejercicio 6: Configure un Trigger basado en email para acciones automatizadas

Esta continuación de la automatización de la creación de tickets de
soporte técnico se centra en la configuración de un trigger en el agente
de soporte técnico de TI de Contoso para vincular las entradas de correo
electrónico con el flujo automatizado de Power Automate. Los
participantes configurarán los disparadores y finalizarán el agente para
la implementación.

1.  Vaya a la página overview del agente, baje y haga clic en **+ Add
    trigger**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image66.png)

2.  Y luego desde la ventana Add trigger, seleccione el **When a new
    email arrives (V3)** trigger.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image67.png)

3.  Después de la conexión exitosa de copilot y outlook y aparece la
    marca verde, haga clic en el botón **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image68.png)

4.  En el campo folder seleccione el icono folder y seleccione la
    carpeta **Inbox** y seleccione **Create trigger**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image69.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image70.png)

5.  Cierre el **Time to test your trigger** prompt. En la página Support
    agent overview, baje y en la sección trigger haga clic en tres
    puntos **(…)** y seleccione **Edit in Power Automate.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image71.png)

6.  Haga clic derecho en el trigger When a new email arrives y
    seleccione **Delete**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image72.png)

7.  Y haga clic en Add a trigger, busque +++**When new email
    arrives**+++ y seleccione **When a new email arrives** trigger desde
    la sección **Office 365 outlook**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image73.png)

8.  Haga clic en **Send a prompt to the specified copilot for
    processing**, en la sección body/message ingrese el prompt, +++**Run
    Create an Employee Support Ticket flow and use content from Body
    From.**+++ Reemplace **Body** y **From** como dynamic content
    variable.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image74.png)

9.  **Guarde** y **Publique** el flow, cierre la ventana power automate
    y vuelva a la ventana copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image75.png)

10. Vaya a la sección overview y desde la esquina superior derecha, haga
    clic en **Publish** y de nuevo en **Publish** para publicar el
    copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image76.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image77.png)

**Conclusión**

Al completar el ejercicio, los participantes aprenderán:

- Cómo configurar triggers en Copilot para automatizar los workflows
  basados en las entradas de correo electrónico.

- Pasos para asignar dinámicamente el contenido del correo electrónico a
  los flujos de Power Automate.

- El proceso de publicación y finalización del agente de IA para su uso
  operativo.

- Habilidades prácticas para vincular herramientas de comunicación como
  Outlook con workflows automatizados.

## Ejercicio 7: Pruebe el agente

Este ejercicio se centra en probar la integración de la función Contoso
IT Support Agent con Power Automate y Outlook. Los participantes
verificarán la capacidad del agente para procesar correos electrónicos,
crear tickets de soporte y activar workflows automatizados de manera
efectiva.

1.  Vaya a la página overview del agente, baje y haga clic en **(…)** en
    trigger y seleccione **Edit in power automate**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image78.png)

2.  Navegará hasta el flujo de Power Automate, desde la barra superior
    haga clic en el botón **Test** y luego seleccione **Manually** y de
    nuevo haga clic en **Test**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image79.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image80.png)

3.  **Envíe un correo electrónico** al ID de correo del tenant de
    administración de 365 desde cualquier otro buzón de correo con el
    fin de **activar la acción**. El correo debe describir un problema y
    debe tener sus detalles, como la identificación del empleado,
    similar a la de la captura de pantalla a continuación. El contenido
    de ejemplo es el siguiente

> Hi Support Team,
>
> I hope this message finds you well.
>
> Iam Mark Brown, working as a Software Engineer at Contoso. My employee
> ID is CONTOSO099
>
> Issue: Monitor is completely balank and not functioning.
>
> Kindly raise a support ticket and assist in resolving this issue at
> the earlierst.
>
> Thank you for your support.
>
> Best Regards,
>
> Mark Brown

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image81.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image82.png)

4.  Navegue a la página de copilot agent overview, baje y
    seleccione **Test trigger**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

5.  Haga clic en **Start testing**, se iniciará la prueba.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image84.png)

6.  En la sección de test haga clic en **Connect**, se abrirá la ventana
    de conexión.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image85.png)

7.  Haga clic en **Connect** de nuevo y seleccione **Submit.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image86.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image87.png)

8.  Navegue a la ventana copilot studio y ejecute el **Test** de nuevo.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

9.  La solicitud de soporte se genera automáticamente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image88.png)

10. Vaya a Power Apps y vaya a la tabla de registros de tickets de
    soporte técnico para empleados y compruebe los detalles.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image89.png)

11. Compruebe el correo de soporte que configuramos en el flujo de Power
    Automate para enviar un correo electrónico. El correo electrónico se
    envía automáticamente al equipo de soporte.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image90.png)

12. Vaya a la ventana de prueba y la consulta del escritor como usuario
    +++**Mark Brown Ticket Current Status**+++ . Da el estado del
    problema como no resuelto.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image91.png)

13. Como ingeniero de soporte, escriba un mensaje en la sección de
    prueba. +++**I want to know about all Unresolved ticket**+++ .

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image92.png)

**Conclusión**

Al completar este ejercicio, los participantes aprenderán:

- Cómo probar la funcionalidad del agente simulando escenarios del mundo
  real.

- Pasos para validar workflows desencadenados por correo electrónico y
  generación de tickets en Power Automate.

- Cómo revisar los registros generados en Dataverse y asegurarse de que
  las notificaciones se envíen al equipo de soporte.

- Información práctica sobre la depuración y finalización de workflows
  de automatización.

## Conclusión final de la guía de laboratorio

Esta guía de laboratorio proporcionó a los participantes una experiencia
práctica en la implementación de un agente de copilot autónomo para el
servicio de soporte técnico de TI de Contoso Solutions. Al seguir los
ejercicios paso a paso, los participantes pudieron:

1.  **Configurar Copilot Studio**: Los participantes aprendieron a
    iniciar sesión en Copilot Studio, crear y configurar el agente de
    soporte de TI y habilitar configuraciones esenciales como la IA
    generativa y el orquestador para una solución de problemas eficaz y
    la automatización de tickets.

2.  **Navegar en Power Apps**: Los participantes adquirieron
    conocimientos prácticos sobre el inicio de sesión en Power Apps, la
    configuración de una tabla de Dataverse y la importación de datos de
    Excel para realizar un seguimiento y administrar los tickets de
    soporte de manera eficiente.

3.  **Mejorar las capacidades de los bots**: Los ejercicios se centraron
    en agregar una base de conocimientos al bot, personalizar los temas
    de inicio y reserva de la conversación para mejorar la interacción
    del usuario y garantizar que el bot pudiera manejar una amplia gama
    de escenarios de soporte de TI.

4.  **Automatizar las tareas de soporte de TI**: Los participantes
    también aprendieron a automatizar la creación de tickets de soporte
    mediante Power Automate, lo que mejoró la capacidad del bot para
    administrar problemas no resueltos y mejorar los workflows del
    equipo de TI.

Al completar estos ejercicios, los participantes pudieron implementar un
sólido sistema de soporte autónomo que mejora los tiempos de respuesta,
reduce la carga de trabajo manual y mejora la productividad general de
las operaciones de soporte de TI. La integración de Copilot Studio,
Power Apps y Dataverse garantiza un flujo continuo de información,
automatiza las tareas rutinarias y optimiza los workflows de soporte,
proporcionando soluciones inmediatas de solución de problemas a los
empleados y gestión automatizada de tickets para problemas no resueltos.
