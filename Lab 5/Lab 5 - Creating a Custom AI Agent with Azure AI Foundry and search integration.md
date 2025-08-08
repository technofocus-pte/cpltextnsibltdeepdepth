# Laboratório 5 - Criando um agente de AI personalizado com o Azure AI Foundry e integração de pesquisa

**Tempo estimado: 45 min**

## Objetivo

O objetivo deste laboratório é orientar os participantes na criação de
um agente com tecnologia de AI usando os serviços do Azure AI e a
integração com o Search. A Retrieval Augmented Generation (RAG) é uma
técnica usada para criar aplicativos que integram dados de fontes
personalizadas em um prompt para um modelo de AI generativo. RAG é um
padrão comumente usado para desenvolver aplicativos de AI generativa –
aplicativos baseados em chat que usam um modelo de linguagem para
interpretar entradas e gerar respostas apropriadas. Os participantes
aprenderão a usar o portal do Azure AI Foundry para integrar dados
personalizados em um fluxo de prompts de AI generativo.

## Solução

Este laboratório se concentra na integração dos serviços do Azure AI com
recursos avançados de pesquisa para criar uma solução robusta e
inteligente. Ele enfatiza a configuração de um agente com tecnologia de
AI, permitindo a recuperação de dados sem interrupções e fornecendo
respostas contextuais. Ao utilizar a AI e a integração de pesquisa, a
solução visa otimizar fluxos de trabalho, aprimorar a tomada de decisões
e aprimorar o engajamento do usuário por meio de interações intuitivas e
eficientes.

## Tarefa 1: Criar um recurso de pesquisa do Azure AI

1.  Em um navegador da web, abra o portal do Azure em
    +++[https://portal.azure.com+++]() e **faça login** usando

- Username - <+++@lab.CloudPortalCredential>(User1).Username+++

- Password - <+++@lab.CloudPortalCredential>(User1).Password+++

![A screenshot of a computer Description automatically
generated](./media/image1.png)

2.  Na página inicial, selecione **+ Create a resource.**

![A screenshot of a computer Description automatically
generated](./media/image2.png)

3.  Na barra de pesquisa, pesquise e selecione +++**Azure AI
    Search**+++.

![A screenshot of a computer Description automatically
generated](./media/image3.png)

4.  Selecione o menu suspenso ao lado de **Create** e selecione **Azure
    AI Search**.

![A screenshot of a computer Description automatically
generated](./media/image4.png)

5.  Na página **Create a search service**, insira os detalhes abaixo e
    clique em **Review + create**.

    - **Subscription**: Selecione sua assinatura do Azure no menu
      suspenso.

    - **Resource group**: Selecione o grupo de recursos atribuído à sua
      assinatura (ResourceGroup1)

    - **Service name**: <+++aisearch@lab.LabInstance.Id>+++

    - **Location**: Selecione
      lab.CloudResourceGroup(ResourceGroup1).Location

    - **Pricing tier**: Standard

![A screenshot of a computer Description automatically
generated](./media/image5.png)

6.  Revise as configurações e clique em **Create**.

![A screenshot of a search service Description automatically
generated](./media/image6.png)

7.  Aguarde a conclusão da implementação do recurso do Azure AI Search.

![A screenshot of a computer Description automatically
generated](./media/image7.png)

## Tarefa 2: Criar um recurso e projeto do Azure AI Hub

1.  Selecione **Azure AI Foundry** na página **Home** do portal do
    Azure.

![image](./media/image8.png)

2.  Selecione **Use with AI Foundry** -\> **AI Hubs**. Selecione **+
    Create** -\> **Hub.**

![image](./media/image9.png)

3.  Insira os detalhes abaixo, aceite os outros padrões e selecione
    **Review + create**.

    - Subscription - Selecione sua **assinatura atribuída**

    - Resource group - Selecione o grupo de recursos atribuído
      (**ResourceGroup1**)

    - Region - Selecione
      @lab.CloudResourceGroup(ResourceGroup1).Location

    - Name -
      +++[**hub@lab.LabInstance.Id**](mailto:hub@lab.LabInstance.Id)+++

![image](./media/image10.png)

![image](./media/image11.png)

4.  Após a avaliação, selecione **Create**.

![image](./media/image12.png)

5.  Quando a implementação estiver concluída, clique em **Go to
    resource**.

![image](./media/image13.png)

6.  Selecione **Launch Azure AI Foundry** na página de recursos do hub.

![image](./media/image14.png)

7.  No recurso do hub iniciado, role para baixo e selecione **+ New
    project**

![image](./media/image15.png)

![image](./media/image16.png)

8.  Digite o nome como
    +++[**ragpfproject@lab.LabInstance.Id**](mailto:ragpfproject@lab.LabInstance.Id)+++
    e selecione **Create**.

![image](./media/image17.png)

9.  **Close** o pop-up **Explore and experiment**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image18.png)

