using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public enum SCFilter
    {
        [Parameter("all")]
        All,

        [Parameter("public")]
        Public,

        [Parameter("private")]
        Private,

        [Parameter("streamable")]
        Streamable,

        [Parameter("downloadable")]
        Downloadable
    }
}