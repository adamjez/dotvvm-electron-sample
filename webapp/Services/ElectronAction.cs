using System;

namespace WebApp.Services
{
    public class ElectronAction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Method { get; set; }
        public string Module { get; set; }
        public object[] Arguments { get; set; } = Array.Empty<object>();
    }
}
