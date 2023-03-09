namespace Soraka.Api
{
	public static class SpectatorApi
	{
		private static readonly string _uri = "/lol/spectator/v4";
		private static readonly string _currentGameInfoBySummonerIdUri = _uri + "/active-games/by-summoner/{0}";
		private static readonly string _featuredGamesUri = _uri + "/featured-games";
	}
}
