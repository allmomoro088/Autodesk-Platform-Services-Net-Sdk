using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Base;
using Autodesk.PlatformServices.DM.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// A collection of Data Management Hubs APIs in Autodesk Platform Services
    /// </summary>
    public class HubsApi : DMApi
    {
        DMRequestBuilder _requestBuilder;

        /// <summary>
        /// Creates an instance of <see cref="HubsApi"/>
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        public HubsApi(ClientCredentials cc) : base (cc, new DataManagementScope())
        {
            Client = new DMClient(Authenticator);
            _requestBuilder = new DMRequestBuilder();
        }
        /// <summary>
        /// Creates an instance of <see cref="HubsApi"/>. Mainly used by Dependency Injection
        /// </summary>
        /// <param name="dmClient">The DMClient to be used on executing requests</param>
        /// <param name="requestBuilder">The DM request builder to be used</param>
        public HubsApi(DMClient dmClient, DMRequestBuilder requestBuilder)
        {
            Client = dmClient;
            _requestBuilder = requestBuilder;
        }

        /// <summary>
        /// Gets all the available hubs from Autodesk Platform Services
        /// </summary>
        /// <returns>A list of <see cref="Hub"/> available</returns>
        public IEnumerable<Hub> GetHubs()
        {
            var r = _requestBuilder
                .UseGetHubs()
                .Build();

            var hubs = Client.ExecuteDMApi<List<Hub>>(r);
            return hubs;
        }

        /// <summary>
        /// Gets a hub from Autodesk Platform Services by its id 
        /// </summary>
        /// <param name="hubId">The hub id</param>
        /// <returns>The instance of <see cref="Hub"/> for the provided id</returns>
        public Hub GetHub(string hubId)
        {
            var r = _requestBuilder
                .UseGetHub(hubId)
                .Build();

            return Client.ExecuteDMApi<Hub>(r);
        }
    }
}
