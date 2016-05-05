using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects.Activities
{
    internal class ActivityPlaylist : ActivityBase, IActivity<Playlist>
    {
        [JsonProperty(PropertyName = "origin", NullValueHandling = NullValueHandling.Ignore)]
        public Playlist Origin { get; set; }
    }
}