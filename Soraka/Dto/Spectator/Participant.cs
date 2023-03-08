namespace Soraka.Dto.Spectator
{
	internal record Participant
	{
		public bool Bot { get; init; }
		public long Spell2Id { get; init; }
		public long ProfileIconId { get; init; }
		public string SummonerName { get; init; } = default!;
		public long ChampionId { get; init; }
		public long TeamId { get; init; }
		public long Spell1Id { get; init; }
	}
}
