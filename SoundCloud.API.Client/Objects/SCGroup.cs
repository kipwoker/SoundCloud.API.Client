using System;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Objects
{
    public class SCGroup
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string Permalink { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
        public SCScalableEntity<SCArtworkFormat> Artwork { get; set; }
        public string PermalinkUrl { get; set; }
        public SCUser Creator { get; set; } 
    }
}