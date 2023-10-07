using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A mapper class for the <see cref="LeagueDivision"/> enum.
    /// </summary>
    public class LeagueDivisionMapper
    {
        private static readonly ImmutableDictionary<LeagueDivision, string> s_valueByLeagueDivision =
            new Dictionary<LeagueDivision, string>
            {
                { LeagueDivision.I, "I" },
                { LeagueDivision.II, "II" },
                { LeagueDivision.III, "III" },
                { LeagueDivision.IV, "IV" }
            }.ToImmutableDictionary();

        public static string GetValue(LeagueDivision leagueDivision)
        {
            string? value = s_valueByLeagueDivision.GetValueOrDefault(leagueDivision);
            return value ?? throw new NotImplementedException($"Value for league division {leagueDivision} not implemented");
        }
    }
}
