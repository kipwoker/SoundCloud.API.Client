using System.Linq;
using NUnit.Framework;
using SoundCloud.API.Client.Internal.Infrastructure.Network;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class GroupApiTest : AuthTestBase
    {
        private IGroupApi groupApi;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            groupApi = soundCloudClient.Group(settings.TestGroupId);
        }

        [Test]
        public void TestGroup()
        {
            var @group = groupApi.GetGroup();
            Assert.AreEqual(settings.TestGroupId, @group.Id);
        }

        [Test]
        public void TestGetModerators()
        {
            TestCollection(groupApi.GetModerators, 0, 50);
        }

        [Test]
        public void TestGetMembers()
        {
            TestCollection(groupApi.GetMembers, 0, 50);
        }

        [Test]
        public void TestGetContributors()
        {
            TestCollection(groupApi.GetContributors, 0, 50);
        }

        [Test]
        public void TestGetUsers()
        {
            TestCollection(groupApi.GetUsers, 0, 50);
        }

        [Test]
        public void TestGetApprovedTracks()
        {
            TestCollection(groupApi.GetApprovedTracks, 0, 50);
        }

        [Test]
        public void TestGetPendingTracks()
        {
            TestCollection(groupApi.GetPendingTracks, 0, 50);
        }

        [Test]
        public void TestGetPendingTrack()
        {
            var pendingTracks = groupApi.GetPendingTracks();
            if (pendingTracks.Length == 0)
            {
                Assert.Inconclusive("There are no pending tracks.");
            }

            TestGetEntity(groupApi.GetPendingTracks, groupApi.GetPendingTrack, t => t.Id);
        }

        [Test]
        public void TestAcceptPendingTrack()
        {
            var pendingTracks = groupApi.GetPendingTracks();
            if (pendingTracks.Length == 0)
            {
                Assert.Inconclusive("There are no pending tracks.");
            }

            var pendingTrack = pendingTracks[0];
            groupApi.AcceptPendingTrack(pendingTrack.Id);

            Assert.IsTrue(groupApi.GetApprovedTracks().Any(x => x.Id == pendingTrack.Id));
        }

        [Test]
        public void TestRejectPendingTrack()
        {
            var pendingTracks = groupApi.GetPendingTracks();
            if (pendingTracks.Length == 0)
            {
                Assert.Inconclusive("There are no pending tracks.");
            }

            var pendingTrack = pendingTracks[0];
            groupApi.RejectPendingTrack(pendingTrack.Id);

            Assert.IsTrue(groupApi.GetPendingTracks().All(x => x.Id != pendingTrack.Id));
            Assert.IsTrue(groupApi.GetApprovedTracks().All(x => x.Id != pendingTrack.Id));
        }

        [Test]
        public void TestGetContributions()
        {
            TestCollection(groupApi.GetContributions, 0, 50);
        }

        [Test]
        [Ignore("Build group with contributions")]
        public void TestGetContribution()
        {
            TestGetEntity(groupApi.GetContributions, groupApi.GetContribution, t => t.Id);
        }

        [Test]
        public void TestCreateAndDeleteContribution()
        {
            groupApi.CreateContribution(settings.TestTrackId);

            var contribution = groupApi.GetContribution(settings.TestTrackId);
            Assert.IsNotNull(contribution);

            groupApi.DeleteContribution(settings.TestTrackId);
            Assert.Throws<WebGatewayException>(() => groupApi.GetContribution(settings.TestTrackId));
        }

        [Test]
        public void TestSearch()
        {
            TestCollection((o,l) => soundCloudClient.Groups.Search(null, o, l), 0, 50);
            var @group = groupApi.GetGroup();

            var groups = soundCloudClient.Groups.Search(@group.Name);
            Assert.IsTrue(groups.Any(x => x.Id == @group.Id));
        }
    }
}