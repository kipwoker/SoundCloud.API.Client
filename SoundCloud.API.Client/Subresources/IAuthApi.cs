using System;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface IAuthApi
    {
        SCAccessToken Authorize(string userName, string password);
        Uri GetRequestTokenUri(string responseUri);
        SCAccessToken RefreshToken(string token);
    }
}