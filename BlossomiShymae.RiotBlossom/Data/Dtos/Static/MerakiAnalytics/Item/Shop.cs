using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Shop : DataObject
    {
        public Prices Prices { get; init; } = new();
        public bool Purchasable { get; init; }
        public List<string> Tags { get; init; } = [];
    }
}
