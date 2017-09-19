using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApp.Services
{
    public class WebSocketHandler
    {
        private WebSocket _currentWebSocket;
        private readonly ILogger<WebSocketHandler> _logger;

        public WebSocketHandler(ILogger<WebSocketHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(WebSocket webSocket)
        {
            _logger.LogError(webSocket.State.ToString());


            if(webSocket.State == WebSocketState.Open)
            {
                _currentWebSocket = webSocket;
            }
            else
            {
                _currentWebSocket = null;
            }

            // var buffer = new byte[1024 * 4];
            // WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);


            // // await Send("Test");
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        public async Task Send(string message)
        {
            if(_currentWebSocket == null || _currentWebSocket.State != WebSocketState.Open)
            {
                return;
            }

            var encodedMessage = System.Text.Encoding.UTF8.GetBytes(message);
            var buffer = new ArraySegment<byte>(encodedMessage, 0, encodedMessage.Length);
            await _currentWebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}