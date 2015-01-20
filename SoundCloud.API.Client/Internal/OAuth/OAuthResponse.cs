using System.Collections.Generic;
using System.Linq;

namespace SoundCloud.API.Client.Internal.OAuth
{
    internal class OAuthResponse
    {
        public string AllText { get; set; }
        private readonly Dictionary<string, string> _params;

        public string this[string ix]
        {
            get
            {
                return _params[ix];
            }
        }

        internal OAuthResponse(string alltext)
        {
            AllText = alltext;
            _params = new Dictionary<string, string>();
            var kvpairs = alltext.Split('&');
            foreach (var kv in kvpairs.Select(pair => pair.Split('=')))
            {
                _params.Add(kv[0], kv[1]);
            }
            // expected keys:
            //   oauth_token, oauth_token_secret, user_id, screen_name, etc
        }
    }
}