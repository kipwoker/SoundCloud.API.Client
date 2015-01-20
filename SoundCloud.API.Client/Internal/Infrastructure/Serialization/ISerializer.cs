namespace SoundCloud.API.Client.Internal.Infrastructure.Serialization
{
    internal interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string json);
    }
}