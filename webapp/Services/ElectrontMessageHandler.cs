using System.Net.WebSockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApp.Services
{
    public class ElectronMessageHandler : WebSocketHandler
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public ElectronMessageHandler()
        {
            _serializerSettings = new JsonSerializerSettings();
            _serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            _serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            _serializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
        }

        public async Task SendActionAsync(ElectronAction action)
        {
            var serializedObject = JsonConvert.SerializeObject(action, _serializerSettings);

            await SendMessageAsync(serializedObject);
        }

        public override Task ReceiveAsync(WebSocketReceiveResult result, byte[] buffer)
        {
            return Task.CompletedTask;
        }
    }
}