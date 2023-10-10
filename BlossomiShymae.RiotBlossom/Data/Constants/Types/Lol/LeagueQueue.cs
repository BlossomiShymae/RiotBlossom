using BlossomiShymae.RiotBlossom.Core.Utils;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Types.Lol
{
    /// <summary>
    /// <para>An enum that represents League ranked queue types.</para>
    /// <see href="https://developer.riotgames.com/apis#league-v4"/>
    /// </summary>
    public sealed record LeagueQueue : ValueEnum<string>
    {
        public static readonly LeagueQueue RankedSolo5x5 = new("RANKED_SOLO_5x5");
        public static readonly LeagueQueue RankedFlexSummonersRift = new("RANKED_FLEX_SR");
        public static readonly LeagueQueue RankedFlexTeamfightTactics = new("RANKED_FLEX_TT");

        private LeagueQueue(string value) : base(value)
        {
        }
    }
}
