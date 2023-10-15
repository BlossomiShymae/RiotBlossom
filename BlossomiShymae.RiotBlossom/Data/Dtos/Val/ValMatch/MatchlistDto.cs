using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record MatchlistDto : DataObject
    {
        public required string Puuid { get; init; }
        public List<MatchlistEntryDto> History { get; init; } = [];
    }
}
