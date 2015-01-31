using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal interface IGroupConverter
    {
        SCGroup Convert(Group @group);
        Group Convert(SCGroup @group);
    }
}