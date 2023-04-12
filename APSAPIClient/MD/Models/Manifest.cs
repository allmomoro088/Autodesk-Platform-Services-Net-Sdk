using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class Manifest
    {
        public string HasThumbnail { get; set; }
        public string Status { get; set; }
        public string Progress { get; set; }
        public string Region { get; set; }
        public string Urn { get; set; }
        public List<Derivative> Derivatives { get; set; }
    }
}
