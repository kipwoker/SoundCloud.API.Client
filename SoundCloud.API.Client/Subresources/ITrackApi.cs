using System;
using System.IO;
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
        SCComment PostComment(string text, TimeSpan? timestamp = null);
        void DeleteComment(string commentId);

        SCUser[] GetFavoriters(int offset = 0, int limit = 50);
        [Obsolete("API BUG. Use GetFavoriters(). This method returns 401. It's API trouble. More here: https://github.com/soundcloud/soundcloud-ruby/issues/24")]
        SCUser GetFavoriter(string favoriterId);

        /// <summary>
        /// Be careful. Sometimes throws 403. Invalid signature key. More: https://github.com/kipwoker/SoundCloud.API.Client/issues/1
        /// </summary>
        /// <returns></returns>
        Stream GetStream();

        //todo:
        //GET, POST, PUT, DELETE	/tracks/{id}/shared-to/users	users who have access to the track
        //GET, POST, PUT, DELETE	/tracks/{id}/shared-to/emails	email addresses who are invited to the track
        //GET, PUT	/tracks/{id}/secret-token	secret token of the track
    }
}