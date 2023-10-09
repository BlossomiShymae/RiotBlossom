namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValContent
{
    public record ContentItemDto : DataObject
    {
        public required string Name { get; init; }
        /// <summary>
        /// This is excluded when a locale is set.
        /// </summary>
        public LocalizedNamesDto? LocalizedNames { get; init; }
        public required string Id { get; init; }
        public required string AssetName { get; init; } 
        /// <summary>
        /// This is only included for maps and game modes.
        /// </summary>
        public string? AssetPath { get; init; }
    }
}
