﻿using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A mapper class for the <see cref="LeagueQueue"/> enum.
    /// </summary>
    public static class LeagueQueueMapper
    {
        private static readonly ImmutableDictionary<LeagueQueue, string> s_valueByLeagueQueue =
            new Dictionary<LeagueQueue, string>
            {
                { LeagueQueue.RankedSolo5x5, "RANKED_SOLO_5x5" },
                { LeagueQueue.RankedFlexSummonersRift, "RANKED_FLEX_SR" },
                { LeagueQueue.RankedFlexTeamfightTactics, "RANKED_FLEX_TT" }
            }.ToImmutableDictionary();

        public static string GetValue(LeagueQueue leagueQueue)
        {
            string? value = s_valueByLeagueQueue.GetValueOrDefault(leagueQueue);
            return value ?? throw new NotImplementedException($"Value for league queue {leagueQueue} not implemented");
        }
    }
}
