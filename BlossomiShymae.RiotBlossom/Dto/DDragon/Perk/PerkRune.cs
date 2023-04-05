namespace BlossomiShymae.RiotBlossom.Dto.DDragon.Perk
{
    public record PerkRune
    {
        public int Id { get; init; }
        public string Key { get; init; } = default!;
        public string Icon { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string ShortDesc { get; init; } = default!;
        public string LongDesc { get; init; } = default!;
    }
}
