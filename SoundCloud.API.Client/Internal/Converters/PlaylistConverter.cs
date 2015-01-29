using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class PlaylistConverter : IPlaylistConverter
    {
        internal static readonly IPlaylistConverter Default = new PlaylistConverter();

        public Playlist Convert(SCPlaylist playlist)
        {
            if (playlist == null)
            {
                return null;
            }

            return new Playlist();
        }

        public SCPlaylist Convert(Playlist playlist)
        {
            if (playlist == null)
            {
                return null;
            }

            return new SCPlaylist();
        }
    }
}