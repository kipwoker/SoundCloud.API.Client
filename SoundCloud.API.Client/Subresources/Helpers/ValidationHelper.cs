using SoundCloud.API.Client.Internal.Validation;

namespace SoundCloud.API.Client.Subresources.Helpers
{
    internal static class ValidationHelper
    {
        internal static void Validate(this IPaginationValidator paginationValidator, int offset, int limit)
        {
            string errorMessage;
            if (!paginationValidator.IsValid(offset, limit, out errorMessage))
            {
                throw new SoundCloudApiException(errorMessage);
            }
        }
    }
}