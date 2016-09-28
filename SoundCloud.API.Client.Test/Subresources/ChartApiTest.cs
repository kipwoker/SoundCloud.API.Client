using System.Linq;
using NUnit.Framework;
using SoundCloud.API.Client.Objects.ExplorePieces;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class ChartApiTest : AuthTestBase
    {
        private IChartApi chartApi;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            chartApi = soundCloudClient.Chart;
        }

        [Test]
        public void TestGetChartAllSongs()
        {
            var tracks = chartApi.GetTracks(null);
            Assert.IsTrue(tracks.Any());
        }

        [Test]
        public void TestGetChartSpecificCategory()
        {
            var tracks = chartApi.GetTracks(SCExploreCategory.Create(SCExploreCategoryType.Classical));
            Assert.IsTrue(tracks.Any());
        }

        [Test]
        public void TestGetChartPopularMusicCategory()
        {
            var tracks = chartApi.GetTracks(SCExploreCategory.Create(SCExploreCategoryType.PopularMusic));
            Assert.IsTrue(tracks.Any());
        }

        [Test]
        public void TestDubstepCategory()
        {
            var tracks = chartApi.GetTracks(SCExploreCategory.Create(SCExploreCategoryType.Dubstep));
            Assert.IsTrue(tracks.Any());
        }
    }
}
