using System;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Objects
{
    public class SCTrack
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UserId { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Commentable { get; set; }
        public SCState State { get; set; }
        public SCSharing Sharing { get; set; }
        public SCTagList TagList { get; set; }
        public string Permalink { get; set; }
        public string Description { get; set; }
        public bool? Streamable { get; set; }
        public bool? Downloadable { get; set; }
        public string Genre { get; set; }
        public string ReleaseNumber { get; set; }
        public string PurchaseUrl { get; set; }
        public SCUser Label { get; set; }
        public string LabelId { get; set; }
        public string LabelName { get; set; }
        public string Isrc { get; set; }
        public string VideoUrl { get; set; }
        public SCTrackType TrackType { get; set; }
        public string KeySignature { get; set; }
        public float? Bpm { get; set; }
        public string Title { get; set; }
        public DateTimeOffset? ReleaseDate { get; set; }
        public string OriginalFormat { get; set; }
        public SCLicense License { get; set; }
        public string Uri { get; set; }
        public string PermalinkUrl { get; set; }
        public SCScalableEntity<SCArtworkFormat> Artwork { get; set; }
        public string WaveformUrl { get; set; }
        public SCUser User { get; set; }
        public string StreamUrl { get; set; }
        public string DownloadUrl { get; set; }
        public int? DownloadsRemaining { get; set; }
        public string SecretToken { get; set; }
        public string SecretUri { get; set; }
        public int? UserPlaybackCount { get; set; }
        public bool? UserFavorite { get; set; }
        public int? PlaybackCount { get; set; }
        public int DownloadCount { get; set; }
        public int FavoritingsCount { get; set; }
        public int CommentsCount { get; set; }
        public string AttachmentUri { get; set; }
        public SCEmbeddableBy EmbeddableBy { get; set; }
        public long? OriginalContentSize { get; set; }
        public SCApplication CreatedWith { get; set; }
    }
}