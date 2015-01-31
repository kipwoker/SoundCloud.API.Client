using System;
using System.Linq;
using SoundCloud.API.Client.Internal.Converters.Infrastructure;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.PlaylistPieces;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class PlaylistConverter : IPlaylistConverter
    {
        private readonly IUserConverter userConverter;
        private readonly ITrackConverter trackConverter;
        private readonly ITagListConverter tagListConverter;
        private readonly IDateTimeConverter dateTimeConverter;
        internal static readonly IPlaylistConverter Default = new PlaylistConverter(UserConverter.Default, TrackConverter.Default, TagListConverter.Default, DateTimeConverter.Default);

        private PlaylistConverter(IUserConverter userConverter, ITrackConverter trackConverter, ITagListConverter tagListConverter, IDateTimeConverter dateTimeConverter)
        {
            this.userConverter = userConverter;
            this.trackConverter = trackConverter;
            this.tagListConverter = tagListConverter;
            this.dateTimeConverter = dateTimeConverter;
        }

        public SCPlaylist Convert(Playlist playlist)
        {
            if (playlist == null)
            {
                return null;
            }

            return new SCPlaylist
            {
                Id = playlist.Id,
                CreatedAt = dateTimeConverter.Convert(playlist.CreatedAt),
                UserId = playlist.UserId,
                User = userConverter.Convert(playlist.User),
                Title = playlist.Title,
                Permalink = playlist.Permalink,
                PermalinkUrl = playlist.PermalinkUrl,
                Uri = playlist.Uri,
                Sharing = playlist.Sharing.GetValue<SCSharing>(),
                EmbeddableBy = playlist.EmbeddableBy.GetValue<SCEmbeddableBy>(),
                PurchaseUrl = playlist.PurchaseUrl,
                Artwork = SCScalableEntity<SCArtworkFormat>.Create(playlist.ArtworkUrl),
                Description = playlist.Description,
                Label = userConverter.Convert(playlist.Label),
                LabelId = playlist.LabelId,
                LabelName = playlist.LabelName,
                Duration = TimeSpan.FromMilliseconds(playlist.Duration),
                Genre = playlist.Genre,
                TagList = tagListConverter.Convert(playlist.TagList),
                Release = playlist.Release,
                ReleaseDate = dateTimeConverter.ConvertReleaseDate(playlist.ReleaseYear, playlist.ReleaseMonth, playlist.ReleaseDay),
                Streamabale = playlist.Streamabale,
                Downloadable = playlist.Downloadable,
                Ean = playlist.Ean,
                PlaylistType = playlist.PlaylistType.GetValue<SCPlaylistType>(),
                License = playlist.License.GetValue<SCLicense>(),
                Tracks = playlist.Tracks.Select(trackConverter.Convert).ToArray(),
                Type = playlist.Type.GetValue<SCTrackType>()
            };
        }

        public Playlist Convert(SCPlaylist playlist)
        {
            if (playlist == null)
            {
                return null;
            }

            return new Playlist
            {
                Id = playlist.Id,
                CreatedAt = dateTimeConverter.Convert(playlist.CreatedAt),
                UserId = playlist.UserId,
                User = userConverter.Convert(playlist.User),
                Title = playlist.Title,
                Permalink = playlist.Permalink,
                PermalinkUrl = playlist.PermalinkUrl,
                Uri = playlist.Uri,
                Sharing = playlist.Sharing.GetParameterName(),
                EmbeddableBy = playlist.Sharing.GetParameterName(),
                PurchaseUrl = playlist.PurchaseUrl,
                ArtworkUrl = playlist.Artwork == null? null : playlist.Artwork.Url(),
                Description = playlist.Description,
                Label = userConverter.Convert(playlist.Label),
                LabelId = playlist.LabelId,
                LabelName = playlist.LabelName,
                Duration = (int)playlist.Duration.TotalMilliseconds,
                Genre = playlist.Genre,
                TagList = tagListConverter.Convert(playlist.TagList),
                Release = playlist.Release,
                ReleaseYear = playlist.ReleaseDate.SafeGet<DateTimeOffset, int>(x => x.Year),
                ReleaseMonth = playlist.ReleaseDate.SafeGet<DateTimeOffset, int>(x => x.Month),
                ReleaseDay = playlist.ReleaseDate.SafeGet<DateTimeOffset, int>(x => x.Day),
                Streamabale = playlist.Streamabale,
                Downloadable = playlist.Downloadable,
                Ean = playlist.Ean,
                PlaylistType = playlist.PlaylistType.GetParameterName(),
                License = playlist.License.GetParameterName(),
                Tracks = playlist.Tracks.Select(trackConverter.Convert).ToArray(),
                Type = playlist.Type.GetParameterName()
            };
        }
    }
}