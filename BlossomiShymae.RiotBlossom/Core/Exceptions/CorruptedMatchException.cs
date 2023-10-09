namespace BlossomiShymae.RiotBlossom.Core.Exceptions
{
    /// <summary>
    /// <para>An exception class for a corrupted Riot API game match. :c</para>
    /// <see href="https://github.com/RiotGames/developer-relations/issues/642"/>
    /// </summary>
    public class CorruptedMatchException : System.Exception
    {
        public CorruptedMatchException(string matchId) : base(matchId) { }

        public CorruptedMatchException(string matchId, System.Exception inner) : base(matchId, inner) { }
    }
}
