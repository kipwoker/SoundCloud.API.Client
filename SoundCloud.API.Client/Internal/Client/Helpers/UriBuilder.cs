using System;
using System.Collections.Generic;
using System.Linq;

namespace SoundCloud.API.Client.Internal.Client.Helpers
{
    internal class UriBuilder : IUriBuilder
    {
        private Uri uri;

        internal UriBuilder(Uri uri)
        {
            this.uri = uri;
        }

        public IUriBuilder AddParameters(params object[] parameters)
        {
            uri = new Uri(string.Format(uri.ToString(), parameters));
            return this;
        }

        public IUriBuilder AddToken(string token)
        {
            return AddToQueryString("oauth_token", token);
        }

        public IUriBuilder AddClientId(string clientId)
        {
            return AddToQueryString("client_id", clientId);
        }

        public IUriBuilder AddQueryParameters(Dictionary<string, object> parameters)
        {
            return parameters == null || parameters.Count == 0 
                ? this 
                : AddToQueryString(string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value))));
        }

        public IUriBuilder AddToQueryString(string name, string value)
        {
            uri = new System.UriBuilder(uri) { Query = (uri.Query + "&" + name + "=" + value).TrimStart('&') }.Uri;
            return this;
        }

        public IUriBuilder AddToQueryString(string queryString)
        {
            uri = new System.UriBuilder(uri) { Query = (uri.Query + "&" + queryString).TrimStart('&') }.Uri;
            return this;
        }

        public Uri Build()
        {
            return uri;
        }
    }
}