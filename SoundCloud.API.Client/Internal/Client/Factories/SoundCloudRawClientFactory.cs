using SoundCloud.API.Client.Internal.Client.Helpers.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Network;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Client.Factories
{
    internal class SoundCloudRawClientFactory : ISoundCloudRawClientFactory
    {
        private readonly IUriBuilderFactory uriBuilderFactory;
        private readonly IWebGateway webGateway;
        private readonly ISerializer serializer;

        internal SoundCloudRawClientFactory(IUriBuilderFactory uriBuilderFactory, IWebGateway webGateway, ISerializer serializer)
        {
            this.uriBuilderFactory = uriBuilderFactory;
            this.webGateway = webGateway;
            this.serializer = serializer;
        }

        public ISoundCloudRawClient Create(SCCredentials credentials)
        {
            return new SoundCloudRawClient(credentials, uriBuilderFactory, webGateway, serializer);
        }
    }
}