10. Você será direcionado para a página do projeto criado.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image19.png)

## Tarefa 3: Implementar modelos

Você precisa de dois modelos para implementar sua solução:

- Um modelo de incorporação para vetorizar dados de texto para indexação
  e processamento eficientes.

- Um modelo que pode gerar respostas em linguagem natural para perguntas
  baseadas em seus dados.

1.  Selecione **Models + endpoints** em **My assets** no painel
    esquerdo.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image20.png)

2.  Na **página Manage deployments of your models and services,** clique
    em **+ Deploy model** e selecione **Deploy base model.**

![A screenshot of a computer Description automatically
generated](./media/image21.png)

3.  Na página **Select a model**, pesquise e selecione o modelo
    +++**text-embedding-ada-002**+++ e clique em **Confirm.**

![A screenshot of a computer Description automatically
generated](./media/image22.png)

4.  No painel **Deploy model text-embedding-ada-002**, aceite o valor
    pré-preenchido para **Deployment name.** Selecione **Deployment
    type** como **standard**. Clique em **Customize** e insira os
    seguintes detalhes no assistente de implementação do modelo.

![A screenshot of a computer Description automatically
generated](./media/image23.png)

- **Model version**: Selecione a versão padrão

- **AI resource**: Selecione o recurso criado anteriormente (esse é o
  recurso listado no menu suspenso)

- **Tokens per Minute Rate Limit (thousands)**: 5K

- **Content filter**: DefaultV2

- **Enable dynamic quota**: Desativado

![A screenshot of a computer Description automatically
generated](./media/image24.png)

![A screenshot of a computer Description automatically
generated](./media/image25.png)

![A screenshot of a computer Description automatically
generated](./media/image26.png)

5.  Repita as etapas anteriores para implementar um modelo
    +++**gpt-4o**+++ com o nome de implementação gpt-4o.

![A screenshot of a computer Description automatically
generated](./media/image27.png)

6.  Agora temos as duas implementações prontas.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image28.png)

\[!Observação\] **Observação:** Reduzir os Tokens Per Minute (TPM) ajuda
a evitar o uso excessivo da cota disponível na assinatura que você está
usando. 5.000 TPM são suficientes para os dados usados neste exercício.

## Tarefa 4: Adicionar dados ao seu projeto

Os dados do seu copilot consistem em um conjunto de folhetos de viagem
em formato PDF da agência de viagens fictícia *Margie's Travel* . Vamos
adicioná-los ao projeto.

1.  Selecione **Data + indexes** em **My assets** no painel esquerdo.
    Selecione **+ New data**.

![A screenshot of a computer Description automatically
generated](./media/image29.png)

2.  No assistente **Add your data**, selecione **Upload files/folders**
    no menu suspenso.

![A screenshot of a computer Description automatically
generated](./media/image30.png)

3.  Selecione **Upload folder** e selecione a pasta de **brochures** em
    **C:\LabFiles** e clique em **Upload**.

![A screenshot of a computer Description automatically
generated](./media/image31.png)

