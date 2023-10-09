using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record RoundResultDto : DataObject
    {
        public int RoundNum { get; init; }
        public required string RoundResult { get; init; } 
        public required string RoundCeremony { get; init; }
        public required string WinningTeam { get; init; }
        public required string BombPlanter { get; init; } 
        public required string BombDefuser { get; init; }
        public int PlantRoundTime { get; init; }
        public List<PlayerLocationsDto> PlantPlayerLocations { get; init; } = [];
        public LocationDto PlantLocation { get; init; } = new();
        public required string PlantSite { get; init; } 
        public int DefuseRoundTime { get; init; }
        public List<PlayerLocationsDto> DefusePlayerLocations { get; init; } = [];
        public LocationDto DefuseLocation { get; init; } = new();
        public List<PlayerRoundStatsDto> PlayerStats { get; init; } = [];
        public required string RoundResultCode { get; init; } 
    }
}
