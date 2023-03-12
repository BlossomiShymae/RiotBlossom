namespace Gwen.Dto.Spectator
{
    internal record GameCustomizationObject
    {
        public string Category { get; init; } = default!;
        public string Content { get; init; } = default!;
    }
}
