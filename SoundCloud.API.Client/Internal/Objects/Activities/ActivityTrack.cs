using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects.Activities
{
    internal class ActivityTrack : ActivityBase, IActivity<Track>
    {
        [JsonProperty(PropertyName = "origin", NullValueHandling = NullValueHandling.Ignore)]
        public Track Origin { get; set; }
    }
}