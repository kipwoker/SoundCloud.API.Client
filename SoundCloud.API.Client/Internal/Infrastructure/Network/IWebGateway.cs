using System.Collections.Generic;
using SoundCloud.API.Client.Internal.Client.Helpers;
using SoundCloud.API.Client.Internal.Infrastructure.Objects;
using SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading;

namespace SoundCloud.API.Client.Internal.Infrastructure.Network
{
    internal interface IWebGateway
    {
        string Request(IUriBuilder uriBuilder, HttpMethod method, Dictionary<string, object> parameters, byte[] body);
        string Upload(IUriBuilder uriBuilder, Dictionary<string, object> parameters, params File[] files);
    }
}