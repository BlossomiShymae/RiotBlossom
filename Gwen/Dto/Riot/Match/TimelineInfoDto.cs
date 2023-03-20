using System.Collections.Immutable;

namespace Gwen.Dto.Riot.Match
{
    public record TimelineInfoDto
    {
        public long FrameInterval { get; init; }
        public ImmutableList<Frame> Frames { get; init; } = ImmutableList<Frame>.Empty;
        public long GameId { get; init; }
        public ImmutableList<TimelineParticipant> Participants { get; init; } = ImmutableList<TimelineParticipant>.Empty;
    }
}
