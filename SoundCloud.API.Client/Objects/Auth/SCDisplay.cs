using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.Auth
{
    public enum SCDisplay
    {
        [Parameter("popup")]
        Popup,

        [Parameter("page")]
        Page,

        [Parameter("touch")]
        Touch
    }
}