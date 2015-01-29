using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal interface IApplicationConverter
    {
        SCApplication Convert(Application application);
        Application Convert(SCApplication application);
    }
}