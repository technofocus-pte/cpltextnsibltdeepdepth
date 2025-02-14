// The module 'vscode' contains the VS Code extensibility API
// Import the module and reference it with the alias vscode in your code below
import { start } from 'repl';
import * as vscode from 'vscode';


const AGENT_DOWNLOADCODE_COMMAND_ID = 'PYAGENT.downloadCode';

interface IPyAgentChatResult extends vscode.ChatResult {
    metadata: {
        command: string;
    };
}


const MODEL_SELECTOR: vscode.LanguageModelChatSelector = { vendor: 'copilot', family: 'gpt-4o' };



// This method is called when your extension is activated
// Your extension is activated the very first time the command is executed
export function activate(context: vscode.ExtensionContext) {

	const codinghandler: vscode.ChatRequestHandler = async (request: vscode.ChatRequest, context: vscode.ChatContext, stream: vscode.ChatResponseStream, token: vscode.CancellationToken): Promise<IPyAgentChatResult> => {



		
		if (request.command === 'help') {

			const content = "Welcome to Coding assistant with PyAgent. I am a Python assistant who can help you convert requiremnt into code and generate project based on requirement. "; 
			stream.progress(content);


            try {
                const [model] = await vscode.lm.selectChatModels(MODEL_SELECTOR);
                if (model) {
                    const messages = [
                        vscode.LanguageModelChatMessage.User("Please help me express this content in a humorous way: I am a Python assistant who can help you convert requiremnt into code and generate Flask project based on requirement.")
                    ];
                    const chatResponse = await model.sendRequest(messages, {}, token);
                    for await (const fragment of chatResponse.text) {
                        stream.markdown(fragment);
                    }
                }
            } catch(err) {
				console.log(err);
            }


            return { metadata: { command: 'help' } };

		} 


		
		if (request.command === 'proj') {



			const content = "Please wait ... I am generating project for you 😋😋😋😋";

			stream.progress(content);


			const result = await gen(request.prompt);

			const code = result;
	
			stream.markdown(result);

            return { metadata: { command: 'proj' } };

		}



		return { metadata: { command: '' } };

	};


	const pyagnt_ext = vscode.chat.createChatParticipant("chat.PYAGENT", codinghandler);

	pyagnt_ext.iconPath = new vscode.ThemeIcon('sparkle');


    pyagnt_ext.followupProvider = {
        provideFollowups(result: IPyAgentChatResult, context: vscode.ChatContext, token: vscode.CancellationToken) {
            return [{
                prompt: 'Let us generation project with PyAgent 😋😋😋😋',
                label: vscode.l10n.t('Enjoy coding with PyAgent'),
                command: 'help'
            } satisfies vscode.ChatFollowup];
        }
    };


	context.subscriptions.push(
			pyagnt_ext
	);
}

interface GenCode {
	Request: string;
}

interface GenCodeResponse {
	answer: string;
}

async function gen(prompt: string) {

	const postData: GenCode = {
		Request: prompt
	};
	const response = await fetch('http://localhost:5284/api/gencode', {
		method: 'POST',
		body: JSON.stringify(postData),
		headers: { 'Content-Type': 'application/json' }
	});
	const post = await response.json();
	const resultResponse = post as GenCodeResponse;

	const start = resultResponse.answer.lastIndexOf("/");
	const end = resultResponse.answer.indexOf(".zip");

	// resultResponse.answer.substring(start,end);

	var result = "🐙🐙🐙 The code has been generated and saved successfully. You can download the project zip file using the link below:\n\n🔽🔽 [Download project](http://localhost:5284/arch/" + resultResponse.answer.substring(start+1,end) + ".zip)";
	// return result;
	return result;
}


// This method is called when your extension is deactivated
export function deactivate() {}
