using SoundCloud.API.Client.Internal.Client;

namespace SoundCloud.API.Client.Factories
{
    internal interface ISoundCloudClientBuilder
    {
        ISoundCloudClient Build(ISoundCloudRawClient soundCloudRawClient);
        IUnauthorizedSoundCloudClient CreateUnauthorized(ISoundCloudRawClient soundCloudRawClient);
    }
}