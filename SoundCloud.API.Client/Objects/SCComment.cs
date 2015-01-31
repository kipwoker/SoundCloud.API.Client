using System;

namespace SoundCloud.API.Client.Objects
{
    public class SCComment
    {
        public string Id { get; set; }
        public string TrackId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public TimeSpan Timestamp { get; set; }
        public string Body { get; set; }
        public string Uri { get; set; }
        public string UserId { get; set; }
        public SCUser User { get; set; }
    }
}