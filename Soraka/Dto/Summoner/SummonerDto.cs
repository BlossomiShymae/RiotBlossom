namespace Soraka.Dto.Summoner
{
	internal record SummonerDto
	{
		public string AccountId { get; init; } = default!;
		public int ProfileIconId { get; init; }
		public long RevisionDate { get; init; }
		public string Name { get; init; } = default!;
		public string Id { get; init; } = default!;
		public string Puuid { get; init; } = default!;
		public long SummonerLevel { get; init; }
	}
}
