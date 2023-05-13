using BlossomiShymae.RiotBlossom.Converter;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class ValRegionExtensions
    {
        private static readonly ValRegionAbbreviationConverter s_abbreviationConverter = new();

        /// <summary>
        /// Get an abbreviation of a VALORANT region e.g. "NA",  "AP", "LATAM".
        /// </summary>
        /// <param name="valRegion"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetAbbreviation(this ValRegion valRegion)
            => s_abbreviationConverter.Convert(valRegion);

        /// <summary>
        /// Get the raw routing value e.g. "na", "ap", "latam".
        /// </summary>
        /// <param name="valRegion"></param>
        /// <returns></returns>
        public static string GetId(this ValRegion valRegion)
        {
            return ValRegionMapper.GetId(valRegion);
        }
    }
}
