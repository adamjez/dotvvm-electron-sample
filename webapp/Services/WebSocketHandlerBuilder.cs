using System.Net.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Services
{
    public static class WebSocketHandlerBuilder
    {
        public static void UseWebSocketHandler(this IApplicationBuilder app, string path)
        {
            var handler = app.ApplicationServices.GetService<WebSocketHandler>();

            app.Map(path, (builder) =>
            {
                builder.UseMiddleware<WebSocketManagerMiddleware>();
            });
        }

        // private static void UseWebSocketMiddleware(this IApplicationBuilder app)
        // {
        //     if (context.WebSockets.IsWebSocketRequest)
        //     {
        //         WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();

        //         await handler.Handle(webSocket);
        //     }
        //     else
        //     {
        //         context.Response.StatusCode = 400;
        //     })
        // }
    }
}