using BlossomiShymae.RiotBlossom.Core.Utils;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Types.Lol
{
    /// <summary>
    /// <para>An enum that represents the possible Challenge levels.</para>
    /// <see href="https://developer.riotgames.com/apis#lol-challenges-v1/GET_getChallengeLeaderboards"/>
    /// </summary>
    public sealed record ChallengeLevel : ValueEnum<string>
    {
        public static readonly ChallengeLevel None = new("NONE");
        public static readonly ChallengeLevel Iron = new("IRON");
        public static readonly ChallengeLevel Bronze = new("BRONZE");
        public static readonly ChallengeLevel Silver = new("SILVER");
        public static readonly ChallengeLevel Gold = new("GOLD");
        public static readonly ChallengeLevel Platinum = new("PLATINUM");
        public static readonly ChallengeLevel Diamond = new("DIAMOND");
        public static readonly ChallengeLevel Master = new("MASTER");
        public static readonly ChallengeLevel Grandmaster = new("GRANDMASTER");
        public static readonly ChallengeLevel Challenger = new("CHALLENGER"); 

        private ChallengeLevel(string value) : base(value)
        {
        }
    }
}
