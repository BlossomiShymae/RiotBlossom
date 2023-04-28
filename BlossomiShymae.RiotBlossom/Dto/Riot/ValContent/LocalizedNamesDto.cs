using BlossomiShymae.RiotBlossom.Core;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValContent
{
    public record LocalizedNamesDto
    {
        [JsonPropertyName("ar-AE")]
        public string ArabicUAE { get; init; } = default!;
        [JsonPropertyName("de-DE")]
        public string GermanGermany { get; init; } = default!;
        [JsonPropertyName("en-GB")]
        public string EnglishUnitedKingdom { get; init; } = default!;
        [JsonPropertyName("en-US")]
        public string EnglishUnitedStates { get; init; } = default!;
        [JsonPropertyName("es-ES")]
        public string SpanishSpain { get; init; } = default!;
        [JsonPropertyName("es-MX")]
        public string SpanishMexico { get; init; } = default!;
        [JsonPropertyName("fr-FR")]
        public string FrenchFrance { get; init; } = default!;
        [JsonPropertyName("id-ID")]
        public string IndonesianIndonesia { get; init; } = default!;
        [JsonPropertyName("it-IT")]
        public string ItalianItaly { get; init; } = default!;
        /// <summary>
        /// Yaa!
        /// </summary>
        [JsonPropertyName("ja-JP")]
        public string JapaneseJapan { get; init; } = default!;
        [JsonPropertyName("ko-KR")]
        public string KoreanKorea { get; init; } = default!;
        [JsonPropertyName("pl-PL")]
        public string PolishPoland { get; init; } = default!;
        [JsonPropertyName("pt-BR")]
        public string PortugueseBrazil { get; init; } = default!;
        [JsonPropertyName("ru-RU")]
        public string RussianRussia { get; init; } = default!;
        [JsonPropertyName("th-TH")]
        public string ThaiThailand { get; init; } = default!;
        [JsonPropertyName("tr-TR")]
        public string TurkishTurkey { get; init; } = default!;
        [JsonPropertyName("vi-VN")]
        public string VietnameseVietnam { get; init; } = default!;
        [JsonPropertyName("zh-CN")]
        public string ChineseSimplified { get; init; } = default!;
        [JsonPropertyName("zh-TW")]
        public string ChineseTaiwan { get; init; } = default!;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
