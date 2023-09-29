using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A mapper class for the <see cref="TftLeagueQueue"/> enum.
    /// </summary>
    public static class TftLeagueQueueMapper
    {
        private static readonly ImmutableDictionary<TftLeagueQueue, string> s_valueByTftLeagueQueue =
            new Dictionary<TftLeagueQueue, string>
            {
                { TftLeagueQueue.RankedTftTurbo, "RANKED_TFT_TURBO" }
            }.ToImmutableDictionary();

        public static string GetValue(TftLeagueQueue leagueQueue)
        {
            string? value = s_valueByTftLeagueQueue.GetValueOrDefault(leagueQueue);
            return value ?? throw new NotImplementedException($"Value for TFT league queue {leagueQueue} not implemented");
        }
    }
}
