using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Internal.Converters.Infrastructure
{
    internal interface ITagListConverter
    {
        SCTagList Convert(string tagList);
        string Convert(SCTagList tagList);
    }
}