using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Skin : DataObject
    {
        public string? Name { get; init; }
        public int Id { get; init; }
        public bool IsBase { get; init; }
        public string? Availability { get; init; }
        public string? FormatName { get; init; }
        public bool LootEligible { get; init; }
        [JsonConverter(typeof(StringJsonConverter))]
        public string? Cost { get; init; }
        public int Sale { get; init; }
        public string? Distribution { get; init; }
        public string? Rarity { get; init; }
        public ImmutableList<Chroma> Chromas { get; init; } = ImmutableList<Chroma>.Empty;
        public string? Lore { get; init; }
        public string? Release { get; init; }
        public ImmutableList<string> Set { get; init; } = ImmutableList<string>.Empty;
        public string? SplashPath { get; init; }
        public string? UncenteredSplashPath { get; init; }
        public string? TilePath { get; init; }
        public string? LoadScreenPath { get; init; }
        public string? LoadScreenVintagePath { get; init; }
        public bool NewEffects { get; init; }
        public bool NewAnimations { get; init; }
        public bool NewRecall { get; init; }
        public bool NewVoice { get; init; }
        public bool NewQuotes { get; init; }
        public ImmutableList<string> VoiceActor { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<string> SplashArtist { get; init; } = ImmutableList<string>.Empty;
    }
}
