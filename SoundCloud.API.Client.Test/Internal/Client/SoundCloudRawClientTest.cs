using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Client.Helpers.Factories;
using SoundCloud.API.Client.Internal.Infrastructure.Network;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Test.Internal.Client
{
    public class SoundCloudRawClientTest : TestBase
    {
        private IUriBuilderFactory uriBuilderFactory;
        private IWebGateway webGateway;
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
            webGateway = NewMock<IWebGateway>();
            serializer = NewMock<ISerializer>();
        }

        [Test]
        [TestCase((int)HttpMethod.Get)]
        [TestCase((int)HttpMethod.Post)]
        [TestCase((int)HttpMethod.Delete)]
        [TestCase((int)HttpMethod.Put)]
        public void TestRequestWithResponse(int httpMethod)
        {
            var parameters = new Dictionary<string, object> { { "p1", "2" } };
            var method = (HttpMethod)httpMethod;
            var bytes = new byte[] { 1, 2, 3, 4 };
            var scAccessToken = new SCAccessToken
            {
                AccessToken = "aToken"
            };

            var expected = new EmptyClass();

            using (mocks.Record())
            {
                var uriBuilder = NewMock<IUriBuilder>();
                uriBuilder.Expect(f => f.AddCredentials(scCredentials, scAccessToken)).Return(uriBuilder);
                uriBuilderFactory.Expect(f => f.Create(Domain.Api.GetParameterName() + "prefix/command.json")).Return(uriBuilder);

                webGateway.Expect(f => f.Request(uriBuilder, method, parameters, bytes)).Return("response");

                serializer.Expect(f => f.Deserialize<EmptyClass>("response")).Return(expected);
            }
            
            var soundCloudRawClient = new SoundCloudRawClient(scCredentials, uriBuilderFactory, webGateway, serializer)
            {
                AccessToken = scAccessToken
            };
            var actual = soundCloudRawClient.Request<EmptyClass>("prefix", "command", method, parameters, bytes, "json", Domain.Api);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestRequestWithoutResponse()
        {
            var parameters = new Dictionary<string, object> { { "p1", "2" } };
            const HttpMethod method = HttpMethod.Post;

            using (mocks.Record())
            {
                var uriBuilder = NewMock<IUriBuilder>();
                uriBuilder.Expect(f => f.AddCredentials(scCredentials, null)).Return(uriBuilder);
                uriBuilderFactory.Expect(f => f.Create(Domain.Api.GetParameterName() + "prefix/command")).Return(uriBuilder);
                
                webGateway.Expect(f => f.Request(uriBuilder, method, parameters, null)).Return("response");
            }

            var soundCloudRawClient = new SoundCloudRawClient(scCredentials, uriBuilderFactory, webGateway, serializer)
            {
                AccessToken = null
            };
            soundCloudRawClient.Request("prefix", "command", method, parameters, null, Domain.Api);
        }

        [Test]
        [TestCase("command", "json", "https://soundcloud.com/command.json")]
        [TestCase("", "json", "https://soundcloud.com")]
        [TestCase("command", "", "https://soundcloud.com/command")]
        [TestCase("", "", "https://soundcloud.com")]
        public void TestBuildUri(string command, string responseType, string expectedFullCommandWithResponse)
        {
            var parameters = new Dictionary<string, object>();

            var expectedUri = new Uri("http://fake.org");
            using (mocks.Record())
            {
                var uriBuilder = NewMock<IUriBuilder>();
                uriBuilder.Expect(f => f.AddQueryParameters(parameters)).Return(uriBuilder);
                uriBuilder.Expect(f => f.AddCredentials(scCredentials, null)).Return(uriBuilder);
                uriBuilder.Expect(f => f.Build()).Return(expectedUri);
                uriBuilderFactory.Expect(f => f.Create(expectedFullCommandWithResponse)).Return(uriBuilder);
            }

            var soundCloudRawClient = new SoundCloudRawClient(scCredentials, uriBuilderFactory, webGateway, serializer)
            {
                AccessToken = null
            };

            var uri = soundCloudRawClient.BuildUri(command, parameters, responseType, Domain.Direct);

            Assert.AreEqual(expectedUri, uri.AbsoluteUri);
        }

        private class EmptyClass
        {

        }
    }
}