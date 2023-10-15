namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record DamageDto : DataObject
    {
        /// <summary>
        /// The PUUID of affected player.
        /// </summary>
        public required string Receiver { get; init; }
        public int Damage { get; init; }
        public int Legshots { get; init; }
        public int Bodyshots { get; init; }
        public int Headshots { get; init; }
    }
}
