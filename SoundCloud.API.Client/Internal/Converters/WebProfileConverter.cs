using SoundCloud.API.Client.Internal.Converters.Infrastructure;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class WebProfileConverter : IWebProfileConverter
    {
        private readonly IDateTimeConverter dateTimeConverter;

        internal WebProfileConverter(IDateTimeConverter dateTimeConverter)
        {
            this.dateTimeConverter = dateTimeConverter;
        }

        public SCWebProfile Convert(WebProfile webProfile)
        {
            if (webProfile == null)
            {
                return null;
            }

            return new SCWebProfile
            {
                Id = webProfile.Id,
                Kind = webProfile.Kind,
                Service = webProfile.Service,
                Title = webProfile.Title,
                Url = webProfile.Url,
                UserName = webProfile.UserName,
                CreatedAt = dateTimeConverter.SafeConvert(webProfile.CreatedAt)
            };
        }

        public WebProfile Convert(SCWebProfile webProfile)
        {
            if (webProfile == null)
            {
                return null;
            }

            return new WebProfile
            {
                Id = webProfile.Id,
                Kind = webProfile.Kind,
                Service = webProfile.Service,
                Title = webProfile.Title,
                Url = webProfile.Url,
                UserName = webProfile.UserName,
                CreatedAt = dateTimeConverter.Convert(webProfile.CreatedAt)
            };
        }
    }
}