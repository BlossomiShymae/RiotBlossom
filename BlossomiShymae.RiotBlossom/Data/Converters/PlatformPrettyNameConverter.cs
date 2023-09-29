using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Converter
{
    internal class PlatformPrettyNameConverter : IConverter<Platform, string>
    {
        public Platform Convert(string value)
        {
            throw new NotImplementedException();
        }

        public string Convert(Platform value)
        {
            return value switch
            {
                Platform.Brazil => "Brazil",
                Platform.EuropeNordicEast => "Europe Nordic and East",
                Platform.EuropeWest => "Europe West",
                Platform.LatinAmericaNorth => "Latin America North",
                Platform.LatinAmericaSouth => "Latin America South",
                Platform.NorthAmerica => "North America",
                Platform.Oceania => "Oceania",
                Platform.Russia => "Russia",
                Platform.Turkey => "Turkey",
                Platform.Korea => "Republic of Korea",
                Platform.Philippines => "The Philippines",
                Platform.Singapore => "Singapore, Malaysia, and Indonesia",
                Platform.Taiwan => "Taiwan, Hong Kong, and Macao",
                Platform.Thailand => "Thailand",
                Platform.Vietnam => "Vietnam",
                _ => throw new NotImplementedException("Pretty name is not yet added for this platform!")
            };
        }
    }
}
