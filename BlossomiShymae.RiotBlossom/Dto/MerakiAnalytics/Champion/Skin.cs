using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Skin
    {
        public string? Name { get; set; }
        public int Id { get; set; }
        public bool IsBase { get; set; }
        public string? Availability { get; set; }
        public string? FormatName { get; set; }
        public bool LootEligible { get; set; }
        public string? Cost { get; set; }
        public int Sale { get; set; }
        public string? Distribution { get; set; }
        public string? Rarity { get; set; }
        public ImmutableList<Chroma> Chromas { get; set; } = ImmutableList<Chroma>.Empty;
        public string? Lore { get; set; }
        public float Release { get; set; }
        public ImmutableList<string> Set { get; set; } = ImmutableList<string>.Empty;
        public string? SplashPath { get; set; }
        public string? UncenteredSplashPath { get; set; }
        public string? TilePath { get; set; }
        public string? LoadScreenPath { get; set; }
        public string? LoadScreenVintagePath { get; set; }
        public bool NewEffects { get; set; }
        public bool NewAnimations { get; set; }
        public bool NewRecall { get; set; }
        public bool NewVoice { get; set; }
        public bool NewQuotes { get; set; }
        public ImmutableList<string> VoiceActor { get; set; } = ImmutableList<string>.Empty;
        public ImmutableList<string> SplashArtist { get; set; } = ImmutableList<string>.Empty;
    }
}
