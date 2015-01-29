using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading;
using File = SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading.File;

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

            request.Method = method.GetParameterName();

            request.ContentType = "application/json";
            request.ContentLength = 0;

            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");

            Func<int, string, string> buildExceptionMessage = (statusCode, content) =>
                                                              string.Format("WebRequest exception. Parameters: method = {1}, uri = {0}. Response: {2} - {3}.", uri.AbsoluteUri, method, statusCode, content);

            return GetResponse(request, buildExceptionMessage);
        }

        private static string GetResponse(WebRequest request, Func<int, string, string> buildExceptionMessage)
        {
            try
            {
                using (var response = (HttpWebResponse) request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                {
                    var content = SmartReadContent(response, responseStream);
                    if (IsError(response.StatusCode))
                    {
                        throw new WebGatewayException(buildExceptionMessage((int)response.StatusCode, content), response.StatusCode);
                    }

                    return content;
                }
            }
            catch (WebException ex)
            {
                using (var response = (HttpWebResponse) ex.Response)
                using (var responseStream = response.GetResponseStream())
                {
                    var content = SmartReadContent(response, responseStream);
                    throw new WebGatewayException(buildExceptionMessage((int)response.StatusCode, content), response.StatusCode, ex);
                }
            }
            catch (Exception ex)
            {
                const HttpStatusCode statusCode = HttpStatusCode.ServiceUnavailable;
                throw new WebGatewayException(buildExceptionMessage((int)statusCode, string.Empty), statusCode, ex);
            }
        }

        public string Upload(Uri uri, Dictionary<string, object> parameters, params File[] files)
        {
            var mimeParts = new List<MimePart>();
            
            try
            {
                var request = WebRequest.Create(uri);

                foreach (var key in parameters.Keys)
                {
                    var part = new StringMimePart();

                    part.Headers["Content-Disposition"] = "form-data; name=\"" + key + "\"";
                    part.StringData = parameters[key].ToString();

                    mimeParts.Add(part);
                }

                var nameIndex = 0;

                foreach (var file in files)
                {
                    var part = new StreamMimePart();

                    if (string.IsNullOrEmpty(file.FieldName))
                        file.FieldName = "file" + nameIndex++;

                    part.Headers["Content-Disposition"] = "form-data; name=\"" + file.FieldName + "\"; filename=\"" + file.Path + "\"";
                    part.Headers["Content-Type"] = file.ContentType;

                    part.SetStream(file.Data);

                    mimeParts.Add(part);
                }

                var boundary = "----------" + DateTime.Now.Ticks.ToString("x");

                request.ContentType = "multipart/form-data; boundary=" + boundary;
                request.Method = "POST";

                var footer = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");

                var contentLength = mimeParts.Sum(part => part.GenerateHeaderFooterData(boundary));

                request.ContentLength = contentLength + footer.Length;

                var buffer = new byte[8192];
                var afterFile = Encoding.UTF8.GetBytes("\r\n");

                using (var s = request.GetRequestStream())
                {
                    foreach (var part in mimeParts)
                    {
                        s.Write(part.Header, 0, part.Header.Length);

                        int read;
                        while ((read = part.Data.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            s.Write(buffer, 0, read);
                        }

                        part.Data.Dispose();

                        s.Write(afterFile, 0, afterFile.Length);
                    }

                    s.Write(footer, 0, footer.Length);
                }

                return GetResponse(request, (statusCode, content) => 
                                            string.Format("Upload failed. Parameters: uri = {0}. Files: {1}. Response: {2} - {3}", 
                                                uri.AbsoluteUri, 
                                                string.Join(";",files.Select(x => x.Path)),
                                                statusCode,
                                                content));
            }
            finally 
            {
                foreach (var mimePart in mimeParts.Where(part => part.Data != null))
                {
                    mimePart.Data.Dispose();
                }
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