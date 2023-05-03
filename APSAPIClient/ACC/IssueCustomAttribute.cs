using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Autodesk.PlatformServices.ACC
{
    public class IssueCustomAttribute
    {
        public string AttributeDefinitionId { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
    }
}
