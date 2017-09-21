using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Services.Modules.Options;


namespace WebApp.Services.Modules
{
    public class DialogModule : ElectronModule
    {
        public DialogModule(ElectronMessageHandler handler) : base(handler)
        {
        }

        public async Task<IEnumerable<string>> ShowOpenDialogAsync(ShowOpenDialogOptions options = null)
        {
            var result = await SendActionAsync(arguments: options);

            return result.ToObject<List<string>>();
        }
    }
}