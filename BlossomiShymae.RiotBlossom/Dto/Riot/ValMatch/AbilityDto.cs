namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record AbilityDto
    {
        public string GrenadeEffects { get; init; } = default!;
        public string Ability1Effects { get; init; } = default!;
        public string Ability2Effects { get; init; } = default!;
        public string UltimateEffects { get; init; } = default!;
    }
}
