using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class RegionExtensions
    {
        /// <summary>
        /// Get the raw identifier value e.g. "americas", "europe".
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static string GetId(this Region region)
        {
            return RegionMapper.GetId(region);
        }

        /// <summary>
        /// Get the pretty name of region e.g. "Americas", "Asia".
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetPrettyName(this Region region)
        {
            return region switch
            {
                Region.Americas => "Americas",
                Region.Asia => "Asia",
                Region.SouthEastAsia => "Southeast Asia",
                Region.Europe => "Europe",
                _ => throw new NotImplementedException("Pretty name is not implemented for region!")
            };
        }
    }
}
