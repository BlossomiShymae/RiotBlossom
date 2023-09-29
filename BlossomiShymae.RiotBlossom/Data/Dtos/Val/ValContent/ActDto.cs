namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValContent
{
    public record ActDto : DataObject
    {
        public string Name { get; init; } = default!;
        /// <summary>
        /// This is excluded from respone when a locale is set.
        /// </summary>
        public LocalizedNamesDto? LocalizedNames { get; init; }
        public string Id { get; init; } = default!;
        public bool IsActive { get; init; }
    }
}
