namespace BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ChromaRarity : DataObject<ChromaRarity>
    {
        public string Region { get; init; } = default!;
        public int Rarity { get; init; }
    }
}
