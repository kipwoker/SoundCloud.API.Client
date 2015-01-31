using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.ConnectionPieces
{
    //note: Excluded 'myspace', because api returs 422. Seems like it's doesn't supported.
    public enum SCServiceType
    {
        [Parameter("facebook_profile")]
        Facebook,

        [Parameter("twitter")]
        Twitter
    }
}