using System.Collections.Generic;

namespace WebApp.Services.Modules
{
    public class FileFilter
    {
        public string Name { get; set; }
        public IEnumerable<string> Extensions { get; set; }
    }
}