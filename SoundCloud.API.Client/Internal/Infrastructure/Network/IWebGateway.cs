using System;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;

#if DEBUG
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("SoundCloud.API.Client.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
#endif

namespace SoundCloud.API.Client.Internal.Infrastructure.Network
{
    internal interface IWebGateway
    {
        string Request(Uri uri, HttpMethod method);
    }
}