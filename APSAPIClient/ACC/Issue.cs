using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace Autodesk.PlatformServices.ACC
{
    public class Issue
    {
        public string Id { get; set; }
        public string ContainerId { get; set; }
        public bool Deleted { get; set; }
        public int DisplayId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SnapshotUrn { get; set; }
        public string IssueTypeId { get; set; }
        public string IssueSubtypeId { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public string AssingedToType { get; set; }
        public string DueDate { get; set; }
        public string StartData { get; set; }
        public string LocationId { get; set; }
        public string LocationDetails { get; set; }
        public List<IssueLinkedDocument> LinkedDocuments { get; set; }
        public List<string> Links { get; set; }
        public string OwnerId { get; set; }
        public string RootCouseId { get; set; }
        public object OfficialResponse { get; set; }
        public string IssueTemplateId { get; set; }
        public List<string> PermittedStatuses { get; set; }
        public List<string> PermittedAttributes { get; set; }
        public bool Published { get; set; }
        public object PermittedActions { get; set; }
        public int CommentCount { get; set; }
        public string AttachmentCount { get; set; }
        public string OpenedBy { get; set; }
        public string OpenedAt { get; set; }
        public string ClosedBy{ get; set; }
        public string ClosedAt { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public List<string> Watchers { get; set; }
        public List<IssueCustomAttribute> CustomAttributes { get; set; }
        public IssueGpsCoordinates GPSCoordinates { get; set; }
    }
}
