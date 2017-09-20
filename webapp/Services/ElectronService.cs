using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApp.Services.Modules;

namespace WebApp.Services
{
    public class ElectronService
    {
        public ElectronService(DialogModule dialogModule, MainWindowModule mainWindowModule, ClipboardModule clipBoardModule)
        {
            Dialog = dialogModule;
            ClipBoard = clipBoardModule;
            MainWindow = mainWindowModule;
        }

        public DialogModule Dialog { get; set; }

        public ClipboardModule ClipBoard { get; set; }

        public MainWindowModule MainWindow { get; set; }
    }
}