using SoundCloud.API.Client.Internal.Client;
using SoundCloud.API.Client.Internal.Validation;

namespace SoundCloud.API.Client.Subresources.Factories
{
    internal class SubresourceFactory : ISubresourceFactory
    {
        private readonly ISoundCloudRawClient soundCloudRawClient;
        private readonly IPaginationValidator paginationValidator;

        public SubresourceFactory(ISoundCloudRawClient soundCloudRawClient, IPaginationValidator paginationValidator)
        {
            this.soundCloudRawClient = soundCloudRawClient;
            this.paginationValidator = paginationValidator;
        }

        public IUsersApi CreateUsers(string userId)
        {
            return new UsersApi(userId, soundCloudRawClient, paginationValidator);
        }
    }
}