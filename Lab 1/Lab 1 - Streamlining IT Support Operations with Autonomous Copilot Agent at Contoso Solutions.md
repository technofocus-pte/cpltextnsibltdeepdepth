# Laboratorio 1 – Agilizar las operaciones de soporte de TI con agente de Copilot autónomo mediante Copilot Studio

**Duración estimada: 60 minutos**

**Objetivo**

El objetivo de este laboratorio es permitir a los participantes
simplificar las operaciones de soporte técnico de TI en Contoso
Solutions mediante la creación de un agente Copilot autónomo. Los
participantes aprenderán a configurar Microsoft Copilot Studio,
configurar el agente de soporte de TI, integrar Power Apps y Dataverse,
mejorar las capacidades del bot con una base de conocimientos y
automatizar la creación de tickets con Power Automate. Este laboratorio
práctico equipará a los usuarios con las habilidades para mejorar los
workflows de TI, reducir el esfuerzo manual y mejorar la eficiencia del
soporte.

**Solución**

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
problemas y la automatización del workflow, lo que garantiza que las
operaciones de soporte de TI sean fluidas.

## Ejercicio 1: Introducción a Power Apps

Este ejercicio presenta Power Apps y Dataverse a los participantes. El
objetivo es iniciar sesión en Power Apps, configurar un entorno de
trabajo y crear una tabla de Dataverse importando datos de un archivo de
Excel. Los participantes aprenderán habilidades esenciales para trabajar
con aplicaciones basadas en datos.

### Tarea 1: Inicie sesión en Power Apps

1.  Navegue al sitio web de power apps
    +++<https://www.microsoft.com/en-us/power-platform/products/power-apps+++> y
    haga clic en el botón **Try for Free**.

![](./media/image1.png)

2.  Introudzca el **Administrative Username** desde la sección **Office
    365 Tenant** de la pestaña **Resources** en el campo de
    email, **seleccione** la **casilla** y haga clic en el botón **Start
    Free.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image2.png)

3.  Enter the **Administrative Password** and you will be taken to the
    Power Apps Home page.

4.  Select **Yes** in the Stay Signed in dialog and **Got it** for the
    Save password prompt and select **No, Thanks** in the Sign in to
    Microsoft Edge pop up.

\[!Note\] **Note:** If it again prompts for the user name, password or
any information to login, please provide the same and login.

### Task 2: Update the Developer environment settings

1.  Login to the Power Platform admin center at
    +++https://admin.powerplatform.microsoft.com/home+++ using your
    login credentials.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image3.png)

2.  Seleccione **Manage** en el panel izquierdo y seleccione **+ New**
    en **Environments**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image4.png)

3.  Proporcione el environment name como +++**Dev One**+++ y seleccione
    el Type como **Developer** y seleccione **Next**.

![](./media/image5.png)

4.  Seleccione **Save** en el diálogo **Add Dataverse**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image6.png)

5.  Una vez que el entorno esté **listo**, seleccione el **Dev One**
    environment creado.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image7.png)

6.  Haga clic en **Edit** para editar las configuraciones.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

7.  En el panel Edit, active el **Administration mode** a **ON** y
    seleccione **Save**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

8.  Una vez guardados los cambios editados, seleccione **Settings**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

9.  Seleccione **Product -\> Features**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

10. En **Features**, active las opciones **Dataverse search** y **Single
    table search** a On y seelccione **Save**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

### Tarea 3: Configuración de un Dataverse Table

1.  Seleccione el entorno **Dev One** desde la parte superior derecha.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image15.png)

2.  En la barra de navegación izquierda, seleccione **Tables.** En la
    barra superior de la sección de Table, haga clic en **+ New
    table** y seleccione **Create new tables**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

3.  Seleccione la opción **Import an Excel file or CSV** para crear una
    nueva tabla.

![](./media/image17.png)

4.  Haga clic en la opción **Select form device** y seleccione el
    archivo excel **Support Ticket** desde la carpeta **C:\LabFiles**.

![](./media/image18.png)

5.  Seleccione **Import** en la siguiente pantalla.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

6.  Seleccione la tabla y haga clic en **View data** para visualizar la
    tabla.

