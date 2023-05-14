using BlossomiShymae.RiotBlossom.Core;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Common
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Stat : DataObject<Stat>
    {
        [JsonConverter(typeof(DoubleJsonConverter))]
        public double Flat { get; init; }
        public double Percent { get; init; }
        public double PerLevel { get; init; }
        public double PercentPerLevel { get; init; }
        public double PercentBase { get; init; }
        public double PercentBonus { get; init; }
    }
}
