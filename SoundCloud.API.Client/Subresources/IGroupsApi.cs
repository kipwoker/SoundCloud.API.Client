using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface IGroupsApi
    {
        SCGroup[] Search(string query, int offset = 0, int limit = 50);
    }
}