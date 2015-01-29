using SoundCloud.API.Client.Objects.UserPieces;

namespace SoundCloud.API.Client.Objects
{
    public class SCUser
    {
        public string Id { get; set; }
        public string Permalink { get; set; }
        public string UserName { get; set; }
        public string Uri { get; set; }
        public string PermalinkUrl { get; set; }
        public SCScalableEntity<SCAvatarFormat> Avatar { get; set; }
        public string Country { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Discogs { get; set; }
        public string Myspace { get; set; }
        public string WebsiteUrl { get; set; }
        public string WebsiteTitle { get; set; }
        public bool? IsOnline { get; set; }
        public int TrackCount { get; set; }
        public int PlaylistCount { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public int FavoriteCount { get; set; }
        public string Plan { get; set; }
        public int? PrivateTrackCount { get; set; }
        public int? PrivatePlaylistCount { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}