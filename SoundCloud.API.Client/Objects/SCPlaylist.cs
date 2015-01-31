using System;
using SoundCloud.API.Client.Objects.PlaylistPieces;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Objects
{
    public class SCPlaylist
    {
        public SCPlaylist()
        {
            Tracks = new SCTrack[0];
        }

        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UserId { get; set; }
        public TimeSpan Duration { get; set; }
        public SCSharing Sharing { get; set; }
        public SCTagList TagList { get; set; }
        public string Permalink { get; set; }
        public string Description { get; set; }
        public bool? Streamabale { get; set; }
        public bool? Downloadable { get; set; }
        public string Genre { get; set; }
        public string Release { get; set; }
        public string PurchaseUrl { get; set; }
        public string LabelId { get; set; }
        public string LabelName { get; set; }
        public SCUser Label { get; set; }
        public SCTrackType Type { get; set; }
        public SCPlaylistType PlaylistType { get; set; }
        public string Ean { get; set; }
        public string Title { get; set; }
        public DateTimeOffset? ReleaseDate { get; set; }
        public SCLicense License { get; set; }
        public string Uri { get; set; }
        public string PermalinkUrl { get; set; }
        public SCScalableEntity<SCArtworkFormat> Artwork { get; set; }
        public SCUser User { get; set; }
        public SCTrack[] Tracks { get; set; }
        public SCEmbeddableBy EmbeddableBy { get; set; }
    }
}