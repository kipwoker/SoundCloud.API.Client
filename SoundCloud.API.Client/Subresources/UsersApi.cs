using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public class UsersApi : IUsersApi
    {
        private readonly string userId;
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;

        internal UsersApi(string userId, ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator)
        {
            this.userId = userId;
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
        }

        public SCUser GetUser()
        {
            return soundCloudRawClient.Request<SCUser>(ApiCommand.User, HttpMethod.Get, null, true, userId);
        }

        public SCTrack[] GetTracks(int offset = 0, int limit = 50)
        {
            string errorMessage;
            if (!paginationValidator.IsValid(offset, limit, out errorMessage))
            {
                throw new SoundCloudApiException(errorMessage);
            }

            return soundCloudRawClient.Request<SCTrack[]>(ApiCommand.UserTracks, HttpMethod.Get, new Dictionary<string, object> { { "offset", offset }, { "limit", limit } }, true, userId);
        }

        public SCPlaylist[] GetPlaylists(int offset = 0, int limit = 50)
        {
            throw new System.NotImplementedException();
        }

        public SCUser[] GetFollowings(int offset = 0, int limit = 50)
        {
            throw new System.NotImplementedException();
        }

        public SCUser GetFollowing(string followingUserId)
        {
            throw new System.NotImplementedException();
        }

        public void PutFollowing(string followingUserId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteFollowing(string followingUserId)
        {
            throw new System.NotImplementedException();
        }

        public SCUser[] GetFollowers(int offset = 0, int limit = 50)
        {
            throw new System.NotImplementedException();
        }

        public SCUser GetFollower(string followerUserId)
        {
            throw new System.NotImplementedException();
        }

        public SCComment[] GetComments(int offset = 0, int limit = 50)
        {
            throw new System.NotImplementedException();
        }

        public SCTrack[] GetFavorites(int offset = 0, int limit = 50)
        {
            throw new System.NotImplementedException();
        }

        public SCTrack GetFavorite(string favoriteTrackId)
        {
            throw new System.NotImplementedException();
        }

        public void PutFavorite(string favoriteTrackId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteFavorite(string favoriteTrackId)
        {
            throw new System.NotImplementedException();
        }

        public SCGroup[] GetGroups(int offset = 0, int limit = 50)
        {
            throw new System.NotImplementedException();
        }
    }
}