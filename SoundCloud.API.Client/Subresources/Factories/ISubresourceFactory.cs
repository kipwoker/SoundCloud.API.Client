namespace SoundCloud.API.Client.Subresources.Factories
{
    internal interface ISubresourceFactory
    {
        IUserApi CreateUser(string userId);
        IUsersApi CreateUsers();
        ITrackApi CreateTrack(string trackId);
        ITracksApi CreateTracks();
        IPlaylistApi CreatePlaylist(string playlistId);
        IMeApi CreateMe();
        ICommentApi CreateComment(string commentId);
    }
}