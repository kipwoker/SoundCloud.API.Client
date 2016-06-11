using Newtonsoft.Json;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class ExploreCategoryList
    {
        [JsonProperty(PropertyName = "music")]
        public List<string> MusicCategoryNames { get; set; }

        [JsonProperty(PropertyName = "audio")]
        public List<string> AudioCategoryNames { get; set; }
    }
}
