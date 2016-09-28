namespace SoundCloud.API.Client.Objects.ExplorePieces
{
    internal static class SCExploreCategoryExtensions
    {
        public static string GetName(this SCExploreCategory category)
        {
            return category?.Type?.GetValue() ?? category?.Name;
        }
    }
}