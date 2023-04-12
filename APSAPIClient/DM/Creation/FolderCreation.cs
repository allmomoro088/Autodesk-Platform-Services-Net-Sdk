using Autodesk.PlatformServices.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class FolderCreation : CreationDataBase
    {
        [JsonProperty("data")]
        public FolderCreationData Data { get; set; }
    }
}
