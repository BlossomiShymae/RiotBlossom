namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolChallenges
{
    public record ApexPlayerInfoDto : DataObject
    {
        /// <summary>
        /// The encrypted PUUID of apex player.
        /// </summary>
        public required string Puuid { get; init; }
        /// <summary>
        /// The value the apex player has for challenge.
        /// </summary>
        public double Value { get; init; }
        /// <summary>
        /// The leaderboard position of apex player.
        /// </summary>
        public long Position { get; init; }
    }
}
