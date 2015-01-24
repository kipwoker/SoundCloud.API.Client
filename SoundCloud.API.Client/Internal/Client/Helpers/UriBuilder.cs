using System;
using System.Collections.Generic;

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
            if (parameters.Length == 0)
            {
                return this;
            }

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
            if (parameters == null || parameters.Count == 0)
            {
                return this;
            }

            foreach (var parameter in parameters)
            {
                AddToQueryString(parameter.Key, parameter.Value.ToString());
            }

            return this;
        }

        public IUriBuilder AddToQueryString(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                return this;   
            }

            AddToQueryString(name + "=" + value);
            return this;
        }

        public IUriBuilder AddToQueryString(string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                return this;
            }

            uri = new System.UriBuilder(uri) { Query = (uri.Query + "&" + queryString).TrimStart('&', '?') }.Uri;
            return this;
        }

        public Uri Build()
        {
            return uri;
        }
    }
}