using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lor.LorRanked
{
    public record LeaderboardDto : DataObject
    {
        /// <summary>
        /// The list of players in Master tier.
        /// </summary>
        public List<PlayerDto> Players { get; init; } = [];
    }
}
