using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class Hub
    {
        public string Id { get; set; }
        public HubAttributes Attributes { get; set; }
        public LinksSelf Links { get; set; }
        public HubRelationships Relationships { get; set; }
    }
}
