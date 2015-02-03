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
    public interface IAppApi
    {
        SCApplication GetApplication();

        SCTrack[] GetTracks(int offset = 0, int limit = 50);
    }

    public class AppApi : IAppApi
    {
        private readonly IPaginationValidator paginationValidator;
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IApplicationConverter applicationConverter;
        private readonly ITrackConverter trackConverter;
        private readonly string prefix;

        internal AppApi(
            string applicationId, 
            IPaginationValidator paginationValidator, 
            ISoundCloudRawClient soundCloudRawClient, 
            IApplicationConverter applicationConverter,
            ITrackConverter trackConverter)
        {
            this.paginationValidator = paginationValidator;
            this.soundCloudRawClient = soundCloudRawClient;
            this.applicationConverter = applicationConverter;
            this.trackConverter = trackConverter;

            prefix = string.Format("apps/{0}", applicationId);
        }


        public SCApplication GetApplication()
        {
            var application = soundCloudRawClient.Request<Application>(prefix, string.Empty, HttpMethod.Get);
            return applicationConverter.Convert(application);
        }

        public SCTrack[] GetTracks(int offset = 0, int limit = 50)
        {
            var tracks = soundCloudRawClient.GetCollection<Track>(paginationValidator, prefix, "tracks", offset, limit);
            return tracks.Select(trackConverter.Convert).ToArray();
        }
    }
}