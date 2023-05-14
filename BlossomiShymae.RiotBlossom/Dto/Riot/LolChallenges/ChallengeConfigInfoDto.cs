using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LolChallenges
{
    public record ChallengeConfigInfoDto : DataObject<ChallengeConfigInfoDto>
    {
        /// <summary>
        /// The challenge ID.
        /// </summary>
        public long Id { get; init; }
        /// <summary>
        /// The locale translations of text for challenge.
        /// </summary>
        public ImmutableDictionary<string, LocalizedName> LocalizedNames { get; init; } = ImmutableDictionary<string, LocalizedName>.Empty;
        /// <summary>
        /// The state of challenge e.g. "DISABLED", "HIDDEN", "ARCHIVED".
        /// </summary>
        public string? State { get; init; } = default!;
        /// <summary>
        /// The tracking type of challenge e.g. "LIFETIME", "SEASON".
        /// </summary>
        public string? Tracking { get; init; } = default!;
        /// <summary>
        /// The Unix timestamp for when the challenge has started.
        /// </summary>
        public long StartTimestamp { get; init; }
        /// <summary>
        /// The Unix timestamp for when the challenge has ended.
        /// </summary>
        public long EndTimestamp { get; init; }
        /// <summary>
        /// Whether the challenge has a ranking leaderboard.
        /// </summary>
        public bool Leaderboard { get; init; }
        /// <summary>
        /// The map of threshold values for challenge.
        /// </summary>
        public ImmutableDictionary<string, double> Thresholds { get; init; } = ImmutableDictionary<string, double>.Empty;
    }
}
