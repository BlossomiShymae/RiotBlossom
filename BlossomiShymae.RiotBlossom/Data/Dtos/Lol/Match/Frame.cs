using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Frame : DataObject
    {
        public List<Event> Events { get; init; } = [];
        public Dictionary<string, ParticipantFrame> ParticipantFrames { get; init; } = [];
        public long Timestamp { get; init; }
    }
}
