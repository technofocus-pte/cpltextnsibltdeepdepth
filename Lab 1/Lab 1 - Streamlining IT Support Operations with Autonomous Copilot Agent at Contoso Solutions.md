# Laboratório 1 - Simplificando as operações de suporte de TI com o agente autônomo copilot usando o Copilot Studio

**Tempo estimado: 60 minutos**

## Objetivo

O objetivo deste laboratório é capacitar os participantes a otimizar as
operações de suporte de TI na Contoso Solutions, criando um agente
Copilot autônomo. Os participantes aprenderão a configurar o Microsoft
Copilot Studio, configurar o Agente de Suporte de TI, integrar o Power
Apps e o Dataverse, aprimorar os recursos do bot com uma base de
conhecimento e automatizar a criação de tickets usando o Power Automate.
Este laboratório prático equipará os usuários com as habilidades
necessárias para aprimorar os fluxos de trabalho de TI, reduzir o
esforço manual e aumentar a eficiência do suporte.

## Solução

Os participantes criarão um Agente de Suporte de TI personalizado da
Contoso usando o Microsoft Copilot Studio, configurando-o para lidar com
problemas comuns de TI e o integrarão ao Dataverse para armazenar dados
de suporte. Eles definirão um ambiente de desenvolvimento, adicionarão
fontes de conhecimento e refinarão os fluxos de conversação do bot para
melhorar a interação do usuário. Utilizando o Power Apps, os
participantes criarão uma tabela do Dataverse para gerenciar registros
de suporte de TI. Usando o Power Automate, eles automatizarão a criação
de tickets e notificações por e-mail para problemas não resolvidos. Por
fim, os participantes testarão o agente para validar sua precisão na
solução de problemas e a automação dos fluxos de trabalho, garantindo
operações de suporte de TI sem falhas.

## Exercício 1: Introdução ao Power Apps

Este exercício apresenta aos participantes o Power Apps e o Dataverse. O
objetivo é efetuar login no Power Apps, configurar um ambiente de
trabalho e criar uma tabela do Dataverse importando dados de um arquivo
do Excel. Os participantes aprenderão habilidades essenciais para
trabalhar com aplicativos orientados a dados.

### Tarefa 1: Efetuando login no Power Apps

1.  Abra um navegador na VM do laboratório.

2.  Acesse o site do Power Apps
    +++<https://www.microsoft.com/en-us/power-platform/products/power-apps+++>
    e clique no botão **Try for Free**.

![](./media/image1.png)

3.  Insira o **Administrative Username** da seção **Office 365 Tenant**
    da aba **Resources** no campo do e-mail, **selecione** a **caixa de
    seleção** e clique no botão **Start free**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image2.png)

4.  Digite **Administrative Password** e você será levado para a página
    inicial do Power Apps.

5.  Selecione **Yes** na caixa de diálogo **Stay Signed** e **Got it**
    no prompt **Save password** e selecione **No, Thanks** no pop-up
    **Sign in to Microsoft Edge**.

Observação: Se for solicitado novamente o nome de usuário, a senha ou
qualquer informação para efetuar login, forneça-os e efetue login.

### Tarefa 2: Configurando uma tabela do Dataverse

1.  Certifique-se de que o ambiente **Dev One** esteja selecionado.
    Selecione-o se ainda não estiver selecionado.

![](./media/image3.png)

2.  Na barra de navegação à esquerda, selecione **Tables.** Na barra
    superior da seção Tabelas, clique em **+ New table** e selecione
    **Create new tables**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image4.png)

3.  Selecione a opção **Import an Excel file or CSV** para criar uma
    nova tabela.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image5.png)

4.  Clique na opção **Select form device** e selecione o arquivo Excel
    **Support Ticket** da pasta **C:\LabFiles**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image6.png)

5.  Selecione a tabela e clique em **View data** para vê-la.

Observação: Neste caso, a tabela é denominada ***Employee Technical
Support Record***. O nome pode variar a cada execução. Salve o nome da
tabela para referência futura. O nome da coluna também pode variar
durante a execução.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image7.png)

