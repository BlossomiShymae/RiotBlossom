using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Clash
{
    public record TeamDto : DataObject
    {
        /// <summary>
        /// The team ID.
        /// </summary>
        public string Id { get; init; } = default!;
        /// <summary>
        /// The associated tournament ID the team is participating in.
        /// </summary>
        public int TournamentId { get; init; }
        /// <summary>
        /// The team name.
        /// </summary>
        public string Name { get; init; } = default!;
        /// <summary>
        /// The icon ID of team.
        /// </summary>
        public int IconId { get; init; }
        /// <summary>
        /// The rank tier of team.
        /// </summary>
        public int Tier { get; init; }
        /// <summary>
        /// The encrypted summoner ID of team captain.
        /// </summary>
        public string Captain { get; init; } = default!;
        /// <summary>
        /// The abbreviation of team name.
        /// </summary>
        public string Abbreviation { get; init; } = default!;
        /// <summary>
        /// The current team roster.
        /// </summary>
        public ImmutableList<PlayerDto> Players { get; init; } = ImmutableList<PlayerDto>.Empty;
    }
}
