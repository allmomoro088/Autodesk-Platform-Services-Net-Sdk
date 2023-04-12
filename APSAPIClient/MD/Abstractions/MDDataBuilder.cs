using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class MDDataBuilder
    {
        object _data;

        internal MDDataBuilder UsePostJob(string urn,
                           bool compressedUrn,
                           string rootFileName,
                           string region,
                           string format,
                           List<string> views = null,
                           Dictionary<string, object> advanced = null)
        {
            _data = new JobCreation
            {
                Input = new JobCreationInput
                {
                    Urn = urn,
                    CompressedUrn = compressedUrn,
                    RootFileName = rootFileName
                },
                Output = new JobOutput
                {
                    Destination = new OutputDestination
                    {
                        Region = region
                    },
                    Formats = new List<OutputFormat>
                    {
                        new OutputFormat
                        {
                            Type = format,
                            Views = views,
                            Advanced = advanced
                        }
                    }
                }
            };
            return this;
        }

        internal string Build(Func<object, string> customSerialization = null)
        {
            if (customSerialization == null)
            {
                return JsonConvert.SerializeObject(_data);
            }
            else
            {
                var s = customSerialization(_data);
                return s.ToString();
            }
        }
    }
}
