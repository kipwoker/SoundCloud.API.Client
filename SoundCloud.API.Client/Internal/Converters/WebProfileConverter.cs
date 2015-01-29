using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class WebProfileConverter : IWebProfileConverter
    {
        internal static readonly IWebProfileConverter Default = new WebProfileConverter();

        public SCWebProfile Convert(WebProfile webProfile)
        {
            if (webProfile == null)
            {
                return null;
            }

            return new SCWebProfile();
        }

        public WebProfile Convert(SCWebProfile webProfile)
        {
            if (webProfile == null)
            {
                return null;
            }

            return new WebProfile();
        }
    }
}