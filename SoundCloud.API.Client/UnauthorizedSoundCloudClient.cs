using SoundCloud.API.Client.Subresources;
using SoundCloud.API.Client.Subresources.Factories;
using SoundCloud.API.Client.Subresources.Public;

namespace SoundCloud.API.Client
{
    public class UnauthorizedSoundCloudClient : IUnauthorizedSoundCloudClient
    {
        private readonly ISubresourceFactory subresourceFactory;

        internal UnauthorizedSoundCloudClient(ISubresourceFactory subresourceFactory)
        {
            this.subresourceFactory = subresourceFactory;

            Users = subresourceFactory.CreateUsers();
            Tracks = subresourceFactory.CreateTracks();
            Me = subresourceFactory.CreateMe();
            Groups = subresourceFactory.CreateGroups();
            Resolve = subresourceFactory.CreateResolve();
            Explore = subresourceFactory.CreateExplore();
            OEmbed = subresourceFactory.CreateOEmbed();
        }

        public IPublicUserApi User(string userId)
        {
            return (IPublicUserApi)subresourceFactory.CreateUser(userId);
        }

        public IUsersApi Users { get; private set; }

        public IPublicTrackApi Track(string trackId)
        {
            return (IPublicTrackApi)subresourceFactory.CreateTrack(trackId);
        }

        public ITracksApi Tracks { get; private set; }
        
        public IPlaylistApi Playlist(string playlistId)
        {
            return subresourceFactory.CreatePlaylist(playlistId);
        }

        public IPublicGroupApi Group(string groupId)
        {
            return (IPublicGroupApi)subresourceFactory.CreateGroup(groupId);
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

        public IOEmbed OEmbed { get; private set; }
    }
}