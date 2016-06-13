using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects.Versioning;

namespace SoundCloud.API.Client.Internal.Versioning.Tracks
{
    internal interface IVersionDependentSearchParametersBuilder
    {
        SCApiVersion Version { get; }
        Func<Dictionary<string, object>, Track[]> BuildGetter(ISoundCloudRawClient soundCloudRawClient);
    }
}