using System.Collections.Immutable;

namespace Soraka.Dto.Spectator
{
	internal record CurrentGameInfo
	{
		public long GameId { get; init; }
		public string GameType { get; init; } = default!;
		public long GameStartTime { get; init; }
		public long MapId { get; init; }
		public long GameLength { get; init; }
		public string PlatformId { get; init; } = default!;
		public string GameMode { get; init; } = default!;
		public ImmutableList<BannedChampion> BannedChampions { get; init; } = ImmutableList<BannedChampion>.Empty;
		public long GameQueueConfigId { get; init; }
		public Observer Observers { get; init; } = new();
		public ImmutableList<CurrentGameParticipant> Participants { get; init; } = ImmutableList<CurrentGameParticipant>.Empty;

	}
}
