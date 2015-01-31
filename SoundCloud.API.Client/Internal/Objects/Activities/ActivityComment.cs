using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects.Activities
{
    internal class ActivityComment : ActivityBase, IActivity<Comment>
    {
        [JsonProperty(PropertyName = "origin")]
        public Comment Origin { get; set; }
    }
}