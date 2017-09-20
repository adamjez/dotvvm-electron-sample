using System;
using Newtonsoft.Json.Linq;

namespace WebApp.Services
{
    public class ElectronResponse
    {
        public Guid ActionId { get; set; }
        public JToken Result { get; set; }
        public ElectronResponseType Type { get; set; }
    }
}