\[Ojo\] **Ojo:** en este caso, la tabla se llama *Employee Technical
Support Record*. El nombre puede variar con cada ejecución. Guarde el
nombre de la tabla para futuras referencias. El nombre de la columna
también puede variar en la ejecución.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

7.  Vaya a datos de la tabla, seleccione el menú desplegable junto a
    la **Technical Issue Description**, seleccione **Edit column**,
    Establezca el tipo de datos como **Text** 🡪 **Multiple
    line** 🡪 **Plain Text** y haga clic en **Update**. El nombre de la
    columna puede ser diferente en cada caso.

\[Ojo\] **Ojo:** El nombre de **la columna puede ser ligeramente
diferente**, pero será algo similar a la descripción del problema, ya
que se genera en Copilot.

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image21.png)

![](./media/image22.png)

8.  Seleccione el menú desplegable junto a **Current Status**,
    seleccione **Edit column**, establezca Choices como
    +++**Unresolved**+++, +++**Resolved**+++, +++**Processing**+++.
    Establezca Default choice como **Unresolved** y haga clic
    en **Update**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

9.  Desde la parte superior derecha, haga clic en **Save and Exit** para
    guardar la tabla.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

### Tarea 4: Agregue un archivo al OneDrive

1.  Desde la parte superior izquierda de la página Power Apps,
    seleccione el menú y seleccione OneDrive.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

2.  Seleccione **My files** -\> **+ Add new**.

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image26.png)

3.  Seleccione **Files upload**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

4.  Elija **IT Support.xlsx** desde **C:\LabFiles**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

5.  Este archivo se utilizará en un ejercicio posterior.

![](./media/image29.png)

> **Conclusión**
>
> Al completar este ejercicio, los participantes aprenderán a:

- Acceder y navegar por Power Apps mediante las credenciales de office
  365 admin tenant.

- Dar pasos para crear y configurar un Dataverse table al importar
  datos.

- Obtener conocimiento práctic3o de configurar un entorno para admitir
  workflows de desarrollo de aplicaciones.

## Ejercicio 2: Cree el Contoso IT Support Agent

Este ejercicio se centra en iniciar sesión en Microsoft Copilot Studio y
crear un agente de Copilot personalizado y adaptado a las operaciones de
soporte técnico de TI en Contoso. Los participantes adquirirán
experiencia práctica en la navegación de Copilot Studio, la
configuración de entornos y la creación de un agente impulsado por IA
para optimizar los workflows de TI.

### Tarea 1: Cree y configure el Contoso IT Support Agent

1.  Inicie sesión en +++https://copilotstudio.microsoft.com+++ con sus
    credenciales de inicio de sesión.

2.  En la sección Copilot Studio home de la parte superior derecha,
    seleccione el **environment** y elija el entorno **DevOne**.

![](./media/image30.png)

3.  En la pestaña welcome copilot studio, haga clic en **Skip** para
    seguir adelante.

![](./media/image31.png)

4.  Desde la barra de navegación izquierda seleccione **Create** y
    seleccione **New agent** para empezar a crear un nuevo agente.

![](./media/image32.png)

5.  Desde la esquina superior derecha, haga clic en **Skip to
    configure**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  Introduzca **Name, Description and Instruction** del agente como se
    indica a continuación y haga clic en **Create**.

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
> updates to a OneDrive file describing unresolved issues. Create an
> action to save these technical issues into a Dataverse table, ensuring
> all details are stored for tracking and reporting. Test the agent to
> validate its troubleshooting accuracy and ticket automation workflow
> before deployment.+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

7.  En la página de overview del agente de soporte técnico de TI de
    Contoso, **habilite** el orquestador para el agente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

8.  Desde la esquina superior derecha del agente, haga clic en el botón
    **Settings**.

![](./media/image36.png)

9.  A continuación, vaya a la sección **Generative AI**,
    seleccione **Generative**, establezca content moderation
    como **Medium** y haga clic en **Save** para guardar las
    configuraciones.

![](./media/image37.png)

10. Una vez **guardado**, **cierre** el panel Settings.

11. En la página overview del agente, **Desabilite** la opción “**Allow
    the AI to use its own general knowledge**”.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

