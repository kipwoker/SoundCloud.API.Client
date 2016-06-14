using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ExploreCategoryCollection
    {
        public ExploreCategoryCollection()
        {
            MusicCategoryNames = new string[0];
            AudioCategoryNames = new string[0];
        }

        [JsonProperty(PropertyName = "music", NullValueHandling = NullValueHandling.Ignore)]
        public string[] MusicCategoryNames { get; set; }

        [JsonProperty(PropertyName = "audio", NullValueHandling = NullValueHandling.Ignore)]
        public string[] AudioCategoryNames { get; set; }
    }
}
