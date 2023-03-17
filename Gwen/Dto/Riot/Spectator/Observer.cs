namespace Gwen.Dto.Riot.Spectator
{
    public record Observer
    {
        /// <summary>
        /// The key used to decrypt the spectator grid game data for playback.
        /// </summary>
        public string EncryptionKey { get; init; } = default!;
    }
}
