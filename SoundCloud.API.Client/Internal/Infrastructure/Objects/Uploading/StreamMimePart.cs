using System.IO;

namespace SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading
{
    public class StreamMimePart : MimePart
    {
        Stream data;

        public void SetStream(Stream stream)
        {
            data = stream;
        }

        public override Stream Data { get { return data; } }
    }
}
