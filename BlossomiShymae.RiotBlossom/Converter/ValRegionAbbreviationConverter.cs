using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Converter
{
    internal class ValRegionAbbreviationConverter : IConverter<ValRegion, string>
    {
        public ValRegion Convert(string value)
        {
            throw new NotImplementedException();
        }

        public string Convert(ValRegion value)
        {
            return value switch
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
    }
}
