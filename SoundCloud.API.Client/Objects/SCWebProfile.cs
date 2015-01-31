using System;

namespace SoundCloud.API.Client.Objects
{
    public class SCWebProfile
    {
        public string Kind { get; set; }
        public string Id { get; set; }
        public string Service { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}