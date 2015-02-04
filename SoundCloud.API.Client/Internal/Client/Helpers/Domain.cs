using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Internal.Client.Helpers
{
    internal enum Domain
    {
        [Parameter("https://api.soundcloud.com/")]
        Api,

        [Parameter("https://soundcloud.com/")]
        Direct
    }
}