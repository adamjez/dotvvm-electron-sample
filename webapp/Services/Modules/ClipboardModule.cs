using System.Threading.Tasks;
using WebApp.Helpers;

namespace WebApp.Services.Modules
{
    public class ClipboardModule : ElectronModule
    {
        public ClipboardModule(ElectronMessageHandler handler) : base(handler)
        {
        }

        public async Task ReadTextAsync(string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(type));
        }

        public async Task WriteTextAsync(string text, string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(text, type));
        }

        public async Task ReadHtmlAsync(string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(type));
        }


        public async Task WriteHtmlAsync(string markup, string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(markup, type));
        }

        public async Task ReadBookmarksAsync()
        {
            await SendActionAsync();
        }

        public async Task WriteBookmarkAsync(string title, string url, string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(title, url, type));
        }

        public async Task ReadRTFAsync(string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(type));
        }
        public async Task WriteRTFAsync(string text, string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(text, type));
        }


    }
}