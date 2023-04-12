using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class Version
    {
        public string Id { get; set; }
        public VersionAttributes Attributes { get; set; }
        public VersionExtension Extension { get; set; }
        public LinksSelfWebView Links { get; set; }
        public VersionRelationships Relationships { get; set; }
    }
}