> **Conclusión**
>
> Al completar este ejercicio, los participantes aprenderán:

- Cómo acceder y configurar Microsoft Copilot Studio.

- Los pasos de crear y configurar un agente Copilot personalizado.

- Las habilidades prácticas para habilitar las configuraciones de
  generative AI y orchestrator para el agente.

- Las formas de mejorar las operaciones de TI mediante la automatización
  de la creación de tickets y el aprovechamiento de la IA para la
  resolución de problemas.

## Ejercicio 3: Mejore las capacidades del bot

Este ejercicio se centra en mejorar las capacidades del agente de
soporte técnico de TI de Contoso mediante la adición de una base de
conocimiento y la personalización de los temas de bots para mejorar la
interacción. Los participantes refinarán las respuestas del bot y se
asegurarán de que ayude eficazmente a los usuarios en la resolución de
problemas y la escalada.

### Tarea 1: Agregue una base de conocimiento

1.  En la página Contoso agent overview, baje y haga clic en el
    botón **+ Add Knowledge**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

2.  Seleccione **Upload file** Para agregar el archivo de
    laboratorio **Contoso Common IT Issue.docx** desde la
    carpeta **C:\LabFiles** y haga clic en **Add** para guardar el
    archivo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

>  ![image](./media/image41.png)

3.  De nuevo, vaya a agent overview, baje y haga clic en **+ Add
    knowledge.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image42.png)

4.  Seleccione la opción **Dataverse (preview)** como data source.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image43.png)

5.  En la barra de búsqueda de la esquina superior derecha, ingrese y
    busque +++**Employee**+++ y seleccione la tabla **Employee Technical
    Support Record**. Luego haga clic en **Next, Next** y **Add** para
    agregar el knowledge source.

**Ojo:** El nombre de **la tabla puede ser diferente** en su caso, ya
que es una generada por Copilot.

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image44.png)

![](./media/image45.png)

\[!Alerta\] **Importante:** desde el panel Knowledge, asegure que se ha
subido un knowledge source de forma exitosa. Por lo general, esto
tardará de 10 a 15 minutos en completarse.

### Tarea 2: Personalice un Conversation Start Topic

1.  Desde la opción de la barra superior, haga clic en **Topics**,
    seleccione **System** y luego haga clic y abra **Conversation
    Start** topic.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image46.png)

2.  Baje y vaya al nodo de mensajes. Actualice el mensaje después del
    nombre del bot como se indica a continuación:

Hello. I’m Bot Name, a virtual assistant. +++How can I help you?+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

3.  Desde la parte superior, haga clic en **Save** para guardar el tema.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image48.png)

### Tarea 3: Actualice el Fallback Topic

1.  Desde la opción de la barra superior, haga clic en **Topics** y, a
    continuación, abra el **Fallback** topic.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image49.png)

2.  Baje y vaya al nodo de mensajes. Actualice el mensaje como se indica
    a continuación:

+++I’m sorry. This information is not available in my system. You can
raise the support ticket via mail for this issue.+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image50.png)

3.  Desde la parte superior derecha, haga clic en el **botón Save** para
    guardar el tema.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image51.png)

> **Conclusión**
>
> Al completar este ejercicio, los participantes aprenderán:

- Cómo cargar e integrar una base de conocimientos para mejorar la
  funcionalidad del bot.

- Los pasos para personalizar los mensajes de inicio de conversación
  para una experiencia de usuario más atractiva.

- Las técnicas para actualizar las respuestas de reserva para un mejor
  control de las consultas no admitidas.

## Ejercicio 4: Pruebe el agente

Este ejercicio guía a los participantes a través de las pruebas del
agente de soporte técnico de TI de Contoso para validar su
funcionalidad. Los participantes comprobarán cómo el bot maneja las
indicaciones utilizando la base de conocimientos y los temas de reserva
para garantizar una interacción y una escalada fluidas.

1.  Desde la esquina superior derecha, haga clic en el botón **Test**.
    Luego, en la sección de prueba, haga clic en **Map**, **actívelo** y
    luego haga clic en **Refresh**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image52.png)

