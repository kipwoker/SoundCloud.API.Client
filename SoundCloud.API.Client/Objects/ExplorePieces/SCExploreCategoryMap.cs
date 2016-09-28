using System.Collections.Generic;

namespace SoundCloud.API.Client.Objects.ExplorePieces
{
    internal static class SCExploreCategoryMap
    {
        private static readonly Dictionary<SCExploreCategoryType, string> exploreCategoryMap = new Dictionary<SCExploreCategoryType, string>
        {
            { SCExploreCategoryType.PopularMusic, "Popular+Music" },
            { SCExploreCategoryType.AlternativeRock, "Alternative+Rock" },
            { SCExploreCategoryType.Ambient, "Ambient" },
            { SCExploreCategoryType.Classical, "Classical" },
            { SCExploreCategoryType.Country, "Country" },
            { SCExploreCategoryType.DanceAndEDM, "Dance+&+EDM" },
            { SCExploreCategoryType.Dancehall, "Dancehall" },
            { SCExploreCategoryType.DeepHouse, "Deep+House" },
            { SCExploreCategoryType.Disco, "Disco" },
            { SCExploreCategoryType.DrumAndBass, "Drum+&+Bass" },
            { SCExploreCategoryType.Dubstep, "Dubstep" },
            { SCExploreCategoryType.Electronic, "Electronic" },
            { SCExploreCategoryType.FolkAndSingerSongwriter, "Folk+&+Singer-Songwriter" },
            { SCExploreCategoryType.HipHopAndRap, "Hip-Hop+&+Rap" },
            { SCExploreCategoryType.House, "House" },
            { SCExploreCategoryType.Indie, "Indie" },
            { SCExploreCategoryType.JazzAndBlues, "Jazz+&+Blues" },
            { SCExploreCategoryType.Latin, "Latin" },
            { SCExploreCategoryType.Metal, "Metal" },
            { SCExploreCategoryType.Piano, "Piano" },
            { SCExploreCategoryType.Pop, "Pop" },
            { SCExploreCategoryType.RnBAndSoul, "R&B+&+soul" },
            { SCExploreCategoryType.Reggae, "Reggae" },
            { SCExploreCategoryType.Reggaeton, "Reggaeton" },
            { SCExploreCategoryType.Rock, "Rock" },
            { SCExploreCategoryType.Soundtrack, "Soundtrack" },
            { SCExploreCategoryType.Techno, "Techno" },
            { SCExploreCategoryType.Trance, "Trance" },
            { SCExploreCategoryType.Trap, "Trap" },
            { SCExploreCategoryType.Triphop, "Triphop" },
            { SCExploreCategoryType.World, "World" }
        };

        public static string GetValue(this SCExploreCategoryType scExploreCategoryType)
        {
            return exploreCategoryMap[scExploreCategoryType];
        }
    }
}