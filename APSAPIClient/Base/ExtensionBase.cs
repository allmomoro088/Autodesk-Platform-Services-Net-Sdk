using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Base
{
    public class ExtensionBase
    {
        public string Type { get; set; }
        public string Version { get; set; } = "1.0";
        public HrefRelation Schema { get; set; }
    }
}
