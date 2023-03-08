using System.Collections.Immutable;

namespace Soraka.Dto.Spectator
{
	internal record FeaturedGameInfo
	{
		public string GameMode { get; init; } = default!;
		public long GameLength { get; init; }
		public long MapId { get; init; }
		public string GameType { get; init; } = default!;
		public ImmutableList<BannedChampion> BannedChampions { get; init; } = ImmutableList<BannedChampion>.Empty;
		public long GameId { get; init; }
		public Observer Observers { get; init; } = default!;
		public long GameQueueConfigId { get; init; }
		public long GameStartTime { get; init; }
		public ImmutableList<Participant> Participants { get; init; } = ImmutableList<Participant>.Empty;
		public string PlatformId { get; init; } = default!;
	}
}
