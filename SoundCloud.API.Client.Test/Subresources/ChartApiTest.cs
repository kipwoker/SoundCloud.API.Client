using System.Linq;
using NUnit.Framework;
using SoundCloud.API.Client.Subresources;
using System;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class ChartApiTest : AuthTestBase
    {
        private IChartApi chartApi;
        private IExploreApi exploreApi;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            exploreApi = soundCloudClient.Explore;
            chartApi = soundCloudClient.Chart;
        }

        [Test]
        public void TestGetChartAllSongs()
        {
            var tracks = chartApi.GetTracks(null);
            Assert.IsTrue(tracks.Count() > 0);
        }

        [Test]
        public void TestGetChartSpecificCategory()
        {
            var categories = exploreApi.GetExploreCategories();
            var tracks = chartApi.GetTracks(categories[1]);
            Assert.IsTrue(tracks.Count() > 0);
        }

        [Test]
        public void TestGetChartPopularMusicCategory()
        {
            var categories = exploreApi.GetExploreCategories();
            var tracks = chartApi.GetTracks(categories.First());
            Assert.IsTrue(tracks.Count() > 0);
        }

        [Test]
        public void TestDubstepCategory()
        {
            var categories = exploreApi.GetExploreCategories();
            var tracks = chartApi.GetTracks(categories.First(ec => ec.Name == "Dubstep"));
            Assert.IsTrue(tracks.Count() > 0);
        }

    }
}
