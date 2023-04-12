using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class FolderExtensionData
    {
        public List<string> AllowedTypes { get; set; }
        public List<string> VisibleTypes { get; set; }
        public bool? IsRoot { get; set; }
        public string FolderType { get; set; }
        public List<FolderExtensionDataParent> FolderParents { get; set; }
    }
}
