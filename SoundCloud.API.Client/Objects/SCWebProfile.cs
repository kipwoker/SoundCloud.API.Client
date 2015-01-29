using System;
using System.Globalization;
using Newtonsoft.Json;

namespace SoundCloud.API.Client.Objects
{
    public class SCWebProfile
    {
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "service")]
        public string Service { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        private string createdAt { get; set; }

        public DateTime CreatedAt
        {
            get { return (DateTime.Parse(createdAt)); }
            set { createdAt = value.ToString(CultureInfo.InvariantCulture); }
        }
    }
}