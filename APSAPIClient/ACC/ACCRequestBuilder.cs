using Autodesk.PlatformServices.Base;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.ACC
{
    public class ACCRequestBuilder : RequestBuilderBase
    {
        public virtual ACCRequestBuilder UseGetIssues(string projectId)
        {
            throw new NotImplementedException();
        }
        public override RestRequest Build()
        {
            throw new NotImplementedException();
        }
    }
}
