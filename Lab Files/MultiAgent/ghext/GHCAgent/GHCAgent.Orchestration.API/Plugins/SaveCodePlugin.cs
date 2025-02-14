using System.ComponentModel;
using System.Threading.Tasks;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

using GHCAgent.Core.Agents;

namespace GHCAgent.Orchestration.API.Plugins
{
    public sealed class SaveCodePlugin
    {
            [KernelFunction, Description("Save code")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Too smart")]
            public async Task<string> SaveCode([Description("save genertion code")] string code)
            {
                // await SaveCodeAgent.Init();
                return await SaveCodeAgent.SaveCode(code);
            }
    }
}