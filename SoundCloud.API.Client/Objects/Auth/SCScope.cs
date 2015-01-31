using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.Auth
{
    public enum SCScope
    {
        [Parameter("non-expiring")]
        NonExpiring,

        [Parameter("*")]
        Asterisk
    }
}