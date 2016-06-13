using System;
using System.Collections.Generic;
using System.Linq;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects.Versioning;

namespace SoundCloud.API.Client.Internal.Versioning.Tracks
{
    internal class CompositeSearchParametersBuilder : ISearchParametersBuilder
    {
        private readonly IVersionDependentSearchParametersBuilder[] searchParametersBuilders;

        public CompositeSearchParametersBuilder(IVersionDependentSearchParametersBuilder[] searchParametersBuilders)
        {
            this.searchParametersBuilders = searchParametersBuilders;
        }

        public Func<Dictionary<string, object>, Track[]> BuildGetter(SCApiVersion version, ISoundCloudRawClient soundCloudRawClient)
        {
            var searchParametersBuilder = searchParametersBuilders.SingleOrDefault(x => x.Version == version);
            if (searchParametersBuilder == null)
            {
                throw new NotSupportedException(string.Format("Search for version {0} not supported", version));
            }

            return searchParametersBuilder.BuildGetter(soundCloudRawClient);
        }
    }
}