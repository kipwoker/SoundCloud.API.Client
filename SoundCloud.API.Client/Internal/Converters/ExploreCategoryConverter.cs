using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;
using System.Linq;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class ExploreCategoryConverter : IExploreCategoryConverter
    {
        public SCExploreCategory[] Convert(ExploreCategoryCollection categoryCollection)
        {
            if (categoryCollection == null)
            {
                return new SCExploreCategory[0];
            }

            return categoryCollection.MusicCategoryNames.Select(cn => new SCExploreCategory { Name = cn }).ToArray();
        }
    }
}
