using System;
using System.Collections.Generic;
using System.Linq;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Internal.Client.Helpers
{
    internal class UriBuilder : IUriBuilder
    {
        private readonly Uri uri;
        private readonly Dictionary<string, string> queryParameters = new Dictionary<string, string>();

        internal UriBuilder(Uri uri)
        {
            this.uri = uri;
        }

        public IUriBuilder AddQueryParameters(Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count == 0)
            {
                return this;
            }

            foreach (var parameter in parameters.Where(x => x.Value != null))
            {
                AddParameter(parameter.Key, parameter.Value.ToString());
            }

            return this;
        }

        public IUriBuilder AddCredentials(SCCredentials credentials, SCAccessToken accessToken)
        {
            if (credentials == null)
                return this;

            if (accessToken != null)
            {
                AddToken(accessToken.AccessToken);
            }

            AddClientId(credentials.ClientId);
            return this;
        }

        public Uri Build()
        {
            var queryString = string.Join("&", queryParameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
            var uriWithParams = new System.UriBuilder(uri) { Query = (uri.Query + "&" + queryString).TrimStart('&', '?') }.Uri;
            return uriWithParams;
        }

        private void AddToken(string token)
        {
            AddParameter("oauth_token", token);
        }

        private void AddClientId(string clientId)
        {
            AddParameter("client_id", clientId);
        }

        public void AddParameter(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            queryParameters[name] = value;
        }
    }
}