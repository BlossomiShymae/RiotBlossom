namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Spectator
{
    public record BannedChampion : DataObject
    {
        /// <summary>
        /// The Draft Pick turn for when the champion was banned.
        /// </summary>
        public int PickTurn { get; init; }
        /// <summary>
        /// The champion ID.
        /// </summary>
        public long ChampionId { get; init; }
        /// <summary>
        /// The banning team ID.
        /// </summary>
        public long TeamId { get; init; }
    }
}
