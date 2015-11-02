using Newtonsoft.Json;
using SoundCloud.API.Client.Objects;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class TrackCollection
    {
        [JsonProperty(PropertyName = "collection")]
        public List<Track> Tracks { get; set; }
    }
}
