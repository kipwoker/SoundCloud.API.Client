using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public class UserApi : IUserApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly string prefix;

        internal UserApi(string userId, ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;

            prefix = string.Format("users/{0}", userId);
        }

        public SCUser GetUser()
        {
            return soundCloudRawClient.RequestApi<SCUser>(prefix, string.Empty, HttpMethod.Get);
        }

        public SCTrack[] GetTracks(int offset = 0, int limit = 50)
        {
            return soundCloudRawClient.GetCollection<SCTrack>(paginationValidator, prefix, "tracks", offset, limit);
        }

        public SCPlaylist[] GetPlaylists(int offset = 0, int limit = 50)
        {
            return soundCloudRawClient.GetCollection<SCPlaylist>(paginationValidator, prefix, "playlists", offset, limit);
        }

        public SCUser[] GetFollowings(int offset = 0, int limit = 50)
        {
            return soundCloudRawClient.GetCollection<SCUser>(paginationValidator, prefix, "followings", offset, limit);
        }

        public SCUser GetFollowing(string followingUserId)
        {
            return soundCloudRawClient.RequestApi<SCUser>(prefix, "followings/" + followingUserId, HttpMethod.Get);
        }

        public void PutFollowing(string followingUserId)
        {
            soundCloudRawClient.RequestApi(prefix, "followings/" + followingUserId, HttpMethod.Put);
        }

        public void DeleteFollowing(string followingUserId)
        {
            soundCloudRawClient.RequestApi(prefix, "followings/" + followingUserId, HttpMethod.Delete);
        }

        public SCUser[] GetFollowers(int offset = 0, int limit = 50)
        {
            return soundCloudRawClient.GetCollection<SCUser>(paginationValidator, prefix, "followers", offset, limit);
        }

        public SCUser GetFollower(string followerUserId)
        {
            return soundCloudRawClient.RequestApi<SCUser>(prefix, "followers/" + followerUserId, HttpMethod.Get);
        }

        public SCComment[] GetComments(int offset = 0, int limit = 50)
        {
            return soundCloudRawClient.GetCollection<SCComment>(paginationValidator, prefix, "comments", offset, limit);
        }

        public SCTrack[] GetFavorites(int offset = 0, int limit = 50)
        {
            return soundCloudRawClient.GetCollection<SCTrack>(paginationValidator, prefix, "favorites", offset, limit);
        }

        public SCTrack GetFavorite(string favoriteTrackId)
        {
            return soundCloudRawClient.RequestApi<SCTrack>(prefix, "favorites/" + favoriteTrackId, HttpMethod.Get);
        }

        public void PutFavorite(string favoriteTrackId)
        {
            soundCloudRawClient.RequestApi(prefix, "favorites/" + favoriteTrackId, HttpMethod.Put);
        }

        public void DeleteFavorite(string favoriteTrackId)
        {
            soundCloudRawClient.RequestApi(prefix, "favorites/" + favoriteTrackId, HttpMethod.Delete);
        }

        public SCGroup[] GetGroups(int offset = 0, int limit = 50)
        {
            return soundCloudRawClient.GetCollection<SCGroup>(paginationValidator, prefix, "groups", offset, limit);
        }

        public SCWebProfile[] GetWebProfiles(int offset = 0, int limit = 50)
        {
            return soundCloudRawClient.GetCollection<SCWebProfile>(paginationValidator, prefix, "web-profiles", offset, limit);
        }
    }
}