namespace SoundCloud.API.Client.Internal.Infrastructure.Network.Factories
{
    internal interface IWebGatewayFactory
    {
        IWebGateway Create(bool enableGZip);
    }
}