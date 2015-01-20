using System;

namespace SoundCloud.API.Client.Internal.Client.Helpers.Factories
{
    internal class UriBuilderFactory : IUriBuilderFactory
    {
        internal static readonly IUriBuilderFactory Default = new UriBuilderFactory();

        public IUriBuilder Create(Uri uri)
        {
            return new UriBuilder(uri);
        }
    }
}