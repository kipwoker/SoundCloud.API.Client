using Newtonsoft.Json;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization.Custom;

namespace SoundCloud.API.Client.Internal.Infrastructure.Serialization
{
    internal class JsonSerializer : ISerializer
    {
        private static readonly JsonConverter[] customConverters = { new JsonActivityConverter() };

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, customConverters);
        }
    }
}