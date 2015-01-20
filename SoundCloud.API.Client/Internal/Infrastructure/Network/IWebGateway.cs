using System;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Internal.Infrastructure.Network
{
    internal interface IWebGateway
    {
        T Request<T>(Uri uri, HttpMethod method);
    }
}