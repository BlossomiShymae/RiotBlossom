using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Champion : DataObject
    {
        public required string Id { get; init; }
        public required string Key { get; init; } 
        public required string Name { get; init; } 
        public required string Title { get; init; }
        public required Image Image { get; init; } 
        public List<Skin> Skins { get; init; } = [];
        public required string Lore { get; init; }
        public required string Blurb { get; init; } 
        public List<string> Allytips { get; init; } = [];
        public List<string> Enemytips { get; init; } = [];
        public List<string> Tags { get; init; } = [];
        public required string Partype { get; init; } 
        public Info Info { get; init; } = new();
        public Stats Stats { get; init; } = new();
        public List<Spell> Spells { get; init; } = [];
        public required Passive Passive { get; init; }
    }
}
