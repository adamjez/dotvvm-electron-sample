using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Helpers;
using WebApp.Services.Modules.Options;


namespace WebApp.Services.Modules
{
    public class AppModule : ElectronModule
    {
        public AppModule(ElectronMessageHandler handler) : base(handler)
        {
        }

        public async Task BeforeQuit()
        {
            await SendEventAsync();
        }
     
    }
}