6.  Vá para os dados da tabela, selecione o menu suspenso ao lado do
    campo **Technical Issue Description**, selecione **Edit column** e
    defina o tipo de dados como **Text** 🡪 **Multiple line** 🡪 **Plain
    Text** e clique em **Update**. O nome da coluna pode ser diferente
    em cada caso.

Observação: O **nome da coluna pode ser um pouco diferente**, mas será
algo semelhante à descrição do problema, pois foi gerado pelo Copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image8.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image9.png)

7.  Selecione o menu suspenso ao lado do campo **Current Status**,
    selecione **Edit column**, defina as opções como
    +++**Unresolved**+++, +++**Resolved**+++, +++**Processing**+++.
    Defina a opção Padrão como **Unresolved** e clique em **Update**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image10.png)

8.  No canto superior direito, clique em **Save and exit** para salvar a
    tabela.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image11.png)

**Conclusão**

Ao concluir este exercício, os participantes aprenderão:

- Como acessar e navegar no Power Apps usando credenciais de locatário
  de administrador do Office 365.

- Etapas para criar e configurar uma tabela do Dataverse importando
  dados.

- Conhecimento prático de configuração de um ambiente para dar suporte a
  fluxos de trabalho de desenvolvimento de aplicativos.

## Exercício 2: Criando o Agente de Suporte de TI da Contoso

Este exercício se concentra no login no Microsoft Copilot Studio e na
criação de um agente Copilot personalizado, adaptado às operações de
suporte de TI da Contoso. Os participantes ganharão experiência prática
na navegação pelo Copilot Studio, na configuração de ambientes e na
criação de um agente com tecnologia de AI para otimizar os fluxos de
trabalho de TI.

### Tarefa 1: Efetuando login no Microsoft Copilot Studio

1.  Em um navegador, navegue até a url
    +++[https://Copilotstudio.microsoft.com+++](https://copilotstudio.microsoft.com+++/).

2.  Se a mensagem **Setting up your Copilot,** como na captura de tela
    abaixo, selecione **Environments** no menu superior direito e
    selecione **Dev One**. Caso contrário, ignore esta etapa e continue
    com a Etapa 3.

![image](./media/image12.png)

3.  Clique em **Start free trial** para iniciar o teste do Copilot
    Studio.

![](./media/image13.png)

### Tarefa 2: Criando e configurando o agente de suporte de TI da Contoso

1.  Se a etapa 2 da tarefa anterior estiver concluída, ignore esta
    etapa. Caso contrário, execute esta etapa. Na seção inicial do
    Copilot Studio, no canto superior direito, selecione o **ambiente**
    e escolha o ambiente **DevOne**.

![](./media/image14.png)

2.  Na aba Bem-vindo ao Copilot Studio, clique em **Skip**  para
    avançar.

![](./media/image15.png)

3.  Na barra de navegação à esquerda, selecione **Create**  e depois
    **New agent** para começar a criar um novo agente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image16.png)

4.  No canto superior direito, clique no botão **Skip to configure**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image17.png)

5.  Digite **Name, Description and Instruction** do agente, conforme
    abaixo, e clique no botão **Create.**

**Name:** +++Contoso IT Support Agent+++

**Description:** +++Create a Contoso IT Support Agent which transforms
IT support at Contoso Solutions by providing instant troubleshooting for
common issues, automating ticket creation for unresolved problems, and
storing all interactions in Dataverse. This solution enhances response
times, reduces manual workloads, and boosts employee productivity.+++

**Instruction:** +++Create the Copilot Agent and configure it to handle
IT support operations. Add a knowledge source containing solutions for
common IT issues like hardware troubleshooting, connectivity, and
software glitches. Set up a trigger to detect incoming emails from
employees describing unresolved issues. Create an action to save these
technical issues into a Dataverse table, ensuring all details are stored
for tracking and reporting. Test the agent to validate its
troubleshooting accuracy and ticket automation workflow before
deployment.+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image18.png)

6.  Na página de visão geral do Contoso IT Support Agent, **Enable** o
    orquestrador para o agente.

![](./media/image19.png)

7.  Na página de visão geral do agente, **Disable**  a opção “**Allow
    the AI to use its own general knowledge**”.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

8.  No canto superior direito do agente, clique no botão **Settings**.

![](./media/image21.png)

