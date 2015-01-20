using System;

namespace SoundCloud.API.Client
{
    public class SoundCloudApiException : Exception
    {
        public SoundCloudApiException(string errorMessage)
            : base(errorMessage)
        {
            
        }
    }
}