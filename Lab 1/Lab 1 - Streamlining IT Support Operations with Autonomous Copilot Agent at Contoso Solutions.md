# Laboratório 1 - Simplificando as operações de suporte de TI com o agente autônomo Copilot usando o Copilot Studio

**Tempo estimado: 60 minutos**

**Objetivo**

O objetivo deste laboratório é capacitar os participantes a otimizar as
operações de suporte de TI na Contoso Solutions, criando um agente
Copilot autônomo. Os participantes aprenderão a configurar o Microsoft
Copilot Studio, configurar o Agente de Suporte de TI, integrar o Power
Apps e o Dataverse, aprimorar os recursos do bot com uma base de
conhecimento e automatizar a criação de tickets usando o Power Automate.
Este laboratório prático equipará os usuários com as habilidades
necessárias para aprimorar os fluxos de trabalho de TI, reduzir o
esforço manual e aumentar a eficiência do suporte.

**Solução**

Os participantes criarão um Contoso IT Support Agent personalizado
usando o Microsoft Copilot Studio, configurando-o para lidar com
problemas comuns de TI e integrando-o ao Dataverse para armazenar os
dados de suporte. Eles configurarão um ambiente de desenvolvimento,
adicionarão fontes de conhecimento e refinarão os fluxos de conversação
do bot para melhorar a interação do usuário. Utilizando o Power Apps, os
participantes criarão uma tabela do Dataverse para gerenciar registros
de suporte de TI. Usando o Power Automate, automatizarão a criação de
tickets e notificações por e-mail para problemas não resolvidos. Por
fim, os participantes testarão o agente para validar sua precisão na
solução de problemas e a automação do fluxo de trabalho, garantindo
operações de suporte de TI integradas.

## Exercício 1: Introdução ao Power Apps

Este exercício apresenta aos participantes o Power Apps e o Dataverse. O
objetivo é efetuar login no Power Apps, configurar um ambiente de
trabalho e criar uma tabela do Dataverse importando dados de um arquivo
do Excel. Os participantes aprenderão habilidades essenciais para
trabalhar com aplicativos orientados a dados.

### Tarefa 1: Efetuando login no Power Apps

1.  Acesse o site do Power Apps +++
    <https://www.microsoft.com/en-us/power-platform/products/power-apps+++>
    e clique no botão **Try for Free.**

![](./media/image1.png)

2.  Insira o **Administrative Username** da seção **Office 365 Tenant**
    da aba **Resources** no campo do e-mail, **selecione** a
    **checkbox** e clique no botão **Start free**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image2.png)

3.  Digite a **Administrative Password** e você será levado para a
    página inicial do Power Apps.

4.  Selecione **Yes** na caixa de diálogo **Stay Signed** e **Got it**
    no prompt **Save password** e selecione **No, Thanks** no pop **-**
    up **Sign in** no Microsoft Edge.

\[!Nota \] **Nota:** Se for solicitado novamente o nome de usuário, a
senha ou qualquer informação para efetuar login, forneça os mesmos e
efetue login.

### Tarefa 2: Atualizar as configurações do ambiente do desenvolvedor

1.  Efetue login no centro de administração do Power Platform em
    +++https://admin.powerplatform.microsoft.com/home+++ usando suas
    credenciais de login.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image3.png)

2.  Selecione **Manage** no painel esquerdo e selecione **+ New** em
    **Environments**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image4.png)

3.  Forneça o nome do ambiente como +++ **Dev One** +++ e selecione o
    Tipo como **Developer** e selecione **Next**.

![](./media/image5.png)

4.  Selecione **Save** na caixa de diálogo **Add Dataverse**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image6.png)

5.  Quando o ambiente estiver **pronto**, selecione o ambiente **Dev
    One** criado**.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image7.png)

6.  Clique em **Edit** para editar as configurações.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

7.  No painel Editar, alterne o **Administration mode** para **ON** e
    selecione **Save**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

8.  Depois que as alterações editadas forem salvas, selecione
    **Settings**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image12.png)

9.  Selecione **Product -\> Features**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image13.png)

10. Em **Features**, alterne a opção **Dataverse search** e **Single
    table search** para **On** e selecione **Save**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image14.png)

### Tarefa 3: Configurando uma tabela do Dataverse

1.  Selecione o ambiente **Dev One** no canto superior direito.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image15.png)

