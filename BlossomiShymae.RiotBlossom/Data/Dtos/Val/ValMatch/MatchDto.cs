using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record MatchDto : DataObject
    {
        public required MatchInfoDto MatchInfo { get; init; }
        public List<PlayerDto> Players { get; init; } = [];
        public List<CoachDto> Coaches { get; init; } = [];
        public List<TeamDto> Teams { get; init; } = [];
        public List<RoundResultDto> RoundResults { get; init; } = [];
    }
}
