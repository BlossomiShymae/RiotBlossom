using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record MatchlistDto : DataObject<MatchlistDto>
    {
        public string Puuid { get; init; } = default!;
        public ImmutableList<MatchlistEntryDto> History { get; init; } = ImmutableList<MatchlistEntryDto>.Empty;
    }
}
