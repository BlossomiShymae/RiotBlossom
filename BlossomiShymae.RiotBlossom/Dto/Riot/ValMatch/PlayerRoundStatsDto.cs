using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record PlayerRoundStatsDto : DataObject
    {
        public string Puuid { get; init; } = default!;
        public ImmutableList<KillDto> Kills { get; init; } = ImmutableList<KillDto>.Empty;
        public ImmutableList<DamageDto> Damage { get; init; } = ImmutableList<DamageDto>.Empty;
        public int Score { get; init; }
        public EconomyDto Economy { get; init; } = new();
        public AbilityDto Ability { get; init; } = new();
    }
}