9.  Em seguida, vá para a seção **Generative AI**, selecione
    **Generative**, defina a moderação de conteúdo como **Medium** e
    clique em **Save** para salvar a configuração.

![](./media/image22.png)

**Conclusão**

Ao concluir este exercício, os participantes aprenderão:

- Como acessar e configurar o Microsoft Copilot Studio.

- Etapas para criar e configurar um agente Copilot personalizado.

- Habilidades práticas para habilitar configurações de AI generativa e
  orquestrador para o agente.

- Maneiras de aprimorar as operações de TI automatizando a criação de
  tickets e aproveitando a AI para solução de problemas.

## Exercício 3: Aprimorando as capacidades do bot

Este exercício se concentra em aprimorar os recursos do Agente de
Suporte de TI da Contoso, adicionando uma base de conhecimento e
personalizando os tópicos do bot para melhorar a interação. Os
participantes refinarão as respostas do bot e garantirão que ele auxilie
os usuários de forma eficaz na solução de problemas e no escalonamento.

### Tarefa 1: Adicionar Base de Conhecimento

1.  Na página de visão geral do agente da Contoso, role para baixo e
    clique no botão **+Add Knowledge**.

![](./media/image23.png)

2.  Selecione **Upload file** para adicionar o arquivo de laboratório
    **Contoso Common IT Issue.docx** da pasta **C:\LabFiles** e clique
    em **Add**  para salvar o arquivo.

![image](./media/image24.png) ![image](./media/image25.png)

3.  Novamente, vá para a página de visão geral do agente, role para
    baixo e clique em **+ Add knowledge.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image26.png)

4.  Selecione a opção **Dataverse (preview)** como fonte de dados.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image27.png)

5.  Na barra de pesquisa no canto superior direito, digite e pesquise
    por +++**Employee**+++ e selecione a tabela **Employee Technical
    Support Record**. Em seguida, clique nos botões **Next, Next** e
    **Add**  para adicionar a fonte de conhecimento.

**Observação: O** **nome da tabela pode ser diferente** no seu caso,
pois é uma tabela gerada pelo Copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image29.png)

\[!Alerta\] **Importante:** Na página Conhecimento, certifique-se de que
a fonte de conhecimento adicionada foi carregada com sucesso. Isso
geralmente leva de 10 a 15 minutos para ser concluído.

### Tarefa 2: Personalize o tópico de início da conversa

1.  Na barra de opções superior, clique em **Topics** -\> **System** e
    depois clique e abra o tópico **Conversation Start**.

![image](./media/image30.png)

2.  Role para baixo e vá para o nó de mensagens. Atualize a mensagem
    após o nome do bot, conforme mostrado abaixo:

Hello. I’m Bot Name, a virtual assistant. +++How can I help you?+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image31.png)

3.  No topo, clique em **Save** para salvar o tópico.

![](./media/image32.png)

### Tarefa 3: Atualizar o tópico de fallback

1.  Na barra de opções superior, clique em **Topics** -\> **System** e
    depois abra o tópico **Fallback**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image33.png)

2.  Role para baixo e vá até o nó de mensagens. Atualize a mensagem
    conforme mostrado abaixo:

+++I’m sorry. This information is not available in my system. You can
raise the support ticket via mail for this issue.+++

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image34.png)

3.  No canto superior direito, clique no botão **Save** para salvar o
    tópico.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

**Conclusão**

Ao concluir este exercício, os participantes aprenderão:

- Como carregar e integrar uma base de conhecimento para melhorar a
  funcionalidade do bot.

- Etapas para personalizar mensagens de início de conversa para uma
  experiência do usuário mais envolvente.

- Técnicas para atualizar respostas de fallback para melhor tratamento
  de consultas não suportadas.

## Exercício 4: Teste o agente

Este exercício orienta os participantes no teste do Agente de Suporte de
TI da Contoso para validar sua funcionalidade. Os participantes
verificarão como o bot lida com solicitações usando a base de
conhecimento e tópicos alternativos para garantir interação e
escalonamento contínuos.

1.  No canto superior direito, clique no botão **Test**. Em seguida, na
    seção de teste, clique em **Map**, coloque em **On**  e clique em
    **Refresh**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image36.png)

