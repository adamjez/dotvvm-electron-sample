using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Helpers;
using WebApp.Services.Modules.Options;


namespace WebApp.Services.Modules
{
    public class MenuModule : ElectronModule
    {
        public MenuModule(ElectronMessageHandler handler) : base(handler)
        {
        }

        public async Task PopupAsync(PopupMenuOptions options = null)
        {
            await SendActionAsync(arguments:options);
        }

        public async Task ClosePopupAsync()
        {
            await SendActionAsync();
        }

    }
}