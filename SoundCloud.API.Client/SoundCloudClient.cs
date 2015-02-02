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
            Me = subresourceFactory.CreateMe();
            Groups = subresourceFactory.CreateGroups();
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
        
        public IPlaylistApi Playlist(string playlistId)
        {
            return subresourceFactory.CreatePlaylist(playlistId);
        }

        public IGroupApi Group(string groupId)
        {
            return subresourceFactory.CreateGroup(groupId);
        }

        public IGroupsApi Groups { get; private set; }

        public IMeApi Me { get; private set; }

        public ICommentApi Comment(string commentId)
        {
            return subresourceFactory.CreateComment(commentId);
        }

        public IAppApi App(string appId)
        {
            return subresourceFactory.CreateApp(appId);
        }
    }
}