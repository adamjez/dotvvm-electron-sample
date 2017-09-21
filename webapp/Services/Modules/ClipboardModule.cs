using System.Threading.Tasks;
using WebApp.Helpers;

namespace WebApp.Services.Modules
{
    public class ClipboardModule : ElectronModule
    {
        public ClipboardModule(ElectronMessageHandler handler) : base(handler)
        {
        }
        public async Task<string> ReadTextAsync(string type = null)
        {
            var result = await SendActionAsync();
            return result.ToObject<string>();
        }

        public async Task WriteTextAsync(string text, string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(text, type));
        }

        public async Task<string> ReadHtmlAsync(string type = null)
        {
            var result = await SendActionAsync(arguments: ParamHelpers.GetParams(type));
            return result.ToObject<string>();
        }

        public async Task WriteHtmlAsync(string markup, string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(markup, type));
        }

        public async Task ReadBookmarksAsync() // TODO return
        {
            await SendActionAsync();
        }

        public async Task WriteBookmarkAsync(string title, string url, string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(title, url, type));
        }

        public async Task<string> ReadRTFAsync(string type = null)
        {
            var result = await SendActionAsync(arguments: ParamHelpers.GetParams(type));
            return result.ToObject<string>();
        }
        public async Task WriteRTFAsync(string text, string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(text, type));
        }

        public async Task ClearAsync(string type = null)
        {
            await SendActionAsync(arguments: ParamHelpers.GetParams(type));
        }

    }
}