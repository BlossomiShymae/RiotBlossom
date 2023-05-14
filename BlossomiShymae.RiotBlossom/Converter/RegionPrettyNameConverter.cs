using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Converter
{
    internal class RegionPrettyNameConverter : IConverter<Region, string>
    {
        public Region Convert(string value)
        {
            throw new NotImplementedException();
        }

        public string Convert(Region value)
        {
            return value switch
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
