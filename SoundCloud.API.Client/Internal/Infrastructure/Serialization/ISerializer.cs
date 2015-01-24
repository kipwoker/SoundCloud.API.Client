#if DEBUG
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("SoundCloud.API.Client.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
#endif

namespace SoundCloud.API.Client.Internal.Infrastructure.Serialization
{
    internal interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string json);
    }
}