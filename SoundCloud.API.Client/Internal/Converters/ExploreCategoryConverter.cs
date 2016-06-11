using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;
using System.Linq;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class ExploreCategoryConverter : IExploreCategoryConverter
    {
        public SCExploreCategory[] Convert(ExploreCategoryList categoryList)
        {
            if (categoryList == null)
            {
                return null;
            }

            return categoryList.MusicCategoryNames.Select(cn => new SCExploreCategory { Name = cn }).ToArray();
        }
    }
}
