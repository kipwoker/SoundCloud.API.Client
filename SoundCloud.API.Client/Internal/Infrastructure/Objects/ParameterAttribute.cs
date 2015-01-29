using System;

namespace SoundCloud.API.Client.Internal.Infrastructure.Objects
{
    [AttributeUsage(AttributeTargets.All)]
    internal class ParameterAttribute : Attribute
    {
        internal ParameterAttribute(string parameterName)
        {
            ParameterName = parameterName;
        }

        internal string ParameterName { get; private set; }
    }
}