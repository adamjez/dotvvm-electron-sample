using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using WebApp.Services;

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
            await _electronService.Dialog.ShowOpenDialogAsync();
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
