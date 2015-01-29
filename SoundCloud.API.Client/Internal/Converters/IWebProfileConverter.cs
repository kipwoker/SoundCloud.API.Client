using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal interface IWebProfileConverter
    {
        SCWebProfile Convert(WebProfile webProfile);
        WebProfile Convert(SCWebProfile webProfile);
    }
}