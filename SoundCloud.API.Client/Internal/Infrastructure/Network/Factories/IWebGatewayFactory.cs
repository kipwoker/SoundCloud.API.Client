#if DEBUG
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("SoundCloud.API.Client.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
#endif

namespace SoundCloud.API.Client.Internal.Infrastructure.Network.Factories
{
    internal interface IWebGatewayFactory
    {
        IWebGateway Create(bool enableGZip);
    }
}