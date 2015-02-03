using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public class ResolveApi : IResolveApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IGroupConverter groupConverter;
        private readonly IUserConverter userConverter;
        private readonly ITrackConverter trackConverter;
        private readonly IPlaylistConverter playlistConverter;

        private const string prefix = "resolve";

        internal ResolveApi(
            ISoundCloudRawClient soundCloudRawClient, 
            IGroupConverter groupConverter, 
            IUserConverter userConverter, 
            ITrackConverter trackConverter, 
            IPlaylistConverter playlistConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.groupConverter = groupConverter;
            this.userConverter = userConverter;
            this.trackConverter = trackConverter;
            this.playlistConverter = playlistConverter;
        }

        public SCUser GetUser(string url)
        {
            var user = ResolveUrl<User>(url);
            return userConverter.Convert(user);
        }

        public SCTrack GetTrack(string url)
        {
            var track = ResolveUrl<Track>(url);
            return trackConverter.Convert(track);
        }

        public SCPlaylist GetPlaylist(string url)
        {
            var user = ResolveUrl<Playlist>(url);
            return playlistConverter.Convert(user);
        }

        public SCGroup GetGroup(string url)
        {
            var user = ResolveUrl<Group>(url);
            return groupConverter.Convert(user);
        }

        private T ResolveUrl<T>(string url)
            where T : class 
        {
            return soundCloudRawClient.Request<T>(prefix, string.Empty, HttpMethod.Get, new Dictionary<string, object> { { "url", url } }, isRequiredAuth: false);
        }
    }
}