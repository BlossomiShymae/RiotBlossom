using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValContent
{
    public record ContentDto : DataObject
    {
        public string Version { get; init; } = default!;
        public List<ContentItemDto> Characters { get; init; } = [];
        public List<ContentItemDto> Maps { get; init; } = [];
        public List<ContentItemDto> Chromas { get; init; } = [];
        public List<ContentItemDto> Skins { get; init; } = [];
        public List<ContentItemDto> SkinLevels { get; init; } = [];
        public List<ContentItemDto> Equips { get; init; } = [];
        public List<ContentItemDto> GameModes { get; init; } = [];
        public List<ContentItemDto> Sprays { get; init; } = [];
        public List<ContentItemDto> SprayLevels { get; init; } = [];
        public List<ContentItemDto> Charms { get; init; } = [];
        public List<ContentItemDto> CharmLevels { get; init; } = [];
        public List<ContentItemDto> PlayerCards { get; init; } = [];
        public List<ContentItemDto> PlayerTitles { get; init; } = [];
        public List<ActDto> Acts { get; init; } = [];
    }
}
