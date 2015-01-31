using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Playlist
    {
        public Playlist()
        {
            Tracks = new Track[0];
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        public string Sharing { get; set; }

        [JsonProperty(PropertyName = "tag_list")]
        public string TagList { get; set; }

        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "streamable")]
        public bool? Streamabale { get; set; }

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

        [JsonProperty(PropertyName = "label")]
        public User Label { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "playlist_type")]
        public string PlaylistType { get; set; }

        [JsonProperty(PropertyName = "ean")]
        public string Ean { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "release_year")]
        public int? ReleaseYear { get; set; }

        [JsonProperty(PropertyName = "release_month")]
        public int? ReleaseMonth { get; set; }

        [JsonProperty(PropertyName = "release_day")]
        public int? ReleaseDay { get; set; }

        [JsonProperty(PropertyName = "license")]
        public string License { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        [JsonProperty(PropertyName = "tracks")]
        public Track[] Tracks { get; set; }

        [JsonProperty(PropertyName = "embeddable_by")]
        public string EmbeddableBy { get; set; }
    }
}