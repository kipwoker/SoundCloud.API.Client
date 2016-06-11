using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class Application
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "external_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalUrl { get; set; }

        [JsonProperty(PropertyName = "creator", NullValueHandling = NullValueHandling.Ignore)]
        public string Creator { get; set; }
    }
}