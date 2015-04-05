using SoundCloud.API.Client.Internal.Client;

namespace SoundCloud.API.Client.Factories
{
    internal class SoundCloudClientBuilder : ISoundCloudClientBuilder
    {
        private readonly ISubresourceFactoryBuilder subresourceFactoryBuilder;

        internal SoundCloudClientBuilder()
        {
            subresourceFactoryBuilder = new SubresourceFactoryBuilder();
        }

        public ISoundCloudClient Build(ISoundCloudRawClient soundCloudRawClient)
        {
            return new SoundCloudClient(soundCloudRawClient.AccessToken, subresourceFactoryBuilder.CreateSubresourceFactory(soundCloudRawClient));
        }

        public IUnauthorizedSoundCloudClient CreateUnauthorized(ISoundCloudRawClient soundCloudRawClient)
        {
            return new UnauthorizedSoundCloudClient(subresourceFactoryBuilder.CreateSubresourceFactory(soundCloudRawClient));
        }
    }
}