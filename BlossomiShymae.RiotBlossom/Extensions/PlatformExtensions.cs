using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class PlatformExtensions
    {
        /// <summary>
        /// Get an abbreviation of a platform e.g. "NA", "LAS", "EUNE", "JP".
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetAcronym(this Platform platform)
        {
            return platform switch
            {
                Platform.Brazil => "BR",
                Platform.EuropeNordicEast => "EUNE",
                Platform.EuropeWest => "EUW",
                Platform.LatinAmericaNorth => "LAN",
                Platform.LatinAmericaSouth => "LAS",
                Platform.NorthAmerica => "NA",
                Platform.Oceania => "OCE",
                Platform.Russia => "RU",
                Platform.Turkey => "TR",
                Platform.Japan => "JP",
                Platform.Korea => "KR",
                Platform.Philippines => "PH",
                Platform.Singapore => "SG",
                Platform.Taiwan => "TW",
                Platform.Thailand => "TH",
                Platform.Vietnam => "VN",
                _ => throw new NotImplementedException("Acronym is not yet added for this platform!")
            };
        }

        /// <summary>
        /// Get the associated <see cref="Region"/>.
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static Region GetRegion(this Platform platform)
        {
            return PlatformToRegionConverter.ToRegion(platform);
        }

        /// <summary>
        /// Get the raw identifier value e.g. "na1", "euw1".
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static string GetId(this Platform platform)
        {
            return PlatformMapper.GetId(platform);
        }

        /// <summary>
        /// Get the associated region identifier value e.g. "americas", "europe".
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static string GetRegionId(this Platform platform)
        {
            return RegionMapper.GetId(platform.GetRegion());
        }

        /// <summary>
        /// Get the default locale e.g. "ja_JP", "en_GB", "ko_KR".
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetDefaultLocale(this Platform platform)
        {
            return platform switch
            {
                Platform.Brazil => "pt_BR",
                Platform.EuropeNordicEast => "en_GB",
                Platform.EuropeWest => "en_GB",
                Platform.Japan => "ja_JP",
                Platform.Korea => "ko_KR",
                Platform.LatinAmericaNorth => "es_MX",
                Platform.LatinAmericaSouth => "es_AR",
                Platform.NorthAmerica => "en_US",
                Platform.Oceania => "en_AU",
                Platform.Russia => "ru_RU",
                Platform.Turkey => "tr_TR",
                Platform.Philippines => "en_PH",
                Platform.Singapore => "en_SG",
                Platform.Thailand => "th_TH",
                Platform.Taiwan => "zn_TW",
                Platform.Vietnam => "vn_VN",
                _ => throw new NotImplementedException("Default locale is not yet added for this platform!")
            };
        }
    }
}
