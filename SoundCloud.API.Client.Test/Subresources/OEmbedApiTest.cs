using NUnit.Framework;
using SoundCloud.API.Client.Subresources;

namespace SoundCloud.API.Client.Test.Subresources
{
    public class OEmbedApiTest : AuthTestBase
    {
        private IOEmbed oEmbed;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            oEmbed = soundCloudClient.OEmbed;
        }

        [Test]
        [TestCase("https://soundcloud.com/lewruge")]
        [TestCase("https://soundcloud.com/lewruge/one-shot")]
        [TestCase("https://soundcloud.com/groups/radio-nite")]
        [TestCase("https://soundcloud.com/odesza/sets/in-return")]
        public void TestWithoutParametersJson(string url)
        {
            var embed = oEmbed.BeginQuery(url).ExecuteJson();
            Assert.IsNotNull(embed);

            Assert.AreEqual("100%", embed.Width);
        }

        [Test]
        [TestCase("https://soundcloud.com/lewruge")]
        [TestCase("https://soundcloud.com/lewruge/one-shot")]
        [TestCase("https://soundcloud.com/groups/radio-nite")]
        [TestCase("https://soundcloud.com/odesza/sets/in-return")]
        public void TestWithParametersJson(string url)
        {
            var embed = oEmbed.BeginQuery(url)
                              .SetAutoPlay(true)
                              .SetCallback("dropTable()")
                              .SetColor("c6c6c6")
                              .SetIFrame(false)
                              .SetMaxHeight(95)
                              .SetMaxWidth(42)
                              .SetShowComments(false)
                              .ExecuteJson();
            Assert.IsNotNull(embed);

            Assert.AreEqual(42.ToString(), embed.Width);
            Assert.AreEqual(95.ToString(), embed.Height);
            Assert.IsTrue(embed.Html.Contains("auto_play=True"));
            Assert.IsTrue(embed.Html.Contains("callback=dropTable%28%29"));
            Assert.IsTrue(embed.Html.Contains("color=c6c6c6"));
            Assert.IsTrue(embed.Html.Contains("maxheight=95px"));
            Assert.IsTrue(embed.Html.Contains("maxwidth=42%25"));
            Assert.IsTrue(embed.Html.Contains("show_comments=False"));
        }

        [Test]
        [TestCase("https://soundcloud.com/lewruge")]
        [TestCase("https://soundcloud.com/lewruge/one-shot")]
        [TestCase("https://soundcloud.com/groups/radio-nite")]
        [TestCase("https://soundcloud.com/odesza/sets/in-return")]
        public void TestWithoutParametersJsonP(string url)
        {
            var embed = oEmbed.BeginQuery(url).ExecuteJsonP();
            Assert.IsFalse(string.IsNullOrEmpty(embed));

            Assert.IsTrue(embed.Contains("\"width\":\"100%\""));
        }

        [Test]
        [TestCase("https://soundcloud.com/lewruge")]
        [TestCase("https://soundcloud.com/lewruge/one-shot")]
        [TestCase("https://soundcloud.com/groups/radio-nite")]
        [TestCase("https://soundcloud.com/odesza/sets/in-return")]
        public void TestWithParametersJsonP(string url)
        {
            var embed = oEmbed.BeginQuery(url)
                              .SetAutoPlay(true)
                              .SetCallback("dropTable()")
                              .SetColor("c6c6c6")
                              .SetIFrame(false)
                              .SetMaxHeight(95)
                              .SetMaxWidth(42)
                              .SetShowComments(false)
                              .ExecuteJsonP();
            Assert.IsFalse(string.IsNullOrEmpty(embed));

            Assert.IsTrue(embed.Contains("auto_play=True"));
            Assert.IsTrue(embed.Contains("callback=dropTable%28%29"));
            Assert.IsTrue(embed.Contains("color=c6c6c6"));
            Assert.IsTrue(embed.Contains("maxheight=95px"));
            Assert.IsTrue(embed.Contains("maxwidth=42%25"));
            Assert.IsTrue(embed.Contains("show_comments=False"));
        }
    }
}