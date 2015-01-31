using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Objects.ActivityPieces
{
    public enum SCActivityTag
    {
        /// <summary>
        /// A sharing to only a handful of people
        /// </summary>
        [Parameter("exclusive")]
        Exclusive,

        /// <summary>
        /// An activity from somebody the logged-in user follows
        /// </summary>
        [Parameter("affiliated")]
        Affiliated,

        /// <summary>
        /// The first sharing from a user the logged-in user does not follow
        /// </summary>
        [Parameter("first")]
        First,

        /// <summary>
        /// An activity on one of the logged-in users tracks
        /// </summary>
        [Parameter("own")]
        Own,

        /// <summary>
        /// A comment which is in reaction to a comment made earlier
        /// </summary>
        [Parameter("converation")]
        Converation
    }
}