using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Clash
{
    public record TeamDto : DataObject
    {
        /// <summary>
        /// The team ID.
        /// </summary>
        public required string Id { get; init; }
        /// <summary>
        /// The associated tournament ID the team is participating in.
        /// </summary>
        public int TournamentId { get; init; }
        /// <summary>
        /// The team name.
        /// </summary>
        public required string Name { get; init; }
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
        public required string Captain { get; init; }
        /// <summary>
        /// The abbreviation of team name.
        /// </summary>
        public required string Abbreviation { get; init; }
        /// <summary>
        /// The current team roster.
        /// </summary>
        public List<PlayerDto> Players { get; init; } = [];
    }
}
