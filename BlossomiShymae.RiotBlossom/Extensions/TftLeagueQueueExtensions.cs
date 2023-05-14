using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class TftLeagueQueueExtensions
    {
        /// <summary>
        /// Get the associated raw value e.g. "RANKED_TFT_TURBO".
        /// </summary>
        /// <param name="tftLeagueQueue"></param>
        /// <returns></returns>
        public static string GetValue(this TftLeagueQueue tftLeagueQueue)
        {
            return TftLeagueQueueMapper.GetValue(tftLeagueQueue);
        }
    }
}
