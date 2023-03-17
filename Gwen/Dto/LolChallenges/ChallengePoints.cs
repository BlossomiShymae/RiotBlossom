namespace Gwen.Dto.LolChallenges
{
	public record ChallengePoints
	{
		public string Level { get; init; } = default!;
		public int Current { get; init; }
		public int Max { get; init; }
		public int Percentile { get; init; }
	}
}
