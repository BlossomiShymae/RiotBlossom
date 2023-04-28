using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ChromaDescription
    {
        public string Region { get; init; } = default!;
        public string Description { get; init; } = default!;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
