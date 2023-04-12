using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class DerivativeChild
    {
        public string Guid { get; set; }
        public string Type { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Progress { get; set; }
        public string HasThumbnail { get; set; }
        public List<DerivativeChildInfo> Children { get; set; }
    }
}
