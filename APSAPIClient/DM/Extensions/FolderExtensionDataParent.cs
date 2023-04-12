using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class FolderExtensionDataParent
    {
        public string Urn { get; set; }
        public bool? IsRoot { get; set; }
        public string Title { get; set; }
        public string ParentUrn { get; set; }
    }
}
