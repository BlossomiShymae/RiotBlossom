namespace Soraka.Dto.Match
{
	internal record BanDto
	{
		public int ChampionId { get; init; }
		public int PickTurn { get; init; }
	}
}
