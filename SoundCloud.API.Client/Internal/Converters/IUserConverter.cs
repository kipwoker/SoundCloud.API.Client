using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal interface IUserConverter
    {
        SCUser Convert(User user);
        User Convert(SCUser user);
    }
}