![A screenshot of a computer Description automatically
generated](./media/image32.png)

4.  Aguarde o upload da pasta e observe que ela contém vários arquivos
    .pdf. Selecione **Next** quando todos os arquivos forem enviados.

![A screenshot of a computer Description automatically
generated](./media/image33.png)

5.  Na próxima página de **name and finish**, insira o nome dos dados
    como
    +++[**data@lab.LabInstance.Id**](mailto:data@lab.LabInstance.Id)+++
    e clique em **Create.**

![A screenshot of a computer Description automatically
generated](./media/image34.png)

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image35.png)

## Tarefa 5: Criar um índice para seus dados

Agora que você adicionou uma fonte de dados ao seu projeto, pode usá-la
para criar um índice no seu recurso do Azure AI Search.

1.  Na página **Data + indexes**, selecione a aba **Indexes**.

![A screenshot of a computer Description automatically
generated](./media/image36.png)

2.  Na aba **Indexes**, selecione **+ New index** para adicionar um novo
    índice.

![A screenshot of a computer Description automatically
generated](./media/image37.png)

3.  Insira os detalhes abaixo e clique em **Next**.

    - **Data source** - Selecione **Data in Azure AI Foundry**

Selecione a **data source** e clique em **Next**.

![A screenshot of a computer Description automatically
generated](./media/image38.png)

4.  Insira os detalhes abaixo na página **Create a vector index – Index
    configuration** e clique em **Next.**

    - **Select Azure AI Search service**: Selecione **AzureAISearch**

    - Vector index - +++**brochures-index**+++

    - **Virtual machine**: Selecione **Auto select**

![A screenshot of a computer Description automatically
generated](./media/image39.png)

5.  Na página **Create a vector index – Search settings**,

**Vector settings** - Selecione **Add vector search to this search
resource**

Aceite os outros padrões e selecione **Next.**

![A screenshot of a search box Description automatically
generated](./media/image40.png)

6.  Na página **Review and finish**, revise os detalhes e selecione
    **Create vector index**.

![A screenshot of a computer Description automatically
generated](./media/image41.png)

7.  Aguarde a conclusão do processo de indexação, que pode levar vários
    minutos. A operação de criação do índice consiste nas seguintes
    tarefas:

    - Divida, fragmente e integre os tokens de texto dos dados dos seus
      folhetos.

    - Crie o índice do Azure AI Search.

    - Registre o ativo indexado.

![A screenshot of a computer error Description automatically
generated](./media/image42.png)

![A screenshot of a computer program Description automatically
generated](./media/image43.png)

## Tarefa 6: Testar o índice

Antes de usar seu índice em um fluxo de prompt baseado em RAG, vamos
verificar se ele pode ser utilizado para influenciar as respostas da AI
generativa.

1.  Selecione **Playgrounds** no painel esquerdo e selecione **Chat
    Playground.**

![A screenshot of a chat Description automatically
generated](./media/image44.png)

2.  Clique em **Show setup** se não estiver visível por padrão.

![A screenshot of a computer Description automatically
generated](./media/image45.png)

3.  Certifique-se de que a implementação do seu modelo **gpt-4o** esteja
    selecionada. Em seguida, no painel principal da sessão do chat,
    envie o prompt +++**Where can I stay in New York?**+++

![A screenshot of a computer program Description automatically
generated](./media/image46.png)

![A screenshot of a chat Description automatically
generated](./media/image47.png)

4.  Revise a resposta, que deve ser uma resposta genérica do modelo sem
    nenhum dado proveniente do índice.

5.  No painel Configuração, expanda o campo **Add your data**, selecione
    o índice do projeto **brochures-index** e selecione o tipo de
    pesquisa **hybrid (vector + keyword)**.

![A screenshot of a computer Description automatically
generated](./media/image48.png)

\[!Nota\] **Observação:** Alguns usuários estão percebendo que os
índices recém-criados não ficam disponíveis imediatamente. Atualizar o
navegador geralmente resolve, mas, se o problema persistir e o índice
ainda não for encontrado, pode ser necessário aguardar até que o índice
seja reconhecido.

