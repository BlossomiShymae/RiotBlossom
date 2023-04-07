namespace BlossomiShymae.RiotBlossom.Dto.DDragon.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Rune
    {
        public bool IsRune { get; init; }
        public int Tier { get; init; }
        public string Type { get; init; } = default!;
    }
}
