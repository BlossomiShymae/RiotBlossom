using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Clash
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
        public string NameKey { get; init; } = default!;
        /// <summary>
        /// The secondary name of tournament e.g. "day_2".
        /// </summary>
        public string NameKeySecondary { get; init; } = default!;
        /// <summary>
        /// The spanning date the tournament will take place on.
        /// </summary>
        public ImmutableList<TournamentPhaseDto> Schedule { get; init; } = ImmutableList<TournamentPhaseDto>.Empty;
    }
}
