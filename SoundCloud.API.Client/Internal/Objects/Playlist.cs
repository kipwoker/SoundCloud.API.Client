using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Playlist
    {
        public Playlist()
        {
            Tracks = new Track[0];
        }

        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "duration", NullValueHandling = NullValueHandling.Ignore)]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "sharing", NullValueHandling = NullValueHandling.Ignore)]
        public string Sharing { get; set; }

        [JsonProperty(PropertyName = "tag_list", NullValueHandling = NullValueHandling.Ignore)]
        public string TagList { get; set; }

        [JsonProperty(PropertyName = "permalink", NullValueHandling = NullValueHandling.Ignore)]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "streamable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Streamabale { get; set; }

        [JsonProperty(PropertyName = "downloadable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Downloadable { get; set; }

        [JsonProperty(PropertyName = "genre", NullValueHandling = NullValueHandling.Ignore)]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "release", NullValueHandling = NullValueHandling.Ignore)]
        public string Release { get; set; }

        [JsonProperty(PropertyName = "purchase_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PurchaseUrl { get; set; }

        [JsonProperty(PropertyName = "label_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LabelId { get; set; }

        [JsonProperty(PropertyName = "label_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LabelName { get; set; }

        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)]
        public User Label { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "playlist_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PlaylistType { get; set; }

        [JsonProperty(PropertyName = "ean", NullValueHandling = NullValueHandling.Ignore)]
        public string Ean { get; set; }

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "release_year", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReleaseYear { get; set; }

        [JsonProperty(PropertyName = "release_month", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReleaseMonth { get; set; }

        [JsonProperty(PropertyName = "release_day", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReleaseDay { get; set; }

        [JsonProperty(PropertyName = "license", NullValueHandling = NullValueHandling.Ignore)]
        public string License { get; set; }

        [JsonProperty(PropertyName = "uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "artwork_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ArtworkUrl { get; set; }

        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }

        [JsonProperty(PropertyName = "tracks", NullValueHandling = NullValueHandling.Ignore)]
        public Track[] Tracks { get; set; }

        [JsonProperty(PropertyName = "embeddable_by", NullValueHandling = NullValueHandling.Ignore)]
        public string EmbeddableBy { get; set; }
    }
}