2.  Na barra de navegação à esquerda, selecione **Tables.** Na barra
    superior da seção Tabelas, clique em **+ New table** e selecione
    **Create new tables**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

3.  Selecione a opção **Import an Excel file or CSV** para criar uma
    nova tabela.

![](./media/image17.png)

4.  Clique na opção **Select form device** e selecione o arquivo Excel
    do **Support Ticket** na pasta **C:\LabFiles**.

![](./media/image18.png)

5.  Selecione **Import** na próxima tela.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

6.  Selecione a tabela e clique em **View data** para vê-la.

\[!Nota \] **Observação:** Neste caso, a tabela é denominada *Employee
Technical Support Record*. O nome pode variar a cada execução. Salve o
nome da tabela para referência futura. O nome da coluna também pode
variar durante a execução.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

7.  Vá para os dados da tabela, selecione o menu suspenso ao lado do
    campo **Technical Issue Description**, selecione **Edit column** e
    defina o tipo de dado como **Text** 🡪 **Multiple line** 🡪 **Plain
    Text** e clique em **Update**. O nome da coluna pode ser diferente
    em cada caso.

\[!Nota \] **Nota:** O **nome da coluna pode ser um pouco diferente**,
mas será algo semelhante à descrição do problema, pois foi gerado pelo
Copilot.

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image21.png)

![](./media/image22.png)

8.  Selecione o menu suspenso ao lado do campo **Current Status**,
    selecione **Edit column**, defina as opções como
    +++**Unresolved**+++, +++ **Resolved** +++, +++ **Processing** +++.
    Defina a opção Padrão como **Unresolved** e clique em **Update**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image23.png)

9.  No canto superior direito, clique em **Save and exit** para salvar a
    tabela.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image24.png)

### Tarefa 4: Adicionar um arquivo ao OneDrive

1.  No canto superior esquerdo da página do Power Apps, selecione o menu
    e selecione OneDrive.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image25.png)

2.  Selecione **My files** -\> **+ Add new**.

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image26.png)

3.  Selecione **Files upload**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

4.  Escolha **IT Support.xlsx** em **C:\LabFiles**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

5.  Este arquivo será usado em um exercício mais adiante.

![](./media/image29.png)

> **Conclusão**
>
> Ao concluir este exercício, os participantes aprenderão:

- Como acessar e navegar no Power Apps usando credenciais de locatário
  de administrador do Office 365.

- As etapas para criar e configurar uma tabela do Dataverse importando
  dados.

- O conhecimento prático de configuração de um ambiente para dar suporte
  a fluxos de trabalho de desenvolvimento de aplicativos.

## Exercício 2: Criando o Contoso IT Support Agent

Este exercício se concentra no login no Microsoft Copilot Studio e na
criação de um agente Copilot personalizado, adaptado às operações de
suporte de TI da Contoso. Os participantes ganharão experiência prática
na navegação pelo Copilot Studio, na configuração de ambientes e na
criação de um agente com tecnologia de AI para otimizar os fluxos de
trabalho de TI.

### Tarefa 1: Criando e configurando o Contoso IT Support Agent

1.  Efetue login em +++ https://copilotstudio.microsoft.com +++ usando
    suas credenciais de hospedagem.

2.  Na seção inicial do Copilot Studio, no canto superior direito,
    selecione o **environment** e escolha o ambiente **DevOne**.

![](./media/image30.png)

3.  Na aba Bem-vindo ao Copilot Studio, clique em **Skip** para avançar.

![](./media/image31.png)

4.  Na barra de navegação à esquerda, selecione **Create** e depois
    **New agent** para começar a criar um novo agente.

![](./media/image32.png)

5.  No canto superior direito, clique no botão **Skip to configure**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

6.  Digite o **Name, Description and Instruction** do agente, conforme
    abaixo, e clique no botão **Create.**

> **Name:** +++ Contoso IT Support Agent +++
>
> **Description:** +++Create a Contoso IT Support Agent which transforms
> IT support at Contoso Solutions by providing instant troubleshooting
> for common issues, automating ticket creation for unresolved problems,
> and storing all interactions in Dataverse. This solution enhances
> response times, reduces manual workloads, and boosts employee
> productivity.+++
>
> **Instruction:** +++Create the Copilot Agent and configure it to
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

7.  Na página de visão geral do Contoso IT Support Agent, **Enable** o
    orquestrador para o agente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

8.  No canto superior direito do agente, clique no botão **Settings**.

