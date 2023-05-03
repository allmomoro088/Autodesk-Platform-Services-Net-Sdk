using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Text;

namespace Autodesk.PlatformServices.ACC
{
    public class IssuesApi : ApiBase
    {
        ACCClient Client;
        ACCRequestBuilder _requestBuilder;

        public IssuesApi(ClientCredentials cc) : base (cc, new DataScope())
        {
            Client = new ACCClient(Authenticator);
        }

        public IssuesApi(ACCClient client, ACCRequestBuilder requestBuilder)
        {
            Client = client;
            _requestBuilder = requestBuilder;
        }

        public IEnumerable<Issue> GetIssues(string projectId)
        {
            var r = _requestBuilder
                .UseGetIssues(projectId)
                .Build();

            var response = Client.Execute<IssuesPagination>(r);
            return response.Results;
        }
    }
}
