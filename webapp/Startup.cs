﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApp.Services;
using WebApp.Services.Modules;
using WebApp.ViewModels;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
            services.AddAuthorization();
            services.AddWebEncoders();

            services.AddDotVVM(options =>
            {
                options.AddDefaultTempStorages("Temp");
            });
            services.AddTransient<ElectronService>();
            services.AddTransient<DialogModule>();
            services.AddTransient<AppModule>();
            services.AddTransient<ShellModule>();
             services.AddTransient<MenuModule>();
            services.AddTransient<ClipboardModule>();
            services.AddTransient<MainWindowModule>();

            services.AddTransient<DefaultViewModel>();

            services.AddSingleton<ElectronMessageHandler>();
            services.AddSingleton<WebSocketHandler, ElectronMessageHandler>(c => c.GetService<ElectronMessageHandler>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseWebSockets();

            app.UseWebSocketHandler("/ws");

            // use DotVVM
            var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);

            // use static files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(env.WebRootPath)
            });
        }
    }
}
