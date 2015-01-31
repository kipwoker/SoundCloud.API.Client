using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client
{
    public interface ISoundCloudClient
    {
        IUserApi User(string userId);
        IUsersApi Users { get; }
        
        ITrackApi Track(string trackId);
        ITracksApi Tracks { get; }

        IPlaylistApi Playlist(string playlistId);

        IMeApi Me { get; }

        ICommentApi Comment(string commentId);
    }
}