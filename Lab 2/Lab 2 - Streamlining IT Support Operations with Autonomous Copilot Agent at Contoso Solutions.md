# Lab 2 - Streamlining IT Support Operations with Autonomous Copilot Agent at Contoso Solutions

**Estimate Time: 60 mins**

## Objective

The objective of this lab is to enable participants to streamline IT
support operations at Contoso Solutions by creating an autonomous
Copilot agent. Participants will learn to set up Microsoft Copilot
Studio, configure the IT Support Agent, integrate Power Apps and
Dataverse, enhance the bot’s capabilities with a knowledge base, and
automate ticket creation using Power Automate. This hands-on lab will
equip users with the skills to improve IT workflows, reduce manual
effort, and enhance support efficiency.

## Solution

Participants will create a customized Contoso IT Support Agent using
Microsoft Copilot Studio, configure it to handle common IT issues, and
integrate it with Dataverse for storing support data. They will set up a
development environment, add knowledge sources, and refine the bot's
conversation flows for better user interaction. By leveraging Power
Apps, participants will create a Dataverse table to manage IT support
records. Using Power Automate, they will automate ticket creation and
email notifications for unresolved issues. Finally, participants will
test the agent to validate its troubleshooting accuracy and workflow
automation, ensuring seamless IT support operations.

## Exercise 1: Creating the Contoso IT Support Agent

This exercise focuses on logging into Microsoft Copilot Studio and
creating a customized Copilot agent tailored for IT support operations
at Contoso. Participants will gain hands-on experience navigating
Copilot Studio, configuring environments, and building an AI-powered
agent to streamline IT workflows.

### Task 1: Logging into Microsoft Copilot Studio

1.  Navigate to copilot studio website
    <https://www.microsoft.com/en-us/microsoft-copilot/microsoft-copilot-studio>
    and click on the **Try free.**

<img src="./media/image1.png"
style="width:6.26806in;height:2.87222in" />

2.  Enter admin tenant ID / work or school ID in the respected field and
    click on the **Next** button.

**Note:** For this lab we are using admin tenant credentials,
participant can use their work or school id to start free trial.

<img src="./media/image2.png"
style="width:6.26806in;height:2.79583in" />

3.  Enter **Country or Region** and **Business phone number** in the
    respected fields. Select the check box and click on **the Get
    started** button.

<img src="./media/image3.png"
style="width:6.26806in;height:3.54931in" />

4.  In the confirmation section again click on the **Get Started**
    button.

<img src="./media/image4.png"
style="width:6.26806in;height:2.52778in" />

###  Task 2: Creating and Configuring Contoso IT Support Agent 

1.  In copilot studio home section from top select the environment
    development environment**.** In our case it's dev one participant
    chooses their environment.

<img src="./media/image5.png"
style="width:6.26806in;height:3.03264in" />

2.  On the welcome copilot studio tab, click on the **Skip** to move
    forward.

<img src="./media/image6.png"
style="width:5.40833in;height:4.85796in" />

3.  From the left navigation bar select **Create** and then select **New
    agent** to start creating new agent.

<img src="./media/image7.png"
style="width:6.26806in;height:2.83542in" />

4.  From the top right corner click on **Skip to configure** button.

<img src="./media/image8.png"
style="width:6.26806in;height:2.80903in" />

5.  Enter **Name, Description and Instruction** of the agent as given
    below and click on **Create** button.

> **Name:** Contoso IT Support Agent
>
> **Description:** Create a Contoso IT Support Agent which transforms IT
> support at Contoso Solutions by providing instant troubleshooting for
> common issues, automating ticket creation for unresolved problems, and
> storing all interactions in Dataverse. This solution enhances response
> times, reduces manual workloads, and boosts employee productivity.
>
> **Instruction:** Create the Copilot Agent and configure it to handle
> IT support operations. Add a knowledge source containing solutions for
> common IT issues like hardware troubleshooting, connectivity, and
> software glitches. Set up a trigger to detect incoming emails from
> employees describing unresolved issues. Create an action to save these
> technical issues into a Dataverse table, ensuring all details are
> stored for tracking and reporting. Test the agent to validate its
> troubleshooting accuracy and ticket automation workflow before
> deployment.
>
> <img src="./media/image9.png"
> style="width:6.26806in;height:2.85694in" />

