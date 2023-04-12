using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class OutputFormat
    {
        public string Type { get; set; }
        public List<string> Views { get; set; }
        public Dictionary<string, object> Advanced { get; set; }
    }
}
