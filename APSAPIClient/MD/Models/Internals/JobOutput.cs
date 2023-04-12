using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class JobOutput
    {
        public OutputDestination Destination { get; set; }
        public List<OutputFormat> Formats { get; set; }
    }
}
