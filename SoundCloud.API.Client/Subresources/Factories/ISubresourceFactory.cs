namespace SoundCloud.API.Client.Subresources.Factories
{
    internal interface ISubresourceFactory
    {
        IUsersApi CreateUsers(string userId);
    }
}