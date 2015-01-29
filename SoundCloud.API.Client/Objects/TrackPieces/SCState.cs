using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public enum SCState
    {
        [Parameter("processing")]
        Processing,

        [Parameter("failed")]
        Failed,

        [Parameter("finished")]
        Finished,
    }
}