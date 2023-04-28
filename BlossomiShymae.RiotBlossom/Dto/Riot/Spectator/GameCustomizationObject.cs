using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Spectator
{
    public record GameCustomizationObject
    {
        /// <summary>
        /// The category ID for Game Customization.
        /// </summary>
        public string Category { get; init; } = default!;
        /// <summary>
        /// The content for Game Customization.
        /// </summary>
        public string Content { get; init; } = default!;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
