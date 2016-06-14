using System.Linq;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Subresources.Helpers;
using SoundCloud.API.Client.Subresources.Public;

namespace SoundCloud.API.Client.Subresources
{
    public class UserApi : IUserApi, IPublicUserApi
    {
        private readonly string userId;
        internal readonly ISoundCloudRawClient soundCloudRawClient;
        internal readonly IPaginationValidator paginationValidator;
        private readonly IUserConverter userConverter;
        private readonly ITrackConverter trackConverter;
        private readonly IPlaylistConverter playlistConverter;
        internal readonly ICommentConverter commentConverter;
        private readonly IGroupConverter groupConverter;
        private readonly IWebProfileConverter webProfileConverter;
        private readonly string prefix;

        internal UserApi(
            string userId, 
            ISoundCloudRawClient soundCloudRawClient, 
            IPaginationValidator paginationValidator, 
            IUserConverter userConverter, 
            ITrackConverter trackConverter, 
            IPlaylistConverter playlistConverter,
            ICommentConverter commentConverter,
            IGroupConverter groupConverter,
            IWebProfileConverter webProfileConverter,
            string customPrefix = null)
        {
            this.userId = userId;
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
            this.userConverter = userConverter;
            this.trackConverter = trackConverter;
            this.playlistConverter = playlistConverter;
            this.commentConverter = commentConverter;
            this.groupConverter = groupConverter;
            this.webProfileConverter = webProfileConverter;

            prefix = string.IsNullOrEmpty(customPrefix) ? string.Format("users/{0}", userId) : customPrefix;
        }

        public SCUser UpdateUser(SCUser user)
        {
            if (!string.IsNullOrEmpty(userId) && user.Id != userId)
            {
                throw new SoundCloudApiException(string.Format("Context set for userId = {0}. Create new context for update another user.", userId));
            }

            var currentUser = GetInternalUser();
            var diff = currentUser.GetDiff(userConverter.Convert(user));

            var parameters = diff.ToDictionary(x => string.Format("user[{0}]", x.Key), x => x.Value);
            var updatedUser = soundCloudRawClient.Request<User>(prefix, string.Empty, HttpMethod.Put, parameters);
            return userConverter.Convert(updatedUser);
        }

        public SCUser GetUser()
        {
            var user = GetInternalUser();
            return userConverter.Convert(user);
        }

        public SCTrack[] GetTracks(int offset = 0, int limit = 50)
        {
            var tracks = soundCloudRawClient.GetCollection<Track>(paginationValidator, prefix, "tracks", offset, limit);
            return tracks.Select(trackConverter.Convert).ToArray();
        }

        public SCPlaylist[] GetPlaylists(int offset = 0, int limit = 50)
        {
            var playlists = soundCloudRawClient.GetCollection<Playlist>(paginationValidator, prefix, "playlists", offset, limit);
            return playlists.Select(playlistConverter.Convert).ToArray();
        }

        public SCUser[] GetFollowings(int offset = 0, int limit = 50)
        {
            var users = soundCloudRawClient.GetCollectionBatch<UserCollection, User>(paginationValidator, prefix, "followings", offset, limit);
            return users.Collection.Select(userConverter.Convert).ToArray();
        }

        public SCUser GetFollowing(string followingUserId)
        {
            var user = soundCloudRawClient.Request<User>(prefix, "followings/" + followingUserId, HttpMethod.Get);
            return userConverter.Convert(user);
        }

        public void PutFollowing(string followingUserId)
        {
            soundCloudRawClient.Request(prefix, "followings/" + followingUserId, HttpMethod.Put);
        }

        public void DeleteFollowing(string followingUserId)
        {
            soundCloudRawClient.Request(prefix, "followings/" + followingUserId, HttpMethod.Delete);
        }

        public SCUser[] GetFollowers(int offset = 0, int limit = 50)
        {
            var users = soundCloudRawClient.GetCollectionBatch<UserCollection, User>(paginationValidator, prefix, "followers", offset, limit);
            return users.Collection.Select(userConverter.Convert).ToArray();
        }

        public SCUser GetFollower(string followerUserId)
        {
            var user = soundCloudRawClient.Request<User>(prefix, "followers/" + followerUserId, HttpMethod.Get);
            return userConverter.Convert(user);
        }

        public virtual SCComment[] GetComments(int offset = 0, int limit = 50)
        {
            var comments = soundCloudRawClient.GetCollection<Comment>(paginationValidator, prefix, "comments", offset, limit);
            return comments.Select(commentConverter.Convert).ToArray();
        }

        public SCTrack[] GetFavorites(int offset = 0, int limit = 50)
        {
            var tracks = soundCloudRawClient.GetCollection<Track>(paginationValidator, prefix, "favorites", offset, limit);
            return tracks.Select(trackConverter.Convert).ToArray();
        }

        public SCTrack GetFavorite(string favoriteTrackId)
        {
            var track = soundCloudRawClient.Request<Track>(prefix, "favorites/" + favoriteTrackId, HttpMethod.Get);
            return trackConverter.Convert(track);
        }

        public void PutFavorite(string favoriteTrackId)
        {
            soundCloudRawClient.Request(prefix, "favorites/" + favoriteTrackId, HttpMethod.Put);
        }

        public void DeleteFavorite(string favoriteTrackId)
        {
            soundCloudRawClient.Request(prefix, "favorites/" + favoriteTrackId, HttpMethod.Delete);
        }

        public SCGroup[] GetGroups(int offset = 0, int limit = 50)
        {
            var groups = soundCloudRawClient.GetCollection<Group>(paginationValidator, prefix, "groups", offset, limit);
            return groups.Select(groupConverter.Convert).ToArray();
        }

        public SCWebProfile[] GetWebProfiles(int offset = 0, int limit = 50)
        {
            var webProfiles = soundCloudRawClient.GetCollection<WebProfile>(paginationValidator, prefix, "web-profiles", offset, limit);
            return webProfiles.Select(webProfileConverter.Convert).ToArray();
        }

        private User GetInternalUser()
        {
            return soundCloudRawClient.Request<User>(prefix, string.Empty, HttpMethod.Get);
        }
    }
}