2.  Introduzca el prompt +++**My printer is not working how to fix
    it**+++ . Da la solución según la fuente de conocimiento.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image53.png)

3.  De nuevo, dé el prompt +++**Two factor Authentication (2FA)
    issue**+++ .

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

4.  El problema y la solución de 2FA no están disponibles en la fuente
    de conocimiento, por lo que irá al tema de reserva y devolverá un
    prompt relacionado con Raise Ticket.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

> **Conclusión**
>
> Al completar este ejercicio, los participantes aprenderán:

- Cómo probar y activar un agente de IA para solucionar problemas.

- La validación de la capacidad de respuesta del bot utilizando su base
  de conocimientos.

- Cómo los temas de reserva controlan las consultas no admitidas y
  redirigen a los usuarios de forma eficaz.

## Ejercicio 5: Automatización de la creación de Support Ticket con Power Automate

En este ejercicio se muestra cómo automatizar la creación de vales de
soporte técnico mediante AgentFlow e integrarla con el agente de soporte
técnico de TI de Contoso. Los participantes crearán un flujo para
agilizar los informes de problemas y registrar datos en Dataverse.

1.  Seleccione **Flows** desde la barra de menú izquierda del agente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image56.png)

2.  Seleccione **Start in designer**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image57.png)

3.  Seleccione **Add a trigger** y luego seleccione el trigger **When an
    agent calls the flow**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image58.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

4.  Seleccione el trigger agregado, **When an agent calls the flow** y
    seleccione **Add an Input**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

5.  Seleccione **Text** como data type del input y cambie el nombre de
    input como +++**Name**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image61.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

6.  Con el mismo procedimiento, cree más entradas según los detalles que
    se indican a continuación.

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image63.png)

7.  Debajo de **When an agent calls the flow**, haga clic en el
    signo **(+)** y seleccione **Add an action**.

![](./media/image64.png)

8.  En la barra de búsqueda Add an action, introduzca +++**Add a new
    row**+++ . luego seleccione **Add a new row** desde la sección
    Microsoft Dataverse.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image65.png)

Ojo: SA veces, una conexión de Dataverse no se crea automáticamente. Es
posible que tenga que **volver a iniciar sesión** con la autenticación
de OAuth **de sus credenciales**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image66.png)

9.  En la sección **Table Name** busque y seleccione +++**Employee
    Technical Support Record**+++ (o el nombre de la tabla
    correspondiente creado).

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image67.png)

10. Debajo del nombre de la tabla, seleccione **Show all**, A
    continuación, haga clic en el campo en particular y añada **una
    entrada** con la ayuda del botón de **dynamic content**
    (**Relámpago**) según la siguiente tabla.

> Establezca el campo **Current Status** a **Unresolved**.

[TABLE]

> ![A blue line on a white background AI-generated content may be
> incorrect.](./media/image68.png)
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image69.png)

11. Desde la barra superior, haga clic en **Save draft** y, a
    continuación, haga clic en **Publish**. **Cierre** la pestaña Power
    automate.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image70.png)

12. Seleccione **Flows** en la barra de menú de la izquierda y luego
    seleccione el **flujo Untitled** (el que acabamos de crear).

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image71.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image72.png)

13. Seleccione **Edit** en el flow.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image73.png)

14. Nombre el flow como +++**Create an Employee Support Ticket**+++ y
    seleccione **Save**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image74.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image75.png)

15. Desde la página **Contoso IT Support Agent** **Overview**,
    seleccione **+ Add action**.

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image76.png)

16. Seleccione el **Create an Employee Support Ticket** Agent flow.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image77.png)

17. Haga clic en el botón **Add action** para agregar un flow.

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image78.png)

18. En la página **Overview** del agente, en la sección **Action**,
    seleccione **Edit** para Editar los parámetros de la acción.
    Seleccione la sección **Inputs**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image79.png)

![A screenshot of a support ticket AI-generated content may be
incorrect.](./media/image80.png)

19. Ingrese la descripción dada en el campo de entrada respectivo,
    después de ingresar la descripción, haga clic en el botón **Save**.

[TABLE]

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image81.png)
>
> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image82.png)
>
> **Conclusión**
>
> Al completar este ejercicio, los participantes aprenderán:

