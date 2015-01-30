using System.IO;

namespace SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading
{
    internal class File
    {
        public string Path { get; private set; }
        public string FieldName { get; set; }
        public Stream Data { get; private set; }
        public static string ContentType
        {
            get { return "application/octet-stream"; }
        }

        internal static File Build(Stream data, string fieldName)
        {
            return new File
            {
                Path = "fake.jpg",
                FieldName = fieldName,
                Data = data
            };
        }
    }
}