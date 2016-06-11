using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.ActivityPieces;
using SoundCloud.API.Client.Objects.ConnectionPieces;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class MeApiTest : UserApiTest
    {
        public override IUserApi UserApi
        {
            get { return soundCloudClient.Me; }
        }

        [Test]
        public void TestGetConnections()
        {
            TestCollection(soundCloudClient.Me.GetConnections, 0, 50);
        }

        [Test]
        [TestCase(SCServiceType.Facebook)]
        [TestCase(SCServiceType.Twitter)]
        public void TestPostConnection(SCServiceType serviceType)
        {
            var authUrl = soundCloudClient.Me.PostConnection(serviceType, "http://github.com");
            Assert.IsFalse(string.IsNullOrEmpty(authUrl));
        }

        [Test]
        public void TestGetRecentActivities()
        {
            TestGetActivitiesBase(soundCloudClient.Me.GetRecentActivities);
        }

        [Test]
        public void TestGetRecentAllActivities()
        {
            TestGetActivitiesBase(soundCloudClient.Me.GetRecentAllActivities);
        }

        [Test]
        public void TestGetRecentExclusivelySharedTracks()
        {
            TestGetActivitiesBase(soundCloudClient.Me.GetRecentExclusivelySharedTracks);
        }

        [Test]
        public void TestGetRecentFollowingTracks()
        {
            TestGetActivitiesBase(soundCloudClient.Me.GetRecentFollowingTracks);
        }

        [Test]
        public void TestGetRecentUserTracksActivities()
        {
            TestGetActivitiesBase(soundCloudClient.Me.GetRecentUserTracksActivities);
        }

        private void TestGetActivitiesBase(Func<string, SCActivityResult> getActivities)
        {
            var activityResult = getActivities(null);
            var savedResult = soundCloudClient.Me.GetActivityQueryResult(activityResult.QueryId);

            AssertActivities(activityResult.Comments, savedResult.Comments, c => c.Id);
            AssertActivities(activityResult.Tracks, savedResult.Tracks, c => c.Id);
            AssertActivities(activityResult.Favorites, savedResult.Favorites, c => c.Id);
            AssertActivities(activityResult.Playlists, savedResult.Playlists, c => c.Id);

            if (string.IsNullOrEmpty(activityResult.CursorToNext))
            {
                return;
            }

            var nextResult = getActivities(activityResult.CursorToNext);

            Assert.AreNotEqual(activityResult.QueryId, nextResult.QueryId);
            Assert.AreNotEqual(activityResult.CursorToNext, nextResult.CursorToNext);
        }

        private static void AssertActivities<TActivity>(IEnumerable<SCActivity<TActivity>> expected, IEnumerable<SCActivity<TActivity>> actual, Func<TActivity, string> idGetter)
        {
            var activityCommentIds = string.Join(",", GetActivityIds(expected, idGetter));
            var savedCommentIds = string.Join(",", GetActivityIds(actual, idGetter));

            Assert.AreEqual(activityCommentIds, savedCommentIds);
        }

        private static string[] GetActivityIds<T>(IEnumerable<SCActivity<T>> activities, Func<T, string> idGetter)
        {
            return activities.Select(x => idGetter(x.Activity)).OrderBy(x => x).ToArray();
        }
    }
}