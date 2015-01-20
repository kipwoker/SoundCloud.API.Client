using System;
using SoundCloud.API.Client.Internal.Infrastructure.Serialization;
using SoundCloud.API.Client.Objects;

namespace SoundCloud.API.Client.Internal.Infrastructure.Network.Factories
{
    internal class WebGatewayFactory : IWebGatewayFactory
    {
        private readonly ISerializer serializer;

        internal static readonly IWebGatewayFactory Default = new WebGatewayFactory(JsonSerializer.Default);

        public WebGatewayFactory(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        public IWebGateway Create(bool enableGZip, Action apiActionExecuting = null, Action<SCResponse> apiActionExecuted = null, Action<SCResponse> apiActionError = null)
        {
            return new WebGateway(enableGZip, apiActionExecuting, apiActionExecuted, apiActionError, serializer);
        }
    }
}