using System;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Client.Helpers
{
    internal static class Api
    {
        internal static readonly Dictionary<ApiCommand, Uri> Link = new Dictionary<ApiCommand, Uri>
        {
            //Authorization
            { ApiCommand.AuthorizationCodeFlow, new Uri("https://soundcloud.com/connect?scope=non-expiring&client_id={0}&response_type=code&redirect_uri={1}") },
            { ApiCommand.UserAgentFlow,         new Uri("https://soundcloud.com/connect?client_id={0}&response_type=token&redirect_uri={1}") },
            { ApiCommand.UserCredentialsFlow,   new Uri("https://api.soundcloud.com/oauth2/token?client_id={0}&client_secret={1}&grant_type=password&username={2}&password={3}") },
            { ApiCommand.RefreshToken,          new Uri("https://api.soundcloud.com/oauth2/token?client_id={0}&client_secret={1}&grant_type=refresh_token&refresh_token={2}") },

            //Me
            { ApiCommand.Me,                    new Uri("https://api.soundcloud.com/me.json") },
            { ApiCommand.MeTracks,              new Uri("https://api.soundcloud.com/me/tracks.json") },
            { ApiCommand.MeComments,            new Uri("https://api.soundcloud.com/me/comments.json") },
            { ApiCommand.MeFollowings,          new Uri("https://api.soundcloud.com/me/followings.json") },
            { ApiCommand.MeFollowingsContact,   new Uri("https://api.soundcloud.com/me/followings/{0}.json") },
            { ApiCommand.MeFollowers,           new Uri("https://api.soundcloud.com/me/followers.json") },
            { ApiCommand.MeFollowersContact,    new Uri("https://api.soundcloud.com/me/followers/{0}.json") },
            { ApiCommand.MeFavorites,           new Uri("https://api.soundcloud.com/me/favorites.json") },
            { ApiCommand.MeFavoritesTrack,      new Uri("https://api.soundcloud.com/me/favorites/{0}.json") },
            { ApiCommand.MeGroups,              new Uri("https://api.soundcloud.com/me/groups.json") },
            { ApiCommand.MePlaylists,           new Uri("https://api.soundcloud.com/me/playlists.json") },
            { ApiCommand.MeConnections,         new Uri("https://api.soundcloud.com/me/connections.json") },

            //Users
            { ApiCommand.Users,                 new Uri("https://api.soundcloud.com/users.json") },
            { ApiCommand.User,                  new Uri("https://api.soundcloud.com/users/{0}.json") },
            { ApiCommand.UserTracks,            new Uri("https://api.soundcloud.com/users/{0}/tracks.json") },
            { ApiCommand.UserComments,          new Uri("https://api.soundcloud.com/users/{0}/comments.json") },
            { ApiCommand.UserFollowings,        new Uri("https://api.soundcloud.com/users/{0}/followings.json") },
            { ApiCommand.UserFollowingsContact, new Uri("https://api.soundcloud.com/users/{0}/followings/{contact_id}.json") },
            { ApiCommand.UserFollowers,         new Uri("https://api.soundcloud.com/users/{0}/followers.json") },
            { ApiCommand.UserFollowersContact,  new Uri("https://api.soundcloud.com/users/{0}/followers/{1}.json?consumer_key={2}") },
            { ApiCommand.UserFavorites,         new Uri("https://api.soundcloud.com/users/{0}/favorites.json") },
            { ApiCommand.UserFavoritesTrack,    new Uri("https://api.soundcloud.com/users/{0}/favorites/{1}.json") },
            { ApiCommand.UserGroups,            new Uri("https://api.soundcloud.com/users/{0}/groups.json") },
            { ApiCommand.UserPlaylists,         new Uri("https://api.soundcloud.com/users/{0}/playlists.json") },

            //Tracks
            { ApiCommand.Tracks,                new Uri("https://api.soundcloud.com/tracks.json") },
            { ApiCommand.Track,                 new Uri("https://api.soundcloud.com/tracks/{0}.json") },
            { ApiCommand.TrackComments,         new Uri("https://api.soundcloud.com/tracks/{0}/comments.json") },
            { ApiCommand.TrackPermissions,      new Uri("https://api.soundcloud.com/tracks/{0}/permissions.json") },
            { ApiCommand.TrackSecretToken,      new Uri("https://api.soundcloud.com/tracks/{0}/secret-token.json") },
            { ApiCommand.TrackShare,            new Uri("https://api.soundcloud.com/tracks/{0}/shared-to/connections") },

            //Comments
            { ApiCommand.Comment,               new Uri("https://api.soundcloud.com/comments/{0}.json") },

            //Groups
            { ApiCommand.Groups,                new Uri("https://api.soundcloud.com/groups.json") },
            { ApiCommand.Group,                 new Uri("https://api.soundcloud.com/groups/{0}.json") },
            { ApiCommand.GroupUsers,            new Uri("https://api.soundcloud.com/groups/{0}/users.json") },
            { ApiCommand.GroupModerators,       new Uri("https://api.soundcloud.com/groups/{0}/moderators.json") },
            { ApiCommand.GroupMembers,          new Uri("https://api.soundcloud.com/groups/{0}/members.json") },
            { ApiCommand.GroupContributors,     new Uri("https://api.soundcloud.com/groups/{0}/contributors.json") },
            { ApiCommand.GroupTracks,           new Uri("https://api.soundcloud.com/groups/{0}/tracks.json") },

            //Playlists
            { ApiCommand.Playlists,             new Uri("https://api.soundcloud.com/playlists.json") },
            { ApiCommand.Playlist,              new Uri("https://api.soundcloud.com/playlists/{0}.json") },

            //Resolver
            { ApiCommand.Resolve,               new Uri("https://api.soundcloud.com/resolve.json?url={0}") },
        }; 
    }
}