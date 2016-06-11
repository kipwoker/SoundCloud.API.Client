using Newtonsoft.Json;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ChartTrackList
    {
        public ChartTrackList()
        {
            Tracks = new List<ChartTrack>();
        }

        [JsonProperty(PropertyName = "collection", NullValueHandling = NullValueHandling.Ignore)]
        public List<ChartTrack> Tracks { get; set; }
    }
}
