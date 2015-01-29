using NUnit.Framework;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class UserApiTest : AuthTestBase
    {
        private IUserApi userApi;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            userApi = soundCloudClient.User(settings.TestUserId);
        }

        [Test]
        public void TestGetUser()
        {
            var user = userApi.GetUser();
            Assert.AreEqual(user.Id, settings.TestUserId);
        }

        [Test]
        public void TestGetTracks()
        {
            TestCollection(userApi.GetTracks, 0, 50);
        }

        [Test]
        public void TestGetPlaylists()
        {
            TestCollection(userApi.GetPlaylists, 0, 50);
        }

        [Test]
        public void TestGetFollowings()
        {
            TestCollection(userApi.GetFollowings, 0, 50);
        }

        [Test]
#if LIGHTMODE
        [Ignore("API bug. Test always fails.")]
#endif
        public void TestGetFollowing()
        {
            TestGetEntity(userApi.GetFollowings, userApi.GetFollowing, u => u.Id);
        }

        [Test]
        public void TestDeleteAndPutFollowing()
        {
            TestDeleteAndPutEntity(userApi.GetFollowings, u => u.Id, userApi.PutFollowing, userApi.DeleteFollowing);
        }

        [Test]
        public void TestGetFollowers()
        {
            TestCollection(userApi.GetFollowers, 0, 50);
        }

        [Test]
#if LIGHTMODE
        [Ignore("API bug. Test always fails.")]
#endif
        public void TestGetFollower()
        {
            TestGetEntity(userApi.GetFollowers, userApi.GetFollower, u => u.Id);
        }

        [Test]
        public void TestGetComments()
        {
            TestCollection(userApi.GetComments, 0, 50);
        }

        [Test]
        public void TestGetFavorites()
        {
            TestCollection(userApi.GetFavorites, 0, 50);
        }

        [Test]
        public void TestGetFavorite()
        {
            TestGetEntity(userApi.GetFavorites, userApi.GetFavorite, t => t.Id);
        }

        [Test]
        public void TestDeleteAndPutFavorites()
        {
            TestDeleteAndPutEntity(userApi.GetFavorites, t => t.Id, userApi.PutFavorite, userApi.DeleteFavorite);
        }

        [Test]
        public void TestGetGroups()
        {
            TestCollection(userApi.GetGroups, 0, 50);
        }

        [Test]
        public void TestGetWebProfiles()
        {
            TestCollection(userApi.GetWebProfiles, 0, 50);
        }

        [Test]
        public void TestUpdateUser()
        {
            var user = userApi.GetUser();
            var city = user.City;
            var newCity = city == "Berlin" ? "Moscow" : "Berlin";

            user.City = newCity;
            userApi.UpdateUser(user);
            user = userApi.GetUser();
            Assert.AreEqual(newCity, user.City);

            user.City = city;
            userApi.UpdateUser(user);
            user = userApi.GetUser();
            Assert.AreEqual(city, user.City);
        }

        [Test]
        public void TestUpdateUserWithAvatar()
        {
            var user = userApi.GetUser();
            var city = user.City;
            var newCity = city == "Berlin" ? "Moscow" : "Berlin";

            user.City = newCity;
            userApi.UpdateUser(user);
            user = userApi.GetUser();
            Assert.AreEqual(newCity, user.City);

            user.City = city;
            userApi.UpdateUser(user);
            user = userApi.GetUser();
            Assert.AreEqual(city, user.City);
        }
    }
}