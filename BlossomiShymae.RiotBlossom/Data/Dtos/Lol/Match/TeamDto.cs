using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    public record TeamDto : DataObject
    {
        /// <summary>
        /// The champions that a team has banned in Draft Pick.
        /// </summary>
        public List<BanDto> Bans { get; init; } = [];
        /// <summary>
        /// The objectives that a team has killed/taken in a match.
        /// </summary>
        public ObjectivesDto Objectives { get; init; } = new();
        /// <summary>
        /// The team ID.
        /// </summary>
        public int TeamId { get; init; }
        /// <summary>
        /// Whether a team has winned a match e.g. destroyed the enemy nexus.
        /// </summary>
        public bool Win { get; init; }
    }
}
