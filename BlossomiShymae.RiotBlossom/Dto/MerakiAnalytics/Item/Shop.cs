using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Shop
    {
        public Prices Prices { get; set; } = new();
        public bool Purchasable { get; set; }
        public ImmutableList<string> Tags { get; set; } = ImmutableList<string>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
