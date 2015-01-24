using System;

namespace SoundCloud.API.Client.Internal.Client.Helpers.Factories
{
    internal interface IUriBuilderFactory
    {
        IUriBuilder Create(Uri uri);
        IUriBuilder Create(string url);
    }
}