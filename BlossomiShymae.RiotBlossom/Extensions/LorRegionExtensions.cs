using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class LorRegionExtensions
    {
        /// <summary>
        /// Get the raw routing value e.g. "americas", "sea".
        /// </summary>
        /// <param name="lorRegion"></param>
        /// <returns></returns>
        public static string GetId(this LorRegion lorRegion)
        {
            return LorRegionMapper.GetId(lorRegion);
        }
    }
}
