﻿namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.League
{
    public record LeagueItemDto : DataObject
    {
        /// <summary>
        /// The player is new to the division (<see cref="Rank"/>).
        /// </summary>
        public bool FreshBlood { get; init; }
        /// <summary>
        /// The winning team on Summoner's Rift.
        /// </summary>
        public int Wins { get; init; }
        /// <summary>
        /// The player summoner name.
        /// </summary>
        public required string SummonerName { get; init; } 
        /// <summary>
        /// The current miniseries (rank promotions) the player is involved in.
        /// </summary>
        public MiniSeriesDto? MiniSeries { get; init; }
        /// <summary>
        /// The player no longer actively players in the league.
        /// </summary>
        public bool Inactive { get; init; }
        /// <summary>
        /// The player has played more than 100 games in the division (<see cref="Rank"/>).
        /// </summary>
        public bool Veteran { get; init; }
        /// <summary>
        /// The player has a winning streak of 3 or more games.
        /// </summary>
        public bool HotStreak { get; init; }
        /// <summary>
        /// The rank division ("I", "II", "III", "IV").
        /// </summary>
        public string Rank { get; init; } = default!;
        /// <summary>
        /// The player's current league points needed to progress to the next rank tier.
        /// </summary>
        public int LeaguePoints { get; init; }
        /// <summary>
        /// The losing team on Summoner's Rift.
        /// </summary>
        public int Losses { get; init; }
        /// <summary>
        /// The player encrypted summoner ID.
        /// </summary>
        public required string SummonerId { get; init; }
    }
}
