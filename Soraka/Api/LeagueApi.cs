namespace Soraka.Api
{
	public static class LeagueApi
	{
		private static readonly string _uri = "/lol/league/v4";
		private static readonly string _challengerLeagueByQueue = _uri + "/challengerleagues/by-queue/{0}";
		private static readonly string _leagueEntriesBySummonerId = _uri + "/entries/by-summoner/{0}";
		private static readonly string _leagueEntriesByQueueTierDivision = _uri + "/entries/{0}/{1}/{2}";
		private static readonly string _grandmasterLeagueByQueue = _uri + "/grandmasterleagues/by-queue/{0}";
		private static readonly string _leagueByLeagueId = _uri + "/leagues/{0}";
		private static readonly string _masterLeagueByQueue = _uri + "/masterleagues/by-queue/{0}";
	}
}
