namespace Gwen.Dto.Match
{
	public record ParticipantFrameDto
	{
		public ChampionStatsDto ChampionStats { get; init; } = new();
		public int CurrentGold { get; init; }
		public DamageStatsDto DamageStats { get; init; } = new();
		public int GoldPerSecond { get; init; }
		public int JungleMinionsKilled { get; init; }
		public int Level { get; init; }
		public int MinionsKilled { get; init; }
		public int ParticipantId { get; init; }
		public PositionDto Position { get; init; } = new();
		public int TimeEnemySpentControlled { get; init; }
		public int TotalGold { get; init; }
		public int Xp { get; init; }
	}
}
