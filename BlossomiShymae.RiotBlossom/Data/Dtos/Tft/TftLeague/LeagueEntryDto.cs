using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.League;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftLeague
{
    public record LeagueEntryDto : DataObject
    {
        public string? LeagueId { get; init; }
        public required string SummonerId { get; init; }
        public required string SummonerName { get; init; }
        public required string QueueType { get; init; }
        public string? RatedTier { get; init; }
        public int? RatedRating { get; init; }
        public string? Tier { get; init; }
        public string? Rank { get; init; }
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