- Cómo integrar los flujos de agentes con un agente de Copilot para la
  creación de tickets.

- Los pasos para recopilar y mapear datos de entrada dinámicamente a
  partir de las interacciones del usuario.

- Las técnicas para automatizar las notificaciones por correo
  electrónico para el escalamiento de problemas técnicos.

- La capacidad de configurar workflows para una gestión eficiente de los
  tickets de soporte.

## Ejercicio 6: Configure un trigger para Automated Actions

Esta continuación de la automatización de la creación de vales de
soporte técnico se centra en la configuración de un trigger en el agente
de soporte técnico de TI de Contoso para la creación de un archivo en
OneDrive con el flujo automatizado de Power Automate. Los participantes
configurarán los triggers y finalizarán el agente para la
implementación.

1.  Vaya a la página overview del agente, baje y haga clic en **+ Add
    trigger**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

2.  Seleccione el trigger **When a file is created** y haga clic en
    **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image84.png)

3.  Una vez que el establecimiento de la conexión se haya realizado
    correctamente, seleccione **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image85.png)

4.  Seleccione **Root** para **Folder**, **Yes** para **Include
    Subfolders** y haga clic en **Create trigger**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image86.png)

5.  **Cierre** el diálogo Time to test your trigger.

![A screenshot of a computer error AI-generated content may be
incorrect.](./media/image87.png)

6.  Desde la página overview del agente, Seleccione los tres puntos
    junto al trigger agregado – **When a file is created** y seleccione
    **Edit in Power Automate**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image88.png)

7.  Seleccione el símbolo + debajo de When a file is created node Para
    agregar una acción. En el panel Action, busque +++Get a row+++ y
    seleccione **Get a row** en **Excel Online (Business)**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image89.png)

8.  Una vez que se agrega la acción, agregue los detalles a continuación
    en ella.

- Location – Select OneDrive for Business

- Document Library – OneDrive

- File – ITSupport.xlsx

- Table – Table1

- Key Column – ID

- Key Value – +++ID1234+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image90.png)

9.  Seleccione el **Sends a prompt to the specified copilot for
    processing** node.

En Body/message, introduzca +++Run the flow Create an Employee Support
Ticket+++ y agregue dynamic values, Name, ID, Email ID, Description and
Status. Luego agregue +++along with a message "New record added to the
Employee Support table"+++

Debería tener un aspecto similar al de la captura de pantalla siguiente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image91.png)

10. Ahora, guarde el flujo haciendo clic en **Save Draft** y haga clic
    en **Publish** para publicar el flow.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image92.png)

11. Volviendo al Copilot Studio, haga **Publish**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image93.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image94.png)

## Ejercicio 7: Pruebe el agente

1.  Desde Power Automate flow, **When a file is created**, seleccione
    **Test**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image95.png)

2.  Seleccione la opción **Manually** y seleccione **Test**.

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image96.png)

3.  Abra su página **OneDrive**. En **My files**, seleccione **+ Add
    new** y seleccione **Word document**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image97.png)

4.  Volviendo a la página Power Automate, puede ver que se ha empezado
    la ejecución del flow y se ha aprobado.

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image98.png)

5.  Desde la página de agent Overview, seleccione el icono **Test
    Trigger**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image99.png)

6.  Seleccione el trigger más reciente y seleccione **Start testing**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image100.png)

7.  Ejecuta el flujo, recupera los datos del support tracker y los
    actualiza en la tabla de Dataverse.

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image101.png)

1.  En este caso, hay un detalle de ticket de soporte en el rastreador,
    que se agrega a la tabla de Dataverse, creando así un ticket de
    soporte para el usuario.

&nbsp;

8.  Una generación de correo electrónico al recibir un correo
    electrónico de un usuario con respecto a cualquier problema será más
    apropiada. La parte de configuración de correo electrónico no se
    pudo realizar aquí debido a las restricciones de permisos del
    tenant. Considere la siguiente tarea, si tiene un tenant con los
    permisos.

## Tareas a realizar en el entorno de producción

En un entorno de producción, la generación de tickets de soporte se
basará principalmente en correo.

