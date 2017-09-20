using System.Net.WebSockets;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApp.Services
{
    public class ElectronMessageHandler : WebSocketHandler
    {
        public async Task SendActionAsync(ElectronAction action)
        {
            var serializedObject = JsonConvert.SerializeObject(action);

            await SendMessageAsync(serializedObject);
        }

        public override Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            return Task.CompletedTask;
        }
    }
}