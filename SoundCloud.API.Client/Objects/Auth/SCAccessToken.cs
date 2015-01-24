using Newtonsoft.Json;

namespace SoundCloud.API.Client.Objects.Auth
{
    public class SCAccessToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}