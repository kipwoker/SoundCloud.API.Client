using System;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;

namespace SoundCloud.API.Client.Test
{
    [Category("Network")]
    public abstract class AuthTestBase : TestBase
    {
        protected ISoundCloudClient soundCloudClient;
        protected Settings settings;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            var settingsJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json"), Encoding.UTF8);
            settings = new JsonSerializer().Deserialize<Settings>(settingsJson);

            ISoundCloudConnector soundCloudConnector = new SoundCloudConnector();
            soundCloudClient = soundCloudConnector.DirectConnect(settings.ClientId, settings.ClientSecret, settings.UserName, settings.Password);

            settings.TestUserId = settings.TestUserId ?? soundCloudClient.Me.GetUser().Id;
            settings.TestTrackId = settings.TestTrackId ?? soundCloudClient.Me.GetTracks()[0].Id;
            if (string.IsNullOrEmpty(settings.TestGroupId))
            {
                var me = soundCloudClient.Me.GetUser();
                settings.TestGroupId = soundCloudClient.Me.GetGroups().First(x => x.Creator.Id == me.Id).Id;
            }
        }

        protected class Settings
        {
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string TestUserId { get; set; }
            public string TestTrackId { get; set; }
            public string TestGroupId { get; set; }
            public string TestAppId { get; set; }
        }

        protected static void TestCollection<TResponse>(Func<int, int, TResponse[]> getResponse, int offset, int limit)
        {
            var entities = getResponse(offset, limit);
            Assert.IsTrue(entities.Length >= 0 && entities.Length <= limit);

            if (entities.Length < limit)
                return;

            entities = getResponse(limit, limit);
            Assert.IsTrue(entities.Length >= 0 && entities.Length <= limit);
        }

        protected static void TestDeleteAndPutEntity<TResponse>(Func<int, int, TResponse[]> selector, Func<TResponse, string> idGetter, Action<string> put, Action<string> delete)
        {
            var entities = selector(0, 1);
            Assert.IsTrue(entities.Length > 0, "Selector returned empty collection");

            var entity = entities[0];
            var expectedEntityId = idGetter(entity);
            delete(expectedEntityId);
            entities = selector(0, 1);
            Assert.IsTrue(entities.Length == 0 || idGetter(entities[0]) != expectedEntityId);

            put(expectedEntityId);
            entities = selector(0, 1);

            Assert.AreEqual(expectedEntityId, idGetter(entities[0]));
        }

        protected static void TestGetEntity<TResponse>(Func<int, int, TResponse[]> multiSelector, Func<string, TResponse> selector, Func<TResponse, string> idGetter)
        {
            var entities = multiSelector(0, 1);
            Assert.IsTrue(entities.Length > 0, "Selector returned empty collection");

            var entity = entities[0];
            var expectedId = idGetter(entity);
            var actual = selector(expectedId);

            Assert.AreEqual(expectedId, idGetter(actual));
        }
    }
}