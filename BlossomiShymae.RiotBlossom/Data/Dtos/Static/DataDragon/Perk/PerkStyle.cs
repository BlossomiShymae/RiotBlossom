using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Perk
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record PerkStyle : DataObject
    {
        public int Id { get; init; }
        public required string Key { get; init; } 
        public required string Icon { get; init; } 
        public required string Name { get; init; } 
        public List<Slot> Slots { get; init; } = [];
    }
}
