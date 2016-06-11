using Newtonsoft.Json;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ExploreTrackList
    {
        [JsonProperty(PropertyName = "tracks", NullValueHandling = NullValueHandling.Ignore)]
        public List<Track> Tracks { get; set; }
    }
}
