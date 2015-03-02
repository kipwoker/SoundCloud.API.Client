using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client
{
    public class AnonymousSoundCloudClient : IAnonymousSoundCloudClient
    {
        internal AnonymousSoundCloudClient(IOEmbed oEmbed)
        {
            OEmbed = oEmbed;
        }

        public IOEmbed OEmbed { get; private set; }
    }
}