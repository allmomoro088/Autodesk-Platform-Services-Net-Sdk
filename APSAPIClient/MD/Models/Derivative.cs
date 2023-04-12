using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class Derivative
    {
        public string Name { get; set; }
        public string HasThumbnail { get; set; }
        public string Status { get; set; }
        public string Progress { get; set; }
        public string OutputType { get; set; }
        public List<DerivativeChild> Children { get; set; }
    }
}
