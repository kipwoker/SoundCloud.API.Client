namespace SoundCloud.API.Client.Internal.Infrastructure.Objects
{
    internal enum HttpMethod
    {
        [Parameter("GET")]
        Get,

        [Parameter("POST")]
        Post,

        [Parameter("PUT")]
        Put,

        [Parameter("DELETE")]
        Delete
    }
}