using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValContent
{
    public record LocalizedNamesDto : DataObject
    {
        [JsonPropertyName("ar-AE")]
        public required string ArabicUAE { get; init; } 
        [JsonPropertyName("de-DE")]
        public required string GermanGermany { get; init; } 
        [JsonPropertyName("en-GB")]
        public string? EnglishUnitedKingdom { get; init; }
        [JsonPropertyName("en-US")]
        public required string EnglishUnitedStates { get; init; }
        [JsonPropertyName("es-ES")]
        public required string SpanishSpain { get; init; } 
        [JsonPropertyName("es-MX")]
        public required string SpanishMexico { get; init; } 
        [JsonPropertyName("fr-FR")]
        public required string FrenchFrance { get; init; } 
        [JsonPropertyName("id-ID")]
        public required string IndonesianIndonesia { get; init; }
        [JsonPropertyName("it-IT")]
        public required string ItalianItaly { get; init; } 
        /// <summary>
        /// Yaa!
        /// </summary>
        [JsonPropertyName("ja-JP")]
        public required string JapaneseJapan { get; init; }
        [JsonPropertyName("ko-KR")]
        public required string KoreanKorea { get; init; }
        [JsonPropertyName("pl-PL")]
        public required string PolishPoland { get; init; }
        [JsonPropertyName("pt-BR")]
        public required string PortugueseBrazil { get; init; } 
        [JsonPropertyName("ru-RU")]
        public required string RussianRussia { get; init; } 
        [JsonPropertyName("th-TH")]
        public required string ThaiThailand { get; init; } 
        [JsonPropertyName("tr-TR")]
        public required string TurkishTurkey { get; init; } 
        [JsonPropertyName("vi-VN")]
        public required string VietnameseVietnam { get; init; }
        [JsonPropertyName("zh-CN")]
        public required string ChineseSimplified { get; init; } 
        [JsonPropertyName("zh-TW")]
        public required string ChineseTaiwan { get; init; }
    }
}
