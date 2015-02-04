using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Connection
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "service")]
        public string Service { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "post_favorite")]
        public bool PostFavorite { get; set; }

        [JsonProperty(PropertyName = "post_publish")]
        public bool PostPublish { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; } 
    }
}