using SoundCloud.API.Client.Internal.Converters.Infrastructure;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class GroupConverter : IGroupConverter
    {
        private readonly IDateTimeConverter dateTimeConverter;
        private readonly IUserConverter userConverter;
        internal static readonly IGroupConverter Default = new GroupConverter(DateTimeConverter.Default, UserConverter.Default);

        private GroupConverter(IDateTimeConverter dateTimeConverter, IUserConverter userConverter)
        {
            this.dateTimeConverter = dateTimeConverter;
            this.userConverter = userConverter;
        }

        public SCGroup Convert(Group @group)
        {
            if (@group == null)
            {
                return null;
            }

            return new SCGroup
            {
                Id = @group.Id,
                Artwork = SCScalableEntity<SCArtworkFormat>.Create(@group.ArtworkUrl),
                CreatedAt = dateTimeConverter.Convert(@group.CreatedAt),
                Uri = @group.Uri,
                Description = @group.Description,
                Permalink = @group.Permalink,
                PermalinkUrl = @group.PermalinkUrl,
                Creator = userConverter.Convert(@group.Creator),
                Name = @group.Name,
                ShortDescription = @group.Description
            };
        }

        public Group Convert(SCGroup @group)
        {
            if (@group == null)
            {
                return null;
            }

            return new Group
            {
                Id = @group.Id,
                ArtworkUrl = @group.Artwork.Url(),
                CreatedAt = dateTimeConverter.Convert(@group.CreatedAt),
                Uri = @group.Uri,
                Description = @group.Description,
                Permalink = @group.Permalink,
                PermalinkUrl = @group.PermalinkUrl,
                Creator = userConverter.Convert(@group.Creator),
                Name = @group.Name,
                ShortDescription = @group.Description
            };
        }
    }
}