![](./media/image36.png)

9.  Em seguida, vá para a seção **Generative AI**, selecione
    **Generative**, defina a moderação de conteúdo como **Medium** e
    clique em **Save** para salvar a configuração.

![](./media/image37.png)

10. Depois de **salvo**, **feche** o painel Configurações.

11. Na página de visão geral do agente, **Disable** a opção “**Allow the
    AI to use its own general knowledge**”.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

> **Conclusão**
>
> Ao concluir este exercício, os participantes aprenderão:

- Como acessar e configurar o Microsoft Copilot Studio.

- As etapas para criar e configurar um agente Copilot personalizado.

- As habilidades práticas para habilitar configurações de AI generativa
  e orquestrador para o agente.

- As maneiras de aprimorar as operações de TI automatizando a criação de
  tickets e aproveitando a AI para solução de problemas.

## Exercício 3: Aprimorando as capacidades do bot

Este exercício se concentra em aprimorar os recursos do Contoso IT
Support Agent, adicionando uma base de conhecimento e personalizando os
tópicos do bot para melhorar a interação. Os participantes refinarão as
respostas do bot e garantirão que ele auxilie os usuários de forma
eficaz na solução de problemas e no escalonamento.

### Tarefa 1: Adicionar Base de Conhecimento

1.  Na página de visão geral Contoso agent, role para baixo e clique no
    botão **+ Add Knowledge**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

2.  Selecione **Upload file** para adicionar o arquivo de laboratório
    **Contoso Common IT Issue.docx** da pasta **C:\LabFiles** e clique
    em **Add** para salvar o arquivo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

>  ![image](./media/image41.png)

3.  Novamente, vá para a página de visão geral do agente, role para
    baixo e clique em **+ Add knowledge.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image42.png)

4.  Selecione a opção **Dataverse (preview)** como fonte de dados.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image43.png)

5.  Na barra de pesquisa no canto superior direito, digite e pesquise
    por +++**Employee**+++ e selecione a tabela **Employee Technical
    Support Record**. Em seguida, clique nos botões **Next, Next** e
    **Add** para adicionar a fonte de conhecimento.

**Observação: O** **nome da tabela pode ser diferente** no seu caso,
pois é uma tabela gerada pelo Copilot.

> ![A screenshot of a computer AI-generated content may be
> incorrect.](./media/image44.png)

![](./media/image45.png)

\[!Alerta \] **Importante:** Na página Conhecimento, certifique-se de
que a fonte de conhecimento adicionada foi carregada com sucesso. Isso
geralmente leva de 10 a 15 minutos para ser concluído.

### Tarefa 2: Personalize o tópico de início da conversa

1.  Na barra de opções superior, clique em **Topics**, selecione
    **System** e depois clique e abra o tópico **Conversation Start**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image46.png)

2.  Role para baixo e vá para o nó de mensagens. Atualize a mensagem
    após o nome do bot, conforme mostrado abaixo:

Hello. I’m Bot Name, a virtual assistant. +++How can I help you?+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

3.  No topo, clique em **Save** para salvar o tópico.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image48.png)

### Tarefa 3: Atualizar o tópico de fallback

1.  Na barra de opções superior, clique em **Topics** e depois abra o
    tópico **Fallback.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image49.png)

2.  Role para baixo e vá até o nó de mensagens. Atualize a mensagem
    conforme mostrado abaixo:

+++ I’m sorry. This information is not available in my system. You can
raise the support ticket via mail for this issue.+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image50.png)

3.  No canto superior direito, clique no botão **Save** para salvar o
    tópico.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image51.png)

> **Conclusão**
>
> Ao concluir este exercício, os participantes aprenderão:

- Como carregar e integrar uma base de conhecimento para melhorar a
  funcionalidade do bot.

- As etapas para personalizar mensagens de início de conversa para uma
  experiência do usuário mais envolvente.

- As técnicas para atualizar respostas de fallback para um melhor
  tratamento de consultas não compatíveis.

## Exercício 4: Teste o agente

Este exercício orienta os participantes no teste do Contoso IT Support
Agent para validar sua funcionalidade. Os participantes verificarão como
o bot lida com prompts usando a base de conhecimento e tópicos
alternativos para garantir interação e escalonamento contínuo.

1.  No canto superior direito, clique no botão **Test**. Em seguida, na
    seção de teste, clique em **Map**, **On** e clique em **Refresh**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image52.png)

