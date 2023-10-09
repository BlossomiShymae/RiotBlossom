using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolChallenges
{
    public record PlayerInfoDto : DataObject
    {
        /// <summary>
        /// The list of challenges for player.
        /// </summary>
        public List<ChallengeInfo> Challenges { get; init; } = [];
        /// <summary>
        /// The player client preferences.
        /// </summary>
        public required PlayerClientPreferences Preferences { get; init; }
        /// <summary>
        /// The challenge points information for player.
        /// </summary>
        public required ChallengePoints TotalPoints { get; init; }
        /// <summary>
        /// The map of challenge point information by category e.g. "TEAMWORK", "EXPERTISE", "IMAGINATION", "VETERANCY", "COLLECTION".
        /// </summary>
        public Dictionary<string, ChallengePoints> CategoryPoints { get; init; } = [];
    }
}
