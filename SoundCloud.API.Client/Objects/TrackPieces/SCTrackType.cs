using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public enum SCTrackType
    {
        [Parameter("original")]
        Original,

        [Parameter("remix")]
        Remix,

        [Parameter("live")]
        Live,

        [Parameter("recording")]
        Recording,

        [Parameter("spoken")]
        Spoken,

        [Parameter("podcast")]
        Podcast,

        [Parameter("demo")]
        Demo,

        [Parameter("in progress")]
        InProgress,

        [Parameter("stem")]
        Stem,

        [Parameter("loop")]
        Loop,

        [Parameter("sound effect")]
        SoundEffect,

        [Parameter("sample")]
        Sample,

        [Parameter("other")]
        Other
    }
}