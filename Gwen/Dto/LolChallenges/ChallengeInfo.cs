namespace Gwen.Dto.LolChallenges
{
	public record ChallengeInfo
	{
		public int ChallengeId { get; init; }
		public int Percentile { get; init; }
		public string Level { get; init; } = default!;
		public int Value { get; init; }
		public long AchievedTime { get; init; }
	}
}
