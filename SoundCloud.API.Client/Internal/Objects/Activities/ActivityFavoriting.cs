using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects.Activities
{
    internal class ActivityFavoriting : ActivityBase, IActivity<User>
    {
        [JsonProperty(PropertyName = "origin")]
        public User Origin { get; set; }
    }
}