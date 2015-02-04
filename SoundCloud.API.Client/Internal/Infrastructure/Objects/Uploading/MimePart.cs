using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading
{
    internal abstract class MimePart
    {
        readonly NameValueCollection headers = new NameValueCollection();

        public NameValueCollection Headers
        {
            get { return headers; }
        }

        public byte[] Header { get; private set; }

        public long GenerateHeaderFooterData(string boundary)
        {
            var builder = new StringBuilder();

            builder.Append("--");
            builder.Append(boundary);
            builder.AppendLine();
            foreach (var key in headers.AllKeys)
            {
                builder.Append(key);
                builder.Append(": ");
                builder.AppendLine(headers[key]);
            }
            builder.AppendLine();

            Header = Encoding.UTF8.GetBytes(builder.ToString());

            return Header.Length + Data.Length + 2;
        }

        public abstract Stream Data { get; }
    }
}