using SoundCloud.API.Client.Objects.Auth;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client
{
    public interface ISoundCloudClient
    {
        SCAccessToken CurrentToken { get; }

        IUserApi User(string userId);
        IUsersApi Users { get; }
        
        ITrackApi Track(string trackId);
        ITracksApi Tracks { get; }

        IPlaylistApi Playlist(string playlistId);

        IGroupApi Group(string groupId);
        IGroupsApi Groups { get; }

        IMeApi Me { get; }

        ICommentApi Comment(string commentId);

        IAppApi App(string appId);

        IResolveApi Resolve { get; }

        IExploreApi Explore { get; }

        IChartApi Chart { get; }

        IOEmbed OEmbed { get; }
    }
}