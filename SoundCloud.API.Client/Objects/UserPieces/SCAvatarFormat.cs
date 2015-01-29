using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.UserPieces
{
    public enum SCAvatarFormat
    {
        /// <summary>
        /// 100×100 (default)
        /// </summary>
        [Parameter("large")]
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
        /// 18×18
        /// </summary>
        [Parameter("tiny")]
        T18X18,

        /// <summary>
        /// 16×16
        /// </summary>
        [Parameter("mini")]
        T16X16
    }
}