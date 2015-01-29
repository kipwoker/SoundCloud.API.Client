using NUnit.Framework;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Test.Objects.TrackPieces
{
    public class SCTagListSerializerTest : TestBase
    {
        [Test]
        public void TestDeserialize()
        {
            var expected = new SCTagList
            {
                Tags = new[] { "one", "two", "three four" },
                MachineTags = new[] { new SCMachineTag { Namespace = "five", Key = "six", Value = "seven" }, new SCMachineTag { Namespace = "eight", Key = "nine", Value = "ten eleven twelve" } }
            };
            var actual = SCTagListSerializer.Deserialize("one two \"three four\" five:six=seven \"eight:nine=ten eleven twelve\"");
            Assert.AreEqual(JsonSerializer.Default.Serialize(expected), JsonSerializer.Default.Serialize(actual));
        }

        [Test]
        [TestCase("")]
        [TestCase((string)null)]
        public void TestDeserializeEmpty(string input)
        {
            var expected = new SCTagList();
            var actual = SCTagListSerializer.Deserialize(input);
            Assert.AreEqual(JsonSerializer.Default.Serialize(expected), JsonSerializer.Default.Serialize(actual));
        }

        [Test]
        public void TestSerialize()
        {
            var input = new SCTagList
            {
                Tags = new[] { "one", "two", "three four" },
                MachineTags = new[] { new SCMachineTag { Namespace = "five", Key = "six", Value = "seven" }, new SCMachineTag { Namespace = "eight", Key = "nine", Value = "ten eleven twelve" } }
            };

            const string expected = "one two \"three four\" five:six=seven \"eight:nine=ten eleven twelve\"";

            var actual = SCTagListSerializer.Serialize(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSerializeEmpty()
        {
            var input = new SCTagList();
            const string expected = "";

            var actual = SCTagListSerializer.Serialize(input);
            Assert.AreEqual(expected, actual);
        }
    }
}