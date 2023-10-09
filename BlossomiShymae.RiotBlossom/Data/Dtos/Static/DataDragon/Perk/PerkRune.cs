namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Perk
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record PerkRune : DataObject
    {
        public int Id { get; init; }
        public required string Key { get; init; } 
        public required string Icon { get; init; } 
        public required string Name { get; init; } 
        public required string ShortDesc { get; init; }
        public required string LongDesc { get; init; } 
    }
}
