using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record AbilityCastsDto
    {
        public int GrenadeCasts { get; init; }
        public int Ability1Casts { get; init; }
        public int Ability2Casts { get; init; }
        public int UltimateCasts { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
