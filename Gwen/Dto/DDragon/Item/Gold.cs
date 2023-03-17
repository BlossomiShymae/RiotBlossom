namespace Gwen.Dto.DDragon.Item
{
	public record Gold
	{
		public int Base { get; init; }
		public int Total { get; init; }
		public int Sell { get; init; }
		public bool Purchasable { get; init; }
	}
}
