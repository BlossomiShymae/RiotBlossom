using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record PlayerLocationsDto
    {
        public string Puuid { get; init; } = default!;
        public float ViewRadians { get; init; }
        public LocationDto Location { get; init; } = new();

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
