using BlossomiShymae.RiotBlossom.Core.Utils;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Types.Lol
{
    /// <summary>
    /// <para>An enum that represents League ranked divisions.</para>
    /// <see href="https://developer.riotgames.com/apis#league-v4/GET_getLeagueEntries"/>
    /// </summary>
    public sealed record LeagueDivision : ValueEnum<string>
    {
        public static readonly LeagueDivision I = new("I");
        public static readonly LeagueDivision II = new("II");
        public static readonly LeagueDivision III = new("III");
        public static readonly LeagueDivision IV = new("IV");

        private LeagueDivision(string value) : base(value)
        {
        }
    }
}
