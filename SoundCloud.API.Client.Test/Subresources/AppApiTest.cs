using NUnit.Framework;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class AppApiTest : AuthTestBase
    {
        private IAppApi appApi;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            appApi = soundCloudClient.App(settings.TestAppId);
        }

        [Test]
        public void TestGetApplication()
        {
            var application = appApi.GetApplication();
            Assert.AreEqual(settings.TestAppId, application.Id);
        }

        [Test]
        public void TestGetTracks()
        {
            TestCollection(appApi.GetTracks, 0, 50);
        }
    }
}