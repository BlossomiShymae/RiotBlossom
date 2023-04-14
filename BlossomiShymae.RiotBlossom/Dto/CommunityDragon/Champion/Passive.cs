namespace BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Passive
    {
        public string Name { get; init; } = default!;
        public string AbilityIconPath { get; init; } = default!;
        public string AbilityVideoPath { get; init; } = default!;
        public string AbilityVideoImagePath { get; init; } = default!;
        public string Description { get; init; } = default!;
    }
}
