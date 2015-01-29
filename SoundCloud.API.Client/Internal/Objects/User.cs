using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "discogs_name")]
        public string Discogs { get; set; }

        [JsonProperty(PropertyName = "myspace_name")]
        public string Myspace { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "website_title")]
        public string WebsiteTitle { get; set; }

        [JsonProperty(PropertyName = "online")]
        public bool? IsOnline { get; set; }

        [JsonProperty(PropertyName = "track_count")]
        public int TrackCount { get; set; }

        [JsonProperty(PropertyName = "playlist_count")]
        public int PlaylistCount { get; set; }

        [JsonProperty(PropertyName = "followers_count")]
        public int FollowerCount { get; set; }

        [JsonProperty(PropertyName = "followings_count")]
        public int FollowingCount { get; set; }

        [JsonProperty(PropertyName = "public_favorites_count")]
        public int FavoriteCount { get; set; }

        [JsonProperty(PropertyName = "plan")]
        public string Plan { get; set; }

        [JsonProperty(PropertyName = "private_tracks_count")]
        public int? PrivateTrackCount { get; set; }

        [JsonProperty(PropertyName = "private_playlists_count")]
        public int? PrivatePlaylistCount { get; set; }

        [JsonProperty(PropertyName = "primary_email_confirmed")]
        public bool EmailConfirmed { get; set; }
    }
}