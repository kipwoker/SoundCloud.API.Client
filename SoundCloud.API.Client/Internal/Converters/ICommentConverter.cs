using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal interface ICommentConverter
    {
        SCComment Convert(Comment comment);
        Comment Convert(SCComment comment);
    }
}