using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Item : DataObject
    {
        public required string Name { get; init; } 
        public required Rune Rune { get; init; } 
        public Gold Gold { get; init; } = new();
        public string? Group { get; init; }
        public required string Description { get; init; } 
        public string? Colloq { get; init; }
        public string? Plaintext { get; init; }
        public bool Consumed { get; init; }
        public int Stacks { get; init; }
        public int Depth { get; init; }
        public bool ConsumeOnFull { get; init; }
        public List<string>? From { get; init; }
        public List<string>? Into { get; init; }
        public int SpecialRecipe { get; init; }
        public bool InStore { get; init; }
        public bool HideFromAll { get; init; }
        public string? RequiredChampion { get; init; }
        public string? RequiredAlly { get; init; }
        public Dictionary<string, double> Stats { get; init; } = [];
        public List<string> Tags { get; init; } = [];
        public Dictionary<int, bool> Maps { get; init; } = [];
    }
}
