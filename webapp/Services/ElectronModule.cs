using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApp.Helpers;

namespace WebApp.Services
{
    public abstract class ElectronModule
    {
        private ElectronMessageHandler _handler;

        public ElectronModule(ElectronMessageHandler handler)
        {
            _handler = handler;
        }

        protected async Task SendActionAsync([CallerMemberName] string methodName = null, params object[] arguments)
        {
            if (methodName == null)
            {
                throw new ArgumentException(nameof(methodName));
            }

            var normalizedModuleName = Regex.Replace(this.GetType().Name, @"Module$", string.Empty).FirstCharacterToLower();
            var normalizedMethodName = Regex.Replace(methodName, @"Async$", string.Empty).FirstCharacterToLower();

            var action = new ElectronAction
            {
                Module = normalizedModuleName,
                Method = normalizedMethodName,
                Arguments = arguments
            };

            await _handler.SendActionAsync(action);
        }
    }
}