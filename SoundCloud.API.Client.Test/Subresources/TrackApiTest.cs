using System;
using System.Linq;
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

            track.Title = title;
            trackApi.UpdateTrack(track);
            track = trackApi.GetTrack();
            Assert.AreEqual(title, track.Title);
        }

        [Test]
        [TestCase((string)null)]
        [TestCase("artwork.jpg")]
#if LIGHTMODE
        [Ignore("Slow test")]
#endif
        public void TestUploadAndDeleteTrack(string artwork)
        {
            const string title = "test 123";
            const string description = "description test 321";
            var uploadedTrack = soundCloudClient.Tracks.UploadTrack(Environment.CurrentDirectory + @"\test.mp3", 
                                                                    title, 
                                                                    description, 
                                                                    SCSharing.Private, 
                                                                    string.IsNullOrEmpty(artwork) 
                                                                    ? null 
                                                                    : Environment.CurrentDirectory + "\\" + artwork);
            Assert.AreEqual(title, uploadedTrack.Title);
            Assert.AreEqual(description, uploadedTrack.Description);

            var track = soundCloudClient.Track(uploadedTrack.Id);
            var foundedTrack = track.GetTrack();
            Assert.AreEqual(uploadedTrack.Id, foundedTrack.Id);
            Assert.AreEqual(title, foundedTrack.Title);
            Assert.AreEqual(description, foundedTrack.Description);

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
            trackApi.PostComment("test", timestamp);
            Func<SCComment> getComment = () => trackApi.GetComments().FirstOrDefault(x => x.Body == "test");
            var comment = getComment();
            Assert.IsNotNull(comment);
            Assert.AreEqual(timestamp.TotalMilliseconds, comment.Timestamp.TotalMilliseconds);

            var actualComment = trackApi.GetComment(comment.Id);
            Assert.AreEqual(comment.Id, actualComment.Id);

            trackApi.DeleteComment(comment.Id);
            comment = getComment();
            Assert.IsNull(comment);
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
    }
}