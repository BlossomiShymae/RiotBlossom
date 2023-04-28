using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValRanked
{
    public record LeaderboardDto
    {
        /// <summary>
        /// The shard for the given leaderboard.
        /// </summary>
        public string Shard { get; init; } = default!;
        /// <summary>
        /// The act ID for the given leaderboard.
        /// </summary>
        public string ActId { get; init; } = default!;
        /// <summary>
        /// The total number of players in the given leaderboard.
        /// </summary>
        public long TotalPlayers { get; init; }
        /// <summary>
        /// The list of participating players.
        /// </summary>
        public ImmutableList<PlayerDto> Players { get; init; } = ImmutableList<PlayerDto>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