6.  Esta adição da fonte de dados inicia uma nova sessão. Feito isso,
    reenvie o prompt +++**Where can I stay in New York?**+++

![A screenshot of a chat Description automatically
generated](./media/image49.png)

7.  Revise a resposta e observe que agora ela é baseada em dados no
    índice.

![A screenshot of a chat Description automatically
generated](./media/image50.png)

## Tarefa 7: Usar o índice em um fluxo de prompt

Seu índice vetorial foi salvo no seu projeto do Azure AI Foundry,
permitindo que você o utilize facilmente em um fluxo rápido.

1.  Selecione o **Prompt flow** em **Build and customize** no painel de
    navegação esquerdo e clique em **Create**.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image51.png)

2.  Selecione **Clone** em **Multi-Round Q&A on Your Data**.

![A screenshot of a computer Description automatically
generated](./media/image52.png)

3.  Dê o nome da pasta como +++ **brochure-flow** +++ e clique em
    **Clone**.

![A screenshot of a computer Description automatically
generated](./media/image53.png)

**Observação:** Se ocorrer um erro de permissão, tente novamente com um
novo nome após 2 minutos e o fluxo será clonado.

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image54.png)

4.  Quando a página do designer de fluxo de prompts abrir, revise
    **brochure-flow**. O gráfico deve ser semelhante à seguinte imagem:

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image55.png)

![A screenshot a a prompt flow graph](./media/image56.png)

O fluxo de prompt de exemplo que você está usando implementa a lógica de
prompt para um aplicativo de chat, no qual o usuário pode enviar
iterativamente uma entrada de texto para a interface de chat. O
histórico da conversa é mantido e incluído no contexto de cada iteração.
O fluxo de prompt orquestra uma sequência de *ferramentas* para:

- Anexar o histórico à entrada do chat para definir um prompt na forma
  de uma pergunta contextualizada.

- Recuperar o contexto usando seu índice e um tipo de consulta de sua
  escolha com base na pergunta.

- Gerar contexto de prompt usando os dados recuperados do índice para
  complementar a pergunta.

- Criar variantes de prompt adicionando uma mensagem do sistema e
  estruturando o histórico do chat.

- Enviar o prompt para um modelo de linguagem para gerar uma resposta em
  linguagem natural.

5.  Use o botão **Start compute session** para iniciar a execução da
    computação do fluxo.

Aguarde o início do tempo de execução. Isso fornece um contexto de
computação para o fluxo de prompt. Enquanto aguarda, na aba **Flow**,
revise as seções das ferramentas no fluxo.

![A screenshot of a computer screen Description automatically
generated](./media/image57.png)

6.  Na seção **Inputs**, certifique-se de que as entradas incluam:

    - **chat_history**

    - **chat_input**

O histórico de chat padrão neste exemplo inclui algumas conversas sobre
AI.

![A screenshot of a computer program AI-generated content may be
incorrect.](./media/image58.png)

7.  Na seção **Outputs**, certifique-se de que a saída inclua:

    - **chat_output** com valor ${chat_with_context.output}

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image59.png)

8.  Na seção **modify_query_with_history**, selecione as seguintes
    configurações (deixando as outras como estão):

    - **Connection**: Selecione o **Azure OpenAI resource** para seu hub
      de AI que está listado

    - **API** : Selecione **chat**

    - **deployment_name**: Selecione **gpt-4o**

    - **response_format**: Selecione**{“type”:”text”}**

![A screenshot of a computer AI-generated content may be
incorrect.](./media/image60.png)

9.  Depois que a sessão de computação for iniciada, na seção **lookup**,
    defina os seguintes valores de parâmetros:

    - **mlindex_content**: *Selecione o campo vazio para abrir o painel
      Gerar*

      - **index_type**: Selecione **Registered Index**

 

- **mlindex_asset_id**: Selecione **brochures-index:1**

