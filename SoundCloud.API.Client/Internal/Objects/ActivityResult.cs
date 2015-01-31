using Newtonsoft.Json;
using SoundCloud.API.Client.Internal.Objects.Activities;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ActivityResult
    {
        [JsonProperty(PropertyName = "next_href")]
        public string NextHref { get; set; }

        [JsonProperty(PropertyName = "future_href")]
        public string FutureHref { get; set; }

        [JsonProperty(PropertyName = "collection")]
        public ActivityBase[] Activities { get; set; }
    }
}