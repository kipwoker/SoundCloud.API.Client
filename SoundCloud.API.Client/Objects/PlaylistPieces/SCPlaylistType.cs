using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.PlaylistPieces
{
    public enum SCPlaylistType
    {
        [Parameter("ep single")]
        EpSingle,

        [Parameter("album")]
        Album,

        [Parameter("compilation")]
        Compilation,

        [Parameter("project files")]
        ProjectFiles,

        [Parameter("archive")]
        Archive,

        [Parameter("showcase")]
        Showcase,

        [Parameter("demo")]
        Demo,

        [Parameter("sample pack")]
        SamplePack,

        [Parameter("other")]
        Other
    }
}