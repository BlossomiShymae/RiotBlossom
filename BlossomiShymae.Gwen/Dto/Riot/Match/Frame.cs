using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Dto.Riot.Match
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Frame
    {
        public ImmutableList<Event> Events { get; init; } = ImmutableList<Event>.Empty;
        public ImmutableDictionary<string, ParticipantFrame> ParticipantFrames { get; init; } = ImmutableDictionary<string, ParticipantFrame>.Empty;
        public long Timestamp { get; init; }
    }
}
