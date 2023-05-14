namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record DamageDto : DataObject<DamageDto>
    {
        /// <summary>
        /// The PUUID of affected player.
        /// </summary>
        public string Receiver { get; init; } = default!;
        public int Damage { get; init; }
        public int Legshots { get; init; }
        public int Bodyshots { get; init; }
        public int Headshots { get; init; }
    }
}
