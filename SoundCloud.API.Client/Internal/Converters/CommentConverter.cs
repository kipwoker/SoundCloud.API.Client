using System;
using SoundCloud.API.Client.Internal.Converters.Infrastructure;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class CommentConverter : ICommentConverter
    {
        internal static readonly ICommentConverter Default = new CommentConverter(UserConverter.Default, DateTimeConverter.Default);

        private readonly IUserConverter userConverter;
        private readonly IDateTimeConverter dateTimeConverter;

        private CommentConverter(IUserConverter userConverter, IDateTimeConverter dateTimeConverter)
        {
            this.userConverter = userConverter;
            this.dateTimeConverter = dateTimeConverter;
        }

        public SCComment Convert(Comment comment)
        {
            if (comment == null)
            {
                return null;
            }

            return new SCComment
            {
                Id = comment.Id,
                Uri = comment.Uri,
                User = userConverter.Convert(comment.User),
                UserId = comment.UserId,
                CreatedAt = dateTimeConverter.SafeConvert(comment.CreatedAt),
                Body = comment.Body,
                Timestamp = TimeSpan.FromMilliseconds(comment.Timestamp),
                TrackId = comment.TrackId
            };
        }

        public Comment Convert(SCComment comment)
        {
            if (comment == null)
            {
                return null;
            }

            return new Comment
            {
                Id = comment.Id,
                Uri = comment.Uri,
                User = userConverter.Convert(comment.User),
                UserId = comment.UserId,
                CreatedAt = dateTimeConverter.Convert(comment.CreatedAt),
                Body = comment.Body,
                Timestamp = (int)comment.Timestamp.TotalMilliseconds,
                TrackId = comment.TrackId
            };
        }
    }
}