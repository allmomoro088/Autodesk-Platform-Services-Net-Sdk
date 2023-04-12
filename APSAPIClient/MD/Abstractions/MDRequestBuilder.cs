using Autodesk.PlatformServices.Base;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class MDRequestBuilder : RequestBuilderBase
    {
        //Jobs Api
        internal MDRequestBuilder UsePostJob(string data)
        {
            Resource = "modelderivative/v2/regions/eu/designdata/job";
            Method = Method.Post;
            Headers.Add("Content-Type", "application/json");
            Parameters.Add(("application/json", data, ParameterType.RequestBody));
            return this;
        }

        internal MDRequestBuilder UsePostJobReferences(string urn, string data, bool isBase64 = false)
        {
            if (isBase64)
                Resource = $"modelderivative/v2/designdata/{urn}/references";
            else
                Resource = $"modelderivative/v2/designdata/{Convert.ToBase64String(Encoding.UTF8.GetBytes(urn))}/references";

            Method = Method.Post;
            Headers.Add("Content-Type", "application/json");
            Parameters.Add(("application/json", data, ParameterType.RequestBody));
            return this;
        }

        //Manifest Api
        internal MDRequestBuilder UseGetManifest(string urn, bool isBase64 = false)
        {
            if (isBase64)
                Resource = $"modelderivative/v2/designdata/{urn}/manifest";
            else
                Resource = $"modelderivative/v2/designdata/{Convert.ToBase64String(Encoding.UTF8.GetBytes(urn))}/manifest";

            Method = Method.Get;
            return this;
        }

        internal MDRequestBuilder UseDeleteManifest(string urn, bool isBase64 = false)
        {
            if (isBase64)
                Resource = $"modelderivative/v2/designdata/{urn}/manifest";
            else
                Resource = $"modelderivative/v2/designdata/{Convert.ToBase64String(Encoding.UTF8.GetBytes(urn))}/manifest";

            Method = Method.Delete;
            return this;
        }


        public override RestRequest Build()
        {
            var r = new RestRequest(Resource, Method);
            Headers.Select(x =>
                r.AddOrUpdateHeader(x.Key, x.Value)
            );
            Parameters.Select(x =>
                r.AddParameter(x.Item1, x.Item2, x.Item3.Value)
            );

            return r;
        }
    }
}
