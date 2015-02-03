using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources.Helpers
{
    public interface IOEmbedQuery
    {
        IOEmbedQuery SetCallback(string callback);
        IOEmbedQuery SetMaxWidth(int maxWidthPercent);
        IOEmbedQuery SetMaxHeight(int maxHeightPx);
        IOEmbedQuery SetColor(string color);
        IOEmbedQuery SetAutoPlay(bool autoPlay);
        IOEmbedQuery SetShowComments(bool showComments);
        IOEmbedQuery SetIFrame(bool iframe);
        SCOEmbed ExecuteJson();
        string ExecuteJsonP();
    }
}