using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class WebProfile
    {
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "service")]
        public string Service { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; } 
    }
}