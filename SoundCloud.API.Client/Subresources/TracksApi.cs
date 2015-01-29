using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;
using SoundCloud.API.Client.Subresources.Helpers;
using File = SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading.File;

namespace SoundCloud.API.Client.Subresources
{
    public class TracksApi : ITracksApi
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;
        private const string prefix = "tracks";

        internal TracksApi(ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
        }

        public SCTrack UploadTrack(string path, string title, string description, SCSharing sharing)
        {
            var file = File.Build(path, "track[asset_data]");

            var parameters = new Dictionary<string, object>
            {
                {"track[title]", title},
                {"track[description]", description},
                {"track[sharing]", sharing.GetParameterName()}
            };

            return soundCloudRawClient.Upload<SCTrack>(prefix, string.Empty, parameters, files: file);
        }

        public ITracksSearcher BeginSearch(SCFilter filter)
        {
            return new TracksSearcher(filter, paginationValidator, parameters => soundCloudRawClient.RequestApi<SCTrack[]>(prefix, string.Empty, HttpMethod.Get, parameters));
        }
    }
}