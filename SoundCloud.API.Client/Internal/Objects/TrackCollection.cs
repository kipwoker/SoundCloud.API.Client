using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class TrackCollection
    {
        public TrackCollection()
        {
            Tracks = new Track[0];
        }

        [JsonProperty(PropertyName = "collection", NullValueHandling = NullValueHandling.Ignore)]
        public Track[] Tracks { get; set; }
    }
}
