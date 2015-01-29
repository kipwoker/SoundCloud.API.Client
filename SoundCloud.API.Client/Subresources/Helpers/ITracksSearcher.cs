using System;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Subresources.Helpers
{
    public interface ITracksSearcher
    {
        ITracksSearcher Clear();

        ITracksSearcher Query(string query);
        ITracksSearcher Tags(params string[] tags);
        ITracksSearcher License(SCLicenseSearch? license);
        ITracksSearcher Bpm(float? @from = null, float? to = null);
        ITracksSearcher Duration(TimeSpan? from = null, TimeSpan? to = null);
        ITracksSearcher CreatedAt(DateTimeOffset? from = null, DateTimeOffset? to = null);
        ITracksSearcher Tracks(params string[] trackIds);
        ITracksSearcher Genres(params string[] genres);
        ITracksSearcher Types(params SCTrackType[] trackTypes);

        SCTrack[] Exec(int offset = 0, int limit = 50);
    }
}