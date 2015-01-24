#if DEBUG
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("SoundCloud.API.Client.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
#endif

namespace SoundCloud.API.Client.Internal.Infrastructure.Objects
{
    internal enum HttpMethod
    {
        Get,
        Post,
        Put,
        Delete
    }
}