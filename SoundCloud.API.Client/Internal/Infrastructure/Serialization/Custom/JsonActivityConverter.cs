using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using SoundCloud.API.Client.Internal.Objects.Activities;

namespace SoundCloud.API.Client.Internal.Infrastructure.Serialization.Custom
{
    internal class JsonActivityConverter : JsonCreationConverter<ActivityBase>
    {
        protected override ActivityBase Create(Type objectType, JObject jsonObject)
        {
            var typeName = jsonObject["type"].ToString();

            var pair = ActivityTypes.Repository.First(x => string.Equals(typeName.Split('-')[0], x.Value));
            return Activator.CreateInstance(pair.Key) as ActivityBase;
        }
    }
}