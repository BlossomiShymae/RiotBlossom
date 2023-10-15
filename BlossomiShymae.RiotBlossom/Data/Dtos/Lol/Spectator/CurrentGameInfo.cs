using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Spectator
{
    public record CurrentGameInfo : DataObject
    {
        /// <summary>
        /// The game ID.
        /// </summary>
        public long GameId { get; init; }
        /// <summary>
        /// The selected game type. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/gameTypes.json">gameTypes.json</see>.
        /// </summary>
        public required string GameType { get; init; }
        /// <summary>
        /// The Unix timestamp in milliseconds for when the game started.
        /// </summary>
        public long GameStartTime { get; init; }
        /// <summary>
        /// The selected map ID. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/maps.json">maps.json</see>.
        /// </summary>
        public long MapId { get; init; }
        /// <summary>
        /// The amount of time in seconds the game has passed since started.
        /// </summary>
        public long GameLength { get; init; }
        /// <summary>
        /// The platform ID of game being played.
        /// </summary>
        public required string PlatformId { get; init; } 
        /// <summary>
        /// The selected game mode. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/gameModes.json">gameModes.json</see>.
        /// </summary>
        public required string GameMode { get; init; }
        /// <summary>
        /// The list of champions banned in Draft Pick.
        /// </summary>
        public List<BannedChampion> BannedChampions { get; init; } = [];
        /// <summary>
        /// The queue type. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/queues.json">queues.json</see>.
        /// </summary>
        public long GameQueueConfigId { get; init; }
        /// <summary>
        /// The information pertaining to observers.
        /// </summary>
        public required Observer Observers { get; init; }
        /// <summary>
        /// The information pertaining to participants.
        /// </summary>
        public List<CurrentGameParticipant> Participants { get; init; } = [];
    }
}
