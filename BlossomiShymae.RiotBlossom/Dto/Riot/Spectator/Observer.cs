using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Spectator
{
    public record Observer
    {
        /// <summary>
        /// The key used to decrypt the spectator grid game data for playback.
        /// </summary>
        public string EncryptionKey { get; init; } = default!;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
