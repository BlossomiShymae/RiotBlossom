using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record TimelineInfoDto : DataObject
    {
        public long FrameInterval { get; init; }
        public List<Frame> Frames { get; init; } = [];
        public long GameId { get; init; }
        public List<TimelineParticipant> Participants { get; init; } = [];
    }
}
