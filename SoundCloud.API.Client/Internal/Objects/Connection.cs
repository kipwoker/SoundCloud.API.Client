using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Connection
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "service", NullValueHandling = NullValueHandling.Ignore)]
        public string Service { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "post_favorite", NullValueHandling = NullValueHandling.Ignore)]
        public bool PostFavorite { get; set; }

        [JsonProperty(PropertyName = "post_publish", NullValueHandling = NullValueHandling.Ignore)]
        public bool PostPublish { get; set; }

        [JsonProperty(PropertyName = "uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; } 
    }
}