using System.Collections.Generic;
using System.Linq;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public class ExploreApi : IExploreApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly IExploreCategoryConverter exploreCategoryConverter;
        private readonly ITrackConverter trackConverter;
        private const string prefix = "explore/sounds";
        private const string categoryCommand = "categories";

        internal ExploreApi(ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator, IExploreCategoryConverter exploreCategoryConverter, ITrackConverter trackConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
            this.exploreCategoryConverter = exploreCategoryConverter;
            this.trackConverter = trackConverter;
        }
        public SCExploreCategory[] GetExploreCategories()
        {
            var categories = soundCloudRawClient.Request<ExploreCategoryCollection>(prefix, categoryCommand, HttpMethod.Get, domain: Internal.Client.Helpers.Domain.Api, responseType: string.Empty);
            return exploreCategoryConverter.Convert(categories);
        }

        public SCTrack[] GetTracks(SCExploreCategory category, int offset = 0, int limit = 10)
        {
            paginationValidator.Validate(offset, limit);

            var parameters = new Dictionary<string, object>();

            var tracks = soundCloudRawClient.Request<ExploreTrackCollection>(prefix, category.Name, HttpMethod.Get, parameters: parameters.SetPagination(offset, limit), domain: Internal.Client.Helpers.Domain.ApiV2, responseType: string.Empty);
            return tracks.Collection.Select(trackConverter.Convert).ToArray();
        }
    }
}
