using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
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
        public ImmutableList<double> Range { get; init; } = ImmutableList<double>.Empty;
        public ImmutableList<double> CostCoefficients { get; init; } = ImmutableList<double>.Empty;
        public ImmutableList<double> CooldownCoefficients { get; init; } = ImmutableList<double>.Empty;
        public object Coefficients { get; init; } = default!;
        public object EffectAmounts { get; init; } = default!;
        public object Ammo { get; init; } = default!;
        public int MaxLevel { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
