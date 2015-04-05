using System;
using SoundCloud.API.Client.Factories;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Client.Factories;
using SoundCloud.API.Client.Internal.Client.Helpers.Factories;
using SoundCloud.API.Client.Internal.Converters.Auth;
using SoundCloud.API.Client.Internal.Infrastructure.Network;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects.Auth;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client
{
    public class SoundCloudConnector : ISoundCloudConnector
    {
        private readonly ISoundCloudRawClientFactory soundCloudRawClientFactory;
        private readonly ISoundCloudClientBuilder soundCloudClientBuilder;

        public SoundCloudConnector()
            : this(new SoundCloudRawClientFactory(new UriBuilderFactory(), new WebGateway(), new JsonSerializer()), new SoundCloudClientBuilder())
        {

        }

        private SoundCloudConnector(ISoundCloudRawClientFactory soundCloudRawClientFactory, ISoundCloudClientBuilder soundCloudClientBuilder)
        {
            this.soundCloudRawClientFactory = soundCloudRawClientFactory;
            this.soundCloudClientBuilder = soundCloudClientBuilder;
        }

        public IAnonymousSoundCloudClient AnonymousConnect()
        {
            var soundCloudRawClient = soundCloudRawClientFactory.Create(null);
            return new AnonymousSoundCloudClient(new OEmbed(soundCloudRawClient));
        }

        public IUnauthorizedSoundCloudClient UnauthorizedConnect(string clientId, string clientSecret)
        {
            var credentials = new SCCredentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var soundCloudRawClient = soundCloudRawClientFactory.Create(credentials);
            var soundCloudClient = soundCloudClientBuilder.CreateUnauthorized(soundCloudRawClient);

            return soundCloudClient;
        }

        public ISoundCloudClient DirectConnect(string clientId, string clientSecret, string userName, string password)
        {
            var credentials = new SCCredentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var soundCloudRawClient = soundCloudRawClientFactory.Create(credentials);

            IAuthApi authApi = CreateAuthApi(soundCloudRawClient);
            var accessToken = authApi.AuthorizeByPassword(userName, password);

            soundCloudRawClient.AccessToken = accessToken;

            var soundCloudClient = soundCloudClientBuilder.Build(soundCloudRawClient);
            return soundCloudClient;
        }

        public ISoundCloudClient Connect(string clientId, string clientSecret, string code, string redirectUri)
        {
            var credentials = new SCCredentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var soundCloudRawClient = soundCloudRawClientFactory.Create(credentials);

            IAuthApi authApi = CreateAuthApi(soundCloudRawClient);
            var accessToken = authApi.AuthorizeByCode(code, redirectUri);

            soundCloudRawClient.AccessToken = accessToken;

            var soundCloudClient = soundCloudClientBuilder.Build(soundCloudRawClient);
            return soundCloudClient;
        }

        public ISoundCloudClient Connect(SCAccessToken accessToken)
        {
            var credentials = new SCCredentials();

            var soundCloudRawClient = soundCloudRawClientFactory.Create(credentials);

            soundCloudRawClient.AccessToken = accessToken;

            var soundCloudClient = soundCloudClientBuilder.Build(soundCloudRawClient);
            return soundCloudClient;
        }

        public Uri GetRequestTokenUri(string clientId, string redirectUri, SCResponseType responseType, SCScope scope, SCDisplay display, string state)
        {
            var credentials = new SCCredentials
            {
                ClientId = clientId
            };

            var soundCloudRawClient = soundCloudRawClientFactory.Create(credentials);
            IAuthApi authApi = CreateAuthApi(soundCloudRawClient);
            var requestTokenUri = authApi.GetRequestTokenUri(redirectUri, responseType, scope, display, state);
            return requestTokenUri;
        }

        public SCAccessToken RefreshToken(string clientId, string clientSecret, string token)
        {
            var credentials = new SCCredentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var soundCloudRawClient = soundCloudRawClientFactory.Create(credentials);
            IAuthApi authApi = CreateAuthApi(soundCloudRawClient);
            return authApi.RefreshToken(token);
        }

        private static AuthApi CreateAuthApi(ISoundCloudRawClient soundCloudRawClient)
        {
            return new AuthApi(soundCloudRawClient, new AccessTokenConverter());
        }
    }
}