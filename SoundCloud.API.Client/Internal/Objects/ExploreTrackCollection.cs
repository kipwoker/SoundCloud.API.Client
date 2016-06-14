using Newtonsoft.Json;
using SoundCloud.API.Client.Internal.Objects.Interfaces;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ExploreTrackCollection : IEntityCollection<Track>
    {
        public ExploreTrackCollection()
        {
            Collection = new Track[0];
        }

        [JsonProperty(PropertyName = "tracks", NullValueHandling = NullValueHandling.Ignore)]
        public Track[] Collection { get; set; }
    }
}
