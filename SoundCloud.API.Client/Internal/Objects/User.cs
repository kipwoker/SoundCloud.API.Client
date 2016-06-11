using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class User
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "permalink", NullValueHandling = NullValueHandling.Ignore)]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "username", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "permalink_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PermalinkUrl { get; set; }

        [JsonProperty(PropertyName = "avatar_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "full_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "discogs_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Discogs { get; set; }

        [JsonProperty(PropertyName = "myspace_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Myspace { get; set; }

        [JsonProperty(PropertyName = "website", NullValueHandling = NullValueHandling.Ignore)]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "website_title", NullValueHandling = NullValueHandling.Ignore)]
        public string WebsiteTitle { get; set; }

        [JsonProperty(PropertyName = "online", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOnline { get; set; }

        [JsonProperty(PropertyName = "track_count", NullValueHandling = NullValueHandling.Ignore)]
        public int TrackCount { get; set; }

        [JsonProperty(PropertyName = "playlist_count", NullValueHandling = NullValueHandling.Ignore)]
        public int PlaylistCount { get; set; }

        [JsonProperty(PropertyName = "followers_count", NullValueHandling = NullValueHandling.Ignore)]
        public int FollowerCount { get; set; }

        [JsonProperty(PropertyName = "followings_count", NullValueHandling = NullValueHandling.Ignore)]
        public int FollowingCount { get; set; }

        [JsonProperty(PropertyName = "public_favorites_count", NullValueHandling = NullValueHandling.Ignore)]
        public int FavoriteCount { get; set; }

        [JsonProperty(PropertyName = "plan", NullValueHandling = NullValueHandling.Ignore)]
        public string Plan { get; set; }

        [JsonProperty(PropertyName = "private_tracks_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? PrivateTrackCount { get; set; }

        [JsonProperty(PropertyName = "private_playlists_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? PrivatePlaylistCount { get; set; }

        [JsonProperty(PropertyName = "primary_email_confirmed", NullValueHandling = NullValueHandling.Ignore)]
        public bool EmailConfirmed { get; set; }
    }
}