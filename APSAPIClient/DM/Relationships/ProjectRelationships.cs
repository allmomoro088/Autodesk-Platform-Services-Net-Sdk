using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class ProjectRelationships
    {
        public DMRelationshipWithLinksRelated Hub { get; set; }
        public DMRelationshipWithMeta RootFolder { get; set; }
        public DMRelationshipWithLinksRelated TopFolders { get; set; }
        public DMRelationshipWithMeta Issues { get; set; }
        public DMRelationshipWithMeta Submittals { get; set; }
        public DMRelationshipWithMeta Rfis { get; set; }
        public DMRelationshipWithMeta Markups { get; set; }
        public DMRelationshipWithMeta Checklists { get; set; }
        public DMRelationshipWithMeta Cost { get; set; }
        public DMRelationshipWithMeta Locations { get; set; }
    }
}
