using System;

namespace WebApp.Services
{
    public class ElectronAction
    {
        public string Method { get; set; }
        public string Module { get; set; }
        public object[] Arguments { get; set; } = Array.Empty<object>();
    }
}
