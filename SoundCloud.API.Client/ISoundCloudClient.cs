using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client
{
    public interface ISoundCloudClient
    {
        IUsersApi Users(string userId);
    }
}