6.  On the overview page of Contoso IT Support Agent, **Enable** the
    orchestrator for the agent.

<img src="./media/image10.png"
style="width:6.26806in;height:2.84514in" />

7.  On the overview page of the agent, **Disable** the “**Allow the AI
    to use its own general knowledge**” option.

<img src="./media/image11.png"
style="width:6.26806in;height:2.84236in" />

8.  From the top right corner of the agent, click on the **Settings**
    button.

<img src="./media/image12.png"
style="width:6.26806in;height:2.85347in" />

9.  Then go to Generative AI section, select the Generative AI
    (Preview), set content moderation as **Medium** and click on
    **Save** to save the setting.

<img src="./media/image13.png"
style="width:6.26806in;height:2.78056in" />

###  Conclusion

By completing this exercise, participants will learn:

- How to access and set up Microsoft Copilot Studio.

- Steps to create and configure a custom Copilot agent.

- Practical skills in enabling generative AI and orchestrator settings
  for the agent.

- Ways to enhance IT operations by automating ticket creation and
  leveraging AI for troubleshooting.

## Exercise 2: Getting Started with Power Apps

This exercise introduces participants to Power Apps and Dataverse. The
goal is to log in to Power Apps, set up a working environment, and
create a Dataverse table by importing data from an Excel file.
Participants will learn essential skills for working with data-driven
applications.

### Task 1: Logging into Power Apps

1.  Navigate to power apps website
    <https://www.microsoft.com/en-us/power-platform/products/power-apps>
    and click on the **Try for Fre**e **button.**

> <img src="./media/image14.png"
> style="width:6.26042in;height:2.82292in" />

2.  Enter admin tenant id / work or school id, check the box and click
    on **Start free,** for this tab we are using admin tenant id.

<img src="./media/image15.png"
style="width:6.26806in;height:3.94236in" />

3.  Enter Country/ Region, Phone number, select box check box and click
    on the **Get started**.

> <img src="./media/image16.png"
> style="width:6.26042in;height:3.04167in" />

4.  Confirm the account details and then click on the **Get started**.

> <img src="./media/image17.png"
> style="width:6.26042in;height:3.07292in" />

5.  On the Stay signed in tab select **Yes**.

<img src="./media/image18.png"
style="width:6.26806in;height:3.11389in" />

### Task 2: Setting Up a Dataverse Table

1.  On the power apps home page, from top select the development
    environment. In our case it's Dev One, participants can choose their
    own environment.

<img src="./media/image19.png"
style="width:6.26806in;height:2.86111in" />

2.  From the left navigation bar select **Tables.** In the tables
    section, the top bar clicks on the **+ New table** and then select
    **Create new tables**.

<img src="./media/image20.png"
style="width:6.26806in;height:2.83194in" />

3.  Select **Import an Excel file or CSV** option to create a new table.

<img src="./media/image21.png"
style="width:6.26806in;height:2.40903in" />

4.  Click on the select form device option and select **Support Ticket**
    excel file from **Lab Files** folder.

<img src="./media/image22.png"
style="width:6.26806in;height:2.92014in" />

5.  Select the table and click on **View data** to see the table.

**Note:** In my case, the table is named *Employee Technical Support
Record*. The name may vary with each execution. Please save the table
name for future reference.

<img src="./media/image23.png"
style="width:6.26806in;height:2.19514in" />

6.  Go to table data, select **Technical Issue Description down arrow**,
    select **Edit column**, Set the data type as **Text** à **Multiple
    line** à **Plain Text** and click on the **Update**. The column name
    may be different in each case.

<img src="./media/image24.png"
style="width:6.26806in;height:2.70764in" />

<img src="./media/image25.png"
style="width:6.26806in;height:2.72292in" />

7.  Select **Current Status down arrow**, select **Edit column**, Set
    the Choices as **Unresolved, Resolved, Processing**. Set Default
    choices as **Unresolved** and click on the **Update**.

<img src="./media/image26.png"
style="width:6.26806in;height:2.33264in" />

8.  From the top right side click on **Save and exit** to save the
    table.

<img src="./media/image27.png"
style="width:6.26806in;height:2.4625in" />

### Conclusion

By completing this exercise, participants will learn:

- How to access and navigate Power Apps using admin tenant / work or
  school credentials.

