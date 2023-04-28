using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record FinishingDamageDto
    {
        public string DamageType { get; init; } = default!;
        public string DamageItem { get; init; } = default!;
        public bool IsSecondaryFireMode { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
