using System.Threading.Tasks;

namespace WebApp.Services.Modules
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
}