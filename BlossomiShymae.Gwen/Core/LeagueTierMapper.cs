using System.Collections.Immutable;
using BlossomiShymae.Gwen.Type;

namespace BlossomiShymae.Gwen.Core
{
    /// <summary>
    /// A mapper class for the <see cref="LeagueTier"/> enum.
    /// </summary>
    public static class LeagueTierMapper
    {
        private static readonly ImmutableDictionary<LeagueTier, string> _valueByLeagueTier =
            new Dictionary<LeagueTier, string>
            {
                { LeagueTier.Iron, "IRON" },
                { LeagueTier.Bronze, "BRONZE" },
                { LeagueTier.Silver, "SILVER" },
                { LeagueTier.Gold, "GOLD" },
                { LeagueTier.Platinum, "PLATINUM" },
                { LeagueTier.Diamond, "DIAMOND" }
            }.ToImmutableDictionary();

        public static string GetValue(LeagueTier leagueTier)
        {
            var value = _valueByLeagueTier.GetValueOrDefault(leagueTier);
            if (string.IsNullOrEmpty(value))
                throw new NotImplementedException($"Value for league tier {leagueTier} is not implemented");
            return value;
        }
    }
}
