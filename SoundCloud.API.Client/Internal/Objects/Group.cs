using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Group
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "creator")]
        public User Creator { get; set; }
    }
}