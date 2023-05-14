using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record RoundResultDto : DataObject<RoundResultDto>
    {
        public int RoundNum { get; init; }
        public string RoundResult { get; init; } = default!;
        public string RoundCeremony { get; init; } = default!;
        public string WinningTeam { get; init; } = default!;
        public string BombPlanter { get; init; } = default!;
        public string BombDefuser { get; init; } = default!;
        public int PlantRoundTime { get; init; }
        public ImmutableList<PlayerLocationsDto> PlantPlayerLocations { get; init; } = ImmutableList<PlayerLocationsDto>.Empty;
        public LocationDto PlantLocation { get; init; } = new();
        public string PlantSite { get; init; } = default!;
        public int DefuseRoundTime { get; init; }
        public ImmutableList<PlayerLocationsDto> DefusePlayerLocations { get; init; } = ImmutableList<PlayerLocationsDto>.Empty;
        public LocationDto DefuseLocation { get; init; } = new();
        public ImmutableList<PlayerRoundStatsDto> PlayerStats { get; init; } = ImmutableList<PlayerRoundStatsDto>.Empty;
        public string RoundResultCode { get; init; } = default!;
    }
}
