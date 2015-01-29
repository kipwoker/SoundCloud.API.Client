using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal interface IPlaylistConverter
    {
        Playlist Convert(SCPlaylist playlist);
        SCPlaylist Convert(Playlist playlist);
    }
}