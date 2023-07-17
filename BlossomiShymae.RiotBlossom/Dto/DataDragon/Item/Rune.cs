namespace BlossomiShymae.RiotBlossom.Dto.DataDragon.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Rune : DataObject
    {
        public bool IsRune { get; init; }
        public int Tier { get; init; }
        public string Type { get; init; } = default!;
    }
}
