using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Base;
using Autodesk.PlatformServices.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// Executes requests for Data Management APIs
    /// </summary>
    public class DMClient : BaseClient
    {
        private Authenticator _auth;

        /// <summary>
        /// Creates an instance of <see cref="DMClient"/> with specified Authenticator
        /// </summary>
        /// <param name="auth">Authenticator instance to be used in requests</param>
        public DMClient(Authenticator auth)
        {
            _auth = auth;
        }

        /// <summary>
        /// Executes the request and handles its response with custom parsing and custom error handling
        /// </summary>
        /// <typeparam name="T">The type which the response should be mapped to</typeparam>
        /// <param name="r">The request to be executed</param>
        /// <param name="customParsing">The custom function that receives the json body of the response and maps to T type</param>
        /// <param name="customErrHandling">The custom action to handle errors</param>
        /// <returns>Returns the response mapped to T type according to customParsing func</returns>
        public override T Execute<T>(RestRequest r,
                                       Func<string, T> customParsing = null,
                                       Action<RestResponse> customErrHandling = null)
        {
            r = SetToken(r);
            return base.Execute(r, customParsing, customErrHandling);
        }

        /// <summary>
        /// Executes the request and handles its response
        /// </summary>
        /// <typeparam name="T">The type which the response should be mapped to</typeparam>
        /// <param name="r">The request to be executed</param>
        /// <returns>Returns the response mapped to T type</returns>
        public override T Execute<T>(RestRequest r)
        {
            //Making request
            r = SetToken(r);

            return base.Execute<T>(r);
        }

        /// <summary>
        /// Executes the request and handles its response and custom error handling
        /// </summary>
        /// <param name="r">The request to be executed</param>
        /// <param name="customErrHandling">The custom action to handle errors</param>
        public override void Execute(RestRequest r,
                                     Action<RestResponse> customErrHandling = null)
        {
            r = SetToken(r);

            base.Execute(r, customErrHandling);
        }

        /// <summary>
        /// Executes requests that their responses are wrapped in DMApiResponseBase and handles its response with custom parsing and custom error handling
        /// </summary>
        /// <typeparam name="T">The type which the response should be mapped to</typeparam>
        /// <param name="r">The request to be executed</param>
        /// <param name="customParsing">The custom function that receives the json body of the response and maps to T type</param>
        /// <param name="customErrHandling">The custom action to handle errors</param>
        /// <returns>Returns the response mapped to T type according to customParsing func</returns>
        public virtual T ExecuteDMApi<T>(RestRequest r,
                                         Func<string, DMApiResponseBase<T>> customParsing = null,
                                         Action<RestResponse> customErrHandling = null)
        {
            //Making request
            r = SetToken(r);
            var response = base.Execute<DMApiResponseBase<T>>(r, customParsing, customErrHandling);

            return response.Data;
        }

        /// <summary>
        /// Executes get folder contents request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="r"></param>
        /// <returns></returns>
        public virtual T Execute<T, U, V, W>(RestRequest r) where T : Tuple<List<U>, List<V>, List<W>>, new()
        {
            r = SetToken(r);
            var response = Client.Execute(r);

            ErrorHandling(response);
            JObject j = JObject.Parse(response.Content);
            var l = new T();
            foreach (var d in j.SelectToken("data"))
            {
                var t = d.SelectToken("type").ToString().ToLower();
                if (typeof(U).Name.ToLower() == t.Substring(0, t.Length - 1))
                    l.Item1.Add(JsonConvert.DeserializeObject<U>(d.ToString()));
                else
                    l.Item2.Add(JsonConvert.DeserializeObject<V>(d.ToString()));
            }
            if (j.SelectToken("included") != null)
                foreach (var i in j.SelectToken("included"))
                {
                    var t = i.SelectToken("type").ToString().ToLower();
                    if (typeof(W).Name.ToLower() == t.Substring(0, t.Length - 1))
                        l.Item3.Add(JsonConvert.DeserializeObject<W>(i.ToString()));
                }
            return l;
        }

        /// <summary>
        /// Executes requests that its responses are paginated
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="r"></param>
        /// <returns></returns>
        public virtual T ExecutePaginated<T, U>(RestRequest r) where T : List<U>, new()
        {
            T result = new T();
            DMApiResponsePaginated<T> response = null;
            do //While there's data to be pulled
            {
                //Making requests
                r = SetToken(r);
                response = base.Execute<DMApiResponsePaginated<T>>(r);
            
                //Adding output to results
                result.AddRange(response.Data);
            } while (!string.IsNullOrWhiteSpace(response.Links?.Next?.Href) && response.Data.Count > 0);

            return result;
        }

        /// <summary>
        /// Sets a custom <see cref="Authenticator"/> to be used in requests
        /// </summary>
        /// <param name="authenticator">The <see cref="Authenticator"/> instance to be used</param>
        public void SetAuthenticator(Authenticator authenticator)
        {
            _auth = authenticator;
        }

        /// <summary>
        /// Sets the Authorization header on the request according to Configuration
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private RestRequest SetToken(RestRequest r)
        {
            if (Configuration.UseUserContext)
                r.AddOrUpdateHeader("Authorization", $"Bearer {_auth.ThreeLeggedToken.Access_Token}");
            else
                r.AddOrUpdateHeader("Authorization", $"Bearer {_auth.TwoLeggedToken.Access_Token}");
            return r;
        }
    }
}
