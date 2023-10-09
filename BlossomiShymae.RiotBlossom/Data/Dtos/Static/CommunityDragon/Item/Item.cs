using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Item : DataObject
    {
        public int Id { get; init; }
        public required string Name { get; init; } 
        public required string Description { get; init; } 
        public bool Active { get; init; }
        public bool InStore { get; init; }
        public List<int> From { get; init; } = [];
        public List<int> To { get; init; } = [];
        public List<string> Categories { get; init; } = [];
        public int MaxStacks { get; init; }
        public required string RequiredChampion { get; init; }
        public required string RequiredAlly { get; init; }
        public required string RequiredBuffCurrencyName { get; init; } 
        public int RequiredBuffCurrencyCost { get; init; }
        public int SpecialRecipe { get; init; }
        public bool IsEnchantment { get; init; }
        public int Price { get; init; }
        public int PriceTotal { get; init; }
        public required string IconPath { get; init; } 
    }
}
