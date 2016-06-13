using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using NUnit.Framework;
using SoundCloud.API.Client.Internal.Infrastructure.Network;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class TrackApiTest : AuthTestBase
    {
        private ITrackApi trackApi;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            trackApi = soundCloudClient.Track(settings.TestTrackId);
        }

        [Test]
        public void TestGetTrack()
        {
            var track = trackApi.GetTrack();
            Assert.AreEqual(settings.TestTrackId, track.Id);
        }

        [Test]
        public void TestUpdateTrack()
        {
            var track = trackApi.GetTrack();
            var title = track.Title;
            var newTitle = title + "1";

            track.Title = newTitle;
            trackApi.UpdateTrack(track);
            track = trackApi.GetTrack();
            Assert.AreEqual(newTitle, track.Title);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
#if LIGHTMODE
        [Ignore("Slow test")]
#endif
        public void TestUploadAndDeleteTrack(bool withArtwork)
        {
            const string title = "test 123";
            const string description = "description test 321";
            var trackFileStream = File.OpenRead(Environment.CurrentDirectory + @"\test.mp3");
            Stream artworkStream = null;
            if (withArtwork)
            {
                var avatarUrl = soundCloudClient.User(settings.TestUserId).GetUser().Avatar.Url();
                using (var webClient = new WebClient())
                {
                    var bytes = webClient.DownloadData(avatarUrl);
                    artworkStream = new MemoryStream(bytes);
                }
            }

            var uploadedTrack = soundCloudClient.Tracks.UploadTrack(trackFileStream,
                                                                    title,
                                                                    description,
                                                                    SCSharing.Private,
                                                                    artworkStream);
            Assert.AreEqual(title, uploadedTrack.Title);
            Assert.AreEqual(description, uploadedTrack.Description);
            AssertArtwork(withArtwork, uploadedTrack);

            var track = soundCloudClient.Track(uploadedTrack.Id);
            var foundedTrack = track.GetTrack();
            Assert.AreEqual(uploadedTrack.Id, foundedTrack.Id);
            Assert.AreEqual(title, foundedTrack.Title);
            Assert.AreEqual(description, foundedTrack.Description);
            AssertArtwork(withArtwork, foundedTrack);

            track.DeleteTrack();
            var webGatewayException = Assert.Throws<WebGatewayException>(() => track.GetTrack());
            Assert.AreEqual(HttpStatusCode.NotFound, webGatewayException.StatusCode);
        }

        [Test]
        public void TestGetComments()
        {
            TestCollection(trackApi.GetComments, 0, 50);
        }

        [Test]
        public void TestPostGetAndDeleteComment()
        {
            var timestamp = TimeSpan.FromSeconds(8);
            var comment = trackApi.PostComment("test", timestamp);
            Assert.AreEqual(timestamp.TotalMilliseconds, comment.Timestamp.TotalMilliseconds);

            var actualComment = trackApi.GetComment(comment.Id);
            Assert.AreEqual(comment.Id, actualComment.Id);

            trackApi.DeleteComment(comment.Id);
            var webException = Assert.Throws<WebGatewayException>(() => trackApi.GetComment(comment.Id));
            Assert.AreEqual(HttpStatusCode.NotFound, webException.StatusCode);
        }

        [Test]
        public void TestGetFavoriters()
        {
            TestCollection(trackApi.GetFavoriters, 0 , 50);
        }

        [Test]
#if LIGHTMODE
        [Ignore("API bug. Test always fails.")]
#endif
        public void TestGetFavoriter()
        {
            TestGetEntity(trackApi.GetFavoriters, trackApi.GetFavoriter, u => u.Id);
        }

        [Test]
#if LIGHTMODE
        [Ignore("Sometimes throws 403. Invalid signature key. More: https://github.com/kipwoker/SoundCloud.API.Client/issues/1")]
#endif
        public void TestGetStream()
        {
            using (var stream = trackApi.GetStream())
            {
                var bytes = ReadAll(stream);
                Assert.IsTrue(bytes.Length > 0);
            }
        }

        [Test]
        [Ignore("For debug issue #1")]
        public void TestIssue1()
        {
            var trackIds = new[]
            {
                "190613982",
                "190614460",
                "190614417",
                "190634160",
                "190614339",
                "190612009",
                "190614800",
                "190614360",
                "190611995"
            };

            foreach (var trackId in trackIds)
            {
                Debug.Write(trackId + Environment.NewLine);
                var track = soundCloudClient.Track(trackId);
                using (var stream = track.GetStream())
                {
                    var bytes = ReadAll(stream);
                    Assert.IsTrue(bytes.Length > 0);
                }
            }
        }

        private static void AssertArtwork(bool withArtwork, SCTrack uploadedTrack)
        {
            if (withArtwork)
            {
                Assert.IsNotNull(uploadedTrack.Artwork);
            }
            else
            {
                Assert.IsNull(uploadedTrack.Artwork);
            }
        }

        private static byte[] ReadAll(Stream stream)
        {
            var buffer = new byte[16 * 1024];
            using (var memoryStream = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, read);
                }
                return memoryStream.ToArray();
            }
        }
    }
}