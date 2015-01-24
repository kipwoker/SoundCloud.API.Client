using System;
using System.IO;
using System.Text;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;

namespace SoundCloud.API.Client.Test
{
    public class AuthTestBase : TestBase
    {
        protected ISoundCloudClient soundCloudClient;
        protected Settings settings;

        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            var settingsJson = File.ReadAllText(Environment.CurrentDirectory + "settings.json", Encoding.UTF8);
            settings = JsonSerializer.Default.Deserialize<Settings>(settingsJson);

            ISoundCloudConnector soundCloudConnector = new SoundCloudConnector();
            soundCloudClient = soundCloudConnector.DirectConnect(settings.ClientId, settings.ClientSecret, settings.UserName, settings.Password, true);
        }

        protected class Settings
        {
            public string ClientId { get; set; } 
            public string ClientSecret { get; set; } 
            public string UserName { get; set; } 
            public string Password { get; set; }
            public string TestUserId { get; set; }
        }
    }
}