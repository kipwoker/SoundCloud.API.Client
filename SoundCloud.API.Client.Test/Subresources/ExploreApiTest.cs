using System.Linq;
using NUnit.Framework;
using SoundCloud.API.Client.Subresources;
using System;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class ExploreApiTest : AuthTestBase
    {
        private IExploreApi exploreApi;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            exploreApi = soundCloudClient.Explore;
        }

        [Test]
        public void TestGetExploreCategories()
        {
            var categories = exploreApi.GetExploreCategories();
            Assert.IsTrue(categories.Count() > 0);
            Assert.IsTrue(categories.Any(c => c.Name.Contains("Rock")));
        }

        [Test]
        public void TestGetTracks()
        {
            var tracks = exploreApi.GetTracks(exploreApi.GetExploreCategories().First());
            Assert.IsTrue(tracks.Count() > 0);
        }

    }
}
