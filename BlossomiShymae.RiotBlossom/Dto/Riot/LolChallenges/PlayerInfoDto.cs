using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LolChallenges
{
    public record PlayerInfoDto
    {
        /// <summary>
        /// The list of challenges for player.
        /// </summary>
        public ImmutableList<ChallengeInfo> Challenges { get; init; } = ImmutableList<ChallengeInfo>.Empty;
        /// <summary>
        /// The player client preferences.
        /// </summary>
        public PlayerClientPreferences Preferences { get; init; } = new();
        /// <summary>
        /// The challenge points information for player.
        /// </summary>
        public ChallengePoints TotalPoints { get; init; } = new();
        /// <summary>
        /// The map of challenge point information by category e.g. "TEAMWORK", "EXPERTISE", "IMAGINATION", "VETERANCY", "COLLECTION".
        /// </summary>
        public ImmutableDictionary<string, ChallengePoints> CategoryPoints { get; init; } = ImmutableDictionary<string, ChallengePoints>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
