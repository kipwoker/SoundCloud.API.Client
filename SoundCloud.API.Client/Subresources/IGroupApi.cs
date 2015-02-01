using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface IGroupApi
    {
        SCGroup GetGroup();
        
        SCUser[] GetModerators(int offset = 0, int limit = 50);
        SCUser[] GetMembers(int offset = 0, int limit = 50);
        SCUser[] GetContributors(int offset = 0, int limit = 50);
        SCUser[] GetUsers(int offset = 0, int limit = 50);
        
        SCTrack[] GetApprovedTracks(int offset = 0, int limit = 50);
        SCTrack[] GetPendingTracks(int offset = 0, int limit = 50);
        SCTrack GetPendingTrack(string trackId);
        void AcceptPendingTrack(string trackId);
        void RejectPendingTrack(string trackId);

        SCTrack[] GetContributions(int offset = 0, int limit = 50);
        SCTrack GetContribution(string trackId);
        void CreateContribution(string trackId);
        void DeleteContribution(string trackId);
    }
}