Esta tarea **no está** pensada para realizarse en este entorno de
prueba, ya que el tenent tiene restricciones sobre el uso de la cuenta
de correo. Estos pasos se pueden agregar al flujo después del paso 10 de
**Ejercicio 5: Automatización de la creación de Support Ticket con Power
Automate**, si tiene un tenent que puede enviar y recibir correo.

Omita esta tarea en esta ejecución. Esto se ha agregado puramente para
aprender y comprender la parte de generación de correo y configurar el
correo entrante como un disparador que desempeñará un papel principal en
las operaciones de soporte de TI y luego probar el agente

1.  Debajo de Add a new row action haga clic en (+) y seleccione **Add
    an action**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image102.png)

2.  En la sección add an action, introduzca +++**Send an email**+++ en
    la barra de búsqueda y seleccione **send an email (V2)** desde la
    sección office 365 outlook.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image103.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image104.png)

3.  En la sección send an email, Ingrese el detalle que se da a
    continuación en la sección respectiva:

> Reemplace los marcadores de posición
> de **Name**, **ID**, **Details** con las variables con dynamic content
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
incorrect.](./media/image105.png)

4.  Desde la esquina superior izquierda, cambie el nombre del flujo como
    +++**Create an Employee Support Ticket**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image106.png)

5.  Guarde y publique el flujo

6.  Vaya a la página de overview del agente, desplácese hacia abajo y
    haga clic en **+ Add trigger**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

7.  Luego, desde Add trigger, seleccione el trigger **When a new email
    arrives (V3)**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image107.png)

8.  Después de la conexión exitosa de copilot y outlook y aparece la
    marca verde, haga clic en el botón **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image108.png)

9.  En el campo de carpeta, seleccione el icono de carpeta y seleccione
    **inbox** y, a continuación, seleccione **Create trigger**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image109.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image110.png)

10. Cierre el prompt **Time to test your trigger**. En la página Support
    agent overview baje, en la sección trigger haga clic en tres
    puntos **(…)** y seleccione **Edit in Power Automate.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image111.png)

11. Haga clic derecho en When a new email arrives trigger y
    seleccione **Delete**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image112.png)

12. Luego haga clic en Add a trigger, busque +++**When new email
    arrives**+++ y seleccione **When a new email arrives** trigger desde
    la sección **Office 365 outlook**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image113.png)

13. Haga clic en **Send a prompt to the specified copilot for
    processing**, en la sección Cuerpo/Mensaje, introduzca el prompt,
    +++**Run Create an Employee Support Ticket flow and use content from
    Body From.**+++ Reemplace **Body** y **From** como dynamic content
    variable.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image114.png)

14. **Guarde** y **publique** el flujo, cierre la ventana de Power
    Automate y vuelva a la ventana de Copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image115.png)

15. Vaya a la sección overview y desde la esquina superior derecha haga
    clic en **Publish** y de nuevo haga clic en **Publish** para
    publicar el copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image116.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image117.png)

> **Conclusión**
>
> Al completar este ejercicio, los participantes aprenderán:

- Las técnicas para automatizar las notificaciones por correo
  electrónico para el escalado de problemas técnicos.

&nbsp;

- Cómo configurar triggers en Copilot para automatizar workflows basados
  en entradas de correo electrónico.

- Los pasos para asignar dinámicamente el contenido del correo
  electrónico a los flujos de Power Automate.

- El proceso de publicación y finalización del agente de IA para su uso
  operativo.

- Las habilidades prácticas para vincular herramientas de comunicación
  como Outlook con workflows automatizados.

**Pruebe el agente**

Este ejercicio se centra en probar la integración del agente de soporte
técnico de TI de Contoso con Power Automate y Outlook. Los participantes
verificarán la capacidad del agente para procesar correos electrónicos,
crear tickets de soporte y activar workflows automatizados de manera
efectiva.

1.  Vaya a la página overview del agente, baje y haga clic en **(…)** en
    trigger y seleccione **Edit in power automate**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image118.png)

2.  Navegará hasta el flujo de Power Automate, desde la barra superior
    haga clic en el **botón Test** y luego seleccione **Manually** y
    nuevamente haga clic en **Test**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image119.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image120.png)

