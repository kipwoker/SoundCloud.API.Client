using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal interface ITrackConverter
    {
        SCTrack Convert(Track track);
        Track Convert(SCTrack track);
    }
}