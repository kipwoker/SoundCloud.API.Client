using System;
using System.Collections.Generic;
using NUnit.Framework;
using SoundCloud.API.Client.Objects.Auth;
using UriBuilder = SoundCloud.API.Client.Internal.Client.Helpers.UriBuilder;

namespace SoundCloud.API.Client.Test.Internal.Client.Helpers
{
    public class UriBuilderTest : TestBase
    {
        [Test]
        [TestCase("http://fake.org/{0}/{1}/{2}", "one,two,3", "http://fake.org/one/two/3")]
        [TestCase("http://fake.org/", "one,two", "http://fake.org/")]
        [TestCase("http://fake.org/{0}", "one,two", "http://fake.org/one")]
        [TestCase("http://fake.org/", "", "http://fake.org/")]
        public void TestAddParameters(string baseUrl, string parameters, string expected)
        {
            var values = parameters.Split(',');
            var actual = CreateBuilder(baseUrl).AddParameters(values).Build();

            Assert.AreEqual(expected, actual.AbsoluteUri);
        }

        [Test]
        [TestCase("http://fake.org/", "p1=one&p2=two", "http://fake.org/?p1=one&p2=two")]
        [TestCase("http://fake.org/", "", "http://fake.org/")]
        [TestCase("http://fake.org/", "wrqwrq", "http://fake.org/?wrqwrq")]
        [TestCase("http://fake.org/?p1=one", "p2=two", "http://fake.org/?p1=one&p2=two")]
        public void TestAddToQueryString(string baseUrl, string queryString, string expected)
        {
            var actual = CreateBuilder(baseUrl).AddToQueryString(queryString).Build();

            Assert.AreEqual(expected, actual.AbsoluteUri);
        }

        [Test]
        [TestCase("http://fake.org/", "p1", "one", "http://fake.org/?p1=one")]
        [TestCase("http://fake.org/", "", "one", "http://fake.org/")]
        [TestCase("http://fake.org/", "p1", "", "http://fake.org/?p1=")]
        [TestCase("http://fake.org/", "", "", "http://fake.org/")]
        [TestCase("http://fake.org/?p2=two", "p1", "one", "http://fake.org/?p2=two&p1=one")]
        public void TestAddToQueryStringKeyValue(string baseUrl, string name, string value, string expected)
        {
            var actual = CreateBuilder(baseUrl).AddToQueryString(name, value).Build();

            Assert.AreEqual(expected, actual.AbsoluteUri);
        }

        [Test]
        [TestCaseSource("testAddQueryParamsSource")]
        public void TestAddQueryParams(string baseUrl, Dictionary<string, object> parameters, string expected)
        {
            var actual = CreateBuilder(baseUrl).AddQueryParameters(parameters).Build();

            Assert.AreEqual(expected, actual.AbsoluteUri);
        }

        private readonly object[] testAddQueryParamsSource =
        {
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"p1", "one"}}, "http://fake.org/?p1=one"},
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"", "one"}}, "http://fake.org/"},
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"p1", ""}}, "http://fake.org/?p1="},
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"", ""}}, "http://fake.org/"},
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"p1", "one"}, {"p2", "two"}}, "http://fake.org/?p1=one&p2=two"},
            new object[] {"http://fake.org/", new Dictionary<string, object> (), "http://fake.org/"}
        };

        [Test]
        [TestCase("http://fake.org/", "772", "http://fake.org/?oauth_token=772")]
        [TestCase("http://fake.org/?p1=one", "772", "http://fake.org/?p1=one&oauth_token=772")]
        [TestCase("http://fake.org/?p1=one", "", "http://fake.org/?p1=one&oauth_token=")]
        public void TestAddToken(string baseUrl, string token, string expected)
        {
            var actual = CreateBuilder(baseUrl).AddToken(token).Build();

            Assert.AreEqual(expected, actual.AbsoluteUri);
        }

        [Test]
        [TestCase("http://fake.org/", "772", "http://fake.org/?client_id=772")]
        [TestCase("http://fake.org/?p1=one", "772", "http://fake.org/?p1=one&client_id=772")]
        [TestCase("http://fake.org/?p1=one", "", "http://fake.org/?p1=one&client_id=")]
        public void TestAddClientId(string baseUrl, string clientId, string expected)
        {
            var actual = CreateBuilder(baseUrl).AddClientId(clientId).Build();

            Assert.AreEqual(expected, actual.AbsoluteUri);
        }

        [Test]
        [TestCase("http://fake.org/", false, "", "", "http://fake.org/")]
        [TestCase("http://fake.org/", true, "808", "t0ken", "http://fake.org/?oauth_token=t0ken")]
        [TestCase("http://fake.org/", true, "808", "", "http://fake.org/?client_id=808")]
        public void TestAddCredentials(string baseUrl, bool needCredentials, string clientId, string accessToken, string expected)
        {
            var actual = CreateBuilder(baseUrl)
                .AddCredentials(
                    needCredentials ? new SCCredentials {ClientId = clientId} : null,
                    string.IsNullOrEmpty(accessToken) ? null : new SCAccessToken {AccessToken = accessToken})
                .Build();

            Assert.AreEqual(expected, actual.AbsoluteUri);
        }

        private static UriBuilder CreateBuilder(string url)
        {
            return new UriBuilder(new Uri(url));
        }
    }
}