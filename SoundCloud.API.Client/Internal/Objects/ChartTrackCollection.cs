using Newtonsoft.Json;
using SoundCloud.API.Client.Internal.Objects.Interfaces;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ChartTrackCollection : IEntityCollection<ChartTrack>
    {
        public ChartTrackCollection()
        {
            Collection = new ChartTrack[0];
        }

        [JsonProperty(PropertyName = "collection", NullValueHandling = NullValueHandling.Ignore)]
        public ChartTrack[] Collection { get; set; }
    }
}
