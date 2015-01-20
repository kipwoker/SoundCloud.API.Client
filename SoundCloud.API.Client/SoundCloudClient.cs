using SoundCloud.API.Client.Subresources;
using SoundCloud.API.Client.Subresources.Factories;

namespace SoundCloud.API.Client
{
    public class SoundCloudClient : ISoundCloudClient
    {
        private readonly ISubresourceFactory subresourceFactory;

        internal SoundCloudClient(ISubresourceFactory subresourceFactory)
        {
            this.subresourceFactory = subresourceFactory;
        }

        public IUsersApi Users(string userId)
        {
            return subresourceFactory.CreateUsers(userId);
        }
    }
}