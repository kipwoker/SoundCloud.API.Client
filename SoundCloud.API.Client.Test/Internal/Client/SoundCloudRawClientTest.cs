using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Client.Helpers.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Network;
using SoundCloud.API.Client.Internal.Infrastructure.Network.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Test.Internal.Client
{
    public class SoundCloudRawClientTest : TestBase
    {
        private IUriBuilderFactory uriBuilderFactory;
        private IWebGatewayFactory webGatewayFactory;
        private ISerializer serializer;
        private SCCredentials scCredentials;

        private const string clientId = "clientId";
        private const string clientSecret = "clientSecret";

        public override void SetUp()
        {
            base.SetUp();

            scCredentials = new SCCredentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            uriBuilderFactory = NewMock<IUriBuilderFactory>();
            webGatewayFactory = NewMock<IWebGatewayFactory>();
            serializer = NewMock<ISerializer>();
        }

        [Test]
        [TestCase(true, (int)HttpMethod.Get)]
        [TestCase(false, (int)HttpMethod.Post)]
        [TestCase(true, (int)HttpMethod.Delete)]
        [TestCase(true, (int)HttpMethod.Put)]
        public void TestRequestApiWithResponseUsingToken(bool enableGZip, int httpMethod)
        {
            const bool isRequiredAuth = true;
            var parameters = new Dictionary<string, object> { { "p1", "2" } };
            var method = (HttpMethod)httpMethod;

            var expected = new EmptyClass();

            using (mocks.Record())
            {
                var uriBuilder = NewMock<IUriBuilder>();
                uriBuilder.Expect(f => f.AddQueryParameters(parameters)).Return(uriBuilder);
                uriBuilder.Expect(f => f.AddToken("aToken")).Return(uriBuilder);
                var uri = new Uri("http://fake.org");
                uriBuilder.Expect(f => f.Build()).Return(uri);
                uriBuilderFactory.Expect(f => f.Create(Settings.ApiSoundCloudComPrefix + "prefix/command.json")).Return(uriBuilder);

                var webGateway = NewMock<IWebGateway>();
                webGatewayFactory.Expect(f => f.Create(enableGZip)).Return(webGateway);
                webGateway.Expect(f => f.Request(uri, method)).Return("response");

                serializer.Expect(f => f.Deserialize<EmptyClass>("response")).Return(expected);
            }

            var soundCloudRawClient = new SoundCloudRawClient(scCredentials, enableGZip, uriBuilderFactory, webGatewayFactory, serializer)
            {
                AccessToken = new SCAccessToken
                {
                    AccessToken = "aToken"
                }
            };
            var actual = soundCloudRawClient.RequestApi<EmptyClass>("prefix", "command", method, parameters, isRequiredAuth, "json");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestRequestApiWithResponseUsingClientId()
        {
            const bool isRequiredAuth = true;
            const bool enableGZip = true;
            var parameters = new Dictionary<string, object> { { "p1", "2" } };
            const HttpMethod method = HttpMethod.Get;

            var expected = new EmptyClass();

            using (mocks.Record())
            {
                var uriBuilder = NewMock<IUriBuilder>();
                uriBuilder.Expect(f => f.AddQueryParameters(parameters)).Return(uriBuilder);
                uriBuilder.Expect(f => f.AddClientId(clientId)).Return(uriBuilder);
                var uri = new Uri("http://fake.org");
                uriBuilder.Expect(f => f.Build()).Return(uri);
                uriBuilderFactory.Expect(f => f.Create(Settings.ApiSoundCloudComPrefix + "prefix/command.json")).Return(uriBuilder);

                var webGateway = NewMock<IWebGateway>();
                webGatewayFactory.Expect(f => f.Create(enableGZip)).Return(webGateway);
                webGateway.Expect(f => f.Request(uri, method)).Return("response");

                serializer.Expect(f => f.Deserialize<EmptyClass>("response")).Return(expected);
            }

            var soundCloudRawClient = new SoundCloudRawClient(scCredentials, enableGZip, uriBuilderFactory, webGatewayFactory, serializer)
            {
                AccessToken = null
            };
            var actual = soundCloudRawClient.RequestApi<EmptyClass>("prefix", "command", method, parameters, isRequiredAuth, "json");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestRequestApiWithoutResponseAndAuth()
        {
            const bool enableGZip = true;
            var parameters = new Dictionary<string, object> { { "p1", "2" } };
            const HttpMethod method = HttpMethod.Post;

            using (mocks.Record())
            {
                var uriBuilder = NewMock<IUriBuilder>();
                uriBuilder.Expect(f => f.AddQueryParameters(parameters)).Return(uriBuilder);
                var uri = new Uri("http://fake.org");
                uriBuilder.Expect(f => f.Build()).Return(uri);
                uriBuilderFactory.Expect(f => f.Create(Settings.ApiSoundCloudComPrefix + "prefix/command")).Return(uriBuilder);

                var webGateway = NewMock<IWebGateway>();
                webGatewayFactory.Expect(f => f.Create(enableGZip)).Return(webGateway);
                webGateway.Expect(f => f.Request(uri, method)).Return("response");
            }

            var soundCloudRawClient = new SoundCloudRawClient(scCredentials, enableGZip, uriBuilderFactory, webGatewayFactory, serializer)
            {
                AccessToken = null
            };
            soundCloudRawClient.RequestApi("prefix", "command", method, parameters, false);
        }

        [Test]
        [TestCase("prefix", "command", "json", "prefix/command.json")]
        [TestCase("", "command", "json", "command.json")]
        [TestCase("prefix", "", "json", "prefix.json")]
        [TestCase("", "", "json", ".json")]
        [TestCase("prefix", "command", "", "prefix/command")]
        [TestCase("prefix", "", "", "prefix")]
        [TestCase("", "command", "", "command")]
        [TestCase("", "", "", "")]
        public void TestBuildUri(string prefix, string command, string responseType, string expectedFullCommandWithResponse)
        {
            var parameters = new Dictionary<string, object>();

            var expectedUri = new Uri("http://fake.org");
            using (mocks.Record())
            {
                var uriBuilder = NewMock<IUriBuilder>();
                uriBuilder.Expect(f => f.AddQueryParameters(parameters)).Return(uriBuilder);
                uriBuilder.Expect(f => f.Build()).Return(expectedUri);
                uriBuilderFactory.Expect(f => f.Create(expectedFullCommandWithResponse)).Return(uriBuilder);
            }

            const bool enableGZip = true;
            var soundCloudRawClient = new SoundCloudRawClient(scCredentials, enableGZip, uriBuilderFactory, webGatewayFactory, serializer)
            {
                AccessToken = null
            };

            var uri = soundCloudRawClient.BuildUri(prefix, command, parameters, false, responseType);

            Assert.AreEqual(expectedUri, uri.AbsoluteUri);
        }

        private class EmptyClass
        {

        }
    }
}