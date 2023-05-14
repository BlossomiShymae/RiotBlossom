namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValContent
{
    public record ContentItemDto : DataObject<ContentItemDto>
    {
        public string Name { get; init; } = default!;
        /// <summary>
        /// This is excluded when a locale is set.
        /// </summary>
        public LocalizedNamesDto? LocalizedNames { get; init; }
        public string Id { get; init; } = default!;
        public string AssetName { get; init; } = default!;
        /// <summary>
        /// This is only included for maps and game modes.
        /// </summary>
        public string AssetPath { get; init; } = default!;
    }
}
