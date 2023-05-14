using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Shop : DataObject<Shop>
    {
        public Prices Prices { get; init; } = new();
        public bool Purchasable { get; init; }
        public ImmutableList<string> Tags { get; init; } = ImmutableList<string>.Empty;
    }
}
