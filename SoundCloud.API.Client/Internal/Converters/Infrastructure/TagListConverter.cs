using System.Collections.Generic;
using System.Linq;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Internal.Converters.Infrastructure
{
    internal class TagListConverter : ITagListConverter
    {
        internal static readonly ITagListConverter Default = new TagListConverter();

        private const char whitespace = ' ';
        private const char quote = '"';

        public SCTagList Convert(string tagList)
        {
            if (string.IsNullOrEmpty(tagList))
            {
                return new SCTagList();
            }

            var tags = ParseTags(tagList);

            var rawTags = new List<string>();
            var machineTags = new List<SCMachineTag>();
            foreach (var tag in tags)
            {
                if (tag.Contains(":") && tag.Contains("="))
                {
                    var left = tag.Split(':');
                    if (left.Length != 2)
                    {
                        rawTags.Add(tag);
                    }

                    var @namespace = left[0];
                    var right = left[1].Split('=');
                    if (right.Length != 2)
                    {
                        rawTags.Add(tag);
                    }

                    var key = right[0];
                    var value = right[1];

                    machineTags.Add(new SCMachineTag
                    {
                        Namespace = @namespace,
                        Key = key,
                        Value = value
                    });
                }
                else
                {
                    rawTags.Add(tag);    
                }
            }

            return new SCTagList
            {
                Tags = rawTags.ToArray(),
                MachineTags = machineTags.ToArray()
            };
        }

        public string Convert(SCTagList tagList)
        {
            return string.Join(whitespace.ToString(), tagList.Tags.Select(QuotesScreen).Concat(tagList.MachineTags.Select(x => QuotesScreen(string.Format("{0}:{1}={2}", x.Namespace, x.Key, x.Value)))));
        }

        private static IEnumerable<string> ParseTags(string tagList)
        {
            var chars = tagList.ToCharArray();
            var separatorMode = true;
            var offset = 0;
            var count = 0;
            var tags = new List<string>();

            for (var i = 0; i < chars.Length; ++i)
            {
                var token = chars[i];

                if (token == quote)
                {
                    separatorMode = !separatorMode;
                }

                if (token == whitespace && separatorMode)
                {
                    if (count == 0)
                    {
                        continue;
                    }

                    tags.Add(new string(chars.Skip(offset).Take(count).ToArray()));
                    offset = i + 1;
                    count = 0;
                }

                ++count;
            }

            tags.Add(new string(chars.Skip(offset).ToArray()));
            tags = tags.Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim(quote, whitespace)).ToList();
            return tags;
        }

        private static string QuotesScreen(string value)
        {
            return value.Contains(whitespace) ? string.Format("\"{0}\"", value) : value;
        }
    }
}