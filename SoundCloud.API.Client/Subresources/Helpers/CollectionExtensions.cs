using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects.Interfaces;
using SoundCloud.API.Client.Internal.Validation;

namespace SoundCloud.API.Client.Subresources.Helpers
{
    internal static class CollectionExtensions
    {
        internal static TResponse[] GetCollection<TResponse>(
            this ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator, string prefix, string command, int offset, int limit)
        {
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.Request<TResponse[]>(prefix, command, HttpMethod.Get, new Dictionary<string, object>().SetPagination(offset, limit));
        }

        internal static TCollection GetCollectionBatch<TCollection, TResponse>(
            this ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator, string prefix, string command, int offset, int limit) 
            where TCollection : class, IEntityCollection<TResponse> 
        {
            paginationValidator.Validate(offset, limit);
            return soundCloudRawClient.Request<TCollection>(prefix, command, HttpMethod.Get, new Dictionary<string, object>().SetPagination(offset, limit));
        }
    }
}