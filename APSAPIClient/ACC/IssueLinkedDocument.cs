using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.ACC
{
    public class IssueLinkedDocument
    {
        public string Type { get; set; }
        public string Urn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedAtVersion { get; set; }
        public string ClosedBy { get; set; }
        public string ClosedAt { get; set; }
        public string ClosetAtVersion { get; set; }
        public IssueLinkedDocumentDetails Details { get; set; }
    }
}