2.  Digite o prompt +++**My printer is not working how to fix it**+++.
    Fornece a solução de acordo com a fonte de conhecimento.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image37.png)

3.  Novamente, dê o prompt +++**Two factor Authentication (2FA)
    issue**+++ .

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image38.png)

4.  O problema e a solução do 2FA não estão disponíveis na fonte de
    conhecimento, então ele irá para o tópico de fallback e retornará o
    prompt relacionado ao Raise Ticket.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image39.png)

**Conclusão**

Ao concluir este exercício, os participantes aprenderão:

- Como testar e ativar um agente de AI para solução de problemas.

- Validação da capacidade do bot de responder usando sua base de
  conhecimento.

- Como tópicos de fallback lidam com consultas sem suporte e
  redirecionam usuários de forma eficaz.

## Exercício 5: Automatizando a criação de tickets de suporte com o Power Automate

Este exercício demonstra como automatizar a criação de tickets de
suporte usando o Power Automate e integrá-lo ao Agente de Suporte de TI
da Contoso. Os participantes criarão um fluxo para agilizar o relato de
problemas, registrar dados no Dataverse e notificar os engenheiros de
suporte por e-mail.

1.  Vá para a página de visão geral do agente, role para baixo e clique
    em **+ Add action**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image40.png)

2.  Na janela Escolha uma ação, no canto superior esquerdo, clique em
    **+ New Action** e selecione **New Power Automate Flow**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image41.png)

3.  No fluxo do Power Automate, clique em **When an agent calls the
    flow** e selecione **Add an Input**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image42.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image43.png)

4.  Selecione **Text** como tipo de dado de entrada e renomeie a entrada
    como +++**Name**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image44.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image45.png)

5.  Com o mesmo procedimento, crie mais entradas conforme os detalhes
    fornecidos abaixo.

[TABLE]

6.  ![A screenshot of a computer AI-generated content may be
    incorrect.](./media/image46.png)

7.  Abaixo de **When an agent calls the flow**, clique no sinal **(+)**
    e selecione **Add an action**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image47.png)

8.  Na barra de pesquisa **Add an action**, digite +++**Add a new
    row**+++. Em seguida, selecione **Add a new row** na seção Microsoft
    Dataverse.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image48.png)

Observação: Às vezes, uma conexão com o Dataverse não é criada
automaticamente. Pode ser necessário fazer **sign in** novamente com
suas credenciais de autenticação **OAuth**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image49.png)

9.  Na seção **Table Name**, pesquise e selecione +++**Employee
    Technical Support Record**+++ (ou o nome da tabela correspondente
    criada).

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image50.png)

10. Abaixo do nome da tabela, selecione **Show all**, clique no campo
    específico e adicione a entrada com a ajuda do botão de conteúdo
    dinâmico (Thunderbolt), conforme a tabela abaixo. O campo **Current
    Status** deve ser selecionado com o menu suspenso como
    **Unresolved**.

[TABLE]

11. ![A blue line on a white background AI-generated content may be
    incorrect.](./media/image51.png)

12. ![A screenshot of a computer AI-generated content may be
    incorrect.](./media/image52.png)

13. Abaixo da ação Adicionar uma nova linha, clique em (+) e selecione
    **Add an action**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image53.png)

14. Na seção Adicionar uma ação, insira +++ **Enviar um e-mail** +++ na
    barra de pesquisa e selecione **Enviar um e-mail (V2)** na seção do
    Outlook do Office 365.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

15. Na seção de envio de e-mail, insira os detalhes fornecidos abaixo na
    seção correspondente:

> Substitua os espaços reservados para **Name**, **ID**, e **Details**
> pelas variáveis usando conteúdo dinâmico
>
> **To**
>
> Digite o e-mail do engenheiro de suporte (**Use any email ID** - será
> para esse ID que o e-mail será enviado pelo agente quando o tíquete de
> suporte for aberto)
>
> **Subject**
>
> Novo ticket de suporte técnico gerado
>
> **Body**
>
> Um novo ticket de suporte técnico foi aberto e requer sua atenção.
> Veja os detalhes abaixo:
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
>
> ![A screenshot of a email AI-generated content may be
> incorrect.](./media/image56.png)

