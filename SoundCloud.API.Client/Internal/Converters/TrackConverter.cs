using System;
using SoundCloud.API.Client.Internal.Converters.Infrastructure;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class TrackConverter : ITrackConverter
    {
        private readonly IUserConverter userConverter;
        private readonly ITagListConverter tagListConverter;
        private readonly IApplicationConverter applicationConverter;
        private readonly IDateTimeConverter dateTimeConverter;
        
        internal TrackConverter(IUserConverter userConverter, ITagListConverter tagListConverter, IApplicationConverter applicationConverter, IDateTimeConverter dateTimeConverter)
        {
            this.userConverter = userConverter;
            this.tagListConverter = tagListConverter;
            this.applicationConverter = applicationConverter;
            this.dateTimeConverter = dateTimeConverter;
        }

        public SCTrack Convert(Track track)
        {
            if (track == null)
            {
                return null;
            }

            return new SCTrack
            {
                Id = track.Id,
                CreatedAt = dateTimeConverter.Convert(track.CreatedAt),
                UserId = track.UserId,
                User = userConverter.Convert(track.User),
                Title = track.Title,
                Permalink = track.Permalink,
                PermalinkUrl = track.PermalinkUrl,
                Uri = track.Uri,
                Sharing = track.Sharing.GetValue<SCSharing>(),
                EmbeddableBy = track.EmbeddableBy.GetValue<SCEmbeddableBy>(),
                Artwork = SCScalableEntity<SCArtworkFormat>.Create(track.Artwork),
                Description = track.Description,
                Label = userConverter.Convert(track.Label),
                Duration = TimeSpan.FromMilliseconds(track.Duration),
                Genre = track.Genre,
                TagList = tagListConverter.Convert(track.TagList),
                LabelId = track.LabelId,
                LabelName = track.LabelName,
                ReleaseNumber = track.Release,
                ReleaseDate = dateTimeConverter.ConvertReleaseDate(track.ReleaseYear, track.ReleaseMonth, track.ReleaseDay),
                Streamable = track.Streamable,
                Downloadable = track.Downloadable,
                State = track.State.GetValue<SCState>(),
                License = track.License.GetValue<SCLicense>(),
                TrackType = track.TrackType.GetValue<SCTrackType>(),
                WaveformUrl = track.WaveformUrl,
                DownloadUrl = track.DownloadUrl,
                StreamUrl = track.StreamUrl,
                VideoUrl = track.VideoUrl,
                Bpm = track.Bpm,
                Commentable = track.Commentable,
                Isrc = track.Isrc,
                KeySignature = track.KeySignature,
                CommentsCount = track.CommentsCount,
                DownloadCount = track.DownloadCount,
                PlaybackCount = track.PlaybackCount,
                FavoritingsCount = track.FavoritingsCount,
                OriginalFormat = track.OriginalFormat,
                OriginalContentSize = track.OriginalContentSize,
                CreatedWith = applicationConverter.Convert(track.CreatedWith),
                UserFavorite = track.UserFavorite,
                AttachmentUri = track.AttachmentUri,
                DownloadsRemaining = track.DownloadsRemaining,
                PurchaseUrl = track.PurchaseUrl,
                SecretToken = track.SecretToken,
                SecretUri = track.SecretUri,
                UserPlaybackCount = track.UserPlaybackCount
            };
        }
        
        public Track Convert(SCTrack track)
        {
            if (track == null)
            {
                return null;
            }

            return new Track
            {
                Id = track.Id,
                CreatedAt = dateTimeConverter.Convert(track.CreatedAt),
                UserId = track.UserId,
                User = userConverter.Convert(track.User),
                Title = track.Title,
                Permalink = track.Permalink,
                PermalinkUrl = track.PermalinkUrl,
                Uri = track.Uri,
                Sharing = track.Sharing.GetParameterName(),
                EmbeddableBy = track.EmbeddableBy.GetParameterName(),
                Artwork = track.Artwork == null ? null : track.Artwork.Url(),
                Description = track.Description,
                Label = userConverter.Convert(track.Label),
                Duration = (int)track.Duration.TotalMilliseconds,
                Genre = track.Genre,
                TagList = tagListConverter.Convert(track.TagList),
                LabelId = track.LabelId,
                LabelName = track.LabelName,
                Release = track.ReleaseNumber,
                ReleaseYear = track.ReleaseDate.SafeGet<DateTimeOffset, int>(x => x.Year),
                ReleaseMonth = track.ReleaseDate.SafeGet<DateTimeOffset, int>(x => x.Month),
                ReleaseDay = track.ReleaseDate.SafeGet<DateTimeOffset, int>(x => x.Day),
                Streamable = track.Streamable,
                Downloadable = track.Downloadable,
                State = track.State.GetParameterName(),
                License = track.License.GetParameterName(),
                TrackType = track.TrackType.GetParameterName(),
                WaveformUrl = track.WaveformUrl,
                DownloadUrl = track.DownloadUrl,
                StreamUrl = track.StreamUrl,
                VideoUrl = track.VideoUrl,
                Bpm = track.Bpm,
                Commentable = track.Commentable,
                Isrc = track.Isrc,
                KeySignature = track.KeySignature,
                CommentsCount = track.CommentsCount,
                DownloadCount = track.DownloadCount,
                PlaybackCount = track.PlaybackCount,
                FavoritingsCount = track.FavoritingsCount,
                OriginalFormat = track.OriginalFormat,
                OriginalContentSize = track.OriginalContentSize,
                CreatedWith = applicationConverter.Convert(track.CreatedWith),
                UserFavorite = track.UserFavorite,
                AttachmentUri = track.AttachmentUri,
                DownloadsRemaining = track.DownloadsRemaining,
                PurchaseUrl = track.PurchaseUrl,
                SecretToken = track.SecretToken,
                SecretUri = track.SecretUri,
                UserPlaybackCount = track.UserPlaybackCount
            };
        }
    }
}