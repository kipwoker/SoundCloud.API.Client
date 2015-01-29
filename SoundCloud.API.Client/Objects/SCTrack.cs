using System;
using System.Globalization;
using Newtonsoft.Json;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Objects
{
    public class SCTrack
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        private string createdAt;

        public DateTimeOffset CreatedAt
        {
            get { return DateTimeOffset.Parse(createdAt); }
            set { createdAt = value.UtcDateTime.ToString(CultureInfo.InvariantCulture); }
        }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "duration")] 
        private int duration;

        public TimeSpan Duration
        {
            get { return TimeSpan.FromMilliseconds(duration); }
            set { duration = (int)value.TotalMilliseconds; }
        }

        [JsonProperty(PropertyName = "commentable")]
        public bool Commentable { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        public string Sharing { get; set; }

        [JsonProperty(PropertyName = "tag_list")]
        private string tagList;

        public SCTagList TagList
        {
            get { return SCTagListSerializer.Deserialize(tagList); }
            set { tagList = SCTagListSerializer.Serialize(value); }
        }

        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "streamable")]
        public bool? Streamable { get; set; }

        [JsonProperty(PropertyName = "downloadable")]
        public bool? Downloadable { get; set; }

        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "release")]
        public string Release { get; set; }

        [JsonProperty(PropertyName = "purchase_url")]
        public string PurchaseUrl { get; set; }

        [JsonProperty(PropertyName = "label_id")]
        public string LabelId { get; set; }

        [JsonProperty(PropertyName = "label_name")]
        public string LabelName { get; set; }

        [JsonProperty(PropertyName = "isrc")]
        public string Isrc { get; set; }

        [JsonProperty(PropertyName = "video_url")]
        public string VideoUrl { get; set; }

        [JsonProperty(PropertyName = "track_type")]
        public string TrackType { get; set; }

        [JsonProperty(PropertyName = "key_signature")]
        public string KeySignature { get; set; }

        [JsonProperty(PropertyName = "bpm")]
        public float? Bpm { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "release_year")]
        public string ReleaseYear { get; set; }

        [JsonProperty(PropertyName = "release_month")]
        public string ReleaseMonth { get; set; }

        [JsonProperty(PropertyName = "release_day")]
        public string ReleaseDay { get; set; }

        [JsonProperty(PropertyName = "original_format")]
        public string OriginalFormat { get; set; }

        [JsonProperty(PropertyName = "license")] 
        private string license;

        public SCLicense License
        {
            get { return license.GetValue<SCLicense>(); }
            set { license = value.GetParameterName(); }
        }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "artwork_url")]
        public string Artwork { get; set; }

        [JsonProperty(PropertyName = "waveform_url")]
        public string WaveForm { get; set; }

        [JsonProperty(PropertyName = "user")]
        public SCUser User { get; set; }

        [JsonProperty(PropertyName = "stream_url")]
        public string StreamUrl { get; set; }

        [JsonProperty(PropertyName = "download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty(PropertyName = "downloads_remaining")]
        public int DownloadsRemaining { get; set; }

        [JsonProperty(PropertyName = "secret_token")]
        public string SecretToken { get; set; }

        [JsonProperty(PropertyName = "secret_uri")]
        public string SecretUri { get; set; }

        [JsonProperty(PropertyName = "user_playback_count")]
        public int UserPlaybackCount { get; set; }

        [JsonProperty(PropertyName = "user_favorite")]
        public bool UserFavorite { get; set; }

        [JsonProperty(PropertyName = "playback_count")]
        public int PlaybackCount { get; set; }

        [JsonProperty(PropertyName = "download_count")]
        public int DownloadCount { get; set; }

        [JsonProperty(PropertyName = "favoritings_count")]
        public int FavoritingsCount { get; set; }

        [JsonProperty(PropertyName = "comment_count")]
        public int CommentsCount { get; set; }

        [JsonProperty(PropertyName = "attachments_uri")]
        public string AttachmentUri { get; set; }
    }
}