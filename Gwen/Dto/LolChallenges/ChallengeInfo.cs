namespace Gwen.Dto.LolChallenges
{
	public record ChallengeInfo
	{
		public string Level { get; init; } = default!;
		public int Current { get; init; }
		public int Max { get; init; }
		public int Percentile { get; init; }
	}
}
