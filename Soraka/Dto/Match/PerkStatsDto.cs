namespace Soraka.Dto.Match
{
	internal record PerkStatsDto
	{
		public int Defense { get; init; }
		public int Flex { get; init; }
		public int Offense { get; init; }
	}
}
