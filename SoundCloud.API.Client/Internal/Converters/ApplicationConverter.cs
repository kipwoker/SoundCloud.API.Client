using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class ApplicationConverter : IApplicationConverter
    {
        internal static readonly IApplicationConverter Default = new ApplicationConverter();

        public SCApplication Convert(Application application)
        {
            if (application == null)
            {
                return null;
            }

            return new SCApplication
            {
                Id = application.Id,
                Name = application.Name,
                PermalinkUrl = application.PermalinkUrl,
                Uri = application.Uri
            };
        }

        public Application Convert(SCApplication application)
        {
            if (application == null)
            {
                return null;
            }

            return new Application
            {
                Id = application.Id,
                Name = application.Name,
                PermalinkUrl = application.PermalinkUrl,
                Uri = application.Uri
            };
        }
    }
}