using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Converter
{
    internal class PlatformAbbreviationConverter : IConverter<Platform, string>
    {
        public Platform Convert(string value)
        {
            throw new NotImplementedException();
        }

        public string Convert(Platform value)
        {
            return value switch
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
                _ => throw new NotImplementedException("Abbreviation is not yet added for this platform!")
            };
        }
    }
}
