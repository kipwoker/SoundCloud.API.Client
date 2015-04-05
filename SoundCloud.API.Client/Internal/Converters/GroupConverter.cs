using SoundCloud.API.Client.Internal.Converters.Infrastructure;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class GroupConverter : IGroupConverter
    {
        private readonly IUserConverter userConverter;
        private readonly IDateTimeConverter dateTimeConverter;

        internal GroupConverter(IUserConverter userConverter, IDateTimeConverter dateTimeConverter)
        {
            this.userConverter = userConverter;
            this.dateTimeConverter = dateTimeConverter;
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