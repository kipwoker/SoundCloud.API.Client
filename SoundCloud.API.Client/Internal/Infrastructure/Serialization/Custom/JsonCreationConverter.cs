using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SoundCloud.API.Client.Internal.Infrastructure.Serialization.Custom
{
    internal abstract class JsonCreationConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jsonObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            var target = Create(objectType, jsonObject);
            serializer.Populate(jsonObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}