using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LorRanked
{
    public record LeaderboardDto
    {
        /// <summary>
        /// The list of players in Master tier.
        /// </summary>
        public ImmutableList<PlayerDto> Players { get; init; } = ImmutableList<PlayerDto>.Empty;
    }
}
