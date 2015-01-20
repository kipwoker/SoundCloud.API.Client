using System;
using System.Net;

namespace SoundCloud.API.Client.Objects
{
    public class SCResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ResponseContent { get; set; }
        public Type ReturnedType { get; set; }
    }
}