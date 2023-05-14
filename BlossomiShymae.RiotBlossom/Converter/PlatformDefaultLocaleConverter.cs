using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Converter
{
    internal class PlatformDefaultLocaleConverter : IConverter<Platform, string>
    {
        public Platform Convert(string value)
        {
            throw new NotImplementedException();
        }

        public string Convert(Platform value)
        {
            return value switch
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
