using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public class CommentApi : ICommentApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly ICommentConverter commentConverter;
        private readonly string prefix;

        internal CommentApi(string commentId, ISoundCloudRawClient soundCloudRawClient, ICommentConverter commentConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.commentConverter = commentConverter;

            prefix = string.Format("comments/{0}", commentId);
        }

        public SCComment GetComment()
        {
            var comment = soundCloudRawClient.RequestApi<Comment>(prefix, string.Empty, HttpMethod.Get);
            return commentConverter.Convert(comment);
        }
    }
}