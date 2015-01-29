using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface IUsersApi
    {
        SCUser[] SearchUsers(string query, int offset = 0, int limit = 50);
    }
}