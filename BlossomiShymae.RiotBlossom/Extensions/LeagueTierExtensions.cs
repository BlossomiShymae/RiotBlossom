using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class LeagueTierExtensions
    {
        /// <summary>
        /// Get the associated raw value e.g. "IRON", "BRONZE".
        /// </summary>
        /// <param name="leagueTier"></param>
        /// <returns></returns>
        public static string GetValue(this LeagueTier leagueTier)
        {
            return LeagueTierMapper.GetValue(leagueTier);
        }
    }
}
