using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Validation;

namespace SoundCloud.API.Client.Subresources.Factories
{
    internal class SubresourceFactory : ISubresourceFactory
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly ITrackConverter trackConverter;
        private readonly IUserConverter userConverter;
        private readonly IPlaylistConverter playlistConverter;
        private readonly ICommentConverter commentConverter;
        private readonly IGroupConverter groupConverter;
        private readonly IWebProfileConverter webProfileConverter;
        private readonly IConnectionConverter connectionConverter;
        private readonly IActivityResultConverter activityResultConverter;

        public SubresourceFactory(
            ISoundCloudRawClient soundCloudRawClient,
            IPaginationValidator paginationValidator,
            ITrackConverter trackConverter,
            IUserConverter userConverter,
            IPlaylistConverter playlistConverter,
            ICommentConverter commentConverter,
            IGroupConverter groupConverter,
            IWebProfileConverter webProfileConverter,
            IConnectionConverter connectionConverter,
            IActivityResultConverter activityResultConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
            this.trackConverter = trackConverter;
            this.userConverter = userConverter;
            this.playlistConverter = playlistConverter;
            this.commentConverter = commentConverter;
            this.groupConverter = groupConverter;
            this.webProfileConverter = webProfileConverter;
            this.connectionConverter = connectionConverter;
            this.activityResultConverter = activityResultConverter;
        }

        public IUserApi CreateUser(string userId)
        {
            return new UserApi(userId, soundCloudRawClient, paginationValidator, userConverter, trackConverter, playlistConverter, commentConverter, groupConverter, webProfileConverter);
        }

        public IUsersApi CreateUsers()
        {
            return new UsersApi(soundCloudRawClient, paginationValidator, userConverter);
        }

        public ITrackApi CreateTrack(string trackId)
        {
            return new TrackApi(trackId, soundCloudRawClient, paginationValidator, trackConverter, userConverter, commentConverter);
        }

        public ITracksApi CreateTracks()
        {
            return new TracksApi(soundCloudRawClient, paginationValidator, trackConverter);
        }

        public IPlaylistApi CreatePlaylist(string playlistId)
        {
            return new PlaylistApi(playlistId, soundCloudRawClient, playlistConverter);
        }

        public IMeApi CreateMe()
        {
            return new MeApi(soundCloudRawClient, paginationValidator, userConverter, trackConverter, playlistConverter, commentConverter, groupConverter, webProfileConverter, connectionConverter,
                             activityResultConverter);
        }

        public ICommentApi CreateComment(string commentId)
        {
            return new CommentApi(commentId, soundCloudRawClient, commentConverter);
        }
    }
}