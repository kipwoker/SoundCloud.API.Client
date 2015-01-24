using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Infrastructure.Serialization
{
    internal class JsonSerializer : ISerializer
    {
        internal static readonly ISerializer Default = new JsonSerializer();

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}