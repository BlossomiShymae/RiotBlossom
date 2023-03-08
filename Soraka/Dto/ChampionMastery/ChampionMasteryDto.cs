namespace Soraka.Dto.ChampionMastery
{
	internal record ChampionMasteryDto
	{
		public string ChampionPointsUntilNextLevel { get; init; } = default!;
		public bool ChestGranted { get; init; }
		public long ChampionId { get; init; }
		public long LastPlayTime { get; init; }
		public int ChampionLevel { get; init; }
		public string SummonerId { get; init; } = default!;
		public int ChampionPoints { get; init; }
		public long ChampionPointsSinceLastLevel { get; init; }
		public int TokensEarned { get; init; }
	}
}