- Steps to create and configure a Dataverse table by importing data.

- Practical knowledge of setting up an environment to support app
  development workflows.

## Exercise 3: Enhancing Bot Capabilities

This exercise focuses on enhancing the capabilities of the Contoso IT
Support Agent by adding a knowledge base and customizing bot topics for
improved interaction. Participants will refine the bot's responses and
ensure it effectively assists users in troubleshooting and escalation.

### Task 1: Add Knowledge Base 

1.  On Contoso agent overview page, scroll down and click on **+ Add
    Knowledge** button.

<img src="./media/image28.png"
style="width:6.26806in;height:2.84028in" />

2.  Select **Click to browse** button to add the lab file **Contoso IT
    Support Issue** from Lab Files folder and then click on **Add** to
    save the file.

<img src="./media/image29.png"
style="width:6.26806in;height:4.14444in" />

<img src="./media/image30.png" style="width:6.26806in;height:4.125in" />

3.  Again, go to the agent overview page, scroll down and click on **+
    Add knowledge.**

<img src="./media/image31.png"
style="width:6.26806in;height:2.12361in" />

4.  Select **Dataverse (preview)** option as data source.

<img src="./media/image32.png"
style="width:6.26806in;height:3.16806in" />

5.  In the top right corner search bar, enter and search for
    **Employee** and select **Employee Technical Support Record** table.
    Then click on the **Next, Next** and **Add** button to add the
    knowledge source.

<img src="./media/image33.png"
style="width:6.26806in;height:4.10347in" />

<img src="./media/image34.png"
style="width:6.26806in;height:4.14375in" />

### Task 2: Customize the Conversation Start Topic

1.  From the top bar option click on **Topics** and then click and open
    **Conversation Start** topic.

<img src="./media/image35.png"
style="width:6.26806in;height:2.83819in" />

2.  Scroll down and go to message node. Update the message after bot
    name as given below:

Hello. I’m Bot Name, a virtual assistant. How can I help you?

<img src="./media/image36.png"
style="width:6.26806in;height:3.89444in" />

3.  From top click on the **Save** to save the topic.

<img src="./media/image37.png"
style="width:6.26806in;height:3.89444in" />

###  Task 3: Update the Fallback Topic 

1.  From the top bar option click on **Topics** and then click and open
    **Fallback** topic.

<img src="./media/image38.png"
style="width:6.26806in;height:2.86597in" />

2.  Scroll down and go to message node. Update the message as given
    below:

I’m sorry. This information is not available in my system. You can raise
the support ticket via mail for this issue.

<img src="./media/image39.png"
style="width:6.26806in;height:2.84931in" />

3.  From the top right side click on the **Save** button to save the
    topic.

<img src="./media/image40.png"
style="width:6.26806in;height:2.84931in" />

###  Conclusion

By completing this exercise, participants will learn:

- How to upload and integrate a knowledge base to enhance the bot's
  functionality.

- Steps to customize conversation start messages for a more engaging
  user experience.

- Techniques to update fallback responses for better handling of
  unsupported queries.

## Exercise 4: Test the agent

This exercise guides participants through testing the Contoso IT Support
Agent to validate its functionality. Participants will check how the bot
handles prompts using the knowledge base and fallback topics to ensure
seamless interaction and escalation.

1.  From the top right corner click on the **Test** button. Then in the
    test section click on **Map** turn it on and then click **Refresh**.

<img src="./media/image41.png"
style="width:6.26806in;height:2.83681in" />

2.  Enter the prompt “**My printer is not working how to fix it.”.** It
    gives the solution as per knowledge source.

<img src="./media/image42.png"
style="width:6.26806in;height:2.81111in" />

3.  Again, give the prompt **“Two factor Authentication (2FA) issue”.**

<img src="./media/image43.png"
style="width:6.26806in;height:2.82569in" />

4.  The 2FA issue and solution is not available in the knowledge source
    so it will go to fallback topic and return prompt related to Raise
    Ticket.

<img src="./media/image44.png"
style="width:6.26806in;height:2.78125in" />

### Conclusion

By completing this exercise, participants will learn:

- How to test and activate an AI agent for troubleshooting.

- Validation of the bot’s ability to respond using its knowledge base.

