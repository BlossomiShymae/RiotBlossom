namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record CoachDto : DataObject
    {
        public string Puuid { get; init; } = default!;
        public string TeamId { get; init; } = default!;
    }
}
