using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using WebApp.Services;
using WebApp.Services.Modules;
using static WebApp.Services.Modules.ClipboardModule;

namespace WebApp.ViewModels
{
    public class DefaultViewModel : DotvvmViewModelBase
    {
        private ElectronService _electronService;
        public string ClipBoardReadTextProperty { get; set; }
        public DefaultViewModel(ElectronService electronService)
        {
            _electronService = electronService;
            Title = "Hello from DotVVM!";

        }

        public string Title { get; set; }

        public async Task OpenDialogWindow()
        {
            var options = new ShowOpenDialogOptions
            {
                Properties = new[] { "openFile", "multiSelections" },
                Title = "Title Test",
                Filters = new[] { new FileFilter { Name = "Image", Extensions = new[] { "jpg", "png", "gif" } } }
            };

            Title = string.Join(", ", await _electronService.Dialog.ShowOpenDialogAsync(options));
        }

        public async Task ClipBoardWriteText()
        {
            await _electronService.ClipBoard.WriteTextAsync("Test");
        }

        public async Task ClipBoardReadText()
        {
            ClipBoardReadTextProperty = await _electronService.ClipBoard.ReadTextAsync();
        }

        public async Task MinimizeWindow()
        {
            await _electronService.MainWindow.MinimizeAsync();
        }

        public async Task CloseWindow()
        {
            await _electronService.MainWindow.CloseAsync();
        }
    }
}
