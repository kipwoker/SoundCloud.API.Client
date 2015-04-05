using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Converters.Infrastructure;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Subresources.Factories;

namespace SoundCloud.API.Client.Factories
{
    internal class SubresourceFactoryBuilder : ISubresourceFactoryBuilder
    {
        private readonly IUserConverter userConverter;
        private readonly IApplicationConverter applicationConverter;
        private readonly ITrackConverter trackConverter;
        private readonly ICommentConverter commentConverter;
        private readonly IPlaylistConverter playlistConverter;
        private readonly IPaginationValidator paginationValidator;
        private readonly IGroupConverter groupConverter;
        private readonly IWebProfileConverter webProfileConverter;
        private readonly IConnectionConverter connectionConverter;
        private readonly IActivityResultConverter activityResultConverter;

        public SubresourceFactoryBuilder()
        {
            var dateTimeConverter = new DateTimeConverter();
            var tagListConverter = new TagListConverter();

            userConverter = new UserConverter();
            applicationConverter = new ApplicationConverter();
            trackConverter = new TrackConverter(userConverter, tagListConverter, applicationConverter, dateTimeConverter);
            commentConverter = new CommentConverter(userConverter, dateTimeConverter);
            playlistConverter = new PlaylistConverter(userConverter, trackConverter, tagListConverter, dateTimeConverter);
            paginationValidator = new PaginationValidator();
            groupConverter = new GroupConverter(userConverter, dateTimeConverter);
            webProfileConverter = new WebProfileConverter(dateTimeConverter);
            connectionConverter = new ConnectionConverter(dateTimeConverter);
            activityResultConverter = new ActivityResultConverter(trackConverter, commentConverter, userConverter, playlistConverter, dateTimeConverter);
        }

        public ISubresourceFactory CreateSubresourceFactory(ISoundCloudRawClient soundCloudRawClient)
        {
            return new SubresourceFactory(
                soundCloudRawClient, 
                paginationValidator, 
                trackConverter, 
                userConverter, 
                playlistConverter, 
                commentConverter, 
                groupConverter, 
                webProfileConverter, 
                connectionConverter, 
                activityResultConverter, 
                applicationConverter);
        }
    }
}