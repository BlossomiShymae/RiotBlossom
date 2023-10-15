namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Rune : DataObject
    {
        public bool IsRune { get; init; }
        public int Tier { get; init; }
        public required string Type { get; init; }
    }
}
