using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class UnsavedConnection
    {
        [JsonProperty(PropertyName = "authorize_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizeUrl { get; set; }
    }
}