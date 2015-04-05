using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Client.Factories
{
    internal interface ISoundCloudRawClientFactory
    {
        ISoundCloudRawClient Create(SCCredentials credentials);
    }
}