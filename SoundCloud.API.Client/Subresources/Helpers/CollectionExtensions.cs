using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Validation;

namespace SoundCloud.API.Client.Subresources.Helpers
{
    internal static class CollectionExtensions
    {
        internal static TResponse[] GetCollection<TResponse>(this ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator, string prefix, string command, int offset, int limit)
        {
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.RequestApi<TResponse[]>(prefix, command, HttpMethod.Get, new Dictionary<string, object>().SetPagination(offset, limit));
        }
    }
}