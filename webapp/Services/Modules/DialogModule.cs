using System.Threading.Tasks;

namespace WebApp.Services.Modules
{
    public class DialogModule : ElectronModule
    {
        public DialogModule(ElectronMessageHandler handler) : base(handler)
        {
        }

        public async Task ShowOpenDialogAsync(ShowOpenDialogOptions options = null)
        {
            // new { Properties = new[] { "openFile", "openDirectory", "multiSelections" } }
            await SendActionAsync(arguments: options);
        }
    }
}