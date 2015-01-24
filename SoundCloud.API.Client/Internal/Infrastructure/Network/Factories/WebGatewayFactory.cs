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