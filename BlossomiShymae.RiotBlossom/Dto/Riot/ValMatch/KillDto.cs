using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record KillDto
    {
        public int TimeSinceGameStartMillis { get; init; }
        public int TimeSinceRoundStartMillis { get; init; }
        /// <summary>
        /// The PUUID of killer.
        /// </summary>
        public string Killer { get; init; } = default!;
        /// <summary>
        /// The PUUID of victim.
        /// </summary>
        public string Victim { get; init; } = default!;
        public LocationDto VictimLocation { get; init; } = new();
        /// <summary>
        /// The list of PUUIDs.
        /// </summary>
        public ImmutableList<string> Assistants { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<PlayerLocationsDto> PlayerLocations { get; init; } = ImmutableList<PlayerLocationsDto>.Empty;
        public FinishingDamageDto FinishingDamage { get; init; } = new();
    }
}
