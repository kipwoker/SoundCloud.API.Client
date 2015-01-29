using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public enum SCSharing
    {
        [Parameter("public")]
        Public,

        [Parameter("private")]
        Private
    }
}