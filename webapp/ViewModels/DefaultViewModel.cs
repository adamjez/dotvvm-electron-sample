using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using WebApp.Services;
using WebApp.Services.Modules;

namespace WebApp.ViewModels
{
    public class DefaultViewModel : DotvvmViewModelBase
    {
        private ElectronService _electronService;

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
            await _electronService.ClipBoard.WriteTextAsync("TEST");
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
