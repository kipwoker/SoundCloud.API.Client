using System.Collections.Generic;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Client.Helpers
{
    public static class UrlExtensions
    {
        private static readonly IDictionary<SCResponseType, string> responseTypeValueStorage = new Dictionary<SCResponseType, string>
        {
            {SCResponseType.Code, "code"},
            {SCResponseType.TokenAndCode, "token_and_code"}
        };

        private static readonly IDictionary<SCScope, string> scopeValueStorage = new Dictionary<SCScope, string>
        {
            {SCScope.NonExpiring, "non-expiring"},
            {SCScope.Asterisk, "*"}
        };

        private static readonly IDictionary<SCDisplay, string> displayValueStorage = new Dictionary<SCDisplay, string>
        {
            {SCDisplay.Page, "page"},
            {SCDisplay.Popup, "popup"},
            {SCDisplay.Touch, "touch"}
        };

        public static string ToUrlParameterName(this SCResponseType responseType)
        {
            return responseTypeValueStorage[responseType];
        }

        public static string ToUrlParameterName(this SCScope scope)
        {
            return scopeValueStorage[scope];
        }

        public static string ToUrlParameterName(this SCDisplay display)
        {
            return displayValueStorage[display];
        }
    }
}