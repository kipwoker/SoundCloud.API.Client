using NUnit.Framework;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class ResolveApiTest : AuthTestBase
    {
        private IResolveApi resolveApi;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            resolveApi = soundCloudClient.Resolve;
        }

        [Test]
        [TestCase("https://soundcloud.com/lewruge", "36024030")]
        [TestCase("https://soundcloud.com/siergood", "64562464")]
        public void TestGetUser(string url, string expectedId)
        {
            var response = resolveApi.GetUser(url);
            Assert.AreEqual(expectedId, response.Id);
        }

        [Test]
        [TestCase("https://soundcloud.com/lewruge/one-shot", "184934496")]
        [TestCase("https://soundcloud.com/siergood/indica", "150540499")]
        public void TestGetTrack(string url, string expectedId)
        {
            var response = resolveApi.GetTrack(url);
            Assert.AreEqual(expectedId, response.Id);
        }

        [Test]
        [TestCase("https://soundcloud.com/odesza/sets/in-return", "50200154")]
        public void TestGetPlaylist(string url, string expectedId)
        {
            var response = resolveApi.GetPlaylist(url);
            Assert.AreEqual(expectedId, response.Id);
        }

        [Test]
        [TestCase("https://soundcloud.com/groups/radio-nite", "136779")]
        public void TestGetGroup(string url, string expectedId)
        {
            var response = resolveApi.GetGroup(url);
            Assert.AreEqual(expectedId, response.Id);
        }
    }
}