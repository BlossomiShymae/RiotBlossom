using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.League
{
    public record LeagueListDto : DataObject
    {
        /// <summary>
        /// The associated league ID.
        /// </summary>
        public required string LeagueId { get; init; }
        /// <summary>
        /// The league player entries.
        /// </summary>
        public List<LeagueItemDto> Entries { get; init; } = [];
        /// <summary>
        /// The rank tier for league e.g. "SILVER", "GOLD".
        /// </summary>
        public required string Tier { get; init; }
        /// <summary>
        /// The name for league e.g. "Nunu's Battlemasters".
        /// </summary>
        public required string Name { get; init; }
        /// <summary>
        /// The queue type the league is for e.g. "RANKED_SOLO_5x5".
        /// </summary>
        public required string Queue { get; init; }
    }
}
