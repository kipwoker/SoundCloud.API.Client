using SoundCloud.API.Client.Objects.Auth;
using SoundCloud.API.Client.Subresources;
using SoundCloud.API.Client.Subresources.Factories;

namespace SoundCloud.API.Client
{
    public class SoundCloudClient : ISoundCloudClient
    {
        private readonly ISubresourceFactory subresourceFactory;

        internal SoundCloudClient(SCAccessToken accessToken, ISubresourceFactory subresourceFactory)
        {
            this.subresourceFactory = subresourceFactory;

            CurrentToken = accessToken;

            Users = subresourceFactory.CreateUsers();
            Tracks = subresourceFactory.CreateTracks();
            Me = subresourceFactory.CreateMe();
            Groups = subresourceFactory.CreateGroups();
            Resolve = subresourceFactory.CreateResolve();
            Explore = subresourceFactory.CreateExplore();
            Chart = subresourceFactory.CreateChart();
            OEmbed = subresourceFactory.CreateOEmbed();
        }

        public SCAccessToken CurrentToken { get; private set; }

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

        public IResolveApi Resolve { get; private set; }

        public IExploreApi Explore { get; private set; }

        public IChartApi Chart { get; private set; }

        public IOEmbed OEmbed { get; private set; }
    }
}