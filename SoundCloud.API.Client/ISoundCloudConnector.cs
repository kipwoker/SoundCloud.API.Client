using System;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client
{
    public interface ISoundCloudConnector
    {
        ISoundCloudClient DirectConnect(string clientId, string clientSecret, string userName, string password, bool enableGZip);
        ISoundCloudClient Connect(string clientId, string clientSecret, string code, string redirectUri, bool enableGZip);
        ISoundCloudClient Connect(SCAccessToken accessToken, bool enableGZip);
        Uri GetRequestTokenUri(string clientId, string redirectUri, SCResponseType responseType, SCScope scope, SCDisplay display, string state);
        SCAccessToken RefreshToken(string clientId, string clientSecret, string token);
    }
}