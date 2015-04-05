using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.UserPieces;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class UserConverter : IUserConverter
    {
        public SCUser Convert(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new SCUser
            {
                Id = user.Id,
                Permalink = user.Permalink,
                UserName = user.UserName,
                Uri = user.Uri,
                PermalinkUrl = user.PermalinkUrl,
                Avatar = SCScalableEntity<SCAvatarFormat>.Create(user.AvatarUrl),
                Country = user.Country,
                FullName = user.FullName,
                City = user.City,
                Description = user.Description,
                Discogs = user.Discogs,
                Myspace = user.Myspace,
                WebsiteUrl = user.Website,
                WebsiteTitle = user.WebsiteTitle,
                IsOnline = user.IsOnline,
                TrackCount = user.TrackCount,
                EmailConfirmed = user.EmailConfirmed,
                FavoriteCount = user.FavoriteCount,
                FollowerCount = user.FollowerCount,
                FollowingCount = user.FollowingCount,
                Plan = user.Plan,
                PlaylistCount = user.PlaylistCount,
                PrivatePlaylistCount = user.PrivatePlaylistCount,
                PrivateTrackCount = user.PrivateTrackCount
            };
        }

        public User Convert(SCUser user)
        {
            if (user == null)
            {
                return null;
            }

            return new User
            {
                Id = user.Id,
                Permalink = user.Permalink,
                UserName = user.UserName,
                Uri = user.Uri,
                PermalinkUrl = user.PermalinkUrl,
                AvatarUrl = user.Avatar == null ? null : user.Avatar.Url(),
                Country = user.Country,
                FullName = user.FullName,
                City = user.City,
                Description = user.Description,
                Discogs = user.Discogs,
                Myspace = user.Myspace,
                Website = user.WebsiteUrl,
                WebsiteTitle = user.WebsiteTitle,
                IsOnline = user.IsOnline,
                TrackCount = user.TrackCount,
                EmailConfirmed = user.EmailConfirmed,
                FavoriteCount = user.FavoriteCount,
                FollowerCount = user.FollowerCount,
                FollowingCount = user.FollowingCount,
                Plan = user.Plan,
                PlaylistCount = user.PlaylistCount,
                PrivatePlaylistCount = user.PrivatePlaylistCount,
                PrivateTrackCount = user.PrivateTrackCount
            };
        }
    }
}