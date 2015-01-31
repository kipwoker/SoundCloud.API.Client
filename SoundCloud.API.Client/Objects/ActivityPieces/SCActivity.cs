using System;

namespace SoundCloud.API.Client.Objects.ActivityPieces
{
    public class SCActivity<T>
    {
        public SCActivity()
        {
            Tags = new SCActivityTag[0];
        }

        public string Type { get; set; }
        
        public T Activity { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
        public SCActivityTag[] Tags { get; set; }
    }
}