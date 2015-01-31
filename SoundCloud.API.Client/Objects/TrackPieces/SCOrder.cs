using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public enum SCOrder
    {
        [Parameter("created_at")]
        CreatedAt,

        [Parameter("hotness")]
        Hotness
    }
}