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

            usersApi = soundCloudClient.Users;
        }

        [Test]
        public void TestSearchUsers()
        {
            var users = usersApi.SearchUsers("ODESZA");
            Assert.IsTrue(users.Any(x => x.Id == "18604897"));
        }
    }
}