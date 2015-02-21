using System;
using NUnit.Framework;
using SoundCloud.API.Client.Internal.Validation;

namespace SoundCloud.API.Client.Test.Internal.Validation
{
    public class PaginationValidatorTest : TestBase
    {
        private IPaginationValidator paginationValidator;

        public override void SetUp()
        {
            base.SetUp();

            paginationValidator = PaginationValidator.Default;
        }

        [Test]
        [TestCase(0, 50, true, "")]
        [TestCase(8000, 200, true, "")]
        [TestCase(8001, 200, false, "Parameter 'offset' out of range [0;8000]. Current value: 8001")]
        [TestCase(8000, 201, false, "Parameter 'limit' out of range [1;200]. Current value: 201")]
        [TestCase(8000, -1, false, "Parameter 'limit' out of range [1;200]. Current value: -1")]
        [TestCase(-1, 200, false, "Parameter 'offset' out of range [0;8000]. Current value: -1")]
        [TestCase(0, 0, false, "Parameter 'limit' out of range [1;200]. Current value: 0")]
        [TestCase(-1, 0, false, "Parameter 'offset' out of range [0;8000]. Current value: -1{0}Parameter 'limit' out of range [1;200]. Current value: 0")]
        public void TestIsValid(int offset, int count, bool mustBeValid, string expectedMessage)
        {
            string message;
            var isValid = paginationValidator.IsValid(offset, count, out message);

            Assert.AreEqual(mustBeValid, isValid);

            message = message ?? string.Empty;
            Assert.AreEqual(string.Format(expectedMessage, Environment.NewLine), message);
        }
    }
}