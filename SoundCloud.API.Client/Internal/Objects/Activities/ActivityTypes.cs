using System;
using System.Collections.Generic;

namespace SoundCloud.API.Client.Internal.Objects.Activities
{
    internal static class ActivityTypes
    {
        internal static readonly Dictionary<Type, string> Repository = new Dictionary<Type, string>
        {
            {typeof(ActivityTrack), "track"},
            {typeof(ActivityComment), "comment"},
            {typeof(ActivityPlaylist), "playlist"},
            {typeof(ActivityFavoriting), "favoriting"},
        };
    }
}