using System.Collections.Immutable;

namespace Gwen.Dto.CDragon
{
	public record Spell
	{
		public string SpellKey { get; init; } = default!;
		public string Name { get; init; } = default!;
		public string AbilityIconPath { get; init; } = default!;
		public string AbilityVideoPath { get; init; } = default!;
		public string Cost { get; init; } = default!;
		public string Cooldown { get; init; } = default!;
		public string Description { get; init; } = default!;
		public string DynamicDescription { get; init; } = default!;
		public ImmutableList<int> Range { get; init; } = ImmutableList<int>.Empty;
		public ImmutableList<int> CostCoefficients { get; init; } = ImmutableList<int>.Empty;
		public ImmutableList<int> CooldownCoefficients { get; init; } = ImmutableList<int>.Empty;
		public object Coefficients { get; init; } = default!;
		public object EffectAmounts { get; init; } = default!;
		public object Ammo { get; init; } = default!;
		public int MaxLevel { get; init; }
	}
}
