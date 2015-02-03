using System;
using System.Collections.Generic;
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
    public class GroupApi : IGroupApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly IGroupConverter groupConverter;
        private readonly IUserConverter userConverter;
        private readonly ITrackConverter trackConverter;
        private readonly string prefix;

        internal GroupApi(
            string groupId,
            ISoundCloudRawClient soundCloudRawClient,
            IPaginationValidator paginationValidator,
            IGroupConverter groupConverter,
            IUserConverter userConverter,
            ITrackConverter trackConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
            this.groupConverter = groupConverter;
            this.userConverter = userConverter;
            this.trackConverter = trackConverter;
            prefix = string.Format("groups/{0}", groupId);
        }

        public SCGroup GetGroup()
        {
            var @group = soundCloudRawClient.Request<Group>(prefix, string.Empty, HttpMethod.Get);
            return groupConverter.Convert(@group);
        }

        public SCUser[] GetModerators(int offset, int limit)
        {
            return GetUsers("moderators", offset, limit);
        }

        public SCUser[] GetMembers(int offset, int limit)
        {
            return GetUsers("members", offset, limit);
        }

        public SCUser[] GetContributors(int offset, int limit)
        {
            return GetUsers("contributors", offset, limit);
        }

        public SCUser[] GetUsers(int offset, int limit)
        {
            return GetUsers("users", offset, limit);
        }

        public SCTrack[] GetApprovedTracks(int offset, int limit)
        {
            return GetTracks("tracks", offset, limit);
        }

        public SCTrack[] GetPendingTracks(int offset, int limit)
        {
            return GetTracks("pending_tracks", offset, limit);
        }

        public SCTrack GetPendingTrack(string trackId)
        {
            var track = soundCloudRawClient.Request<Track>(prefix, string.Format("pending_tracks/{0}", trackId), HttpMethod.Get);
            return trackConverter.Convert(track);
        }

        public void AcceptPendingTrack(string trackId)
        {
            soundCloudRawClient.Request(prefix, string.Format("pending_tracks/{0}", trackId), HttpMethod.Put);
        }

        public void RejectPendingTrack(string trackId)
        {
            soundCloudRawClient.Request(prefix, string.Format("pending_tracks/{0}", trackId), HttpMethod.Delete);
        }

        public SCTrack[] GetContributions(int offset, int limit)
        {
            paginationValidator.Validate(offset, limit);
            var tracks = soundCloudRawClient.Request<Track[]>(prefix, "contributions", HttpMethod.Get, new Dictionary<string, object>().SetPagination(offset, limit), responseType: null);
            return tracks.Select(trackConverter.Convert).ToArray();
        }

        public SCTrack GetContribution(string trackId)
        {
            var track = soundCloudRawClient.Request<Track>(prefix, string.Format("contributions/{0}", trackId), HttpMethod.Get, responseType: null);
            return trackConverter.Convert(track);
        }

        public void CreateContribution(string trackId)
        {
            soundCloudRawClient.Request(prefix, "contributions", HttpMethod.Post, new Dictionary<string, object> { { "track[id]", trackId } });
        }

        public void DeleteContribution(string trackId)
        {
            soundCloudRawClient.Request(prefix, string.Format("contributions/{0}", trackId), HttpMethod.Delete);
        }

        private SCUser[] GetUsers(string command, int offset, int limit)
        {
            return GetEntites<User, SCUser>(command, offset, limit, userConverter.Convert);
        }

        private SCTrack[] GetTracks(string command, int offset, int limit)
        {
            return GetEntites<Track, SCTrack>(command, offset, limit, trackConverter.Convert);
        }

        private TOut[] GetEntites<TIn, TOut>(string command, int offset, int limit, Func<TIn, TOut> convert)
        {
            var collection = soundCloudRawClient.GetCollection<TIn>(paginationValidator, prefix, command, offset, limit);
            return collection.Select(convert).ToArray();
        }
    }
}