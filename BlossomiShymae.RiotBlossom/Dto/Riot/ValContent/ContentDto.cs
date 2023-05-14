using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValContent
{
    public record ContentDto : DataObject<ContentDto>
    {
        public string Version { get; init; } = default!;
        public ImmutableList<ContentItemDto> Characters { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> Maps { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> Chromas { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> Skins { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> SkinLevels { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> Equips { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> GameModes { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> Sprays { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> SprayLevels { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> Charms { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> CharmLevels { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> PlayerCards { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ContentItemDto> PlayerTitles { get; init; } = ImmutableList<ContentItemDto>.Empty;
        public ImmutableList<ActDto> Acts { get; init; } = ImmutableList<ActDto>.Empty;
    }
}
