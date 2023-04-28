using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record MatchDto
    {
        public MatchInfoDto MatchInfo { get; init; } = new();
        public ImmutableList<PlayerDto> Players { get; init; } = ImmutableList<PlayerDto>.Empty;
        public ImmutableList<CoachDto> Coaches { get; init; } = ImmutableList<CoachDto>.Empty;
        public ImmutableList<TeamDto> Teams { get; init; } = ImmutableList<TeamDto>.Empty;
        public ImmutableList<RoundResultDto> RoundResults { get; init; } = ImmutableList<RoundResultDto>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
