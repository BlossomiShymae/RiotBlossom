using System.Collections.Immutable;

namespace Gwen.Core
{
    internal static class LeagueTierMapper
    {
        private static readonly ImmutableDictionary<Type.LeagueTier, string> _valueByLeagueTier =
            new Dictionary<Type.LeagueTier, string>
            {
                { Type.LeagueTier.Iron, "IRON" },
                { Type.LeagueTier.Bronze, "BRONZE" },
                { Type.LeagueTier.Silver, "SILVER" },
                { Type.LeagueTier.Gold, "GOLD" },
                { Type.LeagueTier.Platinum, "PLATINUM" },
                { Type.LeagueTier.Diamond, "DIAMOND" }
            }.ToImmutableDictionary();

        public static string GetValue(Type.LeagueTier leagueTier)
        {
            var value = _valueByLeagueTier.GetValueOrDefault(leagueTier);
            if (string.IsNullOrEmpty(value))
                throw new NotImplementedException($"Value for league tier {leagueTier} is not implemented");
            return value;
        }
    }
}
