using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Helpers;
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

        public async Task<string> ShowSaveDialog(ShowSaveDialogOptions options = null)
        {
            var result = await SendActionAsync(arguments: options);
            return result.ToObject<string>();
        }

        public async Task<int> ShowMessageBox(ShowMessageBoxOptions options = null)
        {
            var result = await SendActionAsync(arguments: options);
            return result.ToObject<int>();
        }

        public async Task ShowErrorBox(ShowErrorBoxOptions options = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(options.Title, options.Content));
        }
    }
}