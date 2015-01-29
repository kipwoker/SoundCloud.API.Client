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
    public class UsersApi : IUsersApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly IUserConverter userConverter;
        private const string prefix = "users";

        internal UsersApi(ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator, IUserConverter userConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
            this.userConverter = userConverter;
        }

        public SCUser[] SearchUsers(string query, int offset = 0, int limit = 50)
        {
            paginationValidator.Validate(offset, limit);
            var users = soundCloudRawClient.RequestApi<User[]>(prefix, string.Empty, HttpMethod.Get, new Dictionary<string, object> { { "q", query } }.SetPagination(offset, limit));
            return users.Select(userConverter.Convert).ToArray();
        }
    }
}