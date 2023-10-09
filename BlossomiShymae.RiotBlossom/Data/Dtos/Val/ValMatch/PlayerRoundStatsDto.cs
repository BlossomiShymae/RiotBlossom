using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record PlayerRoundStatsDto : DataObject
    {
        public required string Puuid { get; init; } 
        public List<KillDto> Kills { get; init; } = [];
        public List<DamageDto> Damage { get; init; } = [];
        public int Score { get; init; }
        public required EconomyDto Economy { get; init; }
        public required AbilityDto Ability { get; init; } 
    }
}
