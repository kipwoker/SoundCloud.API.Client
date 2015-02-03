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
    public class GroupsApi : IGroupsApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly IGroupConverter groupConverter;

        private const string prefix = "groups";

        internal GroupsApi(ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator, IGroupConverter groupConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
            this.groupConverter = groupConverter;
        }

        public SCGroup[] Search(string query, int offset = 0, int limit = 50)
        {
            paginationValidator.Validate(offset, limit);

            var parameters = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(query))
            {
                parameters.Add("q", query);
            }

            var groups = soundCloudRawClient.Request<Group[]>(prefix, string.Empty, HttpMethod.Get, parameters.SetPagination(offset, limit));
            return groups.Select(groupConverter.Convert).ToArray();
        }
    }
}