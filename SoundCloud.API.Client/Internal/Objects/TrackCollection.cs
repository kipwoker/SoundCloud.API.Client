using Newtonsoft.Json;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class TrackCollection
    {
        [JsonProperty(PropertyName = "collection")]
        public List<Track> Tracks { get; set; }
    }
}
