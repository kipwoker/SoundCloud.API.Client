using Newtonsoft.Json;

namespace SoundCloud.API.Client.Objects
{
    public class SCExploreCategory
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
