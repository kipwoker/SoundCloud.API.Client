using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public class UsersApi : IUsersApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private const string prefix = "users";

        internal UsersApi(ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
        }

        public SCUser[] SearchUsers(string query, int offset = 0, int limit = 50)
        {
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<SCUser[]>(prefix, string.Empty, HttpMethod.Get, new Dictionary<string, object> { { "q", query } }.SetPagination(offset, limit));
        }
    }
}