using BlossomiShymae.RiotBlossom.Core.Utils;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Types.Tft
{
    /// <summary>
    /// An enum that represents the TFT League ranked queue types for top rated ladder.
    /// </summary>
    public sealed record TftLeagueQueue : ValueEnum<string>
    {
        public static readonly TftLeagueQueue RankedTftTurbo = new("RANKED_TFT_TURBO");

        private TftLeagueQueue(string value) : base(value)
        {
        }
    }
}
