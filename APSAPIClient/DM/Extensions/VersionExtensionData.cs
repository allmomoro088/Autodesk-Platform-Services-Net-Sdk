using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class VersionExtensionData
    {
        public int? ModelVersion { get; set; }
        public string ProjectGuid { get; set; }
        public string OriginalItemUrn { get; set; }
        public bool? IsCompositeDesign { get; set; }
        public string ModelType { get; set; }
        public string MimeType { get; set; }
        public string ModelGuid { get; set; }
        public string ProcessState { get; set; }
        public string ExtractionState { get; set; }
        public string SplittingState { get; set; }
        public string ReviewState { get; set; }
        public string ReviewDisplayLabel { get; set; }
        public string SourceFileName { get; set; }
        public string ConformingStatus { get; set; }
    }
}
