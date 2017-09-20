using System.Threading.Tasks;

namespace WebApp.Services.Modules
{
    public class ClipboardModule : ElectronModule
    {
        public ClipboardModule(ElectronMessageHandler handler) : base(handler)
        {
        }

        public async Task ReadTextAsync(string type = null)
        {
            await SendActionAsync(arguments: type);
        }

        public async Task WriteTextAsync(string text, string type = null)
        {
            await SendActionAsync(arguments: new []{ text, type});
        }


    }
}