2.  Digite o prompt +++ **My printer is not working how to fix it** ++
    +. Ele fornece a solução de acordo com a fonte de conhecimento.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image53.png)

3.  Novamente, digite o prompt +++ **Two factor Authentication (2FA)
    issue**++ +.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

4.  O problema e a solução do 2FA não estão disponíveis na fonte de
    conhecimento, então irá para o tópico de fallback e retornará o
    prompt relacionado ao Raise Ticket.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

> **Conclusão**
>
> Ao concluir este exercício, os participantes aprenderão:

- Como testar e ativar um agente de AI para solução de problemas.

- A validação da capacidade do bot de responder usando sua base de
  conhecimento.

- Como tópicos de fallback lidam com consultas sem suporte e
  redirecionam usuários de forma eficaz.

## Exercício 5: Automatizando a criação de tickets de suporte com o Power Automate

Este exercício demonstra como automatizar a criação de tickets de
suporte usando o AgentFlow e integrá-lo ao Contoso IT Support Agent. Os
participantes criarão um fluxo para otimizar o relato de problemas e
registrar dados no Dataverse.

1.  Selecione **Flows** na barra de menu à esquerda do agente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image56.png)

2.  Selecione **Start in designer**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image57.png)

3.  Selecione **Add a trigger** e, em seguida, selecione o acionador
    **When an agent calls the flow**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image58.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

4.  Selecione o acionador adicionado, **When an agent calls the flow**
    e, em seguida, selecione **Add an Input**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

5.  Selecione **Text** como tipo de dado de entrada e renomeie a entrada
    como +++**Name** +++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image61.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

6.  Com o mesmo procedimento, crie mais entradas conforme os detalhes
    fornecidos abaixo.

| **Input Name** | **Data Type** |
|----------------|---------------|
| +++ID+++             | Texto          |
| +++Email+++          | Texto          |
| +++Details+++        | Texto          |

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image63.png)

7.  Abaixo de **When an agent calls the flow**, clique no sinal **(+)**
    e selecione **Add an action**.

![](./media/image64.png)

8.  Na barra de pesquisa Adicionar uma ação, digite +++ **Add a new
    row** +++. Em seguida, selecione **Add a new row** na seção
    Microsoft Dataverse.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image65.png)

Observação: Às vezes, uma conexão com o Dataverse não é criada
automaticamente. Pode ser necessário fazer **login** novamente com suas
credenciais de autenticação **OAuth**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image66.png)

9.  Na seção **Table Name**, pesquise e selecione +++ **Employee
    Technical Support Record** +++ (ou o nome da tabela correspondente
    criada).

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image67.png)

10. Abaixo do nome da tabela, selecione **Show all**, depois clique no
    campo específico e adicione a **entrada** com a ajuda do botão
    **dynamic content** (**Thunder bolt**) conforme a tabela abaixo.

Defina o campo **Current Status** como **Unresolved**.

| Section   |  Input Variable  |
|:---------|:--------|
| Employee Name   |  Nome (entrada dinâmica)  |
| Email Address   |  E-mail (entrada dinâmica)  |
|  Employee ID  |  ID (Entrada Dinâmica)  |
|  Technical Issue Description  |  Detalhes (entrada dinâmica)  |


![A blue line on a white background AI-generated content may be
incorrect.](./media/image68.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image69.png)

11. Na barra superior, clique em **Save draft** e depois em **Publish**.
    **Feche** a aba do Power Automate.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image70.png)

12. Selecione **Flows** na barra de menu à esquerda e depois selecione o
    fluxo **Untitled** (aquele que acabamos de criar).

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image71.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image72.png)

13. Selecione **Edit** no fluxo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image73.png)

14. Nomeie o fluxo como +++ **Create an Employee Support Ticket** +++ e
    selecione **Save**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image74.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image75.png)

15. Na página **Contoso IT Support Agent** **Overview,** selecione **+
    Add action**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image76.png)

16. Selecione o fluxo de agente **Create an Employee Support Ticket.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image77.png)

17. Clique no botão **Add action** para adicionar um fluxo.

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image78.png)

18. Na página **Overview** do agente, na seção **Action**, selecione
    **Edit** para editar os parâmetros da ação. Selecione a seção
    **Inputs**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image79.png)

![A screenshot of a support ticket AI-generated content may be
incorrect.](./media/image80.png)

