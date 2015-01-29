using System.IO;

namespace SoundCloud.API.Client.Internal.Infrastructure.Objects.Uploading
{
    internal class File
    {
        public string Path { get; set; }
        public string FieldName { get; set; }
        public Stream Data { get; set; }
        public string ContentType
        {
            get { return "application/octet-stream"; }
        }

        internal static File Build(string path, string fieldName)
        {
            var fullPath = System.IO.Path.GetFullPath(path);
            if (!System.IO.File.Exists(fullPath))
            {
                throw new FileNotFoundException();
            }

            return new File
            {
                Path = fullPath,
                FieldName = fieldName,
                Data = System.IO.File.OpenRead(fullPath)
            };
        }
    }
}