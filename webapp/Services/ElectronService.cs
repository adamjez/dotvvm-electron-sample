using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApp.Services.Modules;

namespace WebApp.Services
{
    public class ElectronService
    {
        public ElectronService(DialogModule dialogModule, MainWindowModule mainWindowModule)
        {
            Dialog = dialogModule;
            MainWindow = mainWindowModule;
        }

        public DialogModule Dialog { get; set; }

        public MainWindowModule MainWindow { get; set; }
    }
}