using System.Collections.Immutable;

namespace Soraka.Dto.LolChallenges
{
	internal record ChallengeConfigInfoDto
	{
		public long Id { get; init; }
		public ImmutableDictionary<string, LocalizedName> LocalizedNames { get; init; } = ImmutableDictionary<string, LocalizedName>.Empty;
		public string State { get; init; } = default!;
		public string Tracking { get; init; } = default!;
		public long StartTimestamp { get; init; }
		public long EndTimestamp { get; init; }
		public bool Leaderboard { get; init; }
		public ImmutableDictionary<string, double> Thresholds { get; init; } = ImmutableDictionary<string, double>.Empty;

	}

	internal record LocalizedName
	{
		public string Description { get; init; } = default!;
		public string Name { get; init; } = default!;
		public string ShortDescription { get; init; } = default!;
	}
}
