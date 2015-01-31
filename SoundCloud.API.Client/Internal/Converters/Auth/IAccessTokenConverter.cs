using SoundCloud.API.Client.Internal.Objects.Auth;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Converters.Auth
{
    internal interface IAccessTokenConverter
    {
        SCAccessToken Convert(AccessToken accessToken);
        AccessToken Convert(SCAccessToken accessToken);
    }
}