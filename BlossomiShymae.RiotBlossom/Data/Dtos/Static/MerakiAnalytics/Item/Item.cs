using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Item : DataObject
    {
        public string? Name { get; init; }
        public int Id { get; init; }
        public int Tier { get; init; }
        public ImmutableList<string> Rank { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<int> BuildsFrom { get; init; } = ImmutableList<int>.Empty;
        public ImmutableList<int> BuildsInto { get; init; } = ImmutableList<int>.Empty;
        public int SpecialRecipe { get; init; }
        public bool NoEffects { get; init; }
        public bool Removed { get; init; }
        public string? RequiredChampion { get; init; }
        public string? RequiredAlly { get; init; }
        public string? Icon { get; init; }
        public string? SimpleDescription { get; init; }
        public ImmutableList<string> Nicknames { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<Passive> Passives { get; init; } = ImmutableList<Passive>.Empty;
        public ImmutableList<Active> Actives { get; init; } = ImmutableList<Active>.Empty;
        public Stats Stats { get; init; } = new();
        public Shop Shop { get; init; } = new();
        public bool IconOverlay { get; init; }
    }
}
