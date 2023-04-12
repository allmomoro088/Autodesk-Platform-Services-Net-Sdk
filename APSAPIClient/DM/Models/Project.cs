using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class Project
    {
        public string Id { get; set; }
        public ProjectAttributes Attributes { get; set; }
        public LinksSelfWebView Links { get; set; }
        public ProjectRelationships Relationships { get; set; }
    }
}
