using SoundCloud.API.Client.Objects.ActivityPieces;

namespace SoundCloud.API.Client.Objects
{
    public class SCActivityResult
    {
        public SCActivity<SCTrack>[] Tracks { get; set; } 
        public SCActivity<SCComment>[] Comments { get; set; } 
        public SCActivity<SCUser>[] Favorites { get; set; } 
        public SCActivity<SCPlaylist>[] Playlists { get; set; }

        public string CursorToNext { get; set; }
        public string QueryId { get; set; }
    }
}