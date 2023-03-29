using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Dto.Riot.League
{
    public record LeagueEntryDto
    {
        /// <summary>
        /// The league entry ID.
        /// </summary>
        public string LeagueId { get; init; } = default!;
        /// <summary>
        /// The player encrypted summoner ID.
        /// </summary>
        public string SummonerId { get; init; } = default!;
        /// <summary>
        /// The player summoner name.
        /// </summary>
        public string SummonerName { get; init; } = default!;
        /// <summary>
        /// The queue type for league entry.
        /// </summary>
        public string QueueType { get; init; } = default!;
        /// <summary>
        /// The rank tier e.g. "SILVER", "GOLD".
        /// </summary>
        public string Tier { get; init; } = default!;
        /// <summary>
        /// The rank division ("I", "II", "III", "IV").
        /// </summary>
        public string Rank { get; init; } = default!;
        /// <summary>
        /// The player's current league points needed to progress to the next rank tier.
        /// </summary>
        public int LeaguePoints { get; init; }
        /// <summary>
        /// The winning team on Summoner's Rift.
        /// </summary>
        public int Wins { get; init; }
        /// <summary>
        /// The losing team on Summoner's Rift.
        /// </summary>
        public int Losses { get; init; }
        /// <summary>
        /// The player has a winning streak of 3 or more games.
        /// </summary>
        public bool HotStreak { get; init; }
        /// <summary>
        /// The player has played more than 100 games in the division (<see cref="Rank"/>).
        /// </summary>
        public bool Veteran { get; init; }
        /// <summary>
        /// The player is new to the division (<see cref="Rank"/>).
        /// </summary>
        public bool FreshBlood { get; init; }
        /// <summary>
        /// The player no longer actively plays in the league.
        /// </summary>
        public bool Inactive { get; init; }
        /// <summary>
        /// The current miniseries (rank promotions) the player is involved in.
        /// </summary>
        /// TODO - Potential bug where MiniSeriesDto fails to deserialize into ImmutableList on deterministic input
        public ImmutableList<MiniSeriesDto> MiniSeries { get; init; } = ImmutableList<MiniSeriesDto>.Empty;
    }
}
