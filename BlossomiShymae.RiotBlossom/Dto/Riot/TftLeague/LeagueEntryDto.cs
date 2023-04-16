using BlossomiShymae.RiotBlossom.Dto.Riot.League;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.TftLeague
{
    public record LeagueEntryDto
    {
        public string? LeagueId { get; init; } = default!;
        public string SummonerId { get; init; } = default!;
        public string SummonerName { get; init; } = default!;
        public string QueueType { get; init; } = default!;
        public string? RatedTier { get; init; } = default!;
        public int? RatedRating { get; init; } = default!;
        public string? Tier { get; init; } = default!;
        public string? Rank { get; init; } = default!;
        public int? LeaguePoints { get; init; }
        public int Wins { get; init; }
        public int Losses { get; init; }
        public bool? HotStreak { get; init; }
        public bool? Veteran { get; init; }
        public bool? FreshBlood { get; init; }
        public bool? Inactive { get; init; }
        public MiniSeriesDto? MiniSeries { get; init; }
    }
}
