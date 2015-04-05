using NUnit.Framework;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class PlaylistApiTest : AuthTestBase
    {
        [Test]
        public void TestGetPlaylist()
        {
            var playlists = soundCloudClient.User(settings.TestUserId).GetPlaylists();
            if (playlists.Length == 0)
                return;

            var playlist = soundCloudClient.Playlist(playlists[0].Id).GetPlaylist();
            var jsonSerializer = new JsonSerializer();
            Assert.AreEqual(jsonSerializer.Serialize(playlists[0]), jsonSerializer.Serialize(playlist));
        }
    }
}