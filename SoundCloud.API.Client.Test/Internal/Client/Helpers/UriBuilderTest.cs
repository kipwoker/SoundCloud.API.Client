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
        [TestCaseSource("testAddQueryParamsSource")]
        public void TestAddQueryParams(string baseUrl, Dictionary<string, object> parameters, string expected)
        {
            var actual = CreateBuilder(baseUrl).AddQueryParameters(parameters).Build();

            Assert.AreEqual(expected, actual.AbsoluteUri);
        }

        private static readonly object[] testAddQueryParamsSource =
        {
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"p1", "one"}}, "http://fake.org/?p1=one"},
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"", "one"}}, "http://fake.org/"},
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"p1", ""}}, "http://fake.org/?p1="},
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"", ""}}, "http://fake.org/"},
            new object[] {"http://fake.org/", new Dictionary<string, object> {{"p1", "one"}, {"p2", "two"}}, "http://fake.org/?p1=one&p2=two"},
            new object[] {"http://fake.org/", new Dictionary<string, object> (), "http://fake.org/"}
        };

        [Test]
        [TestCase("http://fake.org/", false, "", "", "http://fake.org/")]
        [TestCase("http://fake.org/", true, "808", "t0ken", "http://fake.org/?oauth_token=t0ken&client_id=808")]
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