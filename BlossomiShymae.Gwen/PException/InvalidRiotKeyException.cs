namespace BlossomiShymae.Gwen.PException
{
    /// <summary>
    /// <para>An exception class for an invalid Riot API key. :c</para>
    /// </summary>
    public class InvalidRiotKeyException : Exception
    {
        public InvalidRiotKeyException(string message) : base(message) { }

        public InvalidRiotKeyException(string message, Exception inner) : base(message, inner) { }
    }
}
