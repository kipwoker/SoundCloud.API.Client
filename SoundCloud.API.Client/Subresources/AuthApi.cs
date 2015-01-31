using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Converters.Auth;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects.Auth;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Subresources
{
    public class AuthApi : IAuthApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IAccessTokenConverter accessTokenConverter;

        private const string prefix = "oauth2";

        internal AuthApi(ISoundCloudRawClient soundCloudRawClient, IAccessTokenConverter accessTokenConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.accessTokenConverter = accessTokenConverter;
        }

        public SCAccessToken CurrentToken { get { return soundCloudRawClient.AccessToken; } }

        public SCAccessToken AuthorizeByPassword(string userName, string password)
        {
            var credentials = soundCloudRawClient.Credentials;
            var accessToken = soundCloudRawClient.RequestApi<AccessToken>(prefix, "token", HttpMethod.Post, new Dictionary<string, object>
            {
                {"client_id", credentials.ClientId},
                {"client_secret", credentials.ClientSecret},
                {"grant_type", "password"},
                {"username", userName},
                {"password", password}
            }, null, false, string.Empty);

            return accessTokenConverter.Convert(accessToken);
        }

        public SCAccessToken AuthorizeByCode(string code, string redirectUri)
        {
            var credentials = soundCloudRawClient.Credentials;
            var accessToken = soundCloudRawClient.RequestApi<AccessToken>(prefix, "token", HttpMethod.Post, new Dictionary<string, object>
            {
                {"client_id", credentials.ClientId},
                {"client_secret", credentials.ClientSecret},
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", redirectUri}
            }, null, false, string.Empty);

            return accessTokenConverter.Convert(accessToken);
        }

        public Uri GetRequestTokenUri(string redirectUri, SCResponseType responseType, SCScope scope, SCDisplay display, string state)
        {
            return soundCloudRawClient.BuildUri(Settings.SoundCloudComPrefix,
                                                "connect",
                                                new Dictionary<string, object>
                                                {
                                                    {"client_id", soundCloudRawClient.Credentials.ClientId},
                                                    {"redirect_uri", redirectUri},
                                                    {"response_type", responseType.GetParameterName()},
                                                    {"scope", scope.GetParameterName()},
                                                    {"display", display.GetParameterName()},
                                                    {"state", state}
                                                },
                                                false,
                                                string.Empty);
        }

        public SCAccessToken RefreshToken(string token)
        {
            var credentials = soundCloudRawClient.Credentials;
            var accessToken = soundCloudRawClient.RequestApi<AccessToken>(prefix, "token", HttpMethod.Post, new Dictionary<string, object>
            {
                {"client_id", credentials.ClientId},
                {"client_secret", credentials.ClientSecret},
                {"grant_type", "refresh_token"},
                {"refresh_token", token}
            }, null, false, string.Empty);

            return accessTokenConverter.Convert(accessToken);
        }
    }
}