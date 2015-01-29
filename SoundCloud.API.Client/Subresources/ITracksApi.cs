using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public interface ITracksApi
    {
        SCTrack UploadTrack(string trackPath, string title, string description, SCSharing sharing, string artworkPath = null);
        ITracksSearcher BeginSearch(SCFilter filter);
    }
}