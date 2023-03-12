using System.Collections.Immutable;

namespace Gwen.Dto.League
{
    internal record LeagueItemDto
    {
        public bool FreshBlood { get; init; }
        public int Wins { get; init; }
        public string SummonerName { get; init; } = default!;
        public ImmutableList<MiniSeriesDto> MiniSeries { get; init; } = ImmutableList<MiniSeriesDto>.Empty;
        public bool Inactive { get; init; }
        public bool Veteran { get; init; }
        public bool HotStreak { get; init; }
        public string Rank { get; init; } = default!;
        public int LeaguePoints { get; init; }
        public int Losses { get; init; }
        public string SummonerId { get; init; } = default!;
    }
}
