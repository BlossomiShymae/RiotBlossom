namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Rarities : DataObject
    {
        public int? Rarity { get; init; }
        public string? Region { get; init; }
    }
}
