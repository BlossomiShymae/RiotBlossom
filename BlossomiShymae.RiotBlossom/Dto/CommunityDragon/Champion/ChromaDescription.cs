namespace BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ChromaDescription : DataObject<ChromaDescription>
    {
        public string Region { get; init; } = default!;
        public string Description { get; init; } = default!;
    }
}
