using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValRanked
{
    public record LeaderboardDto : DataObject
    {
        /// <summary>
        /// The shard for the given leaderboard.
        /// </summary>
        public required string Shard { get; init; }
        /// <summary>
        /// The act ID for the given leaderboard.
        /// </summary>
        public required string ActId { get; init; } 
        /// <summary>
        /// The total number of players in the given leaderboard.
        /// </summary>
        public long TotalPlayers { get; init; }
        /// <summary>
        /// The list of participating players.
        /// </summary>
        public List<PlayerDto> Players { get; init; } = [];
    }
}
