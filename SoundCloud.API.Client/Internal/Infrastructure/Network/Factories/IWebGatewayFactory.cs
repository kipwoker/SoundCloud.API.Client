using System;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Infrastructure.Network.Factories
{
    internal interface IWebGatewayFactory
    {
        IWebGateway Create(bool enableGZip, Action apiActionExecuting = null, Action<SCResponse> apiActionExecuted = null, Action<SCResponse> apiActionError = null);
    }
}