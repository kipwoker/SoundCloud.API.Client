using Newtonsoft.Json;
using SoundCloud.API.Client.Objects;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ExploreTrackList
    {
        [JsonProperty(PropertyName = "tracks")]
        public List<Track> Tracks { get; set; }
    }
}
