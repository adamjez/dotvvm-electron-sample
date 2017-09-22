using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using WebApp.Services;
using WebApp.Services.Modules;
using WebApp.Services.Modules.Options;

namespace WebApp.ViewModels
{
    public class DefaultViewModel : DotvvmViewModelBase
    {
        private ElectronService _electronService;
        public string ClipBoardReadTextProperty { get; set; }
        public ReadBookmarkOptions ReadBookMarkOptions { get; set; }
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

        public async Task BeforeQuit()
        {
            await _electronService.App.BeforeQuit();
        }
        public async Task SaveDialogWindow()
        {
            var options = new ShowSaveDialogOptions
            {
                Title = "TEST"
            };
            Title = await _electronService.Dialog.ShowSaveDialog(options);
        }
        public async Task ShowItemInFolder()
        {
            var result = await _electronService.Shell.ShowItemInFolderAsync(@"C:\Users\Tomas\Desktop\Capture.PNG");
        }

        public async Task OpenItem()
        {
            var result = await _electronService.Shell.OpenItemAsync(@"C:\Users\Tomas\Desktop\Capture.PNG");
        }

        public async Task OpenExternal()
        {
            var result = await _electronService.Shell.OpenExternalAsync(@"https://electron.atom.io/docs/api/shell/");
        }
        public async Task ShowMessageBox()
        {
            var options = new ShowMessageBoxOptions
            {
                Title = "TEST"
            };
            await _electronService.Dialog.ShowMessageBox(options);
        }

        public async Task ShowErrorBox()
        {
            var options = new ShowErrorBoxOptions
            {
                Title = "Test",
                Content = "ERROR"
            };
            await _electronService.Dialog.ShowErrorBox(options);
        }

        public async Task ClipBoardWriteText()
        {
            await _electronService.ClipBoard.WriteTextAsync("Test");
        }

        public async Task ClipBoardReadText()
        {
            ClipBoardReadTextProperty = await _electronService.ClipBoard.ReadTextAsync();
        }

        public async Task ClipBoardWriteBookMark()
        {
            WriteBookmarkOptions obj = new WriteBookmarkOptions
            {
                Text = "test",
                Bookmark = "as"
            };
            await _electronService.ClipBoard.WriteBookMarkAsync(obj);
        }

        public async Task ClipBoardReadBookMark()
        {
            ReadBookMarkOptions = await _electronService.ClipBoard.ReadBookmarkAsync();
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
