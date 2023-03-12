using System.Collections.Immutable;

namespace Gwen.Core
{
    internal static class LeagueQueueMapper
    {
        private static readonly ImmutableDictionary<Type.LeagueQueue, string> _valueByLeagueQueue =
            new Dictionary<Type.LeagueQueue, string>
            {
                { Type.LeagueQueue.RankedSolo5x5, "RANKED_SOLO_5x5" },
                { Type.LeagueQueue.RankedFlexSummonersRift, "RANKED_FLEX_SR" },
                { Type.LeagueQueue.RankedFlexTeamfightTactics, "RANKED_FLEX_TT" }
            }.ToImmutableDictionary();

        public static string GetValue(Type.LeagueQueue leagueQueue)
        {
            var value = _valueByLeagueQueue.GetValueOrDefault(leagueQueue);
            if (string.IsNullOrEmpty(value))
                throw new NotImplementedException($"Value for league queue {leagueQueue} is not implemented");
            return value;
        }
    }
}
