#if DEBUG
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("SoundCloud.API.Client.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
#endif

namespace SoundCloud.API.Client.Internal.Validation
{
    internal interface IPaginationValidator
    {
        bool IsValid(int offset, int count, out string errorMessage);
    }
}