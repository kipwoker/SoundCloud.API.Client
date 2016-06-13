using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Client.Helpers.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Network;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects.Auth;
using File = SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading.File;

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

        public T Request<T>(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters = null, byte[] body = null, string responseType = "json", Domain domain = Domain.Api)
            where T : class 
        {
            var response = GetResponse(domain, apiPrefix, command, method, parameters, body, responseType);
            return typeof(T) == typeof(string) ? response as T : serializer.Deserialize<T>(response);
        }

        public void Request(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters = null, byte[] body = null, Domain domain = Domain.Api)
        {
            GetResponse(domain, apiPrefix, command, method, parameters, body, string.Empty);
        }

        public Uri BuildUri(string command, Dictionary<string, object> parameters, string responseType, Domain domain = Domain.Direct)
        {
            return CreateUriBuilder(domain, string.Empty, command, responseType).AddQueryParameters(parameters).Build();
        }

        public T Upload<T>(string prefix, string command, Dictionary<string, object> parameters, string responseType = "json", Domain domain = Domain.Api, params File[] files)
        {
            var uriBuilder = CreateUriBuilder(domain, prefix, command, responseType);
            var response = webGateway.Upload(uriBuilder, parameters, files);
            return serializer.Deserialize<T>(response);
        }

        public Stream RequestStream(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters = null, byte[] body = null, Domain domain = Domain.Api)
        {
            var token = GetToken();
            var uriBuilder = CreateUriBuilder(domain, apiPrefix, command, string.Empty);
            return webGateway.RequestStream(uriBuilder, method, parameters, body, token);
        }

        private string GetResponse(Domain domain, string prefix, string command, HttpMethod method, Dictionary<string, object> parameters, byte[] body, string responseType)
        {
            var token = GetToken();
            var uriBuilder = CreateUriBuilder(domain, prefix, command, responseType);
            var response = webGateway.Request(uriBuilder, method, parameters, body, token);
            return response;
        }

        private string GetToken()
        {
            return AccessToken != null ? AccessToken.AccessToken : string.Empty;
        }

        private static string SetResponseType(string command, string responseType)
        {
            return string.IsNullOrEmpty(responseType)
                 ? command
                 : string.Format("{0}.{1}", command, responseType);
        }

        private IUriBuilder CreateUriBuilder(Domain domain, string prefix, string command, string responseType)
        {
            var fullCommand = string.Join("/", new[] { domain.GetParameterName(), prefix, command }.Where(x => !string.IsNullOrEmpty(x)).Select(x => x.TrimEnd('/')));
            var fullCommandWithResponse = string.IsNullOrEmpty(prefix) && string.IsNullOrEmpty(command) ? fullCommand : SetResponseType(fullCommand, responseType);

            var uriBuilder = uriBuilderFactory.Create(fullCommandWithResponse);

            return uriBuilder.AddCredentials(Credentials, AccessToken);
        }

        
    }
}