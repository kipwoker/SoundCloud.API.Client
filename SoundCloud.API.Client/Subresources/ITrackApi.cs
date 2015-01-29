using System;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources
{
    public interface ITrackApi
    {
        SCTrack GetTrack();
        void UpdateTrack(SCTrack track);
        void DeleteTrack();

        SCComment[] GetComments(int offset = 0, int limit = 50);
        SCComment GetComment(string commentId);
        void PostComment(string text, TimeSpan? timestamp = null);
        void DeleteComment(string commentId);

        SCUser[] GetFavoriters(int offset = 0, int limit = 50);
        SCUser GetFavoriter(string favoriterId);

        //todo: /tracks/{id}/shared-to/users /tracks/{id}/shared-to/emails /tracks/{id}/secret-token
    }
}