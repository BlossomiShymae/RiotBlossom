namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    public record PerkStatsDto : DataObject
    {
        /// <summary>
        /// The selected defense perk ID.
        /// </summary>
        public int Defense { get; init; }
        /// <summary>
        /// The selected flex perk ID.
        /// </summary>
        public int Flex { get; init; }
        /// <summary>
        /// The selected Offense perk ID.
        /// </summary>
        public int Offense { get; init; }
    }
}
