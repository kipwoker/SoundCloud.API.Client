namespace SoundCloud.API.Client.Objects.ExplorePieces
{
    public class SCExploreCategory
    {
        public string Name { get; private set; }
        public SCExploreCategoryType? Type { get; private set; }

        public static SCExploreCategory Create(string name)
        {
            return new SCExploreCategory
            {
                Name = name
            };
        }

        public static SCExploreCategory Create(SCExploreCategoryType exploreCategoryType)
        {
            return new SCExploreCategory
            {
                Type = exploreCategoryType
            };
        }
    }
}
