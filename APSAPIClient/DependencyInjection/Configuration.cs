using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Base;
using Autodesk.PlatformServices.DM;
using Autodesk.PlatformServices.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Autodesk.PlatformServices.DependencyInjection
{
    public static class Configuration
    {
        public static bool UseUserContext;

        /// <summary>
        /// Adds to <see cref="IServiceCollection"/> the APIs to be injected in the application
        /// </summary>
        /// <typeparam name="T">The API type. Needs to inherit from ApiBase</typeparam>
        /// <param name="services"></param>
        /// <returns>This <see cref="IServiceCollection"/> instance</returns>
        public static IServiceCollection AddAPSService<T>(this IServiceCollection services) where T : ApiBase
        {
            services.AddTransient<T>();
            return services;
        }

        /// <summary>
        /// Adds to <see cref="IServiceCollection"/> all DataManagement APIs and its dependencies to be injected in the application
        /// <para>HubsApi, ProjectsApi, FoldersApi, ItemsApi, VersionsApi, ObjectsApi and BucketsApi</para>
        /// </summary>
        /// <param name="services">This</param>
        /// <param name="clientCredentials">The instance of <see cref="ClientCredentials"/>, an abstraction of Autodesk Platform Services App Credentials</param>
        /// <param name="scopeImplementation">A implementation of <see cref="IScope"/> that reflects the scopes needed in this application</param>
        /// <param name="i2loImplementation">The implementation of <see cref="I2LOStorage"/> for storing Two Legged Authentication tokens</param>
        /// <param name="i3loImplementation">The implementation of <see cref="I3LOStorage"/> for storing Three Legged Autehntication tokens</param>
        /// <param name="useUserContext">If user context should be present on every request possible</param>
        /// <returns>This <see cref="IServiceCollection"/> instance</returns>
        public static IServiceCollection AddDataManagement(this IServiceCollection services,
                                                           ClientCredentials clientCredentials,
                                                           Type scopeImplementation,
                                                           Type i2loImplementation = null,
                                                           Type i3loImplementation = null,
                                                           bool useUserContext = false)
        {
            //Client Credentials
            services
                .AddSingleton(clientCredentials);

            //Auth
            UseUserContext = useUserContext;

            if (i2loImplementation != null)
                services.AddTransient(typeof(I2LOStorage), i2loImplementation);
            if (i3loImplementation != null)
                services.AddTransient(typeof(I3LOStorage), i3loImplementation);
            services.AddSingleton(typeof(IScope), scopeImplementation)
                .AddTransient<AuthClient>()
                .AddTransient<Authenticator>(s =>
                {
                    var a = s.GetRequiredService<AuthClient>();
                    var sc = s.GetRequiredService<IScope>();
                    var i2 = i2loImplementation != null ? s.GetRequiredService<I2LOStorage>() : null;
                    var i3 = i3loImplementation != null ? s.GetRequiredService<I3LOStorage>() : null;
                    return new Authenticator(clientCredentials, a, sc, i2, i3);
                })

            //DM Services
                .AddTransient<DMDataBuilder>()
                .AddTransient<DMRequestBuilder>()
                .AddTransient<DMClient>()
                .AddTransient<HubsApi>(s =>
                {
                    var c = s.GetRequiredService<DMClient>();
                    var r = s.GetRequiredService<DMRequestBuilder>();
                    return new HubsApi(c, r);
                })
                .AddTransient<ProjectsApi>(s =>
                {
                    var c = s.GetRequiredService<DMClient>();
                    var r = s.GetRequiredService<DMRequestBuilder>();
                    var d = s.GetRequiredService<DMDataBuilder>();

                    return new ProjectsApi(c, r, d);
                })
                .AddTransient<FoldersApi>(s =>
                {
                    var c = s.GetRequiredService<DMClient>();
                    var r = s.GetRequiredService<DMRequestBuilder>();
                    var d = s.GetRequiredService<DMDataBuilder>();

                    return new FoldersApi(c, r, d);
                })
                .AddTransient<ItemsApi>(s =>
                {
                    var c = s.GetRequiredService<DMClient>();
                    var r = s.GetRequiredService<DMRequestBuilder>();
                    var d = s.GetRequiredService<DMDataBuilder>();
                    
                    return new ItemsApi(c, r, d);
                })
                .AddTransient<BucketsApi>(s =>
                {
                    var c = s.GetRequiredService<DMClient>();
                    var r = s.GetRequiredService<DMRequestBuilder>();
                    var d = s.GetRequiredService<DMDataBuilder>();

                    return new BucketsApi(c, r, d);
                })
                .AddTransient<ObjectsApi>(s =>
                {
                    var c = s.GetRequiredService<DMClient>();
                    var r = s.GetRequiredService<DMRequestBuilder>();
                    var d = s.GetRequiredService<DMDataBuilder>();

                    return new ObjectsApi(c, r, d);
                })
                .AddTransient<IDataManagementAPI, DataManagementAPI>();

            return services;
        }

        /// <summary>
        /// Reads the ClientCredentials from <see cref="IConfiguration"/>. Property names are APS:ClientId, APS:ClientSecret, APS:RedirectUri
        /// </summary>
        /// <param name="configuration">This</param>
        /// <returns>The <see cref="ClientCredentials"/> instance matching the credentials found in <see cref="IConfiguration"/></returns>
        public static ClientCredentials GetAPSClientCredentials(this IConfiguration configuration)
        {
            return new ClientCredentials(
                    configuration["APS:ClientId"],
                    configuration["APS:ClientSecret"],
                    configuration["APS:RedirectUri"]);
        }

        /// <summary>
        /// Reads the ClientCredentials from <see cref="Environment"/> variables. Variables names are APS_ClientId, APS_ClientSecret, APS_RedirectUri
        /// </summary>
        /// <returns>The <see cref="ClientCredentials"/> instance matching the credentials found in <see cref="Environment"/> variables</returns>
        public static ClientCredentials GetAPSClientCredentials()
        {
            return new ClientCredentials(
                Environment.GetEnvironmentVariable("APS_ClientId"),
                Environment.GetEnvironmentVariable("APS_ClientSecret"),
                Environment.GetEnvironmentVariable("APS_RedirectUri"));
        }

        /// <summary>
        /// Under development, shouldn't be used yet
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBIM360(this IServiceCollection services)
        {
            return services;
        }
    }
}
