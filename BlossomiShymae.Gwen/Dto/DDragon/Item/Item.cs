using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Dto.DDragon.Item
{
    public record Item
    {
        public string Name { get; init; } = default!;
        public Rune Rune { get; init; } = new();
        public Gold Gold { get; init; } = new();
        public string? Group { get; init; }
        public string Description { get; init; } = default!;
        public string? Colloq { get; init; }
        public string? Plaintext { get; init; }
        public bool Consumed { get; init; }
        public int Stacks { get; init; }
        public int Depth { get; init; }
        public bool ConsumeOnFull { get; init; }
        public ImmutableList<string>? From { get; init; }
        public ImmutableList<string>? Into { get; init; }
        public int SpecialRecipe { get; init; }
        public bool InStore { get; init; }
        public bool HideFromAll { get; init; }
        public string? RequiredChampion { get; init; }
        public string? RequiredAlly { get; init; }
        public ImmutableDictionary<string, double> Stats { get; init; } = ImmutableDictionary<string, double>.Empty;
        public ImmutableList<string> Tags { get; init; } = ImmutableList<string>.Empty;
        public ImmutableDictionary<int, bool> Maps { get; init; } = ImmutableDictionary<int, bool>.Empty;
    }
}
