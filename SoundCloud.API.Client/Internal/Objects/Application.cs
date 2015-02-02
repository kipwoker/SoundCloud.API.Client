using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Application
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty(PropertyName = "creator")]
        public string Creator { get; set; }
    }
}