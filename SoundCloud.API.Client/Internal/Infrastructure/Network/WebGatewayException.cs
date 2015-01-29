using System;
using System.Net;

namespace SoundCloud.API.Client.Internal.Infrastructure.Network
{
    public class WebGatewayException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public WebGatewayException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public WebGatewayException(string message, HttpStatusCode statusCode, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}