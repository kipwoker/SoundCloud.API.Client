using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Subresources.Helpers;

namespace SoundCloud.API.Client.Subresources
{
    public class TrackApi : ITrackApi
    {
        private readonly string trackId;
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly ITrackConverter trackConverter;
        private readonly IUserConverter userConverter;
        private readonly ICommentConverter commentConverter;
        private readonly string prefix;

        internal TrackApi(
            string trackId, 
            ISoundCloudRawClient soundCloudRawClient, 
            IPaginationValidator paginationValidator, 
            ITrackConverter trackConverter, 
            IUserConverter userConverter,
            ICommentConverter commentConverter)
        {
            this.trackId = trackId;
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
            this.trackConverter = trackConverter;
            this.userConverter = userConverter;
            this.commentConverter = commentConverter;

            prefix = string.Format("tracks/{0}", trackId);
        }

        public SCTrack GetTrack()
        {
            var track = GetInternalTrack();
            return trackConverter.Convert(track);
        }
        
        public void UpdateTrack(SCTrack track)
        {
            if (track.Id != trackId)
            {
                throw new SoundCloudApiException(string.Format("Context set for trackId = {0}. Create new context for update another track.", trackId));
            }

            var currentTrack = GetInternalTrack();

            var diff = currentTrack.GetDiff(trackConverter.Convert(track));

            soundCloudRawClient.Request(prefix, string.Empty, HttpMethod.Put, diff.ToDictionary(x => string.Format("track[{0}]", x.Key), x => x.Value));
        }

        public void DeleteTrack()
        {
            soundCloudRawClient.Request(prefix, string.Empty, HttpMethod.Delete);
        }

        public SCComment[] GetComments(int offset = 0, int limit = 50)
        {
            var comments = soundCloudRawClient.GetCollection<Comment>(paginationValidator, prefix, "comments", offset, limit);
            return comments.Select(commentConverter.Convert).ToArray();
        }

        public SCComment GetComment(string commentId)
        {
            var comment = soundCloudRawClient.Request<Comment>(prefix, string.Format("comments/{0}", commentId), HttpMethod.Get);
            return commentConverter.Convert(comment);
        }

        public SCComment PostComment(string text, TimeSpan? timestamp)
        {
            var parameters = new Dictionary<string, object> { { "comment[body]", text } };
            if (timestamp.HasValue)
            {
                parameters.Add("comment[timestamp]", timestamp.Value.TotalMilliseconds);
            }

            var comment = soundCloudRawClient.Request<Comment>(prefix, "comments", HttpMethod.Post, parameters);
            return commentConverter.Convert(comment);
        }

        public void DeleteComment(string commentId)
        {
            soundCloudRawClient.Request(prefix, string.Format("comments/{0}", commentId), HttpMethod.Delete);
        }

        public SCUser[] GetFavoriters(int offset = 0, int limit = 50)
        {
            return soundCloudRawClient.GetCollection<SCUser>(paginationValidator, prefix, "favoriters", offset, limit);
        }

        public SCUser GetFavoriter(string favoriterId)
        {
            var user = soundCloudRawClient.Request<User>(prefix, string.Format("favoriters/{0}", favoriterId), HttpMethod.Get);
            return userConverter.Convert(user);
        }

        public Stream GetStream()
        {
            return soundCloudRawClient.RequestStream(prefix, "stream", HttpMethod.Get);
        }

        private Track GetInternalTrack()
        {
            return soundCloudRawClient.Request<Track>(prefix, string.Empty, HttpMethod.Get);
        }
    }
}