using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading;

namespace SoundCloud.API.Client.Internal.Infrastructure.Network
{
    internal interface IWebGateway
    {
        string Request(Uri uri, HttpMethod method);
        string Upload(Uri uri, Dictionary<string, object> parameters, params File[] files);
    }
}