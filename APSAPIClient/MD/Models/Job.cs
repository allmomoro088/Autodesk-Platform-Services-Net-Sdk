using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class Job
    {
        public string Result { get; set; }
        public string Urn { get; set; }
        public AcceptedJobs AcceptedJobs { get; set; }
    }
}
