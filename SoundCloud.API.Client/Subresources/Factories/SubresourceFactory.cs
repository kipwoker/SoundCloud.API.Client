using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Validation;

namespace SoundCloud.API.Client.Subresources.Factories
{
    internal class SubresourceFactory : ISubresourceFactory
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;

        public SubresourceFactory(ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
        }

        public IUserApi CreateUser(string userId)
        {
            return new UserApi(userId, soundCloudRawClient, paginationValidator);
        }

        public IUsersApi CreateUsers()
        {
            return new UsersApi(soundCloudRawClient, paginationValidator);
        }

        public ITrackApi CreateTrack(string trackId)
        {
            return new TrackApi(trackId, soundCloudRawClient, paginationValidator);
        }

        public ITracksApi CreateTracks()
        {
            return new TracksApi(soundCloudRawClient, paginationValidator);
        }
    }
}