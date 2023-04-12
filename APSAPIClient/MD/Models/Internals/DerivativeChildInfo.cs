using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class DerivativeChildInfo
    {
        public string Guid { get; set; }
        public string Type { get; set; }
        public string Progress { get; set; }
        public string Role { get; set; }
        public string Mime { get; set; }
        public List<int> Resolution { get; set; }
        public string Urn { get; set; }
    }
}
