using System;
using SoundCloud.API.Client.Objects.ConnectionPieces;

namespace SoundCloud.API.Client.Objects
{
    public class SCConnection
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public SCServiceType Service { get; set; }
        public string Type { get; set; }
        public bool PostFavorite { get; set; }
        public bool PostPublish { get; set; }
        public string Uri { get; set; } 
    }
}