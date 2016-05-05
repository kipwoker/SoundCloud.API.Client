using Newtonsoft.Json;
using System.ComponentModel;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Track
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "duration", NullValueHandling = NullValueHandling.Ignore)]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "commentable", NullValueHandling = NullValueHandling.Ignore)]
        public bool Commentable { get; set; }

        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty(PropertyName = "sharing", NullValueHandling = NullValueHandling.Ignore)]
        public string Sharing { get; set; }

        [JsonProperty(PropertyName = "embeddable_by", NullValueHandling = NullValueHandling.Ignore)]
        public string EmbeddableBy { get; set; }

        [JsonProperty(PropertyName = "tag_list", NullValueHandling = NullValueHandling.Ignore)]
        public string TagList { get; set; }

        [JsonProperty(PropertyName = "permalink", NullValueHandling = NullValueHandling.Ignore)]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "streamable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Streamable { get; set; }

        [JsonProperty(PropertyName = "downloadable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Downloadable { get; set; }

        [JsonProperty(PropertyName = "genre", NullValueHandling = NullValueHandling.Ignore)]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "release", NullValueHandling = NullValueHandling.Ignore)]
        public string Release { get; set; }

        [JsonProperty(PropertyName = "purchase_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PurchaseUrl { get; set; }

        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)] 
        public User Label { get; set; }

        [JsonProperty(PropertyName = "label_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LabelId { get; set; }

        [JsonProperty(PropertyName = "label_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LabelName { get; set; }

        [JsonProperty(PropertyName = "isrc", NullValueHandling = NullValueHandling.Ignore)]
        public string Isrc { get; set; }

        [JsonProperty(PropertyName = "video_url", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoUrl { get; set; }

        [JsonProperty(PropertyName = "track_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackType { get; set; }

        [JsonProperty(PropertyName = "key_signature", NullValueHandling = NullValueHandling.Ignore)]
        public string KeySignature { get; set; }

        [JsonProperty(PropertyName = "bpm", NullValueHandling = NullValueHandling.Ignore)]
        public float? Bpm { get; set; }

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "release_year", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReleaseYear { get; set; }

        [JsonProperty(PropertyName = "release_month", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReleaseMonth { get; set; }

        [JsonProperty(PropertyName = "release_day", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReleaseDay { get; set; }

        [JsonProperty(PropertyName = "original_format", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalFormat { get; set; }

        [JsonProperty(PropertyName = "license", NullValueHandling = NullValueHandling.Ignore)]
        public string License { get; set; }

        [JsonProperty(PropertyName = "uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "artwork_url", NullValueHandling = NullValueHandling.Ignore)]
        public string Artwork { get; set; }

        [JsonProperty(PropertyName = "waveform_url", NullValueHandling = NullValueHandling.Ignore)]
        public string WaveformUrl { get; set; }

        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }

        [JsonProperty(PropertyName = "stream_url", NullValueHandling = NullValueHandling.Ignore)]
        public string StreamUrl { get; set; }

        [JsonProperty(PropertyName = "download_url", NullValueHandling = NullValueHandling.Ignore)]
        public string DownloadUrl { get; set; }

        [JsonProperty(PropertyName = "downloads_remaining", NullValueHandling = NullValueHandling.Ignore)]
        public int? DownloadsRemaining { get; set; }

        [JsonProperty(PropertyName = "secret_token", NullValueHandling = NullValueHandling.Ignore)]
        public string SecretToken { get; set; }

        [JsonProperty(PropertyName = "secret_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string SecretUri { get; set; }

        [JsonProperty(PropertyName = "user_playback_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? UserPlaybackCount { get; set; }

        [JsonProperty(PropertyName = "user_favorite", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UserFavorite { get; set; }

        [JsonProperty(PropertyName = "playback_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? PlaybackCount { get; set; }

        [JsonProperty(PropertyName = "download_count", NullValueHandling = NullValueHandling.Ignore), DefaultValue(0)]
        public int DownloadCount { get; set; }

        [JsonProperty(PropertyName = "favoritings_count", NullValueHandling = NullValueHandling.Ignore)]
        public int FavoritingsCount { get; set; }

        [JsonProperty(PropertyName = "comment_count", NullValueHandling = NullValueHandling.Ignore)]
        public int CommentsCount { get; set; }

        [JsonProperty(PropertyName = "attachments_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentUri { get; set; }

        [JsonProperty(PropertyName = "original_content_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? OriginalContentSize { get; set; }

        [JsonProperty(PropertyName = "created_with", NullValueHandling = NullValueHandling.Ignore)]
        public Application CreatedWith { get; set; }
    }
}