16. No canto superior esquerdo, renomeie o fluxo como +++**Create an
    Employee Support Ticket**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image57.png)

17. Na barra superior, clique em **Save draft** e depois em **Publish**.
    **Feche** a aba do Power Automate.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image58.png)

18. Volte para a janela do Copilot e clique no botão **Refresh**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

19. Na janela Escolher uma ação, selecione o fluxo de **Create an
    Employee Support Ticket**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

20. Clique no botão **Add action** para adicionar um fluxo.

![A screenshot of a computer screen AI-generated content may be
incorrect.](./media/image61.png)

21. Na página **Overview** do agente, na seção **Action**, selecione
    **Edit** para editar os parâmetros da ação. Selecione a seção
    **Inputs**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image62.png)

![A screenshot of a support ticket AI-generated content may be
incorrect.](./media/image63.png)

22. Insira a descrição fornecida no campo de entrada correspondente.
    Após inserir a descrição, clique no botão **Save**.

[TABLE]

23. ![A screenshot of a computer AI-generated content may be
    incorrect.](./media/image64.png)

24. ![A screenshot of a computer AI-generated content may be
    incorrect.](./media/image65.png)

**Conclusão**

Ao concluir este exercício, os participantes aprenderão:

- Como integrar fluxos do Power Automate com um agente Copilot para
  criação de tickets.

- Etapas para coletar e mapear dados de entrada dinamicamente a partir
  de interações do usuário.

- Técnicas para automatizar notificações por e-mail para encaminhamento
  de problemas técnicos.

- A capacidade de configurar fluxos de trabalho para gerenciamento
  eficiente de tickets de suporte.

## Exercício 6: Configurando um acionamento baseado em e-mail para ações automatizadas

Esta continuação da automação da criação de tickets de suporte se
concentra na configuração de um acionamento no Agente de Suporte de TI
da Contoso para vincular entradas de e-mail ao fluxo automatizado do
Power Automate. Os participantes configurarão os acionamentos e
finalizarão a implementação do agente.

1.  Vá para a página de visão geral do agente, role para baixo e clique
    em **+ Add trigger**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image66.png)

2.  Em seguida, na janela **Add trigger**, selecione o acionamento
    **When a new email arrives (V3)**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image67.png)

3.  Após a conexão bem-sucedida do Copilot e do Outlook e a marca de
    verificação verde aparecer, clique no botão **Next**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image68.png)

4.  No campo de pasta, selecione o ícone da pasta, selecione a pasta
    **Inbox** e, em seguida, selecione **Create trigger**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image69.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image70.png)

5.  Feche o prompt **Time to test your trigger**. Na página de visão
    geral do agente de suporte, role para baixo, na seção de
    acionamentos, clique nos três pontos **(...)** e selecione **Edit in
    Power Automate.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image71.png)

6.  Clique com o botão direito do mouse no acionamento **When a new
    email arrives** e selecione **Delete**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image72.png)

7.  Em seguida, clique em Adicionar um acionamento, pesquise por
    +++**When new email arrives**+++ e selecione o acionamento **When a
    new email arrives** na seção **Office 365 outlook**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image73.png)

8.  Clique em **Send a prompt to the specified Copilot for processing**,
    na seção corpo/mensagem insira o prompt, +++**Run Create an Employee
    Support Ticket flow and use content from Body From.**+++ Substitua
    **Body**  e **From** como variável de conteúdo dinâmico.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image74.png)

9.  **Save** e **Publish** o fluxo, feche a janela do Power Automate e
    volte para a janela do Copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image75.png)

10. Vá para a seção de visão geral e, no canto superior direito, clique
    em **Publish** e novamente em **Publish** para publicar o Copilot.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image76.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image77.png)

**Conclusão**

Ao concluir este exercício, os participantes aprenderão:

- Como configurar acionamentos no Copilot para automatizar fluxos de
  trabalho com base em entradas de e-mail.

- Etapas para mapear dinamicamente o conteúdo de e-mail para fluxos do
  Power Automate.

- O processo de publicação e finalização do agente de AI para uso
  operacional.

- Habilidades práticas para vincular ferramentas de comunicação como o
  Outlook com fluxos de trabalho automatizados.

## Exercício 7: Teste o agente