- How fallback topics handle unsupported queries and redirect users
  effectively.

## Exercise 5: Automating Support Ticket Creation with Power Automate

This exercise demonstrates how to automate support ticket creation using
Power Automate and integrate it with the Contoso IT Support Agent.
Participants will create a flow to streamline issue reporting, record
data in Dataverse, and notify support engineers via email.

1.  Go to the overview page of the agent, scroll down and click on the
    **+ Add action**.

<img src="./media/image45.png"
style="width:6.26806in;height:2.82014in" />

2.  In choose an action window, scroll down and click on **Create a new
    flow**, power automated flow window will open.

<img src="./media/image46.png"
style="width:6.26806in;height:2.8375in" />

3.  In Power automate flow, click on **Run a flow from copilot** and
    then select **Add an Input**.

<img src="./media/image47.png"
style="width:6.26806in;height:3.00347in" />

4.  Select **Text** as data type of input and rename the input as
    **Name**.

<img src="./media/image48.png"
style="width:6.26806in;height:3.76597in" />

<img src="./media/image49.png"
style="width:6.26806in;height:3.55208in" />

5.  With the same procedure create more input as per the details given
    below.

| **Input Name** | **Data Type** |
|----------------|---------------|
| ID             | Text          |
| Email          | Text          |
| Issue          | Tex           |

<img src="./media/image50.png"
style="width:5.74794in;height:3.03381in" />

6.  Below Run a flow from copilot, click on **(+)** sign and select
    **Add an action**.

<img src="./media/image51.png"
style="width:6.26806in;height:3.26667in" />

7.  In Add an action search bar, enter **Add a new row.** Then select
    **Add a new row** from Microsoft Dataverse section.

**Note:** Some time connection is not created automatically, participant
need to sign in with credentials and create connection,

<img src="./media/image52.png"
style="width:6.26806in;height:3.33542in" />

8.  In **the Table Name** section search and select **Employee Technical
    Support Record**.

<img src="./media/image53.png"
style="width:6.26806in;height:2.59028in" />

