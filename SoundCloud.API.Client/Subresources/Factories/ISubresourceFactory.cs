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
        IGroupApi CreateGroup(string groupId);
        IGroupsApi CreateGroups();
        IAppApi CreateApp(string applicationId);
        IResolveApi CreateResolve();
        IExploreApi CreateExplore();
        IChartApi CreateChart();
        IOEmbed CreateOEmbed();
    }
}