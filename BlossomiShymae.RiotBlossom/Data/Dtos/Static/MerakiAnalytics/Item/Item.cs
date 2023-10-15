using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Item : DataObject
    {
        public string? Name { get; init; }
        public int Id { get; init; }
        public int Tier { get; init; }
        public List<string> Rank { get; init; } = [];
        public List<int> BuildsFrom { get; init; } = [];
        public List<int> BuildsInto { get; init; } = [];
        public int SpecialRecipe { get; init; }
        public bool NoEffects { get; init; }
        public bool Removed { get; init; }
        public string? RequiredChampion { get; init; }
        public string? RequiredAlly { get; init; }
        public string? Icon { get; init; }
        public string? SimpleDescription { get; init; }
        public List<string> Nicknames { get; init; } = [];
        public List<Passive> Passives { get; init; } = [];
        public List<Active> Actives { get; init; } = [];
        public Stats Stats { get; init; } = new();
        public Shop Shop { get; init; } = new();
        public bool IconOverlay { get; init; }
    }
}
