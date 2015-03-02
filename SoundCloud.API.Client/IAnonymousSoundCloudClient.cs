using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client
{
    public interface IAnonymousSoundCloudClient
    {
        IOEmbed OEmbed { get; } 
    }
}