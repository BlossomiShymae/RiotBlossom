using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Spectator
{
    public record FeaturedGameInfo : DataObject
    {
        /// <summary>
        /// The selected game mode. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/gameModes.json">gameModes.json</see>.
        /// </summary>
        public required string GameMode { get; init; } 
        /// <summary>
        /// The amount of time in seconds that game has passed since the match started.
        /// </summary>
        public long GameLength { get; init; }
        /// <summary>
        /// The selected map ID. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/maps.json">maps.json</see>.
        /// </summary>
        public long MapId { get; init; }
        /// <summary>
        /// The selected game type. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/gameTypes.json">gameTypes.json</see>.
        /// </summary>
        public required string GameType { get; init; }
        /// <summary>
        /// The list of champions that were banned in Draft Pick.
        /// </summary>
        public List<BannedChampion> BannedChampions { get; init; } = [];
        /// <summary>
        /// The game ID.
        /// </summary>
        public long GameId { get; init; }
        /// <summary>
        /// The information pertaining to observers.
        /// </summary>
        public Observer Observers { get; init; } = default!;
        /// <summary>
        /// The queue type. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/queues.json">queues.json</see>.
        /// </summary>
        public long GameQueueConfigId { get; init; }
        /// <summary>
        /// The Unix timestamp the game has started in milliseconds.
        /// </summary>
        public long GameStartTime { get; init; }
        /// <summary>
        /// The information pertaining to participants.
        /// </summary>
        public List<Participant> Participants { get; init; } = [];
        /// <summary>
        /// The platform ID the game is being played on.
        /// </summary>
        public required string PlatformId { get; init; }
    }
}