19. Insira a descrição fornecida no campo de entrada correspondente.
    Após inserir a descrição, clique no botão **Save**.

| Section | Details |
|----|----|
| Name -- Description | +++Enter the name of the employee.+++ |
| ID -- Description | +++Enter the employee ID in the field.+++ |
| Email -- Description | +++Enter the email address of the employee from whom the email is received.+++ |
| Details -- Description | +++Enter the email details of the employee.+++ |

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image81.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image82.png)

**Conclusão**

Ao concluir este exercício, os participantes aprenderão:

- Como integrar fluxos de agentes com um agente Copilot para criação de
  tickets.

- As etapas para coletar e mapear dados de entrada dinamicamente a
  partir de interações do usuário.

- As técnicas para automatizar notificações por e-mail para
  escalonamento de problemas técnicos.

- A capacidade de configurar fluxos de trabalho para gerenciamento
  eficiente de tickets de suporte.

## Exercício 6: Configurando um acionador para Ações Automatizadas

Esta continuação da automação da criação de tickets de suporte se
concentra na configuração de um acionador no Contoso IT Support Agent
para a criação de um arquivo no OneDrive com o fluxo automatizado do
Power Automate. Os participantes configurarão os acionadores e
finalizarão a implementação do agente.

1.  Vá para a página de visão geral do agente, role para baixo e clique
    em **+Add trigger.** ![A screenshot of a web page AI-generated
    content may be incorrect.](./media/image83.png)

2.  Selecione o acionador **When a file is created** e clique em
    **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image84.png)

3.  Após o estabelecimento da conexão ser bem-sucedido, selecione
    **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image85.png)

4.  Selecione **Root** para **Folder**, **Yes** para **Include
    Subfolders** e então clique em **Create trigger**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image86.png)

5.  **Feche** a caixa de diálogo **Time to test your trigger**.

![A screenshot of a computer error AI-generated content may be
incorrect.](./media/image87.png)

6.  Na página Visão geral do agente, selecione os três pontos ao lado do
    acionador adicionado – **When a file is created** e selecione **Edit
    in Power Automate**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image88.png)

7.  Selecione o símbolo + abaixo do nó **When a file is created** para
    adicionar uma ação. No painel Ação, pesquise por +++ Get a row +++ e
    selecione **Get a row** em **Excel Online (Business)**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image89.png)

8.  Depois que a ação for adicionada, adicione os detalhes abaixo.

- Location – Selecione OneDrive for Business

- Document Library – OneDrive

- File – ITSupport.xlsx

- Table – Table1

- Key Column – ID

- Key Value – +++ID1234+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image90.png)

9.  Selecione o nó **Sends a prompt to the specified copilot for
    processing**. Em Corpo/mensagem, insira +++ then add the dynamic
    values, Name, ID, Email ID, Description and Status. Then add +++
    depois, adicione também "New record added to the Employee Support
    table"+++

Deve ser parecido com o da captura de tela abaixo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image91.png)

10. Agora, salve o fluxo clicando em **Save Draft** e depois em
    **Publish** para publicar o fluxo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image92.png)

11. De volta ao Copilot Studio, **Publish** o agente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image93.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image94.png)

## Exercício 7: Teste o agente

1.  No fluxo do Power Automate, **When a file is created**, selecione
    **Test**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image95.png)

2.  Selecione a opção **Manually** e selecione **Test**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image96.png)

3.  Abra sua página do **OneDrive**. Em **My files**, selecione **+ Add
    new** e selecione **Word document**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image97.png)

4.  De volta à página do Power Automate, você pode ver que o fluxo
    iniciou a execução e foi aprovado.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image98.png)

5.  Na página Visão geral do agente, selecione o ícone **Test Trigger**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image99.png)

6.  Selecione o gatilho mais recente e selecione **Start testing**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image100.png)

7.  Executa o fluxo, obtém os dados do rastreador de suporte e atualiza
    a tabela Dataverse.

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image101.png)

8.  Nesse caso, há um detalhe do ticket de suporte no rastreador, que é
    adicionado à tabela do Dataverse, criando assim um ticket de suporte
    para o usuário.

9.  A geração de e-mail ao receber um e-mail de um usuário sobre
    qualquer problema será mais eficiente. A parte de configuração do
    e-mail não pôde ser feita aqui devido às restrições de permissão do
    locatário. Considere a próxima tarefa, se você tiver um locatário
    com as permissões necessárias.

