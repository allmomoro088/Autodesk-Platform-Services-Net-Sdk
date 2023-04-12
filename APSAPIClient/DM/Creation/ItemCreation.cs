using Autodesk.PlatformServices.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class ItemCreation : CreationDataBase
    {
        [JsonProperty("data")]
        public ItemCreationData Data { get; set; }
        [JsonProperty("included")]
        public List<ItemCreationVersion> Included { get; set; }
    }
}
