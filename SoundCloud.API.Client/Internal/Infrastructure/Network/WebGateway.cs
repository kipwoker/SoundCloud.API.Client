using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Infrastructure.Network
{
    internal class WebGateway : IWebGateway
    {
        private readonly bool enableGZip;
        private readonly Action apiActionExecuting;
        private readonly Action<SCResponse> apiActionExecuted;
        private readonly Action<SCResponse> apiActionError;
        private readonly ISerializer jsonSerializer;
        internal WebGateway(
            bool enableGZip,
            Action apiActionExecuting,
            Action<SCResponse> apiActionExecuted,
            Action<SCResponse> apiActionError,
            ISerializer jsonSerializer)
        {
            this.enableGZip = enableGZip;
            this.apiActionExecuting = apiActionExecuting ?? (() => {});
            this.apiActionExecuted = apiActionExecuted ?? (x => {});
            this.apiActionError = apiActionError ?? (x => {});
            this.jsonSerializer = jsonSerializer;
        }

        public T Request<T>(Uri uri, HttpMethod method)
        {
            var request = WebRequest.Create(uri);

            request.Method = method.ToString().ToUpperInvariant();

            request.ContentType = "application/json";
            request.ContentLength = 0;

            if (enableGZip)
            {
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            }

            apiActionExecuting();

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                {
                    var isError = IsError(response.StatusCode);
                    if (responseStream == null && isError)
                    {
                        apiActionError(new SCResponse { ResponseContent = "Response is empty", ReturnedType = typeof(T), StatusCode = response.StatusCode });
                        return default(T);
                    }

                    var contentEncoding = response.Headers[HttpResponseHeader.ContentEncoding];
                    if (contentEncoding.Contains("gzip") || contentEncoding.Contains("deflate"))
                    {
                        using (var gZipStream = new GZipStream(responseStream, CompressionMode.Decompress))
                        {
                            //todo: maybe if catch error should try stream without gZip?
                            return HandleResponse<T>(response.StatusCode, isError, gZipStream);
                        }
                    }

                    return HandleResponse<T>(response.StatusCode, isError, responseStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("WebRequest exception. Parameters: method = {1}, uri = {0}", uri.AbsoluteUri, method), ex);
            }
        }

        private T HandleResponse<T>(HttpStatusCode statusCode, bool isError, Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                var scEventArgs = new SCResponse { ResponseContent = content, ReturnedType = typeof(T), StatusCode = statusCode };
                if (isError)
                {
                    apiActionError(scEventArgs);
                    return default(T);
                }

                apiActionExecuted(scEventArgs);
                return jsonSerializer.Deserialize<T>(content);
            }
        }

        private static bool IsError(HttpStatusCode httpStatusCode)
        {
            var code = ((int)httpStatusCode).ToString();
            return !(code.StartsWith("2") && code.StartsWith("3"));
        }
    }
}