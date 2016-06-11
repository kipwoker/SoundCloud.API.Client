using Newtonsoft.Json;

namespace SoundCloud.API.Client.Objects
{
    public class SCOEmbed
    {
        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "provider_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ProviderName { get; set; }

        [JsonProperty(PropertyName = "provider_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ProviderUrl { get; set; }

        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public string Height { get; set; }

        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public string Width { get; set; }

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "html", NullValueHandling = NullValueHandling.Ignore)]
        public string Html { get; set; }
    }
}