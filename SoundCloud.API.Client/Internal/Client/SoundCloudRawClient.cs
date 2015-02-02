using System;
using System.Collections.Generic;
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
            Credentials  = credentials;
            this.uriBuilderFactory = uriBuilderFactory;
            this.webGateway = webGateway;
            this.serializer = serializer;
        }

        public T RequestApi<T>(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters, byte[] body, bool isRequiredAuth, string responseType)
        {
            var response = GetResponse(apiPrefix, command, method, parameters, body, isRequiredAuth, responseType);
            return serializer.Deserialize<T>(response);
        }
        
        public void RequestApi(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters, byte[] body, bool isRequiredAuth)
        {
            GetResponse(apiPrefix, command, method, parameters, body, isRequiredAuth, string.Empty);
        }

        public Uri BuildUri(string prefix, string command, Dictionary<string, object> parameters, bool isRequiredAuth, string responseType)
        {
            return CreateUriBuilder(prefix, command, isRequiredAuth, responseType).AddQueryParameters(parameters).Build();
        }

        public T Upload<T>(string apiPrefix, string command, Dictionary<string, object> parameters, bool isRequiredAuth, string responseType, params File[] files)
        {
            var uriBuilder = CreateUriBuilder(Settings.ApiSoundCloudComPrefix + apiPrefix, command, isRequiredAuth, responseType);
            var response = webGateway.Upload(uriBuilder, parameters, files);
            return serializer.Deserialize<T>(response);
        }

        private string GetResponse(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters, byte[] body, bool isRequiredAuth, string responseType)
        {
            var uriBuilder = CreateUriBuilder(Settings.ApiSoundCloudComPrefix + apiPrefix, command, isRequiredAuth, responseType);
            var response = webGateway.Request(uriBuilder, method, parameters, body);
            return response;
        }

        private static string SetResponseType(string command, string responseType)
        {
            return string.IsNullOrEmpty(responseType)
                 ? command
                 : string.Format("{0}.{1}", command, responseType);
        }

        private IUriBuilder CreateUriBuilder(string prefix, string command, bool isRequiredAuth, string responseType)
        {
            var fullCommand = string.Format("{0}/{1}", prefix.TrimEnd('/'), command).Trim('/');
            var fullCommandWithResponse = SetResponseType(fullCommand, responseType);

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