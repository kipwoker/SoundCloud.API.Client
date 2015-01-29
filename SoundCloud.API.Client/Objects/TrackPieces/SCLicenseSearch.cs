using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public enum SCLicenseSearch
    {
        [Parameter("to_share")]
        ToShare,

        [Parameter("to_use_commercially")]
        ToUseCommercially,

        [Parameter("to_modify_commercially")]
        ToModifyCommercially,

        [Parameter("cc-by")]
        CcBy,
        
        [Parameter("cc-by-nc-nd")]
        CcByNcNd,

        [Parameter("cc-by-nc-nd-sa")]
        CcByNcNdSa,

        [Parameter("cc-by-nc-sa")]
        CcByNcSa,

        [Parameter("cc-by-nd")]
        CcByNd,

        [Parameter("cc-by-sa")]
        CcBySa,
    }
}