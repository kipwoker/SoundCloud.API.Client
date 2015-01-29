using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public enum SCEmbeddableBy
    {
        [Parameter("all")]
        All,

        [Parameter("me")]
        Me,

        [Parameter("none")]
        None
    }
}