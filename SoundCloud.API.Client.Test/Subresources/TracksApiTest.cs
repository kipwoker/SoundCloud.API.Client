using System;
using System.Linq;
using NUnit.Framework;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;
using SoundCloud.API.Client.Subresources;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class TracksApiTest : AuthTestBase
    {
        private ITracksApi tracksApi;
        private Func<ITracksSearcher> tracksSearcher;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            tracksApi = soundCloudClient.Tracks;
            tracksSearcher = () => tracksApi.BeginSearch(SCFilter.All);
        }

        [Test]
        [TestCase(SCFilter.All)]
        [TestCase(SCFilter.Public)]
        public void TestSearchByFilter(SCFilter filter)
        {
            TestCollection((o,c) =>tracksApi.BeginSearch(filter).Exec(SCOrder.CreatedAt, o, c), 0 ,50);
        }

        [Test]
        public void TestSearchDownloadable()
        {
            var tracks = tracksApi.BeginSearch(SCFilter.Downloadable).Exec();
            Assert.IsTrue(tracks.All(x => x.Downloadable.HasValue && x.Downloadable.Value));
        }

        [Test]
        public void TestSearchStreamable()
        {
            var tracks = tracksApi.BeginSearch(SCFilter.Streamable).Exec();
            Assert.IsTrue(tracks.All(x => x.Streamable.HasValue && x.Streamable.Value));
        }

        [Test]
        [TestCase(90.5f, 120.7f)]
        [TestCase(90f, null)]
        [TestCase(null, 120f)]
        [TestCase(null, null)]
        public void TestSearchByBpm(float? from, float? to)
        {
            var tracks = tracksSearcher().Bpm(@from, to).Exec();
            if (from.HasValue)
            {
                Assert.IsTrue(tracks.All(x => x.Bpm >= from.Value));
            }

            if (to.HasValue)
            {
                Assert.IsTrue(tracks.All(x => x.Bpm <= to.Value));
            }
        }

        [Test]
        public void TestSearchByQuery()
        {
            var tracks = tracksSearcher().Query("Boat That's Capsized").Exec();
            Assert.IsTrue(tracks.Any(x => x.Title.Contains("Boat That's Capsized")));
        }

        [Test]
        public void TestSearchByTags()
        {
            var tracks = tracksSearcher().Tags("folk", "indie").Exec();
            var invalidTracks = tracks.Where(x => !(x.TagList.Tags.Select(y => y.ToLower()).Contains("indie") || x.TagList.Tags.Select(y => y.ToLower()).Contains("folk"))).ToArray();
            Assert.AreEqual(0, invalidTracks.Length);
        }

        [Test]
        [TestCase(SCLicenseSearch.CcBy)]
        [TestCase(SCLicenseSearch.CcByNcNdSa)]
        [TestCase(SCLicenseSearch.CcByNcNd)]
        [TestCase(SCLicenseSearch.CcByNcSa)]
        [TestCase(SCLicenseSearch.CcByNd)]
        [TestCase(SCLicenseSearch.CcBySa)]
        public void TestSearchByConcreteLicense(SCLicenseSearch license)
        {
            var tracks = tracksSearcher().License(license).Exec();
            Assert.IsTrue(tracks.All(x => x.License.GetParameterName() == license.GetParameterName()));
        }

        [Test]
        [TestCase(SCLicenseSearch.ToModifyCommercially)]
        [TestCase(SCLicenseSearch.ToShare)]
        [TestCase(SCLicenseSearch.ToUseCommercially)]
        public void TestSearchByLicense(SCLicenseSearch license)
        {
            TestCollection((o, c) => tracksSearcher().License(license).Exec(SCOrder.CreatedAt, o, c), 0, 50);
        }

        [Test]
        [TestCase(90, 120)]
        [TestCase(90, null)]
        [TestCase(null, 120)]
        [TestCase(null, null)]
        public void TestSearchByDuration(int? @from, int? to)
        {
            var fromTime = @from.HasValue ? TimeSpan.FromSeconds(@from.Value) : (TimeSpan?)null;
            var toTime = to.HasValue ? TimeSpan.FromSeconds(to.Value) : (TimeSpan?)null;

            var tracks = tracksSearcher().Duration(fromTime, toTime).Exec();
            if (fromTime.HasValue)
            {
                Assert.IsTrue(tracks.All(x => x.Duration >= fromTime.Value));
            }

            if (toTime.HasValue)
            {
                Assert.IsTrue(tracks.All(x => x.Duration <= toTime.Value));
            }
        }

        [Test]
        [TestCase(1, 31)]
        [TestCase(1, null)]
        [TestCase(null, 31)]
        [TestCase(null, null)]
        public void TestSearchByCreatedAt(int? fromDay, int? toDay)
        {
            var @from = fromDay.HasValue ? new DateTimeOffset(new DateTime(2014, 01, fromDay.Value)) : (DateTimeOffset?)null;
            var to = toDay.HasValue ? new DateTimeOffset(new DateTime(2014, 01, toDay.Value)) : (DateTimeOffset?)null;

            var tracks = tracksSearcher().CreatedAt(@from, to).Exec();
            if (@from.HasValue)
            {
                Assert.IsTrue(tracks.All(x => x.CreatedAt >= @from.Value.UtcDateTime));
            }

            if (to.HasValue)
            {
                Assert.IsTrue(tracks.All(x => x.CreatedAt <= to.Value.UtcDateTime));
            }
        }

        [Test]
        public void TestSearchByTracks()
        {
            var tracks = tracksSearcher().Exec();
            var trackIds = tracks.Select(x => x.Id).ToArray();
            var tracksByIds = tracksSearcher().Tracks(trackIds).Exec();

            CollectionAssert.AreEquivalent(trackIds, tracksByIds.Select(x => x.Id).ToArray());
        }

        [Test]
#if LIGHTMODE
        [Ignore("Unexpected behavior. Always returns empty collection.")]
#endif
        public void TestSearchByGenres()
        {
            var tracks = tracksSearcher().Exec();
            var genres = tracks.Where(x => !string.IsNullOrEmpty(x.Genre)).Take(2).Select(x => x.Genre).ToArray();

            var actual = tracksSearcher().Genres(genres).Exec();
            Assert.IsTrue(actual.Length >= 2);
            Assert.IsTrue(actual.All(x => genres.Any(y => x.Genre.ToLower().Contains(y.ToLower()))));
        }

        [Test]
        public void TestSearchByTypes()
        {
            TestCollection((o, c) => tracksSearcher().Types(SCTrackType.Podcast, SCTrackType.Recording).Exec(SCOrder.CreatedAt, o, c), 0, 50);
        }
    }
}