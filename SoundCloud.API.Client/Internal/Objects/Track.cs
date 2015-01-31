using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Track
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "commentable")]
        public bool Commentable { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        public string Sharing { get; set; }

        [JsonProperty(PropertyName = "embeddable_by")]
        public string EmbeddableBy { get; set; }

        [JsonProperty(PropertyName = "tag_list")]
        public string TagList { get; set; }

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

        [JsonProperty(PropertyName = "label")] 
        public User Label { get; set; }

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
        public int? ReleaseYear { get; set; }

        [JsonProperty(PropertyName = "release_month")]
        public int? ReleaseMonth { get; set; }

        [JsonProperty(PropertyName = "release_day")]
        public int? ReleaseDay { get; set; }

        [JsonProperty(PropertyName = "original_format")]
        public string OriginalFormat { get; set; }

        [JsonProperty(PropertyName = "license")]
        public string License { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "artwork_url")]
        public string Artwork { get; set; }

        [JsonProperty(PropertyName = "waveform_url")]
        public string WaveformUrl { get; set; }

        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        [JsonProperty(PropertyName = "stream_url")]
        public string StreamUrl { get; set; }

        [JsonProperty(PropertyName = "download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty(PropertyName = "downloads_remaining")]
        public int? DownloadsRemaining { get; set; }

        [JsonProperty(PropertyName = "secret_token")]
        public string SecretToken { get; set; }

        [JsonProperty(PropertyName = "secret_uri")]
        public string SecretUri { get; set; }

        [JsonProperty(PropertyName = "user_playback_count")]
        public int? UserPlaybackCount { get; set; }

        [JsonProperty(PropertyName = "user_favorite")]
        public bool? UserFavorite { get; set; }

        [JsonProperty(PropertyName = "playback_count")]
        public int? PlaybackCount { get; set; }

        [JsonProperty(PropertyName = "download_count")]
        public int DownloadCount { get; set; }

        [JsonProperty(PropertyName = "favoritings_count")]
        public int FavoritingsCount { get; set; }

        [JsonProperty(PropertyName = "comment_count")]
        public int CommentsCount { get; set; }

        [JsonProperty(PropertyName = "attachments_uri")]
        public string AttachmentUri { get; set; }

        [JsonProperty(PropertyName = "original_content_size")]
        public long? OriginalContentSize { get; set; }

        [JsonProperty(PropertyName = "created_with")]
        public Application CreatedWith { get; set; }
    }
}