using System;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Subresources
{
    public interface IAuthApi
    {
        SCAccessToken CurrentToken { get; }
        SCAccessToken AuthorizeByPassword(string userName, string password);
        SCAccessToken AuthorizeByCode(string code, string redirectUri);
        Uri GetRequestTokenUri(string redirectUri, SCResponseType responseType, SCScope scope, SCDisplay display, string state);
        SCAccessToken RefreshToken(string token);
    }
}