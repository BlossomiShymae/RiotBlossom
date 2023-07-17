namespace BlossomiShymae.RiotBlossom.Dto.Riot.Spectator
{
    public record Observer : DataObject
    {
        /// <summary>
        /// The key used to decrypt the spectator grid game data for playback.
        /// </summary>
        public string EncryptionKey { get; init; } = default!;
    }
}
