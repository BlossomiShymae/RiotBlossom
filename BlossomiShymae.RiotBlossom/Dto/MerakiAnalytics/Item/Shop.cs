using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Shop
    {
        public Prices Prices { get; init; } = new();
        public bool Purchasable { get; init; }
        public ImmutableList<string> Tags { get; init; } = ImmutableList<string>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
