#if DEBUG
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("SoundCloud.API.Client.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
#endif

namespace SoundCloud.API.Client.Internal.Infrastructure.Network.Factories
{
    internal class WebGatewayFactory : IWebGatewayFactory
    {
        internal static readonly IWebGatewayFactory Default = new WebGatewayFactory();
        
        public IWebGateway Create(bool enableGZip)
        {
            return new WebGateway(enableGZip);
        }
    }
}