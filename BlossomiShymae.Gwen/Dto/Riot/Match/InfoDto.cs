using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Dto.Riot.Match
{
    public record InfoDto
    {
        /// <summary>
        /// The Unix timestamp for when the game is created on the game server.
        /// </summary>
        public long GameCreation { get; init; }
        /// <summary>
        /// The maximum <see cref="ParticipantDto.TimePlayed"/> of any participant in seconds.
        /// </summary>
        public long GameDuration { get; init; }
        /// <summary>
        /// The Unix timestamp for when the match ends on the game server. Can be significantly longer than when the 
        /// match actually "ends".
        /// </summary>
        public long GameEndTimestamp { get; init; }
        /// <summary>
        /// The game ID.
        /// </summary>
        public long GameId { get; init; }
        /// <summary>
        /// The game mode. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/gameModes.json">gameModes.json</see>.
        /// </summary>
        public string GameMode { get; init; } = default!;
        /// <summary>
        /// The game name.
        /// </summary>
        public string GameName { get; init; } = default!;
        /// <summary>
        /// The Unix timestamp for when the match starts on the game server.
        /// </summary>
        public long GameStartTimestamp { get; init; }
        /// <summary>
        /// The game type. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/gameTypes.json">gameTypes.json</see>.
        /// </summary>
        public string GameType { get; init; } = default!;
        /// <summary>
        /// The game version the match was played in. The major and minor can be used to determine the patch a game was played on.
        /// </summary>
        public string GameVersion { get; init; } = default!;
        /// <summary>
        /// The map ID. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/maps.json">maps.json</see>.
        /// </summary>
        public int MapId { get; init; }
        /// <summary>
        /// The summoners that participated in the match.
        /// </summary>
        public ImmutableList<ParticipantDto> Participants { get; init; } = ImmutableList<ParticipantDto>.Empty;
        /// <summary>
        /// The platform where the match was played.
        /// </summary>
        public string PlatformId { get; init; } = default!;
        /// <summary>
        /// The queue ID. See Riot Static Developer <see href="https://static.developer.riotgames.com/docs/lol/queues.json">queues.json</see>.
        /// </summary>
        public int QueueId { get; init; }
        /// <summary>
        /// The teams of played match.
        /// </summary>
        public ImmutableList<TeamDto> Teams { get; init; } = ImmutableList<TeamDto>.Empty;
        /// <summary>
        /// The tournament code used to generate the match.
        /// </summary>
        public string TournamentCode { get; init; } = default!;
    }
}
