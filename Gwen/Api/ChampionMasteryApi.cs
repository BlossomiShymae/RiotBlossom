namespace Gwen.Api
{
    public class ChampionMasteryApi
    {
        private static readonly string _uri = "/lol/champion-mastery/v4/champion-masteries";
        private static readonly string _masteriesBySummonerId = "/by-summoner/{0}";
        private static readonly string _masteryBySummonerIdAndChampionId = _masteriesBySummonerId + "/by-champion/{1}";
        private static readonly string _masteriesTopBySummonerId = _masteriesBySummonerId + "/top";
        private static readonly string _scoresBySummonerId = "/lol/champion-mastery/v4/scores/by-summoner/{0}";
    }
}
