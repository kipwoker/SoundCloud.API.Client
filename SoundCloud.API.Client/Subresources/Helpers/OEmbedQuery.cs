using System;
using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Subresources.Helpers
{
    public class OEmbedQuery : IOEmbedQuery
    {
        private readonly Func<Dictionary<string, object>, SCOEmbed> jsonExecutor;
        private readonly Func<Dictionary<string, object>, string> jsonpExecutor;
        private readonly Dictionary<string, object> parameters;

        internal OEmbedQuery(string url, Func<Dictionary<string, object>, SCOEmbed> jsonExecutor, Func<Dictionary<string, object>, string> jsonpExecutor)
        {
            this.jsonExecutor = jsonExecutor;
            this.jsonpExecutor = jsonpExecutor;
            parameters = new Dictionary<string, object> { { "url", url } };
        }

        public IOEmbedQuery SetCallback(string callback)
        {
            parameters.AddOrUpdate("callback", callback);
            return this;
        }

        public IOEmbedQuery SetMaxWidth(int maxWidthPercent)
        {
            parameters.AddOrUpdate("maxwidth", maxWidthPercent + "%");
            return this;
        }

        public IOEmbedQuery SetMaxHeight(int maxHeightPx)
        {
            parameters.AddOrUpdate("maxheight", maxHeightPx + "px");
            return this;
        }

        public IOEmbedQuery SetColor(string color)
        {
            parameters.AddOrUpdate("color", color);
            return this;
        }

        public IOEmbedQuery SetAutoPlay(bool autoPlay)
        {
            parameters.AddOrUpdate("auto_play", autoPlay);
            return this;
        }

        public IOEmbedQuery SetShowComments(bool showComments)
        {
            parameters.AddOrUpdate("show_comments", showComments);
            return this;
        }

        public IOEmbedQuery SetIFrame(bool iframe)
        {
            parameters.AddOrUpdate("iframe", iframe);
            return this;
        }

        public SCOEmbed ExecuteJson()
        {
            return jsonExecutor(parameters);
        }

        public string ExecuteJsonP()
        {
            return jsonpExecutor(parameters);
        }
    }
}