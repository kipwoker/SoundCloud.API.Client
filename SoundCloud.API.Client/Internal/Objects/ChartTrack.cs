using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ChartTrack
    {
        [JsonProperty(PropertyName = "track", NullValueHandling = NullValueHandling.Ignore)]
        public Track Track { get; set; }

    }
}
