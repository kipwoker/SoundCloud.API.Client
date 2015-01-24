using System;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Client.Helpers.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Network.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects.Auth;
using SoundCloud.API.Client.Subresources;
using SoundCloud.API.Client.Subresources.Factories;

namespace SoundCloud.API.Client
{
    public class SoundCloudConnector : ISoundCloudConnector
    {
        public ISoundCloudClient DirectConnect(string clientId, string clientSecret, string userName, string password, bool enableGZip)
        {
            var credentials = new SCCredentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var soundCloudRawClient = CreateSCRawClient(enableGZip, credentials);
            
            IAuthApi authApi = new AuthApi(soundCloudRawClient);
            var accessToken = authApi.AuthorizeByPassword(userName, password);
            
            soundCloudRawClient.AccessToken = accessToken;

            var soundCloudClient = CreateSoundCloudClient(soundCloudRawClient);
            return soundCloudClient;
        }

        public ISoundCloudClient Connect(string clientId, string clientSecret, string code, string redirectUri, bool enableGZip)
        {
            var credentials = new SCCredentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var soundCloudRawClient = CreateSCRawClient(enableGZip, credentials);

            IAuthApi authApi = new AuthApi(soundCloudRawClient);
            var accessToken = authApi.AuthorizeByCode(code, redirectUri);

            soundCloudRawClient.AccessToken = accessToken;

            var soundCloudClient = CreateSoundCloudClient(soundCloudRawClient);
            return soundCloudClient;
        }

        public ISoundCloudClient Connect(SCAccessToken accessToken, bool enableGZip)
        {
            var credentials = new SCCredentials();

            var soundCloudRawClient = CreateSCRawClient(enableGZip, credentials);

            soundCloudRawClient.AccessToken = accessToken;

            var soundCloudClient = CreateSoundCloudClient(soundCloudRawClient);
            return soundCloudClient;
        }

        public Uri GetRequestTokenUri(string clientId, string redirectUri, SCResponseType responseType, SCScope scope, SCDisplay display, string state)
        {
            var credentials = new SCCredentials
            {
                ClientId = clientId
            };

            var soundCloudRawClient = CreateSCRawClient(false, credentials);
            IAuthApi authApi = new AuthApi(soundCloudRawClient);
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

            var soundCloudRawClient = CreateSCRawClient(false, credentials);
            IAuthApi authApi = new AuthApi(soundCloudRawClient);
            return authApi.RefreshToken(token);
        }

        private static SoundCloudClient CreateSoundCloudClient(ISoundCloudRawClient soundCloudRawClient)
        {
            return new SoundCloudClient(
                new SubresourceFactory(
                    soundCloudRawClient,
                    PaginationValidator.Default));
        }

        private static SoundCloudRawClient CreateSCRawClient(bool enableGZip, SCCredentials credentials)
        {
            return new SoundCloudRawClient(credentials, enableGZip, UriBuilderFactory.Default, WebGatewayFactory.Default, JsonSerializer.Default);
        }
    }
}