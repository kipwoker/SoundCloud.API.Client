using System;
using System.Globalization;
using Newtonsoft.Json;

namespace SoundCloud.API.Client.Objects
{
    public class SCComment
    {
        [JsonProperty(PropertyName =  "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName =  "track_id")]
        public string TrackId { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string createdAt;

        public DateTime CreatedAt
        {
            get { return (DateTime.Parse(createdAt)); }
            set { createdAt = value.ToString(CultureInfo.InvariantCulture); }
        }

        [JsonProperty(PropertyName =  "timestamp")]
        private int timestamp;

        public TimeSpan Timestamp
        {
            get { return TimeSpan.FromMilliseconds(timestamp); }
            set { timestamp = (int)value.TotalMilliseconds; }
        }

        [JsonProperty(PropertyName =  "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName =  "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName =  "user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName =  "user")]
        public SCUser User { get; set; }
    }
}