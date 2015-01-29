namespace SoundCloud.API.Client.Objects.TrackPieces
{
    public class SCTagList
    {
        public SCTagList()
        {
            Tags = new string[0];
            MachineTags = new SCMachineTag[0];
        }

        public string[] Tags { get; set; }
        public SCMachineTag[] MachineTags { get; set; }
    }
}