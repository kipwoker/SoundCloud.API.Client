using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace SoundCloud.API.Client.Internal.Infrastructure.Objects
{
    public static class MergeExtensions
    {
        public static Dictionary<string, object> GetDiff<T>(this T to, T @from) where T : class
        {
            var diff = new Dictionary<string, object>();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (!property.PropertyType.IsPrimitive && !(property.PropertyType == typeof(string)))
                {
                    continue;
                }

                var jsonProperty = property.GetCustomAttributes(typeof (JsonPropertyAttribute), false).FirstOrDefault() as JsonPropertyAttribute;
                if (jsonProperty == null)
                {
                    continue;
                }

                var getMethod = property.GetGetMethod();
                if (getMethod == null)
                {
                    continue;
                }

                var fromValue = getMethod.Invoke(@from, new object[0]);
                var toValue = getMethod.Invoke(to, new object[0]);

                if ((fromValue == null && toValue == null) || fromValue.Equals(toValue))
                {
                    continue;
                }

                diff.Add(jsonProperty.PropertyName, fromValue);
            }

            return diff;
        }
    } 
}