using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Spectator
{
    public record CurrentGameInfo
    {
        /// <summary>
        /// The game ID.
        /// </summary>
        public long GameId { get; init; }
        /// <summary>
        /// The selected game type. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/gameTypes.json">gameTypes.json</see>.
        /// </summary>
        public string GameType { get; init; } = default!;
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
        public string PlatformId { get; init; } = default!;
        /// <summary>
        /// The selected game mode. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/gameModes.json">gameModes.json</see>.
        /// </summary>
        public string GameMode { get; init; } = default!;
        /// <summary>
        /// The list of champions banned in Draft Pick.
        /// </summary>
        public ImmutableList<BannedChampion> BannedChampions { get; init; } = ImmutableList<BannedChampion>.Empty;
        /// <summary>
        /// The queue type. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/queues.json">queues.json</see>.
        /// </summary>
        public long GameQueueConfigId { get; init; }
        /// <summary>
        /// The information pertaining to observers.
        /// </summary>
        public Observer Observers { get; init; } = new();
        /// <summary>
        /// The information pertaining to participants.
        /// </summary>
        public ImmutableList<CurrentGameParticipant> Participants { get; init; } = ImmutableList<CurrentGameParticipant>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