![A screenshot of a computer Description automatically
generated](./media/image61.png)

![A screenshot of a computer Description automatically
generated](./media/image62.png)

De volta à seção de pesquisa, insira os detalhes abaixo

- **queries**: ${modify_query_with_history.output}

- **query_type**: Hybrid (vector + keyword)

- **top_k**: 2

![A screenshot of a computer Description automatically
generated](./media/image63.png)

10. Na seção **generate_prompt_context**, revise o script Python e
    certifique-se de que as **inputs** para esta ferramenta incluam o
    seguinte parâmetro:

    - **search_result** *(object)*: ${lookup.output}

![A screenshot of a computer Description automatically
generated](./media/image64.png)

11. Na seção **Prompt_variants**, revise o script Python e certifique-se
    de que as **inputs** para esta ferramenta incluam os seguintes
    parâmetros:

    - **contexts** *(string)*: ${generate_prompt_context.output}

    - **chat_history** *(string)*: ${inputs.chat_history}

    - **chat_input** *(string)*: ${inputs.chat_input}

![A screenshot of a chat Description automatically
generated](./media/image65.png)

12. Na seção **chat_with_context**, selecione as seguintes configurações
    (deixando as outras como estão):

    - **Connection**: Selecione o **Azure OpenAI resource**

    - **Api**: Chat

    - **deployment_name**: gpt-4o

    - **response_format**: {“type”:”text”}

Em seguida, certifique-se de que as **inputs** para esta ferramenta
incluam os seguintes parâmetros:

- **prompt_text** *(string)*: ${Prompt_variants.output}

![A screenshot of a computer Description automatically
generated](./media/image66.png)

13. Selecione o botão **Save** na barra de ferramentas para salvar as
    alterações feitas nas ferramentas no fluxo de prompt.

![A screenshot of a computer Description automatically
generated](./media/image67.png)

14. Na barra de ferramentas, selecione **Chat**. Um painel de chat será
    aberto com o histórico de conversa de exemplo e o campo de entrada
    já preenchido com valores de amostra. Você pode ignorar essas
    informações.

![A screenshot of a computer Description automatically
generated](./media/image68.png)

15. No painel de chat, substitua a entrada padrão pela pergunta
    +++**Where can I stay in London?**+++ e envie-a.

![A screenshot of a chat AI-generated content may be
incorrect.](./media/image69.png)

16. A resposta é baseada nos dados do índice.

17. Revise as saídas de cada ferramenta no fluxo.

![A screenshot of a computer Description automatically
generated](./media/image70.png)

18. No painel de chat, digite a pergunta +++**What can I do there?**+++

19. Revise a resposta, que deve ser baseada nos dados do índice e levar
    em consideração o **chat history** (portanto, “**there**” é
    entendido como “**in London**”).

![A screenshot of a chat Description automatically
generated](./media/image71.png)

20. Revise as saídas de cada ferramenta no fluxo, observando como cada
    ferramenta operou em suas entradas para preparar um prompt
    contextualizado e obter uma resposta apropriada.

## Tarefa 8: Limpar os recursos:

1.  No portal do Azure
    (+++[https://portal.azure.com+++](https://portal.azure.com+++/)),
    selecione o **ResourceGroup1** (aquele atribuído a você).

2.  Selecione todos os recursos abaixo e clique em **Delete**.

![A screenshot of a computer Description automatically
generated](./media/image72.png)

3.  Digite +++**delete**+++ e clique no botão **Delete** para confirmar
    a exclusão. Clique em **Delete** na caixa de diálogo de confirmação
    de exclusão.

![A screenshot of a computer Description automatically
generated](./media/image73.png)

4.  Certifique-se de que os recursos sejam excluídos pela mensagem de
    confirmação de exclusão.

![A screenshot of a computer screen Description automatically
generated](./media/image74.png)

## Resumo

Neste laboratório, aprendemos a criar um agente personalizado que usa
seus próprios dados do **Azure AI Foundry**.
