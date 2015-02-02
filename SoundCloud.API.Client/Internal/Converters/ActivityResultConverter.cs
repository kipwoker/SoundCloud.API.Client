using System;
using System.Linq;
using SoundCloud.API.Client.Internal.Converters.Infrastructure;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Internal.Objects.Activities;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.ActivityPieces;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class ActivityResultConverter : IActivityResultConverter
    {
        private readonly ITrackConverter trackConverter;
        private readonly ICommentConverter commentConverter;
        private readonly IUserConverter userConverter;
        private readonly IPlaylistConverter playlistConverter;
        private readonly IDateTimeConverter dateTimeConverter;
        internal static readonly IActivityResultConverter Default = 
            new ActivityResultConverter(TrackConverter.Default, CommentConverter.Default, UserConverter.Default, PlaylistConverter.Default, DateTimeConverter.Default);

        internal ActivityResultConverter(
            ITrackConverter trackConverter, 
            ICommentConverter commentConverter, 
            IUserConverter userConverter, 
            IPlaylistConverter playlistConverter,
            IDateTimeConverter dateTimeConverter)
        {
            this.trackConverter = trackConverter;
            this.commentConverter = commentConverter;
            this.userConverter = userConverter;
            this.playlistConverter = playlistConverter;
            this.dateTimeConverter = dateTimeConverter;
        }

        public ActivityResult Convert(SCActivityResult entity)
        {
            throw new NotImplementedException();
        }

        public SCActivityResult Convert(ActivityResult activityResult)
        {
            var queryId = GetValueFromUrl(activityResult.FutureHref, "uuid%5Bto%5D");
            var cursor = GetValueFromUrl(activityResult.NextHref, "cursor");

            var activityTracks = GetActivities<ActivityTrack>(activityResult);
            var activityComments = GetActivities<ActivityComment>(activityResult);
            var activityFavoritings = GetActivities<ActivityFavoriting>(activityResult);
            var activityPlaylists = GetActivities<ActivityPlaylist>(activityResult);

            return new SCActivityResult
            {
                QueryId = queryId,
                CursorToNext = cursor,

                Tracks = activityTracks.Select(t => Convert<ActivityTrack, Track, SCTrack>(t, trackConverter.Convert)).ToArray(),
                Comments = activityComments.Select(c => Convert<ActivityComment, Comment, SCComment>(c, commentConverter.Convert)).ToArray(),
                Favorites = activityFavoritings.Select(f => Convert<ActivityFavoriting, User, SCUser>(f, userConverter.Convert)).ToArray(),
                Playlists = activityPlaylists.Select(p => Convert<ActivityPlaylist, Playlist, SCPlaylist>(p, playlistConverter.Convert)).ToArray(),
            };
        }

        private static TActivity[] GetActivities<TActivity>(ActivityResult activityResult)
        {
            var repository = ActivityTypes.Repository;
            return activityResult.Activities.Where(x => x.Type.StartsWith(repository[typeof(TActivity)])).Cast<TActivity>().ToArray();
        }

        private static string GetValueFromUrl(string uri, string parameterKey)
        {
            var futureUri = new Uri(uri);
            var uuidToPair = futureUri.Query.TrimStart('?').Split('&').FirstOrDefault(x => x.Contains(parameterKey));
            var value = string.IsNullOrEmpty(uuidToPair) ? null : uuidToPair.Split('=')[1];

            return value;
        }

        private SCActivity<TPublic> Convert<TActivity, TOrigin, TPublic>(TActivity input, Func<TOrigin, TPublic> converter)
            where TActivity : ActivityBase, IActivity<TOrigin>
        {
            return new SCActivity<TPublic>
            {
                Type = input.Type,
                Tags = string.IsNullOrEmpty(input.Tags) 
                     ? new SCActivityTag[0]
                     : input.Tags
                            .Split(new[] {",", " "}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.GetValue<SCActivityTag>())
                            .ToArray(),
                CreatedAt = dateTimeConverter.SafeConvert(input.CreatedAt),
                Activity = converter(input.Origin)
            };
        }
    }
}