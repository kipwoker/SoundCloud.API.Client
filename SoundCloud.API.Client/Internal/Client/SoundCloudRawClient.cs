using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Client.Helpers.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Network.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Client
{
    internal class SoundCloudRawClient : ISoundCloudRawClient
    {
        public SCAccessToken AccessToken { get; set; }
        public SCCredentials Credentials { get; private set; }
        private readonly bool enableGZip;

        private readonly IUriBuilderFactory uriBuilderFactory;
        private readonly IWebGatewayFactory webGatewayFactory;

        public SoundCloudRawClient(SCCredentials credentials, bool enableGZip, IUriBuilderFactory uriBuilderFactory, IWebGatewayFactory webGatewayFactory)
        {
            Credentials  = credentials;
            this.enableGZip = enableGZip;
            this.uriBuilderFactory = uriBuilderFactory;
            this.webGatewayFactory = webGatewayFactory;
        }

        public T Request<T>(ApiCommand command, HttpMethod method, Dictionary<string, object> extraParameters, bool isRequiredAuth, params object[] parameters)
        {
            var uri = BuildUri(command, extraParameters, isRequiredAuth, parameters);
            var webGateway = webGatewayFactory.Create(enableGZip);

            return webGateway.Request<T>(uri, method);
        }

        public Uri BuildUri(ApiCommand command, Dictionary<string, object> extraParameters, bool isRequiredAuth, params object[] parameters)
        {
            var uriBuilder = uriBuilderFactory.Create(Api.Link[command])
                                              .AddParameters(parameters)
                                              .AddQueryParameters(extraParameters);

            if (isRequiredAuth)
            {
                uriBuilder = AccessToken == null
                           ? uriBuilder.AddClientId(Credentials.ClientId)
                           : uriBuilder.AddToken(AccessToken.AccessToken);
            }

            return uriBuilder.Build();
        }
    }
}