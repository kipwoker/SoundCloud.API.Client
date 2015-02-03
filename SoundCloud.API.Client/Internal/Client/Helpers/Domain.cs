using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Internal.Client.Helpers
{
    public enum Domain
    {
        [Parameter("https://api.soundcloud.com/")]
        Api,

        [Parameter("https://soundcloud.com/")]
        Direct
    }
}