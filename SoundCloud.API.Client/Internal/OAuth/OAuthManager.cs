using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace SoundCloud.API.Client.Internal.OAuth
{
    internal class OAuthManager
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        private readonly Dictionary<String, String> _params;
        private readonly Random random;

        private const string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        public OAuthManager()
        {
            random = new Random();
            _params = new Dictionary<String, String>();
            _params["callback"] = "oob"; // presume "desktop" consumer
            _params["consumer_key"] = "";
            _params["consumer_secret"] = "";
            _params["timestamp"] = GenerateTimeStamp();
            _params["nonce"] = GenerateNonce();
            _params["signature_method"] = "HMAC-SHA1";
            _params["signature"] = "";
            _params["token"] = "";
            _params["token_secret"] = "";
            _params["version"] = "1.0";
        }

        public OAuthManager(string consumerKey,
                       string consumerSecret,
                       string token,
                       string tokenSecret)
            : this()
        {
            _params["consumer_key"] = consumerKey;
            _params["consumer_secret"] = consumerSecret;
            _params["token"] = token;
            _params["token_secret"] = tokenSecret;
        }

        public OAuthManager(string consumerKey, string consumerSecret)
            : this()
        {
            _params["consumer_key"] = consumerKey;
            _params["consumer_secret"] = consumerSecret;
        }

        public string this[string ix]
        {
            get
            {
                if (_params.ContainsKey(ix))
                    return _params[ix];
                throw new ArgumentException(ix);
            }
            set
            {
                if (!_params.ContainsKey(ix))
                    throw new ArgumentException(ix);
                _params[ix] = value;
            }
        }

        public OAuthResponse AcquireRequestToken(string uri, string method = "POST")
        {
            NewRequest();
            var authzHeader = GetAuthorizationHeader(uri, method);

            // prepare the token request
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", authzHeader);
            request.Method = method;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var r = new OAuthResponse(reader.ReadToEnd());
                this["token"] = r["oauth_token"];

                // Sometimes the request_token URL gives us an access token,
                // with no user interaction required. Eg, when prior approval
                // has already been granted.
                try
                {
                    if (r["oauth_token_secret"] != null)
                        this["token_secret"] = r["oauth_token_secret"];
                }
                catch { }
                return r;
            }
        }


        public OAuthResponse AcquireAccessToken(string uri, string method, string pin)
        {
            NewRequest();
            _params.Remove("callback"); // no longer needed
            _params["verifier"] = pin;

            var authzHeader = GetAuthorizationHeader(uri, method);

            try
            {
                // prepare the token request
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers.Add("Authorization", authzHeader);
                request.Method = method;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var s = reader.ReadToEnd();
                        var r = new OAuthResponse(s);
                        this["token"] = r["oauth_token"];
                        this["token_secret"] = r["oauth_token_secret"];
                        return r;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _params.Remove("verifier");
            }
        }

        public string GenerateCredsHeader(string uri, string method, string realm)
        {
            NewRequest();
            var authzHeader = GetAuthorizationHeader(uri, method, realm);
            return authzHeader;
        }

        public string GenerateAuthzHeader(string uri, string method)
        {
            NewRequest();
            var authzHeader = GetAuthorizationHeader(uri, method);
            return authzHeader;
        }

        private string GetAuthorizationHeader(string uri, string method, string realm = null)
        {
            if (string.IsNullOrEmpty(_params["consumer_key"]))
                throw new ArgumentNullException("consumer_key");

            if (string.IsNullOrEmpty(_params["signature_method"]))
                throw new ArgumentNullException("signature_method");

            Sign(uri, method);

            var erp = EncodeRequestParameters(_params);
            return (string.IsNullOrEmpty(realm))
                ? "OAuth " + erp
                : String.Format("OAuth realm=\"{0}\", ", realm) + erp;
        }


        private void Sign(string uri, string method)
        {
            var signatureBase = GetSignatureBase(uri, method);
            var hash = GetHash();

            var dataBuffer = Encoding.ASCII.GetBytes(signatureBase);
            var hashBytes = hash.ComputeHash(dataBuffer);
            var sig = Convert.ToBase64String(hashBytes);
            this["signature"] = sig;
        }

        private string GetSignatureBase(string url, string method)
        {
            var uri = new Uri(url);
            var normUrl = string.Format("{0}://{1}", uri.Scheme, uri.Host);
            if (!((uri.Scheme == "http" && uri.Port == 80) ||
                  (uri.Scheme == "https" && uri.Port == 443)))
                normUrl += ":" + uri.Port;

            normUrl += uri.AbsolutePath;

            var leftPart = string.Format("{0}&{1}&", method, UrlEncode(normUrl));

            var p = ExtractQueryParameters(uri.Query);

            foreach (var x in _params.Where(x => !string.IsNullOrEmpty(_params[x.Key])
                                              && !x.Key.EndsWith("_secret")
                                              && !x.Key.EndsWith("signature")))
            {
                p.Add("oauth_" + x.Key, (x.Key == "callback") ? UrlEncode(x.Value) : x.Value);
            }


            var rightPart = UrlEncode(string.Join("&", p.OrderBy(x => x.Key).Select(x => string.Format("{0}={1}", x.Key, x.Value))));

            return leftPart + rightPart;
        }


        private HashAlgorithm GetHash()
        {
            if (this["signature_method"] != "HMAC-SHA1")
                throw new NotImplementedException();

            var keystring = string.Format("{0}&{1}", UrlEncode(this["consumer_secret"]), UrlEncode(this["token_secret"]));
            return new HMACSHA1
            {
                Key = Encoding.ASCII.GetBytes(keystring)
            };
        }

        private static string GenerateTimeStamp()
        {
            var ts = DateTime.UtcNow - epoch;
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        private void NewRequest()
        {
            _params["nonce"] = GenerateNonce();
            _params["timestamp"] = GenerateTimeStamp();
        }

        private string GenerateNonce()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 8; i++)
            {
                var g = random.Next(3);
                switch (g)
                {
                    case 0:
                        sb.Append((char)(random.Next(26) + 97), 1);
                        break;
                    default:
                        sb.Append((char)(random.Next(10) + 48), 1);
                        break;
                }
            }
            return sb.ToString();
        }

        private static Dictionary<String, String> ExtractQueryParameters(string queryString)
        {
            if (queryString.StartsWith("?"))
                queryString = queryString.Remove(0, 1);

            var result = new Dictionary<String, String>();

            if (string.IsNullOrEmpty(queryString))
                return result;

            foreach (var s in queryString.Split('&').Where(s => !string.IsNullOrEmpty(s) && !s.StartsWith("oauth_")))
            {
                if (s.IndexOf('=') > -1)
                {
                    var temp = s.Split('=');
                    result.Add(temp[0], temp[1]);
                }
                else
                    result.Add(s, string.Empty);
            }

            return result;
        }

        private static string UrlEncode(string value)
        {
            var result = new StringBuilder();
            foreach (var symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                    result.Append(symbol);
                else
                {
                    foreach (var b in Encoding.UTF8.GetBytes(symbol.ToString()))
                    {
                        result.Append('%' + String.Format("{0:X2}", b));
                    }
                }
            }
            return result.ToString();
        }

        private static string EncodeRequestParameters(IEnumerable<KeyValuePair<string, string>> p)
        {
            var sb = new StringBuilder();
            foreach (var item in p.OrderBy(x => x.Key).Where(item => !string.IsNullOrEmpty(item.Value) && !item.Key.EndsWith("secret")))
            {
                sb.AppendFormat("oauth_{0}=\"{1}\", ",
                    item.Key,
                    UrlEncode(item.Value));
            }

            return sb.ToString().TrimEnd(' ').TrimEnd(',');
        }
    }
}