9.  Below table name select **Show all**, then click on the section, add
    input with the help of dynamic content button (Thunder bolt) (as per
    the below given field:

| Section                     | Input Variable                     |
|-----------------------------|------------------------------------|
| Employee Name               | Name (Dynamic Input)               |
| Email Address               | Email (Dynamic Input)              |
| Employee ID                 | ID (Dynamic Input)                 |
| Technical Issue Description | Issue (Dynamic Input)              |
| Current Status              | Unresolved (Select from drop down) |

<img src="./media/image54.png"
style="width:5.43521in;height:2.69111in" />

10. Below Add a new row action click on (+) and select **Add an
    action**.

<img src="./media/image55.png"
style="width:5.14306in;height:3.05586in" />

11. In add an action section, enter **Send an email** in the search bar
    and select **send an email (V2)** from office 365 outlook section.

<img src="./media/image56.png"
style="width:6.26806in;height:4.61875in" />

12. In send an email section, Enter the below given detail in the
    respected section:

<table>
<colgroup>
<col style="width: 13%" />
<col style="width: 86%" />
</colgroup>
<thead>
<tr>
<th>To</th>
<th>Enter support engineer email (Use any email id)</th>
</tr>
</thead>
<tbody>
<tr>
<td>Subject</td>
<td>New Technical Support Ticket Raised</td>
</tr>
<tr>
<td>Body</td>
<td><p>A new technical support ticket has been raised and requires your
attention. Please find details below:</p>
<p>Employee Name: Name (Use Name dynamic content variable)</p>
<p>Employee ID: ID (Use Name dynamic content variable)</p>
<p>Technical Issue: Issue (Use Name dynamic content variable)</p>
<p>Thank you for your prompt attention to this matter.<br />
<br />
Best Regards</p></td>
</tr>
</tbody>
</table>

<img src="./media/image57.png"
style="width:4.74248in;height:4.29167in" />

13. From the top left corner rename the flow as **Raise Support
    Ticket.**

<img src="./media/image58.png" style="width:6.26806in;height:2.65in" />

14. From the top bar click on **Save draft** and then click **Publish**.

<img src="./media/image59.png"
style="width:6.26806in;height:2.64306in" />

15. Go back to Copilot window and click on **the Refresh** button.

<img src="./media/image60.png"
style="width:6.26806in;height:2.67153in" />

16. In Choose an action window, select **Raise Support Ticket** flow.

<img src="./media/image61.png"
style="width:6.26806in;height:4.26319in" />

17. Click on **Next** to move forward and configure the flow.

<img src="./media/image62.png"
style="width:6.26806in;height:4.19444in" />

18. In the Review input and output window, click on **Edit inputs**.

<img src="./media/image63.png"
style="width:6.26806in;height:2.72917in" />

19. Enter the given description in the respected input, after entering
    the description click on **Save** button. After saving the inputs
    description click on **Next** and then **Finish**.

| Name -- Description | Enter the name of the employee. |
|----|----|
| ID -- Description | Enter the employee ID in the field. |
| Email -- Description | Enter the email address of the employee from whom the email is received. |
| Issue -- Description | Enter the technical details of the issue in the field. |

<img src="./media/image64.png"
style="width:6.26806in;height:4.14236in" />

<img src="./media/image65.png"
style="width:6.26806in;height:4.16667in" />

<img src="./media/image66.png"
style="width:6.26806in;height:4.19167in" />

### Conclusion

By completing this exercise, participants will learn:

- How to integrate Power Automate flows with a Copilot agent for ticket
  creation.

- Steps to collect and map input data dynamically from user
  interactions.

- Techniques to automate email notifications for technical issue
  escalation.

- The ability to configure workflows for efficient support ticket
  management.

## Exercise 6: Configuring an Email-Based Trigger for Automated Actions

This continuation of automating support ticket creation focuses on
setting up a trigger in the Contoso IT Support Agent to link email
inputs with the automated Power Automate flow. Participants will
configure triggers and finalize the agent for deployment.

1.  Go to the overview page of the agent, scroll down and click on **+
    Add trigger**.

<img src="./media/image67.png"
style="width:6.26806in;height:3.09653in" />

2.  Then from Add trigger window, select **When a new email arrives
    (V3)** trigger.

<img src="./media/image68.png"
style="width:6.26806in;height:4.50069in" />

3.  After successful connection of copilot and outlook and green tick
    appears click on **Next** button.

<img src="./media/image69.png"
style="width:6.26806in;height:4.47292in" />

4.  In folder field select folder icon and select **Inbox** folder and
    then select **Create trigger.**

<img src="./media/image70.png"
style="width:4.72436in;height:3.37551in" />

<img src="./media/image71.png"
style="width:6.26806in;height:4.49861in" />

5.  On Support agent overview page scroll down, on trigger section click
    on three dots **(…)** and select **Edit in Power Automate.**

<img src="./media/image72.png"
style="width:6.26806in;height:2.25625in" />

6.  Right click on When a new email arrives trigger and select
    **Delete**.

<img src="./media/image73.png"
style="width:6.1672in;height:2.50855in" />

7.  Then click on Add a trigger, search for **When new email arrives**
    and select **When a new email arrives** trigger from **Office 365
    outlook** section.

<img src="./media/image74.png"
style="width:6.26806in;height:3.18333in" />

8.  Click on **Send a prompt to the specified copilot for processing**,
    in body/message section enter the prompt, **Use content from body
    and run raise support ticket flow.** Replace body as dynamic content
    variable.

<img src="./media/image75.png"
style="width:6.26806in;height:2.80069in" />

9.  **Save** and **Publish** the flow, close power automate window and
    go back to copilot window.

<img src="./media/image76.png"
style="width:6.26806in;height:1.66528in" />

10. Go to overview section and from top right corner click on
    **Publish** and again click **Publish** to publish the copilot.

<img src="./media/image77.png"
style="width:6.26806in;height:1.66042in" />

<img src="./media/image78.png"
style="width:6.1922in;height:2.54189in" />

### Conclusion

By completing this exercise, participants will learn:

- How to set up triggers in Copilot to automate workflows based on email
  inputs.

- Steps to dynamically map email content to Power Automate flows.

- The process of publishing and finalizing the AI agent for operational
  use.

- Practical skills in linking communication tools like Outlook with
  automated workflows.

## Exercise 7: Test the agent

This exercise focuses on testing the integration of the Contoso IT
Support Agent with Power Automate and Outlook. Participants will verify
the agent's ability to process emails, create support tickets, and
trigger automated workflows effectively.

1.  Go to overview page of agent, scroll down, click on **(…)** on
    trigger and select **Edit in power automate**.

<img src="./media/image79.png"
style="width:6.26806in;height:2.83819in" />

2.  It will navigate to power automate flow, from top bar click on
    **Test** button and then select **Manually** and again click on
    **Test**.

<img src="./media/image80.png"
style="width:6.26806in;height:1.60556in" />

<img src="./media/image81.png"
style="width:6.26806in;height:2.65069in" />

3.  Open outlook or other email service provider login and send email on
    same admin tenant or same school / work id which is using in copilot
    and power automate login.

<img src="./media/image82.png"
style="width:6.26806in;height:3.25556in" />

<img src="./media/image83.png"
style="width:6.26806in;height:2.47778in" />

4.  Navigate to copilot agent overview page, scroll down and select
    **Test trigger**.

<img src="./media/image84.png"
style="width:6.26806in;height:2.10347in" />

5.  Click on **Start testing**, it will start testing.

<img src="./media/image85.png"
style="width:6.1422in;height:2.80858in" />

6.  In test section click on the **Connect**, it will open the
    connection window.

<img src="./media/image86.png"
style="width:6.26806in;height:2.48542in" />

7.  Click on the **Connect** again and then select **Submit.**

<img src="./media/image87.png"
style="width:6.26806in;height:2.10139in" />

<img src="./media/image88.png"
style="width:6.26806in;height:4.29444in" />

8.  Navigate to copilot studio window and rerun the **Test**.

<img src="./media/image89.png"
style="width:6.26806in;height:2.92083in" />

9.  The support request is automatically generated.

<img src="./media/image90.png"
style="width:6.26806in;height:2.50625in" />

10. Navigate to power apps and go to Employee support ticket record
    table and check the details.

<img src="./media/image91.png"
style="width:6.26806in;height:1.2625in" />

11. Check the Support mail which we configure in power automate flow to
    send an email. The email is automatically sent to the support team.

<img src="./media/image92.png"
style="width:6.26806in;height:2.68819in" />

12. Go to test window and writer query as user **“Mark Brown Ticket
    Current Status”**. It gives the status of the issue as unresolved.

<img src="./media/image93.png"
style="width:6.26806in;height:2.37986in" />

13. As Support Engineer, write a prompt in the test section. “**I want
    to know about all Unresolved ticket**”.

<img src="./media/image94.png"
style="width:6.26806in;height:2.75417in" />

### Conclusion

By completing this exercise, participants will learn:

- How to test the agent's functionality by simulating real-world
  scenarios.

- Steps to validate email-triggered workflows and ticket generation in
  Power Automate.

- How to review generated records in Dataverse and ensure notifications
  are sent to the support team.

- Practical insights into debugging and finalizing automation workflows.

## Final Conclusion of the Lab Guide

This lab guide provided participants with a hands-on experience in
deploying an Autonomous Copilot Agent for Contoso Solutions' IT support
service desk. By following the step-by-step exercises, participants were
able to:

1.  **Set Up Copilot Studio**: Participants learned how to log into
    Copilot Studio, create and configure the IT support agent, and
    enable essential settings like generative AI and orchestrator for
    effective troubleshooting and ticket automation.

2.  **Navigate Power Apps**: Participants gained practical knowledge in
    logging into Power Apps, setting up a Dataverse table, and importing
    data from Excel to track and manage support tickets efficiently.

3.  **Enhance Bot Capabilities**: The exercises focused on adding a
    knowledge base to the bot, customizing the conversation start and
    fallback topics to improve user interaction, and ensuring the bot
    could handle a wide range of IT support scenarios.

4.  **Automate IT Support Tasks**: Participants also learned how to
    automate the creation of support tickets using Power Automate,
    enhancing the bot's capability to manage unresolved issues and
    improve IT team workflows.

By completing these exercises, participants were able to implement a
robust autonomous support system that improves response times, reduces
manual workload, and enhances overall productivity for IT support
operations. The integration of Copilot Studio, Power Apps, and Dataverse
ensures a seamless flow of information, automates routine tasks, and
optimizes support workflows, providing immediate troubleshooting
solutions to employees and automated ticket management for unresolved
issues.
