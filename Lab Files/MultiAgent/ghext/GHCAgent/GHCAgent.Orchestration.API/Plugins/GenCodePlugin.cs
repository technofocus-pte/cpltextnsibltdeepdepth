using System.ComponentModel;
using System.Threading.Tasks;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

using GHCAgent.Core.Agents;


namespace GHCAgent.Orchestration.API.Plugins
{
    public sealed class GenCodePlugin
    {
            [KernelFunction, Description("Generate code")]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "Too smart")]
            public string GenCode([Description("Generate code based on Reqiurements")] string requirements)
            {
                GenCodeAgent.Init();
                return GenCodeAgent.GenRequirement(requirements);
            }

    }
}