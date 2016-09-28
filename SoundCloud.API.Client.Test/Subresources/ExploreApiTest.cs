using System.Linq;
using NUnit.Framework;
using SoundCloud.API.Client.Objects.ExplorePieces;
using SoundCloud.API.Client.Subresources;

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
        public void TestGetTracks()
        {
            var tracks = exploreApi.GetTracks(SCExploreCategory.Create(SCExploreCategoryType.Ambient));
            Assert.IsTrue(tracks.Any());
        }

    }
}
