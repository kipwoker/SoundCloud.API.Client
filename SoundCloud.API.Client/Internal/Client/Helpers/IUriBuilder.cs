using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Client.Helpers
{
    internal interface IUriBuilder
    {
        IUriBuilder AddToken(string token);
        IUriBuilder AddClientId(string clientId);
        IUriBuilder AddQueryParameters(Dictionary<string, object> parameters);
        IUriBuilder AddCredentials(SCCredentials credentials, SCAccessToken accessToken);
        Uri Build();
    }
}