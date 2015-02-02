using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface IResolveApi
    {
        SCUser GetUser(string url);
        SCTrack GetTrack(string url);
        SCPlaylist GetPlaylist(string url);
        SCGroup GetGroup(string url);
    }
}