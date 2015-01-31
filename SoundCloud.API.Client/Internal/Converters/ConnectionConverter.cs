using SoundCloud.API.Client.Internal.Converters.Infrastructure;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects;
using SoundCloud.API.Client.Objects;
using SoundCloud.API.Client.Objects.ConnectionPieces;

namespace SoundCloud.API.Client.Internal.Converters
{
    internal class ConnectionConverter : IConnectionConverter
    {
        private readonly IDateTimeConverter dateTimeConverter;
        internal static readonly IConnectionConverter Default = new ConnectionConverter(DateTimeConverter.Default);

        private ConnectionConverter(IDateTimeConverter dateTimeConverter)
        {
            this.dateTimeConverter = dateTimeConverter;
        }

        public SCConnection Convert(Connection connection)
        {
            if (connection == null)
            {
                return null;
            }

            return new SCConnection
            {
                Id = connection.Id,
                CreatedAt = dateTimeConverter.SafeConvert(connection.CreatedAt),
                DisplayName = connection.DisplayName,
                Uri = connection.Uri,
                Service = connection.Service.GetValue<SCServiceType>(),
                Type = connection.Type,
                PostFavorite = connection.PostFavorite,
                PostPublish = connection.PostPublish
            };
        }

        public Connection Convert(SCConnection connection)
        {
            if (connection == null)
            {
                return null;
            }

            return new Connection
            {
                Id = connection.Id,
                CreatedAt = dateTimeConverter.Convert(connection.CreatedAt),
                DisplayName = connection.DisplayName,
                Uri = connection.Uri,
                Service = connection.Service.GetParameterName(),
                Type = connection.Type,
                PostFavorite = connection.PostFavorite,
                PostPublish = connection.PostPublish
            };
        }
    }
}