namespace Gwen.Exception
{
	/// <summary>
	/// <para>An exception class for a corrupted Riot API game match.</para>
	/// <see href="https://github.com/RiotGames/developer-relations/issues/642"/>
	/// </summary>
	public class GwenCorruptedMatchException : System.Exception
	{
		public GwenCorruptedMatchException(string matchId) : base(matchId)
		{
		}

		public GwenCorruptedMatchException(string matchId, System.Exception inner) : base(matchId, inner)
		{
		}
	}
}
