using NUnit.Framework;
using Rhino.Mocks;

namespace SoundCloud.API.Client.Test
{
    [TestFixture]
    public abstract class TestBase
    {
        protected MockRepository mocks;

        [OneTimeSetUp]
        public virtual void TestFixtureSetUp()
        {
            
        }

        [SetUp]
        public virtual void SetUp()
        {
            mocks = new MockRepository();
        }

        [TearDown]
        public virtual void TearDown()
        {
            mocks.Record().Dispose();
            mocks.VerifyAll();
        }

        protected virtual T NewMock<T>()
        {
            return mocks.StrictMock<T>();
        }
    }
}