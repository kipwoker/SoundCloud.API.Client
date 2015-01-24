using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface IUsersApi
    {
        SCUser GetUser();
        SCTrack[] GetTracks(int offset = 0, int limit = 50);
        SCPlaylist[] GetPlaylists(int offset = 0, int limit = 50);

        SCUser[] GetFollowings(int offset = 0, int limit = 50);
        SCUser GetFollowing(string followingUserId);
        void PutFollowing(string followingUserId);
        void DeleteFollowing(string followingUserId);

        SCUser[] GetFollowers(int offset = 0, int limit = 50);
        SCUser GetFollower(string followerUserId);

        SCComment[] GetComments(int offset = 0, int limit = 50);

        SCTrack[] GetFavorites(int offset = 0, int limit = 50);
        SCTrack GetFavorite(string favoriteTrackId);
        void PutFavorite(string favoriteTrackId);
        void DeleteFavorite(string favoriteTrackId);

        SCGroup[] GetGroups(int offset = 0, int limit = 50);

        //todo: GET, PUT, DELETE	/users/{id}/web-profiles	list of web profiles

        SCUser[] SearchUsers(string query, int offset = 0, int limit = 50);
    }
}