3.  **Envíe un correo electrónico** al identificador de correo del
    tenent de administración de 365 desde cualquier otro buzón para
    activar **la acción**. El correo debe describir un problema y debe
    tener sus detalles, como la identificación del empleado, similar a
    la de la captura de pantalla a continuación. El contenido de ejemplo
    es el siguiente

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
incorrect.](./media/image121.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image122.png)

4.  Navigue a la página copilot agent overview, baje y seleccione **Test
    trigger**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image123.png)

5.  Haga clic en **Start testing**, Se iniciará la prueba.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image124.png)

6.  En la sección de test, haga clic en **Connect**, se abrirá la
    ventana de conexión.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image125.png)

7.  Haga clic en **Connect** nuevamente y luego seleccione **Submit.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image126.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image127.png)

8.  Navigue a la ventana copilot studio y vuelva a ejecutar el **Test**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image123.png)

9.  La solicitud de soporte se genera automáticamente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image128.png)

10. Vaya a Power Apps y vaya a la tabla de registros de tickets de
    soporte técnico para empleados y compruebe los detalles.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image129.png)

11. Compruebe el correo de soporte que configuramos en el flujo de Power
    Automate para enviar un correo electrónico. El correo electrónico se
    envía automáticamente al equipo de soporte.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image130.png)

12. Vaya al test window y writer query como user +++**Mark Brown Ticket
    Current Status**+++ . Da el estado del problema como no resuelto.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image131.png)

13. Como ingeniero de soporte, escriba un prompt en la sección de
    prueba. +++**I want to know about all Unresolved ticket**+++ .

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image132.png)

> **Conclusión**
>
> Al completar este ejercicio, los participantes aprenderán:

- Cómo probar la funcionalidad del agente simulando escenarios del mundo
  real.

- Los pasos para validar workflows activados por correo electrónico y
  generación de tickets en Power Automate.

- Cómo revisar los registros generados en Dataverse y asegurarse de que
  las notificaciones se envíen al equipo de soporte.

- La información práctica sobre la depuración y finalización de
  workflows de automatización.

**Conclusión final de la guía de laboratorio**

Esta guía de laboratorio proporcionó a los participantes una experiencia
práctica en la implementación de un agente de copiloto autónomo para el
servicio de soporte técnico de TI de Contoso Solutions. Al seguir los
ejercicios paso a paso, los participantes pudieron:

1.  **Configurar Copilot Studio**: Los participantes aprendieron a
    iniciar sesión en Copilot Studio, crear y configurar el agente de
    soporte de TI y habilitar configuraciones esenciales como la IA
    generativa y el orquestador para una solución de problemas eficaz y
    la automatización de tickets.

2.  **Navigar en Power Apps**: Los participantes adquirieron
    conocimientos prácticos sobre el inicio de sesión en Power Apps, la
    configuración de una tabla de Dataverse y la importación de datos de
    Excel para realizar un seguimiento y administrar los tickets de
    soporte de manera eficiente.

3.  **Mejorar las capacidades de Bot**: Los ejercicios se centraron en
    agregar una base de conocimientos al bot, personalizar los temas de
    inicio y reserva de la conversación para mejorar la interacción del
    usuario y garantizar que el bot pudiera manejar una amplia gama de
    escenarios de soporte de TI.

4.  **Automatizar las tareas de soporte de IT**: Los participantes
    también aprendieron a automatizar la creación de tickets de soporte
    mediante Power Automate, lo que mejoró la capacidad del bot para
    administrar problemas no resueltos y mejorar los flujos de trabajo
    del equipo de TI.

Al completar estos ejercicios, los participantes pudieron implementar un
sólido sistema de soporte autónomo que mejora los tiempos de respuesta,
reduce la carga de trabajo manual y mejora la productividad general de
las operaciones de soporte de TI. La integración de Copilot Studio,
Power Apps y Dataverse garantiza un flujo de información sin
interrupciones, automatiza las tareas rutinarias y optimiza los
workflows de soporte, proporcionando soluciones inmediatas de solución
de problemas a los empleados y gestión automatizada de tickets para
problemas no resueltos.
