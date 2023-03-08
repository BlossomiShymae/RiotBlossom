namespace Soraka.Dto.League
{
	internal record MiniSeriesDto
	{
		public int Losses { get; init; }
		public string Progress { get; init; } = default!;
		public int Target { get; init; }
		public int Wins { get; init; }
	}
}
