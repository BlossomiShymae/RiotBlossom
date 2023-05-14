using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class LeagueQueueExtensions
    {
        /// <summary>
        /// Get the associated raw value e.g. "RANKED_SOLO_5x5".
        /// </summary>
        /// <param name="leagueQueue"></param>
        /// <returns></returns>
        public static string GetValue(this LeagueQueue leagueQueue)
        {
            return LeagueQueueMapper.GetValue(leagueQueue);
        }
    }
}
