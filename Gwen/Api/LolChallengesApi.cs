namespace Gwen.Api
{
    internal class LolChallengesApi
    {
        private static readonly string _uri = "/lol/challenges/v1/challenges";
        private static readonly string _challengesConfigUri = "/config";
        private static readonly string _challengesPercentilesUri = "/percentiles";
        private static readonly string _challengesConfigForChallengeIdUri = "/{0}/config";
        private static readonly string _challengesTopPlayersByChallengeIdAndLevelUri = "/{0}/leaderboards/by-level/{1}";
        private static readonly string _challengesPercentilesForChallengeIdUri = "/{0}/percentiles";
        private static readonly string _challengesProgressedUri = "/lol/challenges/v1/player-data/{0}";
    }
}
