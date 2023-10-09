namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ChromaDescription : DataObject
    {
        public required string Region { get; init; } 
        public required string Description { get; init; }
    }
}
