namespace BlossomiShymae.Gwen.Exception
{
    /// <summary>
    /// <para>An exception class for a missing Riot API key. :c</para>
    /// </summary>
    public class MissingApiKeyException : System.Exception
    {
        public MissingApiKeyException(string message) : base(message) { }

        public MissingApiKeyException(string message, System.Exception inner) : base(message, inner) { }
    }
}
