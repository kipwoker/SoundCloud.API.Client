using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.ConnectionPieces;

namespace SoundCloud.API.Client.Subresources
{
    public interface IMeApi : IUserApi
    {
        SCConnection[] GetConnections(int offset = 0, int limit = 50);
        string PostConnection(SCServiceType serviceType, string redirectUri);

        SCActivityResult GetActivities(string cursorToNext = null);
        SCActivityResult GetActivityQueryResult(string queryId);
    }
}