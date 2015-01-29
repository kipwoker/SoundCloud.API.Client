using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public interface ITracksApi
    {
        SCTrack UploadTrack(string path, string title, string description, SCSharing sharing);
        ITracksSearcher BeginSearch(SCFilter filter);
    }
}