using System;

namespace SoundCloud.API.Client.Objects.Auth
{
    public class SCAccessToken
    {
        public string AccessToken { get; set; }
        public TimeSpan ExpiresIn { get; set; }
        public SCScope Scope { get; set; }
        public string RefreshToken { get; set; }
    }
}