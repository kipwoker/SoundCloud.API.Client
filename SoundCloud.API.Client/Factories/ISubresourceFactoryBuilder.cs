using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Subresources.Factories;

namespace SoundCloud.API.Client.Factories
{
    internal interface ISubresourceFactoryBuilder
    {
        ISubresourceFactory CreateSubresourceFactory(ISoundCloudRawClient soundCloudRawClient);
    }
}