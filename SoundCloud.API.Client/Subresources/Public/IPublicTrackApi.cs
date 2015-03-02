using System;
using System.IO;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources.Public
{
    public interface IPublicTrackApi
    {
        SCTrack GetTrack();

        SCComment[] GetComments(int offset = 0, int limit = 50);
        SCComment GetComment(string commentId);

        SCUser[] GetFavoriters(int offset = 0, int limit = 50);
        [Obsolete("API BUG. Use GetFavoriters(). This method returns 401. It's API trouble. More here: https://github.com/soundcloud/soundcloud-ruby/issues/24")]
        SCUser GetFavoriter(string favoriterId);

        /// <summary>
        /// Be careful. Sometimes throws 403. Invalid signature key. More: https://github.com/kipwoker/SoundCloud.API.Client/issues/1
        /// </summary>
        /// <returns></returns>
        Stream GetStream(); 
    }
}