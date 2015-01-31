using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface IPlaylistApi
    {
        SCPlaylist GetPlaylist();

        //note: GetPlaylists doesn't support. Returns 500. You can try it here: https://developers.soundcloud.com/console
    }
}