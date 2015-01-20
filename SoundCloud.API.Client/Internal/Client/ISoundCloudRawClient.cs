using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Client
{
    internal interface ISoundCloudRawClient
    {
        SCCredentials Credentials { get; }
        T Request<T>(ApiCommand command, HttpMethod method, Dictionary<string, object> extraParameters, bool isRequiredAuth, params object[] parameters);
        Uri BuildUri(ApiCommand command, Dictionary<string, object> extraParameters, bool isRequiredAuth, params object[] parameters);
    }
}