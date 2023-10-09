namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValContent
{
    public record ActDto : DataObject
    {
        public required string Name { get; init; } 
        /// <summary>
        /// This is excluded from respone when a locale is set.
        /// </summary>
        public LocalizedNamesDto? LocalizedNames { get; init; }
        public required string Id { get; init; }
        public bool IsActive { get; init; }
    }
}
