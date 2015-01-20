using System;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client
{
    public interface ISoundCloudConnector
    {
        ISoundCloudClient Connect(string clientId, string clientSecret, string userName, string password, bool enableGZip);
        ISoundCloudClient Connect(SCAccessToken accessToken, bool enableGZip);
        Uri GetRequestTokenUri(string clientId, string responseUri);
        SCAccessToken RefreshToken(string clientId, string clientSecret, string refreshToken);
    }
}