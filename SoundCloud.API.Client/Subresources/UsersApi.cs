using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public class UsersApi : IUsersApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly string prefix;

        internal UsersApi(string userId, ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator)
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
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<SCTrack[]>(prefix, "tracks", HttpMethod.Get, new Dictionary<string, object> { { "offset", offset }, { "limit", limit } });
        }

        public SCPlaylist[] GetPlaylists(int offset = 0, int limit = 50)
        {
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<SCPlaylist[]>(prefix, "playlists", HttpMethod.Get, new Dictionary<string, object> { { "offset", offset }, { "limit", limit } });
        }

        public SCUser[] GetFollowings(int offset = 0, int limit = 50)
        {
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<SCUser[]>(prefix, "followings", HttpMethod.Get, new Dictionary<string, object> { { "offset", offset }, { "limit", limit } });
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
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<SCUser[]>(prefix, "followers", HttpMethod.Get, new Dictionary<string, object> { { "offset", offset }, { "limit", limit } });
        }

        public SCUser GetFollower(string followerUserId)
        {
            return soundCloudRawClient.RequestApi<SCUser>(prefix, "followers/" + followerUserId, HttpMethod.Get);
        }

        public SCComment[] GetComments(int offset = 0, int limit = 50)
        {
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<SCComment[]>(prefix, "comments", HttpMethod.Get, new Dictionary<string, object> { { "offset", offset }, { "limit", limit } });
        }

        public SCTrack[] GetFavorites(int offset = 0, int limit = 50)
        {
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<SCTrack[]>(prefix, "favorites", HttpMethod.Get, new Dictionary<string, object> { { "offset", offset }, { "limit", limit } });
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
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<SCGroup[]>(prefix, "groups", HttpMethod.Get, new Dictionary<string, object> { { "offset", offset }, { "limit", limit } });
        }

        public SCUser[] SearchUsers(string query, int offset = 0, int limit = 50)
        {
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<SCUser[]>("users", string.Empty, HttpMethod.Get, new Dictionary<string, object> { { "offset", offset }, { "limit", limit }, { "q", query } });
        }
    }
}