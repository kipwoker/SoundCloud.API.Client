using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class CommentConverter : ICommentConverter
    {
        internal static readonly ICommentConverter Default = new CommentConverter();

        public SCComment Convert(Comment comment)
        {
            if (comment == null)
            {
                return null;
            }

            return new SCComment();
        }

        public Comment Convert(SCComment comment)
        {
            if (comment == null)
            {
                return null;
            }

            return new Comment();
        }
    }
}