namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ChromaRarity : DataObject
    {
        public required string Region { get; init; }
        public int Rarity { get; init; }
    }
}
