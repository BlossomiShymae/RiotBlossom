using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.League
{
    public record LeagueListDto : DataObject
    {
        /// <summary>
        /// The associated league ID.
        /// </summary>
        public string LeagueId { get; init; } = default!;
        /// <summary>
        /// The league player entries.
        /// </summary>
        public ImmutableList<LeagueItemDto> Entries { get; init; } = ImmutableList<LeagueItemDto>.Empty;
        /// <summary>
        /// The rank tier for league e.g. "SILVER", "GOLD".
        /// </summary>
        public string Tier { get; init; } = default!;
        /// <summary>
        /// The name for league e.g. "Nunu's Battlemasters".
        /// </summary>
        public string Name { get; init; } = default!;
        /// <summary>
        /// The queue type the league is for e.g. "RANKED_SOLO_5x5".
        /// </summary>
        public string Queue { get; init; } = default!;
    }
}
