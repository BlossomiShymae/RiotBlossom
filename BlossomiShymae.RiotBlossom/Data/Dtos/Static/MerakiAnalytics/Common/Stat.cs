using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Core.Converters;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Common
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Stat : DataObject
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
