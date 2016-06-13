using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects.Versioning;

namespace SoundCloud.API.Client.Internal.Versioning.Tracks
{
    internal class V1SearchParametersBuilder : IVersionDependentSearchParametersBuilder
    {
        private const string prefix = "tracks";

        public SCApiVersion Version { get {return SCApiVersion.V1;} }

        public Func<Dictionary<string, object>, Track[]> BuildGetter(ISoundCloudRawClient soundCloudRawClient)
        {
            return parameters => soundCloudRawClient.Request<Track[]>(prefix, string.Empty, HttpMethod.Get, parameters);
        }
    }
}