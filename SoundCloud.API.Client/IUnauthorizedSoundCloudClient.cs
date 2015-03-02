using SoundCloud.API.Client.Subresources;
using SoundCloud.API.Client.Subresources.Public;

namespace SoundCloud.API.Client
{
    public interface IUnauthorizedSoundCloudClient
    {
        IPublicUserApi User(string userId);
        IUsersApi Users { get; }

        IPublicTrackApi Track(string trackId);
        ITracksApi Tracks { get; }

        IPlaylistApi Playlist(string playlistId);

        IPublicGroupApi Group(string groupId);
        IGroupsApi Groups { get; }

        ICommentApi Comment(string commentId);

        IAppApi App(string appId);

        IResolveApi Resolve { get; }

        IOEmbed OEmbed { get; } 
    }
}