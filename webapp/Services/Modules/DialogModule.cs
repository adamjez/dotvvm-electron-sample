using System.Collections.Generic;
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

    public class ShowOpenDialogOptions
    {
        public string Title { get; set; }
        public string DefaultPath { get; set; }
        public string ButtonLabel { get; set; }
        public IEnumerable<string> Properties { get; set; }
        public IEnumerable<FileFilter> Filters {get;set;}
    }
    public class FileFilter
    {
        public string Name { get; set; }
        public IEnumerable<string> Extensions { get; set; }
    }
}