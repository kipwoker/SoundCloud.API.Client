using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class UnsavedConnection
    {
        [JsonProperty(PropertyName = "authorize_url")]
        public string AuthorizeUrl { get; set; }
    }
}