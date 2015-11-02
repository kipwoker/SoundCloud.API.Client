using System.IO;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public interface ITracksApi
    {
        SCTrack UploadTrack(Stream trackFileStream, string title, string description, SCSharing sharing, Stream artworkFileStream = null);
        ITracksSearcher BeginSearch(SCFilter filter, bool useNewApi = true);
    }
}