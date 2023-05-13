using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class LeagueDivisionExtensions
    {
        /// <summary>
        /// Get the associated raw value e.g. "I", "II", "III", "IV".
        /// </summary>
        /// <param name="leagueDivision"></param>
        /// <returns></returns>
        public static string GetValue(this LeagueDivision leagueDivision)
        {
            return LeagueDivisionMapper.GetValue(leagueDivision);
        }
    }
}
