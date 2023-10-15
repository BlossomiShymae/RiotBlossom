using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolChallenges
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record PlayerClientPreferences : DataObject
    {
        public required string BannerAccent { get; init; } 
        public required string Title { get; init; }
        public List<int> ChallengeIds { get; init; } = [];
    }
}
