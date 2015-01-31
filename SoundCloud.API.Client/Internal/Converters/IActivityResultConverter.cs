using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal interface IActivityResultConverter
    {
        SCActivityResult Convert(ActivityResult activityResult);
    }
}