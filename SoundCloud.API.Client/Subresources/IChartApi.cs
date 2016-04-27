using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface IChartApi
    {
        SCTrack[] GetTracks(SCExploreCategory category, int offset = 0, int limit = 20);
    }
}
