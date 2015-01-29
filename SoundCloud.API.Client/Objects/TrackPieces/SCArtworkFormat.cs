using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public enum SCArtworkFormat
    {
        /// <summary>
        /// 100×100 (default)
        /// </summary>
        [Parameter("100×100")]
        T100X100 = 0,

        /// <summary>
        /// 500×500
        /// </summary>
        [Parameter("t500x500")]
        T500X500,

        /// <summary>
        /// 400×400
        /// </summary>
        [Parameter("crop")]
        T400X400,

        /// <summary>
        /// 300×300
        /// </summary>
        [Parameter("t300x300")]
        T300X300,

        /// <summary>
        /// 67×67
        /// </summary>
        [Parameter("t67x67")]
        T67X67,

        /// <summary>
        /// 47×47
        /// </summary>
        [Parameter("badge")]
        T47X47,

        /// <summary>
        /// 32×32
        /// </summary>
        [Parameter("small")]
        T32X32,

        /// <summary>
        /// 20×20
        /// </summary>
        [Parameter("tiny")]
        T20X20,

        /// <summary>
        /// 16×16
        /// </summary>
        [Parameter("mini")]
        T16X16
    }
}