using Newtonsoft.Json;
using SoundCloud.API.Client.Internal.Objects.Activities;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ActivityResult
    {
        public ActivityResult()
        {
            Activities = new ActivityBase[0];
        }

        [JsonProperty(PropertyName = "next_href", NullValueHandling = NullValueHandling.Ignore)]
        public string NextHref { get; set; }

        [JsonProperty(PropertyName = "future_href", NullValueHandling = NullValueHandling.Ignore)]
        public string FutureHref { get; set; }

        [JsonProperty(PropertyName = "collection", NullValueHandling = NullValueHandling.Ignore)]
        public ActivityBase[] Activities { get; set; }
    }
}