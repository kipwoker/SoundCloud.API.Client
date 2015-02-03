using System;
using System.Collections.Generic;
using System.Linq;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Client.Helpers.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Network;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Client
{
    internal class SoundCloudRawClient : ISoundCloudRawClient
    {
        public SCAccessToken AccessToken { get; set; }
        public SCCredentials Credentials { get; private set; }

        private readonly IUriBuilderFactory uriBuilderFactory;
        private readonly IWebGateway webGateway;
        private readonly ISerializer serializer;

        internal SoundCloudRawClient(SCCredentials credentials, IUriBuilderFactory uriBuilderFactory, IWebGateway webGateway, ISerializer serializer)
        {
            Credentials = credentials;
            this.uriBuilderFactory = uriBuilderFactory;
            this.webGateway = webGateway;
            this.serializer = serializer;
        }

        public T Request<T>(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters, byte[] body, bool isRequiredAuth, string responseType, Domain domain)
            where T : class 
        {
            var response = GetResponse(domain, apiPrefix, command, method, parameters, body, isRequiredAuth, responseType);
            return typeof(T) == typeof(string) ? (response as T) : serializer.Deserialize<T>(response);
        }

        public void Request(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters, byte[] body, bool isRequiredAuth, Domain domain)
        {
            GetResponse(domain, apiPrefix, command, method, parameters, body, isRequiredAuth, string.Empty);
        }

        public Uri BuildUri(string command, Dictionary<string, object> parameters, bool isRequiredAuth, string responseType, Domain domain)
        {
            return CreateUriBuilder(domain, string.Empty, command, isRequiredAuth, responseType).AddQueryParameters(parameters).Build();
        }

        public T Upload<T>(string prefix, string command, Dictionary<string, object> parameters, bool isRequiredAuth, string responseType, Domain domain, params File[] files)
        {
            var uriBuilder = CreateUriBuilder(domain, prefix, command, isRequiredAuth, responseType);
            var response = webGateway.Upload(uriBuilder, parameters, files);
            return serializer.Deserialize<T>(response);
        }

        private string GetResponse(Domain domain, string prefix, string command, HttpMethod method, Dictionary<string, object> parameters, byte[] body, bool isRequiredAuth, string responseType)
        {
            var uriBuilder = CreateUriBuilder(domain, prefix, command, isRequiredAuth, responseType);
            var response = webGateway.Request(uriBuilder, method, parameters, body);
            return response;
        }

        private static string SetResponseType(string command, string responseType)
        {
            return string.IsNullOrEmpty(responseType)
                 ? command
                 : string.Format("{0}.{1}", command, responseType);
        }

        private IUriBuilder CreateUriBuilder(Domain domain, string prefix, string command, bool isRequiredAuth, string responseType)
        {
            var fullCommand = string.Join("/", new[] { domain.GetParameterName(), prefix, command }.Where(x => !string.IsNullOrEmpty(x)).Select(x => x.TrimEnd('/')));
            var fullCommandWithResponse = string.IsNullOrEmpty(prefix) && string.IsNullOrEmpty(command) ? fullCommand : SetResponseType(fullCommand, responseType);

            var uriBuilder = uriBuilderFactory.Create(fullCommandWithResponse);

            if (isRequiredAuth)
            {
                uriBuilder = AccessToken == null
                           ? uriBuilder.AddClientId(Credentials.ClientId)
                           : uriBuilder.AddToken(AccessToken.AccessToken);
            }
            else if (!string.IsNullOrEmpty(Credentials.ClientId))
            {
                uriBuilder.AddClientId(Credentials.ClientId);
            }

            return uriBuilder;
        }
    }
}