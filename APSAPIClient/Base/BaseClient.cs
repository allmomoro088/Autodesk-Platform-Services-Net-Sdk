using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Autodesk.PlatformServices.Base
{
    /// <summary>
    /// A base class for clients. Used to execute requests and treat responses
    /// </summary>
    public abstract class BaseClient
    {
        public RestClient Client = new RestClient("https://developer.api.autodesk.com/");

        /// <summary>
        /// Executes the request and handles its response
        /// </summary>
        /// <typeparam name="T">The type which the response should be mapped to</typeparam>
        /// <param name="r">The request to be executed</param>
        /// <returns>Returns the response mapped to T type</returns>
        public virtual T Execute<T>(RestRequest r)
        {
            var response = Client.Execute<T>(r);

            ErrorHandling(response);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Executes the request and handles its response with custom parsing and custom error handling
        /// </summary>
        /// <typeparam name="T">The type which the response should be mapped to</typeparam>
        /// <param name="r">The request to be executed</param>
        /// <param name="customParsing">The custom function that receives the json body of the response and maps to T type</param>
        /// <param name="customErrHandling">The custom action to handle errors</param>
        /// <returns>Returns the response mapped to T type according to customParsing func</returns>
        public virtual T Execute<T>(RestRequest r,
                                      Func<string, T> customParsing = null,
                                      Action<RestResponse> customErrHandling = null)
        {
            var response = Client.Execute(r);

            if (customErrHandling != null)
                customErrHandling(response);
            else
                ErrorHandling(response);

            if (customParsing != null)
                return customParsing(response.Content);
            else
                return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Executes the request and handles its response and custom error handling
        /// </summary>
        /// <param name="r">The request to be executed</param>
        /// <param name="customErrHandling">The custom action to handle errors</param>
        public virtual void Execute(RestRequest r,
                                    Action<RestResponse> customErrHandling = null)
        {
            var response = Client.Execute(r);

            if (customErrHandling != null)
                customErrHandling(response);
            else
                ErrorHandling(response);
        }

        /// <summary>
        /// Base error handling. Throws Exception if the status code is not OK (200)
        /// </summary>
        /// <param name="r">The response obtained</param>
        /// <exception cref="Exception">Exception containing the response from the API</exception>
        public virtual void ErrorHandling(RestResponse r)
        {
            if (r.StatusCode != HttpStatusCode.OK)
                throw new Exception(r.Content);
        }
    }
}
