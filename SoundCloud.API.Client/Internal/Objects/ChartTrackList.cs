using Newtonsoft.Json;
using SoundCloud.API.Client.Objects;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ChartTrackList
    {
        [JsonProperty(PropertyName = "collection", NullValueHandling = NullValueHandling.Ignore)]
        public List<ChartTrack> Tracks { get; set; }
    }
}
