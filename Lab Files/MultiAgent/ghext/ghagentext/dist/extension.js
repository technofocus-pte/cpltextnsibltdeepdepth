/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ([
/* 0 */
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {


var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || (function () {
    var ownKeys = function(o) {
        ownKeys = Object.getOwnPropertyNames || function (o) {
            var ar = [];
            for (var k in o) if (Object.prototype.hasOwnProperty.call(o, k)) ar[ar.length] = k;
            return ar;
        };
        return ownKeys(o);
    };
    return function (mod) {
        if (mod && mod.__esModule) return mod;
        var result = {};
        if (mod != null) for (var k = ownKeys(mod), i = 0; i < k.length; i++) if (k[i] !== "default") __createBinding(result, mod, k[i]);
        __setModuleDefault(result, mod);
        return result;
    };
})();
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.activate = activate;
exports.deactivate = deactivate;
const vscode = __importStar(__webpack_require__(1));
const AGENT_DOWNLOADCODE_COMMAND_ID = 'PYAGENT.downloadCode';
const MODEL_SELECTOR = { vendor: 'copilot', family: 'gpt-4o' };
// This method is called when your extension is activated
// Your extension is activated the very first time the command is executed
function activate(context) {
    const codinghandler = async (request, context, stream, token) => {
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
            }
            catch (err) {
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
        provideFollowups(result, context, token) {
            return [{
                    prompt: 'Let us generation project with PyAgent 😋😋😋😋',
                    label: vscode.l10n.t('Enjoy coding with PyAgent'),
                    command: 'help'
                }];
        }
    };
    context.subscriptions.push(pyagnt_ext);
}
async function gen(prompt) {
    const postData = {
        Request: prompt
    };
    const response = await fetch('http://localhost:5284/api/gencode', {
        method: 'POST',
        body: JSON.stringify(postData),
        headers: { 'Content-Type': 'application/json' }
    });
    const post = await response.json();
    const resultResponse = post;
    const start = resultResponse.answer.lastIndexOf("/");
    const end = resultResponse.answer.indexOf(".zip");
    // resultResponse.answer.substring(start,end);
    var result = "🐙🐙🐙 The code has been generated and saved successfully. You can download the project zip file using the link below:\n\n🔽🔽 [Download project](http://localhost:5284/arch/" + resultResponse.answer.substring(start + 1, end) + ".zip)";
    // return result;
    return result;
}
// This method is called when your extension is deactivated
function deactivate() { }


/***/ }),
/* 1 */
/***/ ((module) => {

module.exports = require("vscode");

/***/ })
/******/ 	]);
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module is referenced by other modules so it can't be inlined
/******/ 	var __webpack_exports__ = __webpack_require__(0);
/******/ 	module.exports = __webpack_exports__;
/******/ 	
/******/ })()
;
//# sourceMappingURL=extension.js.map