using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects.Activities
{
    internal class ActivityTrack : ActivityBase, IActivity<Track>
    {
        [JsonProperty(PropertyName = "origin")]
        public Track Origin { get; set; }
    }
}