using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record TacticalInfo
    {
        public int Style { get; init; }
        public int Difficulty { get; init; }
        public string DamageType { get; init; } = default!;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
