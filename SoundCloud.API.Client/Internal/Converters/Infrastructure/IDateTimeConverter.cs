using System;

namespace SoundCloud.API.Client.Internal.Converters.Infrastructure
{
    internal interface IDateTimeConverter
    {
        DateTimeOffset Convert(string dateTime);
        DateTimeOffset? SafeConvert(string dateTime);
        string Convert(DateTimeOffset? dateTime);
        DateTimeOffset? ConvertReleaseDate(int? year, int? month, int? day);
    }
}