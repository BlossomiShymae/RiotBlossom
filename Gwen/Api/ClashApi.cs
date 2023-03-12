namespace Gwen.Api
{
    public static class ClashApi
    {
        private static readonly string _uri = "/lol/clash/v1";
        private static readonly string _playersBySummonerIdUri = _uri + "/players/by-summoner/{0}";
        private static readonly string _teamByTeamIdUri = _uri + "/teams/{0}";
        private static readonly string _tournamentsUri = _uri + "/tournaments";
        private static readonly string _tournamentByTeamIdUri = _tournamentsUri + "/by-team/{0}";
        private static readonly string _tournamentById = _tournamentsUri + "/{0}";
    }
}
