using System.Threading.Tasks;

namespace WebApp.Services
{
    public class MainWindowModule : ElectronModule
    {
        public MainWindowModule(ElectronMessageHandler handler) : base(handler)
        {
        }

        public async Task CloseAsync()
        {
            await SendActionAsync();
        }

        public async Task MinimizeAsync()
        {
            await SendActionAsync();
        }
    }

    public class DialogModule : ElectronModule
    {
        public DialogModule(ElectronMessageHandler handler) : base(handler)
        {
        }

        public async Task ShowOpenDialogAsync()
        {
            await SendActionAsync(arguments: new { properties = new[] { "openFile", "openDirectory", "multiSelections" } });
        }
    }
}