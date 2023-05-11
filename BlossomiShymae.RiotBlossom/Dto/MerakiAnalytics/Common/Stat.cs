using BlossomiShymae.RiotBlossom.Core;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Common
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Stat
    {
        [JsonConverter(typeof(DoubleJsonConverter))]
        public double Flat { get; set; }
        public double Percent { get; set; }
        public double PerLevel { get; set; }
        public double PercentPerLevel { get; set; }
        public double PercentBase { get; set; }
        public double PercentBonus { get; set; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
