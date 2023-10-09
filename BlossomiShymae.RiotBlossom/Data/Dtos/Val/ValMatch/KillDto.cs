using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record KillDto : DataObject
    {
        public int TimeSinceGameStartMillis { get; init; }
        public int TimeSinceRoundStartMillis { get; init; }
        /// <summary>
        /// The PUUID of killer.
        /// </summary>
        public required string Killer { get; init; }
        /// <summary>
        /// The PUUID of victim.
        /// </summary>
        public required string Victim { get; init; }
        public LocationDto VictimLocation { get; init; } = new();
        /// <summary>
        /// The list of PUUIDs.
        /// </summary>
        public List<string> Assistants { get; init; } = [];
        public List<PlayerLocationsDto> PlayerLocations { get; init; } = [];
        public required FinishingDamageDto FinishingDamage { get; init; }
    }
}
