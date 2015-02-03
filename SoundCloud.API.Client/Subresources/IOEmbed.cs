using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public interface IOEmbed
    {
        IOEmbedQuery BeginQuery(string url);
    }
}