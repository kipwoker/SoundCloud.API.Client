using System;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Client.Helpers
{
    internal interface IUriBuilder
    {
        IUriBuilder AddParameters(params object[] parameters);
        IUriBuilder AddToken(string token);
        IUriBuilder AddClientId(string clientId);
        IUriBuilder AddQueryParameters(Dictionary<string, object> parameters);
        IUriBuilder AddToQueryString(string name, string value);
        IUriBuilder AddToQueryString(string queryString);
        Uri Build();
    }
}