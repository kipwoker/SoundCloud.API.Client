using Newtonsoft.Json;
using SoundCloud.API.Client.Internal.Objects.Interfaces;

namespace SoundCloud.API.Client.Internal.Objects
{
    internal class UserCollection : IEntityCollection<User>
    {
        public UserCollection()
        {
            Collection = new User[0];
        }

        [JsonProperty(PropertyName = "collection", NullValueHandling = NullValueHandling.Ignore)]
        public User[] Collection { get; set; }

        [JsonProperty(PropertyName = "next_href", NullValueHandling = NullValueHandling.Ignore)]
        public string NextHref { get; set; }
    }
}