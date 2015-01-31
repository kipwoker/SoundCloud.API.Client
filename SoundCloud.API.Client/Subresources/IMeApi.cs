using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.ConnectionPieces;

namespace SoundCloud.API.Client.Subresources
{
    public interface IMeApi : IUserApi
    {
        SCConnection[] GetConnections(int offset = 0, int limit = 50);
        string PostConnection(SCServiceType serviceType, string redirectUri);

        SCActivityResult GetActivityQueryResult(string queryId);
        SCActivityResult GetRecentActivities(string cursorToNext = null);
        SCActivityResult GetRecentAllActivities(string cursorToNext = null);
        SCActivityResult GetRecentFollowingTracks(string cursorToNext = null);
        SCActivityResult GetRecentExclusivelySharedTracks(string cursorToNext = null);
        SCActivityResult GetRecentUserTracksActivities(string cursorToNext = null);
    }
}