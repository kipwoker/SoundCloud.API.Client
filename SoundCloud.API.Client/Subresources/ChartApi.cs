using System;
using System.Collections.Generic;
using System.Linq;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.ExplorePieces;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public class ChartApi : IChartApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly ITrackConverter trackConverter;
        private const string prefix = "";
        private const string command = "charts";

        internal ChartApi(ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator, ITrackConverter trackConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
            this.trackConverter = trackConverter;
        }

        public SCTrack[] GetTracks(SCExploreCategory category, int offset = 0, int limit = 10)
        {
            paginationValidator.Validate(offset, limit);

            var parameters = new Dictionary<string, object> { { "kind", "top" } };

            var categoryName = category.GetName();

            var processed = categoryName == null || categoryName == "Popular+Music"
                ? "all-music"
                : new string(Uri.UnescapeDataString(categoryName).Where(char.IsLetterOrDigit).ToArray()).ToLower();
            var genreFormatQuery = $"soundcloud%3Agenres%3A{processed}";
            parameters.Add("genre", genreFormatQuery);
            parameters.Add("linked_partitioning", 1);

            var tracks = soundCloudRawClient.Request<ChartTrackCollection>(prefix, command, HttpMethod.Get, parameters: parameters.SetPagination(offset, limit), domain: Internal.Client.Helpers.Domain.ApiV2, responseType: string.Empty);
            return tracks.Collection.Select(ct => trackConverter.Convert(ct.Track)).ToArray();
        }
    }
}
