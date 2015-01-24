using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;

namespace SoundCloud.API.Client.Internal.Infrastructure.Network
{
    internal class WebGateway : IWebGateway
    {
        internal static readonly IWebGateway Default = new WebGateway();

        private WebGateway()
        {
        }
        
        public string Request(Uri uri, HttpMethod method)
        {
            var request = WebRequest.Create(uri);

            request.Method = method.ToString().ToUpperInvariant();

            request.ContentType = "application/json";
            request.ContentLength = 0;

            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");

            try
            {
                using (var response = (HttpWebResponse) request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                {
                    var content = SmartReadContent(response, responseStream);
                    if (IsError(response.StatusCode))
                    {
                        throw new Exception(string.Format("WebRequest exception. Parameters: method = {1}, uri = {0}. Response: {2} - {3}.", uri.AbsoluteUri, method, (int)response.StatusCode, content));
                    }

                    return content;
                }
            }
            catch (WebException ex)
            {
                using (var response = (HttpWebResponse)ex.Response)
                using (var responseStream = response.GetResponseStream())
                {
                    var content = SmartReadContent(response, responseStream);
                    throw new Exception(string.Format("WebRequest exception. Parameters: method = {1}, uri = {0}. Response: {2} - {3}", uri.AbsoluteUri, method, (int)response.StatusCode, content), ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("General WebGateway exception. Parameters: method = {1}, uri = {0}", uri.AbsoluteUri, method), ex);
            }
        }

        private static string SmartReadContent(HttpWebResponse response, Stream stream)
        {
            var contentEncoding = response.Headers[HttpResponseHeader.ContentEncoding];
            if (!string.IsNullOrEmpty(contentEncoding) && (contentEncoding.Contains("gzip") || contentEncoding.Contains("deflate")))
            {
                using (var gZipStream = new GZipStream(stream, CompressionMode.Decompress))
                {
                    //todo: maybe in catch error case should try stream without gZip?
                    return ReadContent(gZipStream);
                }
            }

            return ReadContent(stream);
        }

        private static string ReadContent(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static bool IsError(HttpStatusCode httpStatusCode)
        {
            var code = ((int)httpStatusCode).ToString();
            return !(code.StartsWith("2") || code.StartsWith("3"));
        }
    }
}