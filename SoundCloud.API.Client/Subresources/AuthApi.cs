using System;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public class AuthApi : IAuthApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;

        internal AuthApi(ISoundCloudRawClient soundCloudRawClient)
        {
            this.soundCloudRawClient = soundCloudRawClient;
        }

        public SCAccessToken Authorize(string userName, string password)
        {
            var credentials = soundCloudRawClient.Credentials;
            return soundCloudRawClient.Request<SCAccessToken>(ApiCommand.UserCredentialsFlow, HttpMethod.Post, null, false, credentials.ClientId, credentials.ClientSecret, userName, password);
        }

        public Uri GetRequestTokenUri(string responseUri)
        {
            var credentials = soundCloudRawClient.Credentials;
            return soundCloudRawClient.BuildUri(ApiCommand.AuthorizationCodeFlow, null, false, credentials.ClientId, responseUri);
        }

        public SCAccessToken RefreshToken(string token)
        {
            var credentials = soundCloudRawClient.Credentials;
            return soundCloudRawClient.Request<SCAccessToken>(ApiCommand.RefreshToken, HttpMethod.Post, null, true, credentials.ClientId, credentials.ClientSecret, token);
        }
    }
}