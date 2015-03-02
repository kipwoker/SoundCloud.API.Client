using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources.Public
{
    public interface IPublicGroupApi
    {
        SCGroup GetGroup();

        SCUser[] GetModerators(int offset = 0, int limit = 50);
        SCUser[] GetMembers(int offset = 0, int limit = 50);
        SCUser[] GetContributors(int offset = 0, int limit = 50);
        SCUser[] GetUsers(int offset = 0, int limit = 50);

        SCTrack[] GetApprovedTracks(int offset = 0, int limit = 50);
    }
}