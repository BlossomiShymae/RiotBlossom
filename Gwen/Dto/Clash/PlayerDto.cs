namespace Gwen.Dto.Clash
{
    internal record PlayerDto
    {
        public string SummonerId { get; init; } = default!;
        public string TeamId { get; init; } = default!;
        public string Position { get; init; } = default!;
        public string Role { get; init; } = default!;
    }
}
