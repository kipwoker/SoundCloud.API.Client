using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Validation;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.TrackPieces;

namespace SoundCloud.API.Client.Subresources.Helpers
{
    public class TracksSearcher : ITracksSearcher
    {
        private const string dateFormat = "yyyy-MM-dd HH:mm:ss";
        private readonly NumberFormatInfo defaultDecimalSeparator = new NumberFormatInfo { NumberDecimalSeparator = "." };

        private readonly SCFilter filter;
        private readonly IPaginationValidator paginationValidator;
        private readonly Func<Dictionary<string, object>, SCTrack[]> search;
        private readonly Dictionary<string, object> searchParameters;

        internal TracksSearcher(SCFilter filter, bool useNewApi, IPaginationValidator paginationValidator, Func<Dictionary<string, object>, SCTrack[]> search)
        {
            if (filter == SCFilter.Private)
            {
                throw new ArgumentException("Can't search private tracks", "filter");
            }

            this.filter = filter;
            this.paginationValidator = paginationValidator;
            this.search = search;

            searchParameters = new Dictionary<string, object> ();
            Reset();
        }

        public ITracksSearcher Reset()
        {
            searchParameters.Clear();
            searchParameters.Add("filter", filter.GetParameterName());
            return this;
        }
        
        public ITracksSearcher Query(string query)
        {
            const string key = "q";
            if (string.IsNullOrEmpty(query))
            {
                searchParameters.SafeRemove(key);
                return this;
            }

            searchParameters.AddOrUpdate(key, query);
            return this;
        }

        public ITracksSearcher Tags(params string[] tags)
        {
            return Enumerate("tags", tags);
        }

        public ITracksSearcher License(SCLicenseSearch? license)
        {
            const string key = "license";
            if (!license.HasValue)
            {
                searchParameters.SafeRemove(key);
                return this;
            }

            searchParameters.AddOrUpdate(key, license.Value.GetParameterName());
            return this;
        }

        public ITracksSearcher Bpm(float? @from = null, float? to = null)
        {
            return Range("bpm", @from.ToParameterValue(x => x.ToString(defaultDecimalSeparator)), to.ToParameterValue(x => x.ToString(defaultDecimalSeparator)));
        }

        public ITracksSearcher Duration(TimeSpan? @from = null, TimeSpan? to = null)
        {
            return Range("duration", @from.ToParameterValue(x => ((int)x.TotalMilliseconds).ToString()), to.ToParameterValue(x => ((int)x.TotalMilliseconds).ToString()));
        }

        public ITracksSearcher CreatedAt(DateTimeOffset? @from = null, DateTimeOffset? to = null)
        {
            return Range("created_at", @from.ToParameterValue(x => x.UtcDateTime.ToString(dateFormat, CultureInfo.InvariantCulture)), to.ToParameterValue(x => x.UtcDateTime.ToString(dateFormat, CultureInfo.InvariantCulture)));
        }

        public ITracksSearcher Tracks(params string[] trackIds)
        {
            return Enumerate("ids", trackIds);
        }

        public ITracksSearcher Genres(params string[] genres)
        {
            return Enumerate("genres", genres);
        }

        public ITracksSearcher Types(params SCTrackType[] trackTypes)
        {
            return Enumerate("types", trackTypes.Select(x => x.GetParameterName()).ToArray());
        }

        public SCTrack[] Exec(SCOrder order, int offset, int limit)
        {
            paginationValidator.Validate(offset, limit);
            searchParameters.SetPagination(offset, limit);
            searchParameters.AddOrUpdate("order", order.GetParameterName());
            return search(searchParameters);
        }

        private ITracksSearcher Range(string prefix, string @from, string to)
        {
            SafeAddSubParameter(prefix, "from", @from);
            SafeAddSubParameter(prefix, "to", to);

            return this;
        }

        private void SafeAddSubParameter(string prefix, string subparameterName, string value)
        {
            var key = string.Format("{0}[{1}]", prefix, subparameterName);

            if (!string.IsNullOrEmpty(value))
            {
                searchParameters.AddOrUpdate(key, value);
            }
            else
            {
                searchParameters.SafeRemove(key);
            }
        }

        private ITracksSearcher Enumerate(string key, string[] values)
        {
            if (values == null || values.Length == 0)
            {
                searchParameters.SafeRemove(key);
                return this;
            }

            searchParameters.AddOrUpdate(key, string.Join(",", values));
            return this;
        }
    }
}