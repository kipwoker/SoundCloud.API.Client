using System;
using System.Globalization;

namespace SoundCloud.API.Client.Internal.Converters.Infrastructure
{
    internal class DateTimeConverter : IDateTimeConverter
    {
        internal static readonly IDateTimeConverter Default = new DateTimeConverter();

        public DateTimeOffset Convert(string dateTime)
        {
            return DateTimeOffset.Parse(dateTime, CultureInfo.InvariantCulture);
        }

        public DateTimeOffset? SafeConvert(string dateTime)
        {
            return string.IsNullOrEmpty(dateTime) ? (DateTimeOffset?) null : Convert(dateTime);
        }

        public string Convert(DateTimeOffset? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.UtcDateTime.ToString(CultureInfo.InvariantCulture) : null;
        }

        public DateTimeOffset? ConvertReleaseDate(int? year, int? month, int? day)
        {
            return year.HasValue && month.HasValue && day.HasValue
                ? new DateTimeOffset(new DateTime(year.Value, month.Value, day.Value))
                : (DateTimeOffset?)null;
        }
    }
}