using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LolChallenges
{
    public record ApexPlayerInfoDto
    {
        /// <summary>
        /// The encrypted PUUID of apex player.
        /// </summary>
        public string Puuid { get; init; } = default!;
        /// <summary>
        /// The value the apex player has for challenge.
        /// </summary>
        public double Value { get; init; }
        /// <summary>
        /// The leaderboard position of apex player.
        /// </summary>
        public long Position { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
