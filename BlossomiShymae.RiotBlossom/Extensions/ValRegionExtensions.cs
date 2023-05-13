using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class ValRegionExtensions
    {
        /// <summary>
        /// Get an abbreviation of a VALORANT region e.g. "NA",  "AP", "LATAM".
        /// </summary>
        /// <param name="valRegion"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetAbbreviation(this ValRegion valRegion)
        {
            return valRegion switch
            {
                ValRegion.NorthAmerica => "NA",
                ValRegion.Brazil => "BR",
                ValRegion.Korea => "KR",
                ValRegion.AsiaPacific => "AP",
                ValRegion.LatinAmerica => "LATAM",
                ValRegion.Europe => "EU",
                _ => throw new NotImplementedException("Abbreviation is not yet added for VALORANT region!")
            };
        }

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