## Tarefas a serem realizadas em ambiente de produção

Em um ambiente de produção, a geração de tickets de suporte será
principalmente baseada em e-mail.

Esta tarefa **não** deve ser executada neste ambiente de teste, pois o
locatário tem restrições quanto ao uso da conta de e-mail. Essas etapas
podem ser adicionadas ao fluxo após a etapa 10 do **Exercise 5:
Automating Support Ticket Creation with Power Automate**, se você tiver
um locatário que possa enviar e receber e-mails.

Ignore esta tarefa nesta execução. Foi adicionada apenas para
aprendizado e compreensão da parte de geração de e-mails e para
configurar os e-mails recebidos como um acionador que desempenhará um
papel importante nas operações de suporte de TI e, em seguida, testará o
agente.

1.  Abaixo da ação **Add a new row**, clique em (+) e selecione **Add an
    action**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image102.png)

2.  Na seção A**dd an action**, insira +++ **Send an email** +++ na
    barra de pesquisa e selecione **send an email (V2)** na seção do
    Outlook do Office 365.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image103.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image104.png)

3.  Na seção de envio de e-mail, insira os detalhes fornecidos abaixo na
    seção correspondente:

Substitua os espaços reservados para **Name**, **ID**, **Details** pelas
variáveis usando conteúdo dinâmico

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

Best Regards

![A screenshot of a email AI-generated content may be
incorrect.](./media/image105.png)

4.  No canto superior esquerdo, renomeie o fluxo como +++ **Create an
    Employee Support Ticket** +++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image106.png)

5.  Salvar e publicar o fluxo

6.  Vá para a página de visão geral do agente, role para baixo e clique
    em **+ Add trigger**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

7.  Em seguida, na janela **Add trigger**, selecione o acionador **When
    a new email arrives (V3)**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image107.png)

8.  Após a conexão bem-sucedida do Copilot e do Outlook e a marca de
    verificação verde aparecer, clique no botão **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image108.png)

9.  No campo da pasta, selecione o ícone de pasta, escolha a pasta
    **Inbox** e, em seguida, selecione **Create trigger**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image109.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image110.png)

10. Feche o prompt **Time to test your trigger**. Na página de visão
    geral do agente de suporte, role para baixo, na seção de
    acionadores, clique nos três pontos **(...)** e selecione **Edit in
    Power Automate.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image111.png)

11. Clique com o botão direito do mouse no acionador e selecione
    **Delete**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image112.png)

12. Em seguida, clique em **Add a trigger**, pesquise por +++ **When new
    email arrives** +++ e selecione **When a new email arrives** um
    acionador na seção **Office 365 outlook**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image113.png)

13. Clique em **Send a prompt to the specified copilot for processing**,
    na seção corpo/mensagem insira o prompt, +++ **Run Create an
    Employee Support Ticket flow and use content from Body From.**+++
    Substitua **Body** e **From** como variável de conteúdo dinâmico.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image114.png)

14. **Save** e **Publish** o fluxo, feche a janela do Power Automate e
    volte para a janela do Copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image115.png)

15. Vá para a seção de visão geral e, no canto superior direito, clique
    em **Publish** e novamente em **Publish** para publicar o copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image116.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image117.png)

**Conclusão**

Ao concluir este exercício, os participantes aprenderão:

- Técnicas para automatizar notificações por e-mail para escalonamento
  de problemas técnicos.

&nbsp;

- Como configurar gatilhos no Copilot para automatizar fluxos de
  trabalho com base em entradas de e-mail.

- Etapas para mapear dinamicamente o conteúdo de e-mail para fluxos do
  Power Automate.

- O processo de publicação e finalização do agente de AI para uso
  operacional.

- Habilidades práticas para vincular ferramentas de comunicação como o
  Outlook com fluxos de trabalho automatizados.

**Teste o agente**

Este exercício se concentra em testar a integração do Contoso IT Support
Agent com o Power Automate e o Outlook. Os participantes verificarão a
capacidade do agente de processar e-mails, criar tickets de suporte e
acionar fluxos de trabalho automatizados com eficácia.

1.  Acesse a página de visão geral do agente, role para baixo, clique em
    **(…)** no acionador e selecione **Edit in power automate**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image118.png)

2.  Você será direcionado ao Power Automate. Na barra superior, clique
    no botão **Test**, selecione **Manually** e clique novamente em
    **Test**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image119.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image120.png)

