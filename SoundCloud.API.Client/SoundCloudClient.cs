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

            Users = subresourceFactory.CreateUsers();
            Tracks = subresourceFactory.CreateTracks();
        }

        public IUserApi User(string userId)
        {
            return subresourceFactory.CreateUser(userId);
        }

        public IUsersApi Users { get; private set; }

        public ITrackApi Track(string trackId)
        {
            return subresourceFactory.CreateTrack(trackId);
        }

        public ITracksApi Tracks { get; private set; }
    }
}