namespace Gwen.Dto.Spectator
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
    }
}
