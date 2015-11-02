using System.Collections.Generic;
using System.IO;
using System.Linq;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Converters;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;
using SoundCloud.API.Client.Subresources.Helpers;
using File = SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading.File;
using System;

namespace SoundCloud.API.Client.Subresources
{
    public class TracksApi : ITracksApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private readonly ITrackConverter trackConverter;
        private const string prefix = "tracks";
        private const string searchPrefix = "search";
        private const string searchCommand = "tracks";

        internal TracksApi(ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator, ITrackConverter trackConverter)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
            this.trackConverter = trackConverter;
        }

        public SCTrack UploadTrack(Stream trackFileStream, string title, string description, SCSharing sharing, Stream artworkFileStream)
        {
            var files = new List<File>();
            if (artworkFileStream != null)
            {
                var artworkFile = File.Build(artworkFileStream, "track[artwork_data]");
                files.Add(artworkFile);
            }

            var trackFile = File.Build(trackFileStream, "track[asset_data]");
            files.Add(trackFile);

            var parameters = new Dictionary<string, object>
            {
                {"track[title]", title},
                {"track[description]", description},
                {"track[sharing]", sharing.GetParameterName()}
            };

            var uploadedTrack = soundCloudRawClient.Upload<Track>(prefix, string.Empty, parameters, files: files.ToArray());
            return trackConverter.Convert(uploadedTrack);
        }

        public ITracksSearcher BeginSearch(SCFilter filter, bool useNewApi = true)
        {
            Func<Dictionary<string, object>, SCTrack[]> search;
            if (useNewApi)
            {
                search = parameters =>
                {
                    var tracks = soundCloudRawClient.Request<TrackCollection>(searchPrefix, searchCommand, HttpMethod.Get, parameters, responseType: string.Empty, domain: Internal.Client.Helpers.Domain.ApiV2);
                    return tracks.Tracks.Select(trackConverter.Convert).ToArray();
                };
            }
            else
            {
                search = parameters =>
                {
                    var tracks = soundCloudRawClient.Request<Track[]>(prefix, string.Empty, HttpMethod.Get, parameters);
                    return tracks.Select(trackConverter.Convert).ToArray();
                };
            }
            return new TracksSearcher(filter, 
                                      useNewApi,
                                      paginationValidator,
                                      search);
        }
    }
}