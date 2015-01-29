using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public enum SCLicense
    {
        [Parameter("no-rights-reserved")]
        NoRightsReserved,

        [Parameter("all-rights-reserved")]
        AllRightsReserved,

        [Parameter("cc-by")]
        CcBy,

        [Parameter("cc-by-nc")]
        CcByNc,

        [Parameter("cc-by-nd")]
        CcByNd,

        [Parameter("cc-by-sa")]
        CcBySa,

        [Parameter("cc-by-nc-nd")]
        CcByNcNd,

        [Parameter("cc-by-nc-sa")]
        CcByNcSa,

        [Parameter("cc-by-nc-nd-sa")]
        CcByNcNdSa,
    }
}