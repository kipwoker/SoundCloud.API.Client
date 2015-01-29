using NUnit.Framework;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Test.Internal.Converters
{
    public class TagListConverterTest : TestBase
    {
        private TagListConverter tagListConverter;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            tagListConverter = new TagListConverter();
        }

        [Test]
        public void TestConvertString()
        {
            var expected = new SCTagList
            {
                Tags = new[] { "one", "two", "three four" },
                MachineTags = new[] { new SCMachineTag { Namespace = "five", Key = "six", Value = "seven" }, new SCMachineTag { Namespace = "eight", Key = "nine", Value = "ten eleven twelve" } }
            };
            var actual = tagListConverter.Convert("one two \"three four\" five:six=seven \"eight:nine=ten eleven twelve\"");
            Assert.AreEqual(JsonSerializer.Default.Serialize(expected), JsonSerializer.Default.Serialize(actual));
        }

        [Test]
        [TestCase("")]
        [TestCase((string)null)]
        public void TestConvertEmptyString(string input)
        {
            var expected = new SCTagList();
            var actual = tagListConverter.Convert(input);
            Assert.AreEqual(JsonSerializer.Default.Serialize(expected), JsonSerializer.Default.Serialize(actual));
        }

        [Test]
        public void TestConvertModel()
        {
            var input = new SCTagList
            {
                Tags = new[] { "one", "two", "three four" },
                MachineTags = new[] { new SCMachineTag { Namespace = "five", Key = "six", Value = "seven" }, new SCMachineTag { Namespace = "eight", Key = "nine", Value = "ten eleven twelve" } }
            };

            const string expected = "one two \"three four\" five:six=seven \"eight:nine=ten eleven twelve\"";

            var actual = tagListConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestConvertEmptyModel()
        {
            var input = new SCTagList();
            const string expected = "";

            var actual = tagListConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }
    }
}