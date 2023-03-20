namespace Gwen.PException
{
	/// <summary>
	/// <para>An exception class for a corrupted Riot API game match. :c</para>
	/// <see href="https://github.com/RiotGames/developer-relations/issues/642"/>
	/// </summary>
	public class GwenCorruptedMatchException : Exception
	{
		public GwenCorruptedMatchException(string matchId) : base(matchId)
		{
		}

		public GwenCorruptedMatchException(string matchId, Exception inner) : base(matchId, inner)
		{
		}
	}
}
