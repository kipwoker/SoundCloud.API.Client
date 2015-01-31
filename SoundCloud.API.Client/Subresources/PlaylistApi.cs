using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public class PlaylistApi : IPlaylistApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPlaylistConverter playlistConverter;
        private readonly string prefix;

        internal PlaylistApi(string playlistId, ISoundCloudRawClient soundCloudRawClient, IPlaylistConverter playlistConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.playlistConverter = playlistConverter;
            prefix = string.Format("playlists/{0}", playlistId);
        }

        public SCPlaylist GetPlaylist()
        {
            var playlist = soundCloudRawClient.RequestApi<Playlist>(prefix, string.Empty, HttpMethod.Get);
            return playlistConverter.Convert(playlist);
        }
    }
}