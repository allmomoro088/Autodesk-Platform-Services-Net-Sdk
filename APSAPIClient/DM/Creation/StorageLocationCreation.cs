using Autodesk.PlatformServices.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class StorageLocationCreation : CreationDataBase
    {
        [JsonProperty("data")]
        public StorageLocationCreationData Data { get; set; }
    }
}
