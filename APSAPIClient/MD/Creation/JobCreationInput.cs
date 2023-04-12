using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    internal class JobCreationInput
    {
        public string Urn { get; set; }
        public bool? CompressedUrn { get; set; }
        public string RootFileName { get; set; }
    }
}
