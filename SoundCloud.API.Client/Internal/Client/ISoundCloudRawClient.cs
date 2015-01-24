using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Client
{
    internal interface ISoundCloudRawClient
    {
        SCCredentials Credentials { get; }
        SCAccessToken AccessToken { get; }
        T RequestApi<T>(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters = null, bool isRequiredAuth = true, string responseType = "json");
        void RequestApi(string apiPrefix, string command, HttpMethod method, Dictionary<string, object> parameters = null, bool isRequiredAuth = true);
        Uri BuildUri(string prefix, string command, Dictionary<string, object> parameters, bool isRequiredAuth, string responseType);
    }
}