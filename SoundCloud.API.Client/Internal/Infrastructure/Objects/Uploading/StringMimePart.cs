using System.IO;
using System.Text;

namespace SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading
{
    internal class StringMimePart : MimePart
    {
        Stream data;
        public string StringData { set { data = new MemoryStream(Encoding.UTF8.GetBytes(value)); } }
        public override Stream Data { get { return data; } }
    }
}