Este exercício se concentra em testar a integração do Agente de Suporte
de TI da Contoso com o Power Automate e o Outlook. Os participantes
verificarão a capacidade do agente de processar e-mails, criar tickets
de suporte e acionar fluxos de trabalho automatizados com eficácia.

1.  Acesse a página de visão geral do agente, role para baixo, clique em
    **(…)** no acionamento e selecione **Edit in power automate**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image78.png)

2.  Ele navegará para automatizar o fluxo de energia. Na barra superior,
    clique no botão **Test**, selecione **Manually** e clique novamente
    em **Test**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image79.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image80.png)

3.  **Enviar um e-mail** para o ID de e-mail do locatário administrador
    do 365 de qualquer outra caixa de correio a fim de **Acionar a
    ação**. O e-mail deve descrever um problema e conter seus dados,
    como o ID do funcionário, semelhante ao da captura de tela abaixo. O
    conteúdo de exemplo é o seguinte.

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

4.  Navegue até a página de visão geral do agente Copilot, role para
    baixo e selecione **Test trigger**.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

5.  Clique em **Start testing** e o teste será iniciado.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image84.png)

6.  Na seção de teste, clique em **Connect**, isso abrirá a janela de
    conexão.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image85.png)

7.  Clique em **Connect** novamente e selecione **Submit.**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image86.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image87.png)

8.  Navegue até a janela do estúdio do Copilot e execute o **teste**
    novamente.

![A screenshot of a web page AI-generated content may be
incorrect.](./media/image83.png)

9.  A solicitação de suporte é gerada automaticamente.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image88.png)

10. Navegue até Power Apps e vá para a tabela de registros de tickets de
    suporte a funcionários e verifique os detalhes.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image89.png)

11. Verifique o e-mail de suporte que configuramos no fluxo do Power
    Automate para enviar um e-mail. O e-mail é enviado automaticamente
    para a equipe de suporte.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image90.png)

12. Acesse a janela de teste e escreva a consulta como usuário +++**Mark
    Brown Ticket Current Status**+++. Isso indica que o problema está
    como não resolvido.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image91.png)

13. Como engenheiro de suporte, escreva um prompt na seção de teste.
    +++**I want to know about all Unresolved ticket**+++.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image92.png)

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

## Conclusão final do guia de laboratório

Este guia de laboratório proporcionou aos participantes uma experiência
prática na implementação de um Agente Copilot Autônomo para o service
desk de suporte de TI da Contoso Solutions. Seguindo os exercícios passo
a passo, os participantes conseguiram:

1.  **Set Up Copilot Studio**: Os participantes aprenderam como fazer
    login no Copilot Studio, criar e configurar o agente de suporte de
    TI e habilitar configurações essenciais como AI generativa e
    orquestrador para solução de problemas eficaz e automação de
    tickets.

2.  **Navigate Power Apps**: Os participantes ganharam conhecimento
    prático sobre como fazer login no Power Apps, configurar uma tabela
    do Dataverse e importar dados do Excel para rastrear e gerenciar
    tickets de suporte com eficiência.

3.  **Enhance Bot Capabilities**: Os exercícios se concentraram em
    adicionar uma base de conhecimento ao bot, personalizar o início da
    conversa e os tópicos de fallback para melhorar a interação do
    usuário e garantir que o bot pudesse lidar com uma ampla variedade
    de cenários de suporte de TI.

4.  **Automate IT Support Tasks**: Os participantes também aprenderam
    como automatizar a criação de tickets de suporte usando o Power
    Automate, aprimorando a capacidade do bot de gerenciar problemas não
    resolvidos e melhorar os fluxos de trabalho da equipe de TI.

Ao concluir esses exercícios, os participantes conseguiram implementar
um sistema de suporte autônomo robusto que melhora os tempos de
resposta, reduz a carga de trabalho manual e aumenta a produtividade
geral das operações de suporte de TI. A integração do Copilot Studio,
Power Apps e Dataverse garante um fluxo contínuo de informações,
automatiza tarefas de rotina e otimiza os fluxos de trabalho de suporte,
fornecendo soluções imediatas de solução de problemas aos funcionários e
gerenciamento automatizado de tickets para problemas não resolvidos.
