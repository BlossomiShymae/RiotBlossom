namespace Soraka.Api
{
	public static class MatchApi
	{
		private static readonly string _uri = "/lol/match/v5/matches";
		private static readonly string _matchIdsByPuuidUri = _uri + "/by-puuid/{0}/ids";
		private static readonly string _matchByMatchIdUri = _uri + "/{0}";
		private static readonly string _matchTimelineByMatchIdUri = _matchByMatchIdUri + "/timeline";
	}
}
