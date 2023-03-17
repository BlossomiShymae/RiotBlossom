using System.Collections.Immutable;

namespace Gwen.Dto.LolChallenges
{
	public record PlayerInfoDto
	{
		public ImmutableList<ChallengeInfo> Challenges { get; init; } = ImmutableList<ChallengeInfo>.Empty;
		public PlayerClientPreferences Preferences { get; init; } = new();
		public ChallengePoints TotalPoints { get; init; } = new();
		public ImmutableDictionary<string, ChallengePoints> CategoryPoints { get; init; } = ImmutableDictionary<string, ChallengePoints>.Empty;
	}
}
