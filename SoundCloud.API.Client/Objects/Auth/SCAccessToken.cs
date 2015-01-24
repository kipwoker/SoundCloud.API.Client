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
        private string scope;

        public SCScope Scope
        {
            get { return string.Equals(scope, "*") ? SCScope.Asterisk : SCScope.NonExpiring; }
            set
            {
                scope = value == SCScope.Asterisk ? "*" : "non-expiring";
            }
        }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}