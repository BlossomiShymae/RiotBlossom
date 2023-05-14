using BlossomiShymae.RiotBlossom.Converter;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Extensions
{
    public static class PlatformExtensions
    {
        private static readonly PlatformAbbreviationConverter s_abbreviationConverter = new();
        private static readonly PlatformPrettyNameConverter s_prettyNameConverter = new();
        private static readonly PlatformDefaultLocaleConverter s_defaultLocaleConverter = new();

        /// <summary>
        /// Get an abbreviation of platform e.g. "NA", "LAS", "EUNE", "JP".
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetAbbreviation(this Platform platform)
            => s_abbreviationConverter.Convert(platform);

        /// <summary>
        /// Get the pretty name of platform e.g. "Europe Nordic and East".
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetPrettyName(this Platform platform)
            => s_prettyNameConverter.Convert(platform);

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
        /// Get the associated <see cref="Region"/> identifier value e.g. "americas", "europe".
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static string GetRegionId(this Platform platform)
        {
            return platform.GetRegion().GetId();
        }

        /// <summary>
        /// Get the default locale e.g. "ja_JP", "en_GB", "ko_KR".
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetDefaultLocale(this Platform platform)
            => s_defaultLocaleConverter.Convert(platform);
    }
}
