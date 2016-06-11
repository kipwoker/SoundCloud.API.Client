using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Group
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "permalink", NullValueHandling = NullValueHandling.Ignore)]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "short_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortDescription { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "artwork_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ArtworkUrl { get; set; }

        [JsonProperty(PropertyName = "permalink_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "creator", NullValueHandling = NullValueHandling.Ignore)]
        public User Creator { get; set; }
    }
}