3.  **Send an email** para o administrador do 365, utilizando o ID de
    e-mail do locatário, de qualquer outra caixa de correio, para
    **trigger the action**. O e-mail deve descrever um problema e conter
    seus dados, como o ID do funcionário, semelhante ao mostrado na
    captura de tela abaixo. O conteúdo de exemplo é o seguinte:

I hope this message finds you well.

Iam Mark Brown, working as a Software Engineer at Contoso. My employee
ID is CONTOSO099

Issue: Monitor is completely blank and not functioning.

Kindly raise a support ticket and assist in resolving this issue at the
earliest.

Thank you for your support.

Best Regards,

Mark Brown

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image121.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image122.png)

4.  Navegue até a página de visão geral do agente copilot, role para
    baixo e selecione **Test trigger**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image123.png)

5.  Clique em **Start testing** e o teste será iniciado.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image124.png)

6.  Na seção de teste, clique em **Connect**, isso abrirá a janela de
    conexão.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image125.png)

7.  Clique em **Connect** novamente e selecione **Submit.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image126.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image127.png)

8.  Navegue até a janela do estúdio do copilot e execute o **Test**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image123.png)

9.  A solicitação de suporte é gerada automaticamente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image128.png)

10. Navegue até Power Apps e vá para a tabela **Employee support ticket
    record** e verifique os detalhes.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image129.png)

11. Verifique o e-mail de suporte que configuramos no fluxo do Power
    Automate para enviar um e-mail. O e-mail é enviado automaticamente
    para a equipe de suporte.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image130.png)

12. Acesse a janela de teste e escreva a consulta como usuário +++
    **Mark Brown Ticket Current Status** +++. Isso indica que o problema
    está como não resolvido.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image131.png)

13. Como engenheiro de suporte, escreva um prompt na seção de teste. +++
    **I want to know about all Unresolved ticket** +++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image132.png)

**Conclusão**

Ao concluir este exercício, os participantes aprenderão:

- Como testar a funcionalidade do agente simulando cenários do mundo
  real.

- Etapas para validar fluxos de trabalho acionados por email e geração
  de tickets no Power Automate.

- Como revisar registros gerados no Dataverse e garantir que
  notificações sejam enviadas à equipe de suporte.

- Insights práticos sobre depuração e finalização de fluxos de trabalho
  de automação.

**Conclusão final do guia de laboratório**

Este guia de laboratório proporcionou aos participantes uma experiência
prática na implementação de um Agente Copilot Autônomo para o service
desk de suporte de TI da Contoso Solutions. Seguindo os exercícios passo
a passo, os participantes conseguiram:

1.  **Configurar o Copilot Studio**: Os participantes aprenderam como
    fazer login no Copilot Studio, criar e configurar o agente de
    suporte de TI e habilitar configurações essenciais como AI
    generativa e orquestrador para solução de problemas eficaz e
    automação de tickets.

2.  **Navegar no Power Apps**: Os participantes ganharam conhecimento
    prático sobre como fazer login no Power Apps, configurar uma tabela
    do Dataverse e importar dados do Excel para rastrear e gerenciar
    tickets de suporte com eficiência.

3.  **Aprimorar os recursos do bot**: Os exercícios se concentraram em
    adicionar uma base de conhecimento ao bot, personalizar o início da
    conversa e os tópicos de fallback para melhorar a interação do
    usuário e garantir que o bot pudesse lidar com uma ampla variedade
    de cenários de suporte de TI.

4.  **Automatizar tarefas de suporte de TI**: Os participantes também
    aprenderam como automatizar a criação de tickets de suporte usando o
    Power Automate, aprimorando a capacidade do bot de gerenciar
    problemas não resolvidos e melhorar os fluxos de trabalho da equipe
    de TI.

Ao concluir esses exercícios, os participantes conseguiram implementar
um sistema de suporte autônomo robusto que melhora os tempos de
resposta, reduz a carga de trabalho manual e aumenta a produtividade
geral das operações de suporte de TI. A integração do Copilot Studio,
Power Apps e Dataverse garante um fluxo contínuo de informações,
automatiza tarefas de rotina e otimiza os fluxos de trabalho de suporte,
fornecendo soluções imediatas de solução de problemas aos funcionários e
gerenciamento automatizado de tickets para problemas não resolvidos.
