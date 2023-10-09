using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Champion : DataObject
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string Alias { get; init; } 
        public required string Title { get; init; }
        public required string ShortBio { get; init; } 
        public required TacticalInfo TacticalInfo { get; init; }
        public PlaystyleInfo PlaystyleInfo { get; init; } = new();
        public required string SquarePortraitPath { get; init; }
        public required string StingerSfxPath { get; init; }
        public required string ChooseVoPath { get; init; }
        public required string BanVoPath { get; init; }
        public List<string> Roles { get; init; } = [];
        public List<Skin> Skins { get; init; } = [];
        public required Passive Passive { get; init; }
        public List<Spell> Spells { get; init; } = [];
    }
}
