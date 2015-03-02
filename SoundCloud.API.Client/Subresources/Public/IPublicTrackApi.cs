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

        Stream GetStream(); 
    }
}