using Newtonsoft.Json;

namespace SoundCloud.API.Client.Objects
{
    public class SCOEmbed
    {
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty(PropertyName = "provider_url")]
        public string ProviderUrl { get; set; }

        [JsonProperty(PropertyName = "height")]
        public string Height { get; set; }

        [JsonProperty(PropertyName = "width")]
        public string Width { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "html")]
        public string Html { get; set; }
    }
}