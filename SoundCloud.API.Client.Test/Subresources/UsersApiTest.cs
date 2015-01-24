using System.Linq;
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
        public void TestGetTracks()
        {
            TestCollection(usersApi.GetTracks, 0, 50);
        }

        [Test]
        public void TestGetPlaylists()
        {
            TestCollection(usersApi.GetPlaylists, 0, 50);
        }

        [Test]
        public void TestGetFollowings()
        {
            TestCollection(usersApi.GetFollowings, 0, 50);
        }

        [Test]
        public void TestGetFollowing()
        {
            TestGetEntity(usersApi.GetFollowings, usersApi.GetFollowing, u => u.Id);
        }

        [Test]
        public void TestDeleteAndPutFollowing()
        {
            TestDeleteAndPutEntity(usersApi.GetFollowings, u => u.Id, usersApi.PutFollowing, usersApi.DeleteFollowing);
        }

        [Test]
        public void TestGetFollowers()
        {
            TestCollection(usersApi.GetFollowers, 0, 50);
        }

        [Test]
        public void TestGetFollower()
        {
            TestGetEntity(usersApi.GetFollowers, usersApi.GetFollower, u => u.Id);
        }

        [Test]
        public void TestGetComments()
        {
            TestCollection(usersApi.GetComments, 0, 50);
        }

        [Test]
        public void TestGetFavorites()
        {
            TestCollection(usersApi.GetFavorites, 0, 50);
        }

        [Test]
        public void TestGetFavorite()
        {
            TestGetEntity(usersApi.GetFavorites, usersApi.GetFavorite, t => t.Id);
        }

        [Test]
        public void TestDeleteAndPutFavorites()
        {
            TestDeleteAndPutEntity(usersApi.GetFavorites, t => t.Id, usersApi.PutFavorite, usersApi.DeleteFavorite);
        }

        [Test]
        public void TestGetGroups()
        {
            TestCollection(usersApi.GetGroups, 0, 50);
        }

        [Test]
        public void TestSearchUsers()
        {
            var user = usersApi.GetUser();
            var users = usersApi.SearchUsers(user.UserName, 0, 50);

            Assert.IsTrue(users.Select(x => x.Id).Contains(user.Id));
        }
    }
}