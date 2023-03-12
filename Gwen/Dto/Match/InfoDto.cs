using System.Collections.Immutable;

namespace Gwen.Dto.Match
{
    internal record InfoDto
    {
        public long GameCreation { get; init; }
        public long GameDuration { get; init; }
        public long GameEndTimestamp { get; init; }
        public long GameId { get; init; }
        public string GameMode { get; init; } = default!;
        public string GameName { get; init; } = default!;
        public long GameStartTimestamp { get; init; }
        public string GameType { get; init; } = default!;
        public string GameVersion { get; init; } = default!;
        public int MapId { get; init; }
        public ImmutableList<ParticipantDto> Participants { get; init; } = ImmutableList<ParticipantDto>.Empty;
        public string PlatformId { get; init; } = default!;
        public int QueueId { get; init; }
        public ImmutableList<TeamDto> Teams { get; init; } = ImmutableList<TeamDto>.Empty;
        public string TournamentCode { get; init; } = default!;
    }
}
