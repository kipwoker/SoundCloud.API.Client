using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Client
{
    internal interface ISoundCloudRawClient
    {
        SCCredentials Credentials { get; }
        SCAccessToken AccessToken { get; }
        T Request<T>(string prefix, string command, HttpMethod method, Dictionary<string, object> parameters = null, byte[] body = null, bool isRequiredAuth = true, string responseType = "json", Domain domain = Domain.Api) where T : class;
        void Request(string prefix, string command, HttpMethod method, Dictionary<string, object> parameters = null, byte[] body = null, bool isRequiredAuth = true, Domain domain = Domain.Api);
        Uri BuildUri(string command, Dictionary<string, object> parameters, bool isRequiredAuth, string responseType, Domain domain = Domain.Direct);
        T Upload<T>(string prefix, string command, Dictionary<string, object> parameters, bool isRequiredAuth = true, string responseType = "json", Domain domain = Domain.Api, params File[] files);
    }
}