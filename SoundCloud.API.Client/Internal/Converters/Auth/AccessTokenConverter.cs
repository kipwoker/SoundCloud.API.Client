using System;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Objects.Auth;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Converters.Auth
{
    internal class AccessTokenConverter : IAccessTokenConverter
    {
        internal static readonly IAccessTokenConverter Default = new AccessTokenConverter();

        public SCAccessToken Convert(AccessToken accessToken)
        {
            if (accessToken == null)
            {
                return null;
            }

            return new SCAccessToken
            {
                AccessToken = accessToken.Token,
                ExpiresIn = TimeSpan.FromSeconds(accessToken.ExpiresIn),
                RefreshToken = accessToken.RefreshToken,
                Scope = accessToken.Scope.GetValue<SCScope>()
            };
        }

        public AccessToken Convert(SCAccessToken accessToken)
        {
            if (accessToken == null)
            {
                return null;
            }

            return new AccessToken
            {
                Token = accessToken.AccessToken,
                ExpiresIn = (int)accessToken.ExpiresIn.TotalSeconds,
                RefreshToken = accessToken.RefreshToken,
                Scope = accessToken.Scope.GetParameterName()
            };
        }
    }
}