using NUnit.Framework;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class UsersApiTest : AuthTestBase
    {
        private IUsersApi usersApi;
        
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            usersApi = soundCloudClient.Users(settings.TestUserId);
        }

        [Test]
        public void TestGetUser()
        {
            var user = usersApi.GetUser();
            Assert.AreEqual(user.Id, settings.TestUserId);
        }

        [Test]
        [TestCase(0, 50)]
        [TestCase(500, 200)]
        public void TestGetTracks(int offset, int limit)
        {
            var tracks = usersApi.GetTracks(offset, limit);
            Assert.IsTrue(tracks.Length >= 0 && tracks.Length <= limit);
        }
    }
}