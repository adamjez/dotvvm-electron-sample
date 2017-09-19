using System.Threading.Tasks;

namespace WebApp.Services
{
    public class ElectronService
    {
        private WebSocketHandler _handler;

        public ElectronService(WebSocketHandler handler)
        {
            _handler = handler;            
        }

        public async Task OpenDialog()
        {
            await _handler.Send("OpenDialog");
        }

        public async Task MinimizeWindow()
        {
            await _handler.Send("Minimize");
        }

         public async Task CloseWindow()
        {
            await _handler.Send("Exit");
        }
    }
}