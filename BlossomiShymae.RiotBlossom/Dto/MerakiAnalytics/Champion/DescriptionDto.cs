using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record DescriptionDto
    {
        public string? Description { get; set; }
        public string? Region { get; set; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
