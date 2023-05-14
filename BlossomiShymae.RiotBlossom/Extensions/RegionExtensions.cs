using BlossomiShymae.RiotBlossom.Converter;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class RegionExtensions
    {
        private static readonly RegionPrettyNameConverter s_prettyNameConverter = new();

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
            => s_prettyNameConverter.Convert(region);
    }
}
