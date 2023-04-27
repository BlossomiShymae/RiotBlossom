namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValContent
{
    public record ActDto
    {
        public string Name { get; init; } = default!;
        public LocalizedNamesDto? LocalizedNames { get; init; }
        public string Id { get; init; } = default!;
        public bool IsActive { get; init; }
    }
}
