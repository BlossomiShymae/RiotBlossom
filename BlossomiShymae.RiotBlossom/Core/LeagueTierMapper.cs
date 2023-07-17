using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A mapper class for the <see cref="LeagueTier"/> enum.
    /// </summary>
    public static class LeagueTierMapper
    {
        private static readonly ImmutableDictionary<LeagueTier, string> s_valueByLeagueTier =
            new Dictionary<LeagueTier, string>
            {
                { LeagueTier.Iron, "IRON" },
                { LeagueTier.Bronze, "BRONZE" },
                { LeagueTier.Silver, "SILVER" },
                { LeagueTier.Gold, "GOLD" },
                { LeagueTier.Platinum, "PLATINUM" },
                { LeagueTier.Emerald, "EMERALD" },
                { LeagueTier.Diamond, "DIAMOND" }
            }.ToImmutableDictionary();

        public static string GetValue(LeagueTier leagueTier)
        {
            string? value = s_valueByLeagueTier.GetValueOrDefault(leagueTier);
            return value ?? throw new NotImplementedException($"Value for league tier {leagueTier} not implemented");
        }
    }
}
