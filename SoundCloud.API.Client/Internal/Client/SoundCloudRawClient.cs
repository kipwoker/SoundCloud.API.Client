using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Client.Helpers.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Network.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Client
{
    internal class SoundCloudRawClient : ISoundCloudRawClient
    {
        public SCAccessToken AccessToken { get; set; }
        public SCCredentials Credentials { get; private set; }
        private readonly bool enableGZip;

        private readonly IUriBuilderFactory uriBuilderFactory;
        private readonly IWebGatewayFactory webGatewayFactory;
        private readonly ISerializer serializer;

        internal SoundCloudRawClient(SCCredentials credentials, bool enableGZip, IUriBuilderFactory uriBuilderFactory, IWebGatewayFactory webGatewayFactory, ISerializer serializer)
        {
            Credentials  = credentials;
            this.enableGZip = enableGZip;
            this.uriBuilderFactory = uriBuilderFactory;
            this.webGatewayFactory = webGatewayFactory;
            this.serializer = serializer;
        }

        public T RequestApi<T>(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters, bool isRequiredAuth, string responseType)
        {
            var response = GetResponse(apiPrefix, command, method, parameters, isRequiredAuth, responseType);
            return serializer.Deserialize<T>(response);
        }
        
        public void RequestApi(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters = null, bool isRequiredAuth = true)
        {
            GetResponse(apiPrefix, command, method, parameters, isRequiredAuth, string.Empty);
        }

        public Uri BuildUri(string prefix, string command, Dictionary<string, object> parameters, bool isRequiredAuth, string responseType)
        {
            var fullCommand = string.Format("{0}/{1}", prefix.TrimEnd('/'), command).Trim('/');
            var fullCommandWithResponse = SetResponseType(fullCommand, responseType);

            var uriBuilder = uriBuilderFactory.Create(fullCommandWithResponse).AddQueryParameters(parameters);

            if (isRequiredAuth)
            {
                uriBuilder = AccessToken == null
                           ? uriBuilder.AddClientId(Credentials.ClientId)
                           : uriBuilder.AddToken(AccessToken.AccessToken);
            }

            return uriBuilder.Build();
        }

        private string GetResponse(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters, bool isRequiredAuth, string responseType)
        {
            var uri = BuildUri(Settings.ApiSoundCloudComPrefix + apiPrefix, command, parameters, isRequiredAuth, responseType);
            var webGateway = webGatewayFactory.Create(enableGZip);

            var response = webGateway.Request(uri, method);
            return response;
        }

        private static string SetResponseType(string command, string responseType)
        {
            return string.IsNullOrEmpty(responseType)
                 ? command
                 : string.Format("{0}.{1}", command, responseType);
        }
    }
}