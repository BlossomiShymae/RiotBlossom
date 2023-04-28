using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Champion
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public string Alias { get; init; } = default!;
        public string Title { get; init; } = default!;
        public string ShortBio { get; init; } = default!;
        public TacticalInfo TacticalInfo { get; init; } = new();
        public PlaystyleInfo PlaystyleInfo { get; init; } = new();
        public string SquarePortraitPath { get; init; } = default!;
        public string StingerSfxPath { get; init; } = default!;
        public string ChooseVoPath { get; init; } = default!;
        public string BanVoPath { get; init; } = default!;
        public ImmutableList<string> Roles { get; init; } = ImmutableList<string>.Empty;
        public object? RecommendedItemDefaults { get; init; }
        public ImmutableList<Skin> Skins { get; init; } = ImmutableList<Skin>.Empty;
        public Passive Passive { get; init; } = new();
        public ImmutableList<Spell> Spells { get; init; } = ImmutableList<Spell>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
