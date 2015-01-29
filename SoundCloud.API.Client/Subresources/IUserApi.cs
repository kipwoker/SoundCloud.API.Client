using System;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface IUserApi
    {
        SCUser GetUser();
        SCTrack[] GetTracks(int offset = 0, int limit = 50);
        SCPlaylist[] GetPlaylists(int offset = 0, int limit = 50);

        SCUser[] GetFollowings(int offset = 0, int limit = 50);

        [Obsolete("API BUG. Use GetFollowings(). This method returns 401. It's API trouble. More here: https://github.com/soundcloud/soundcloud-ruby/issues/24")]
        SCUser GetFollowing(string followingUserId);

        void PutFollowing(string followingUserId);
        void DeleteFollowing(string followingUserId);

        SCUser[] GetFollowers(int offset = 0, int limit = 50);

        [Obsolete("API BUG. Use GetFollowers(). This method returns 401. It's API trouble. More here: https://github.com/soundcloud/soundcloud-ruby/issues/24")]
        SCUser GetFollower(string followerUserId);

        SCComment[] GetComments(int offset = 0, int limit = 50);

        SCTrack[] GetFavorites(int offset = 0, int limit = 50);
        SCTrack GetFavorite(string favoriteTrackId);
        void PutFavorite(string favoriteTrackId);
        void DeleteFavorite(string favoriteTrackId);

        SCGroup[] GetGroups(int offset = 0, int limit = 50);

        SCWebProfile[] GetWebProfiles(int offset = 0, int limit = 50);
        //todo: PUT, DELETE web-profiles
    }
}