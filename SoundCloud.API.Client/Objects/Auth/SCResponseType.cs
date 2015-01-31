using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.Auth
{
    public enum SCResponseType
    {
        [Parameter("code")]
        Code,

        [Parameter("token_and_code")]
        TokenAndCode
    }
}