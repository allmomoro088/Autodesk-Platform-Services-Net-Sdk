using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class JobCreationReference
    {
        public string Urn { get; set; }
        public string RelativePath { get; set; }
        public string FileName{ get; set; }
        public List<JobCreationReference> References { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}
