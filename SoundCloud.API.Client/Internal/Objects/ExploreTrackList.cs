using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ExploreTrackList
    {
        public ExploreTrackList()
        {
            Tracks = new Track[0];
        }

        [JsonProperty(PropertyName = "tracks", NullValueHandling = NullValueHandling.Ignore)]
        public Track[] Tracks { get; set; }
    }
}
