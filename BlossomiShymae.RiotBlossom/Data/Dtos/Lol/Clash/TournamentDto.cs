using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Clash
{
    public record TournamentDto : DataObject
    {
        /// <summary>
        /// The tournament ID.
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// The theme ID.
        /// </summary>
        public int ThemeId { get; init; }
        /// <summary>
        /// The name of tournament e.g. "bilgewater".
        /// </summary>
        public required string NameKey { get; init; }
        /// <summary>
        /// The secondary name of tournament e.g. "day_2".
        /// </summary>
        public required string NameKeySecondary { get; init; }
        /// <summary>
        /// The spanning date the tournament will take place on.
        /// </summary>
        public List<TournamentPhaseDto> Schedule { get; init; } = [];
    }
}
