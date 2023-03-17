namespace Gwen.Dto.CDragon
{
	public record ChromaRarity
	{
		public string Region { get; init; } = default!;
		public int Rarity { get; init; }
	}
}
