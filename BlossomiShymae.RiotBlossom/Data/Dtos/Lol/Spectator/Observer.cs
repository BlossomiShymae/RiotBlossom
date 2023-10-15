namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Spectator
{
    public record Observer : DataObject
    {
        /// <summary>
        /// The key used to decrypt the spectator grid game data for playback.
        /// </summary>
        public required string EncryptionKey { get; init; } 
    }
}
