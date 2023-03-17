namespace Gwen.Dto.CDragon
{
	public record ChromaDescription
	{
		public string Region { get; init; } = default!;
		public int Rarity { get; init; }
	}
}
