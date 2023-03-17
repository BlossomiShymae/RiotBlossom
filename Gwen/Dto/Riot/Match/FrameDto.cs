using System.Collections.Immutable;

namespace Gwen.Dto.Riot.Match
{
    public record FrameDto
    {
        public ImmutableList<EventDto> Events { get; init; } = ImmutableList<EventDto>.Empty;
        public ImmutableDictionary<string, ParticipantFrameDto> ParticipantFrames { get; init; } = ImmutableDictionary<string, ParticipantFrameDto>.Empty;
        public int Timestamp { get; init; }
    }
}
