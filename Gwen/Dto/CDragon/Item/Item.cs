using System.Collections.Immutable;

namespace Gwen.Dto.CDragon.Item
{
	public record Item
	{
		public int Id { get; init; }
		public string Name { get; init; } = default!;
		public string Description { get; init; } = default!;
		public bool Active { get; init; }
		public bool InStore { get; init; }
		public ImmutableList<int> From { get; init; } = ImmutableList<int>.Empty;
		public ImmutableList<int> To { get; init; } = ImmutableList<int>.Empty;
		public ImmutableList<string> Categories { get; init; } = ImmutableList<string>.Empty;
		public int MaxStacks { get; init; }
		public string RequiredChampion { get; init; } = default!;
		public string RequiredAlly { get; init; } = default!;
		public string RequiredBuffCurrencyName { get; init; } = default!;
		public int RequiredBuffCurrencyCost { get; init; }
		public int SpecialRecipe { get; init; }
		public bool IsEnchantment { get; init; }
		public int Price { get; init; }
		public int PriceTotal { get; init; }
		public string IconPath { get; init; } = default!;
	}
}
