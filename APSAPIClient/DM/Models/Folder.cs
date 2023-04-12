using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class Folder
    {
        public string Id { get; set; }
        public FolderAttributes Attributes { get; set; }
        public LinksSelfWebView Links { get; set; }
        public FolderRelationships Relationships { get; set; }
    }
}
