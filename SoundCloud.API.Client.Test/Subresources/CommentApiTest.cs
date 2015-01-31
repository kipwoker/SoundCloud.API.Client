using NUnit.Framework;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class CommentApiTest : AuthTestBase
    {
        [Test]
        public void TestGetComment()
        {
            TestGetEntity(soundCloudClient.User(settings.TestUserId).GetComments, x => soundCloudClient.Comment(x).GetComment(), c => c.Id);
        }
    }
}