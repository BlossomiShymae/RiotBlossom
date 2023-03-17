using System.Collections.Immutable;

namespace Gwen.Dto.Riot.Match
{
    public record TimelineInfoDto
    {
        public int FrameInterval { get; init; }
        public ImmutableList<FrameDto> Frames { get; init; } = ImmutableList<FrameDto>.Empty;
        public int GameId { get; init; }
        public ImmutableList<TimelineParticipantDto> Participants { get; init; } = ImmutableList<TimelineParticipantDto>.Empty;
    }
}
