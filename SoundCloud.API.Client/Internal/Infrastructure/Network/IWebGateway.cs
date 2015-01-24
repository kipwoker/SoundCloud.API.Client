using System;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Internal.Infrastructure.Network
{
    internal interface IWebGateway
    {
        string Request(Uri uri, HttpMethod method);
    }
}