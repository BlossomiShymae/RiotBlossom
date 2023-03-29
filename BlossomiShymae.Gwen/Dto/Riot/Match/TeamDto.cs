using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Dto.Riot.Match
{
    public record TeamDto
    {
        /// <summary>
        /// The champions that a team has banned in Draft Pick.
        /// </summary>
        public ImmutableList<BanDto> Bans { get; init; } = ImmutableList<BanDto>.Empty;
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
