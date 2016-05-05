using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects.Activities
{
    internal abstract class ActivityBase
    {
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "tags", NullValueHandling = NullValueHandling.Ignore)]
        public string Tags { get; set; }
    }
}