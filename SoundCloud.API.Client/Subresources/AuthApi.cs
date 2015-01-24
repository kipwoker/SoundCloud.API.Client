using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Subresources
{
    public class AuthApi : IAuthApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;

        private const string prefix = "oauth2";

        internal AuthApi(ISoundCloudRawClient soundCloudRawClient)
        {
            this.soundCloudRawClient = soundCloudRawClient;
        }

        public SCAccessToken CurrentToken { get { return soundCloudRawClient.AccessToken; } }

        public SCAccessToken AuthorizeByPassword(string userName, string password)
        {
            var credentials = soundCloudRawClient.Credentials;
            return soundCloudRawClient.RequestApi<SCAccessToken>(prefix, "token", HttpMethod.Post, new Dictionary<string, object>
            {
                {"client_id", credentials.ClientId},
                {"client_secret", credentials.ClientSecret},
                {"grant_type", "password"},
                {"username", userName},
                {"password", password}
            }, false, string.Empty);
        }

        public SCAccessToken AuthorizeByCode(string code, string redirectUri)
        {
            var credentials = soundCloudRawClient.Credentials;
            return soundCloudRawClient.RequestApi<SCAccessToken>(prefix, "token", HttpMethod.Post, new Dictionary<string, object>
            {
                {"client_id", credentials.ClientId},
                {"client_secret", credentials.ClientSecret},
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", redirectUri}
            }, false, string.Empty);
        }

        public Uri GetRequestTokenUri(string redirectUri, SCResponseType responseType, SCScope scope, SCDisplay display, string state)
        {
            return soundCloudRawClient.BuildUri(Settings.SoundCloudComPrefix,
                                                "connect",
                                                new Dictionary<string, object>
                                                {
                                                    {"client_id", soundCloudRawClient.Credentials.ClientId},
                                                    {"redirect_uri", redirectUri},
                                                    {"response_type", responseType.ToUrlParameterName()},
                                                    {"scope", scope.ToUrlParameterName()},
                                                    {"display", display.ToUrlParameterName()},
                                                    {"state", state}
                                                },
                                                false,
                                                string.Empty);
        }

        public SCAccessToken RefreshToken(string token)
        {
            var credentials = soundCloudRawClient.Credentials;
            return soundCloudRawClient.RequestApi<SCAccessToken>(prefix, "token", HttpMethod.Post, new Dictionary<string, object>
            {
                {"client_id", credentials.ClientId},
                {"client_secret", credentials.ClientSecret},
                {"grant_type", "refresh_token"},
                {"refresh_token", token}
            }, false, string.Empty);
        }
    }
}