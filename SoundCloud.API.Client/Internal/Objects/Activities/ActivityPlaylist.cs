using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects.Activities
{
    internal class ActivityPlaylist : ActivityBase, IActivity<Playlist>
    {
        [JsonProperty(PropertyName = "origin")]
        public Playlist Origin { get; set; }
    }
}