using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Item
    {
        public string? Name { get; set; }
        public int Id { get; set; }
        public int Tier { get; set; }
        public ImmutableList<string> Rank { get; set; } = ImmutableList<string>.Empty;
        public ImmutableList<int> BuildsFrom { get; set; } = ImmutableList<int>.Empty;
        public ImmutableList<int> BuildsInto { get; set; } = ImmutableList<int>.Empty;
        public int SpecialRecipe { get; set; }
        public bool NoEffects { get; set; }
        public bool Removed { get; set; }
        public string? RequiredChampion { get; set; }
        public string? RequiredAlly { get; set; }
        public string? Icon { get; set; }
        public string? SimpleDescription { get; set; }
        public ImmutableList<string> Nicknames { get; set; } = ImmutableList<string>.Empty;
        public ImmutableList<Passive> Passives { get; set; } = ImmutableList<Passive>.Empty;
        public ImmutableList<Active> Actives { get; set; } = ImmutableList<Active>.Empty;
        public Stats Stats { get; set; } = new();
        public Shop Shop { get; set; } = new();
        public bool IconOverlay { get; set; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
