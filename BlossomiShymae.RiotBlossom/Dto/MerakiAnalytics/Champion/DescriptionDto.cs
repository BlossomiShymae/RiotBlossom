namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record DescriptionDto : DataObject<DescriptionDto>
    {
        public string? Description { get; init; }
        public string? Region { get; init; }
    }
}
